using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Yalnız açıq --seed-demo əmri ilə işləyən, təkrar icrada yeni qeyd yaratmayan ekran nümunələri.
/// Bütün yeni sənədlər TEST-UI prefiksi ilə seçilir; sistem rolları və admin hesabı saxlanır.
/// </summary>
internal static class DemoDataSeeder
{
    private const string Prefix = "TEST-UI";

    public static async Task SeedAsync(AzAgroPOSDbContext db)
    {
        if (await db.Kateqoriyalar.AnyAsync(k => k.Ad == $"{Prefix} Ərzaq"))
        {
            await using var repairTransaction = await db.Database.BeginTransactionAsync();
            int repaired = await EnsureDemoExpenseCashMovementsAsync(db);
            int stockSigns = await RepairDemoStockMovementSignsAsync(db);
            await repairTransaction.CommitAsync();
            Console.WriteLine($"TEST-UI nümunələri mövcuddur; təkrar əlavə edilmədi. Kassa uzlaşması: {repaired}, stok işarəsi: {stockSigns}.");
            return;
        }

        await using var transaction = await db.Database.BeginTransactionAsync();
        DateTime today = DateTime.Today;
        Istifadeci admin = await db.Istifadeciler.FirstAsync(i => i.RolId == 1 && i.HesabAktivdir);
        db.SetCurrentUser(admin.Id);

        var categories = new[]
        {
            new Kateqoriya { Ad = $"{Prefix} Ərzaq", Tesvir = "Nümunə gündəlik ərzaq", Aktivdir = true },
            new Kateqoriya { Ad = $"{Prefix} İçkilər", Tesvir = "Nümunə içki qrupu", Aktivdir = true },
            new Kateqoriya { Ad = $"{Prefix} Məişət", Tesvir = "Nümunə məişət malları", Aktivdir = true }
        };
        var brands = new[]
        {
            new Brend { Ad = $"{Prefix} Bərəkət", Olke = "Azərbaycan", Tesvir = "Nümunə yerli brend", Aktivdir = true },
            new Brend { Ad = $"{Prefix} Saf", Olke = "Azərbaycan", Tesvir = "Nümunə içki brendi", Aktivdir = true }
        };
        var suppliers = new[]
        {
            new Tedarukcu { Ad = $"{Prefix} Bakı Distribusiya", Voen = "9900000001", Telefon = "+994500009101", Email = "test-ui-supplier1@example.invalid", Unvan = "Bakı, nümunə anbar", Aktivdir = true },
            new Tedarukcu { Ad = $"{Prefix} Region Təchizat", Voen = "9900000002", Telefon = "+994500009102", Email = "test-ui-supplier2@example.invalid", Unvan = "Gəncə, nümunə anbar", Aktivdir = true }
        };
        db.Kateqoriyalar.AddRange(categories);
        db.Brendler.AddRange(brands);
        db.Tedarukculer.AddRange(suppliers);
        await db.SaveChangesAsync();

        var catalog = new (string Name, decimal Cost, decimal Price, int Stock, int Min, int Category, int Brand)[]
        {
            ("Un 1 kq", 1.25m, 1.85m, 52, 12, 0, 0),
            ("Düyü 1 kq", 2.40m, 3.35m, 48, 10, 0, 0),
            ("Şəkər 1 kq", 1.55m, 2.15m, 65, 15, 0, 0),
            ("Günəbaxan yağı 1 L", 3.35m, 4.80m, 32, 8, 0, 0),
            ("Çay 100 q", 2.10m, 3.20m, 24, 8, 0, 0),
            ("Su 0.5 L", 0.30m, 0.65m, 96, 20, 1, 1),
            ("Alma şirəsi 1 L", 1.45m, 2.40m, 39, 10, 1, 1),
            ("Qazlı içki 1 L", 1.10m, 1.95m, 57, 12, 1, 1),
            ("Qab yuyan maye 500 ml", 2.30m, 3.75m, 19, 6, 2, 1),
            ("Kağız dəsmal 2 ədəd", 1.70m, 2.80m, 28, 8, 2, 0)
        };
        var products = catalog.Select((item, index) => new Mehsul
        {
            Ad = $"{Prefix} {item.Name}", StokKodu = $"TUI-{index + 1:000}",
            Barkod = $"289000009{index + 1:000}", AlisQiymeti = item.Cost,
            PerakendeSatisQiymeti = item.Price,
            TopdanSatisQiymeti = Math.Round(item.Price * 0.9m, 2),
            TekEdedSatisQiymeti = item.Price, MovcudSay = item.Stock,
            MinimumStok = item.Min, OlcuVahidi = OlcuVahidi.Ədəd,
            KateqoriyaId = categories[item.Category].Id, BrendId = brands[item.Brand].Id,
            TedarukcuId = suppliers[index % suppliers.Length].Id, Aktivdir = true
        }).ToArray();
        db.Mehsullar.AddRange(products);

        var customers = Enumerable.Range(1, 8).Select(index => new Musteri
        {
            TamAd = $"{Prefix} Müştəri {index:00}", TelefonNomresi = $"+994500009{index:000}",
            Unvan = index % 2 == 0 ? "Bakı, Nizami rayonu" : "Bakı, Yasamal rayonu",
            KreditLimiti = index % 3 == 0 ? 300m : 750m, UmumiBorc = 0
        }).ToArray();
        db.Musteriler.AddRange(customers);

        var workers = Enumerable.Range(1, 3).Select(index => new Isci
        {
            TamAd = $"{Prefix} İşçi {index:00}", DogumTarixi = today.AddYears(-24 - index),
            TelefonNomresi = $"+994500008{index:000}", Unvan = "Bakı, nümunə ünvan",
            Email = $"test-ui-worker{index}@example.invalid", IseBaslamaTarixi = today.AddMonths(-index * 3),
            Maas = 600m + index * 80m, Vezife = index == 1 ? "Kassir" : "Satış məsləhətçisi",
            Departament = "Mağaza", Status = IsciStatusu.Aktiv,
            SvsNo = $"990000{index:000}", QeydiyyatUnvani = "Bakı, nümunə ünvan",
            BankMəlumatları = $"TEST-UI hesab {index}"
        }).ToArray();
        db.Isciler.AddRange(workers);
        await db.SaveChangesAsync();

        db.StokHareketleri.AddRange(products.Select((p, index) => new StokHareketi
        {
            MehsulId = p.Id, HareketTipi = StokHareketTipi.Daxilolma,
            SenedNovu = SenedNovu.Inventarizasiya, Miqdar = catalog[index].Stock,
            AlisQiymeti = p.AlisQiymeti, SatisQiymeti = p.PerakendeSatisQiymeti,
            Tarix = today.AddDays(-12), Qeyd = $"{Prefix} başlanğıc stok", IstifadeciId = admin.Id
        }));

        var orders = Enumerable.Range(0, 4).Select(index => new AlisSifaris
        {
            SifarisNomresi = $"{Prefix}-AS-{index + 1:000}",
            TedarukcuId = suppliers[index % 2].Id,
            GozlenilenTehvilTarixi = today.AddDays(index - 5),
            TesdiqTarixi = index == 0 ? null : today.AddDays(-8 + index),
            FaktikiTehvilTarixi = index < 2 ? today.AddDays(-5 + index) : null,
            Status = index switch { 0 => AlisSifarisStatusu.Yaradildi, 1 => AlisSifarisStatusu.TamTehvilAlindi, 2 => AlisSifarisStatusu.QismenTehvilAlindi, _ => AlisSifarisStatusu.Tesdiqlendi },
            UmumiMebleg = (10 * products[index].AlisQiymeti) + (6 * products[index + 1].AlisQiymeti),
            Qeydler = $"{Prefix} ekran nümunəsi",
            SifarisSetirleri = new List<AlisSifarisSetiri>
            {
                new() { MehsulId = products[index].Id, Miqdar = 10, BirVahidQiymet = products[index].AlisQiymeti, CemiMebleg = 10 * products[index].AlisQiymeti, TehvilAlinanMiqdar = index == 1 ? 10 : 0 },
                new() { MehsulId = products[index + 1].Id, Miqdar = 6, BirVahidQiymet = products[index + 1].AlisQiymeti, CemiMebleg = 6 * products[index + 1].AlisQiymeti, TehvilAlinanMiqdar = index == 1 ? 6 : 0 }
            }
        }).ToArray();
        db.AlisSifarisleri.AddRange(orders);
        await db.SaveChangesAsync();

        var invoice = new AlisSened
        {
            SenedNomresi = $"{Prefix}-SN-001", TedarukcuId = suppliers[1].Id,
            TehvilTarixi = today.AddDays(-4), Status = AlisSenedStatusu.Tesdiqlendi,
            Qeydler = $"{Prefix} tam qəbul", UmumiMebleg = orders[1].UmumiMebleg,
            SenedSetirleri = orders[1].SifarisSetirleri.Select(line => new AlisSenedSetiri
            {
                MehsulId = line.MehsulId, AlisSifarisSetiriId = line.Id,
                Miqdar = line.Miqdar, BirVahidQiymet = line.BirVahidQiymet,
                CemiMebleg = line.CemiMebleg
            }).ToList()
        };
        var draftInvoice = new AlisSened
        {
            SenedNomresi = $"{Prefix}-SN-002", TedarukcuId = suppliers[0].Id,
            TehvilTarixi = today, Status = AlisSenedStatusu.Yaradildi,
            Qeydler = $"{Prefix} təsdiq gözləyir", UmumiMebleg = 15.50m,
            SenedSetirleri = new List<AlisSenedSetiri>
            {
                new() { MehsulId = products[2].Id, Miqdar = 10, BirVahidQiymet = 1.55m, CemiMebleg = 15.50m }
            }
        };
        db.AlisSenetleri.AddRange(invoice, draftInvoice);
        await db.SaveChangesAsync();

        foreach (AlisSenedSetiri line in invoice.SenedSetirleri)
        {
            Mehsul product = products.Single(p => p.Id == line.MehsulId);
            product.MovcudSay += (int)line.Miqdar;
            db.StokHareketleri.Add(new StokHareketi
            {
                MehsulId = product.Id, HareketTipi = StokHareketTipi.Daxilolma,
                SenedNovu = SenedNovu.Alis, SenedId = invoice.Id, Miqdar = (int)line.Miqdar,
                AlisQiymeti = line.BirVahidQiymet, SatisQiymeti = product.PerakendeSatisQiymeti,
                Tarix = invoice.TehvilTarixi, Qeyd = $"{Prefix} alış qəbulu", IstifadeciId = admin.Id
            });
        }
        db.TedarukcuOdemeleri.AddRange(
            new TedarukcuOdeme { OdemeNomresi = $"{Prefix}-OD-001", TedarukcuId = suppliers[1].Id, AlisSenedId = invoice.Id, OdemeTarixi = today.AddDays(-2), Mebleg = 15m, OdemeUsulu = OdemeUsulu.Naqd, Status = OdemeStatusu.Tesdiqlendi, Qeydler = $"{Prefix} qismən ödəniş" },
            new TedarukcuOdeme { OdemeNomresi = $"{Prefix}-OD-002", TedarukcuId = suppliers[0].Id, OdemeTarixi = today, Mebleg = 12m, OdemeUsulu = OdemeUsulu.BankKocurmesi, Status = OdemeStatusu.Yaradildi, Qeydler = $"{Prefix} gözləyən ödəniş" });

        var shift = new Novbe
        {
            IsciId = admin.Id, AcilmaTarixi = today.AddDays(-1).AddHours(9),
            BaglanmaTarixi = today.AddDays(-1).AddHours(21), BaslangicMebleg = 100m,
            GozlenilenMebleg = 100m, FaktikiMebleg = 100m, Status = NovbeStatusu.Bagli
        };
        db.Novbeler.Add(shift);
        await db.SaveChangesAsync();

        var salePrices = new[] { products[0], products[1], products[2], products[5], products[6], products[8], products[3], products[9] };
        decimal cashSales = 0;
        for (int index = 0; index < salePrices.Length; index++)
        {
            Mehsul product = salePrices[index];
            int quantity = index % 3 + 1;
            decimal total = product.PerakendeSatisQiymeti * quantity;
            OdenisMetodu method = index is 3 or 6 ? OdenisMetodu.Nisyə : index is 2 or 5 ? OdenisMetodu.Kart : OdenisMetodu.Nağd;
            Musteri? customer = method == OdenisMetodu.Nisyə ? customers[index % customers.Length] : index % 2 == 0 ? customers[index % customers.Length] : null;
            DateTime saleDate = today.AddDays(-1).AddHours(10 + index);
            var sale = new Satis
            {
                Tarix = saleDate, NovbeId = shift.Id, MusteriId = customer?.Id,
                OdenisMetodu = method, UmumiMebleg = total,
                SatisDetallari = new List<SatisDetali>
                {
                    new() { MehsulId = product.Id, Miqdar = quantity, Qiymet = product.PerakendeSatisQiymeti, AlisQiymeti = product.AlisQiymeti, UmumiMebleg = total }
                }
            };
            db.Satislar.Add(sale);
            await db.SaveChangesAsync();
            product.MovcudSay -= quantity;
            db.StokHareketleri.Add(new StokHareketi
            {
                MehsulId = product.Id, HareketTipi = StokHareketTipi.Cixis,
                SenedNovu = SenedNovu.Satis, SenedId = sale.Id, Miqdar = quantity,
                AlisQiymeti = product.AlisQiymeti, SatisQiymeti = product.PerakendeSatisQiymeti,
                Tarix = saleDate, Qeyd = $"{Prefix} satış #{sale.Id}", IstifadeciId = admin.Id
            });
            if (method == OdenisMetodu.Nağd) cashSales += total;
            if (method == OdenisMetodu.Nisyə && customer != null)
            {
                customer.UmumiBorc += total;
                db.NisyeHereketleri.Add(new NisyeHereketi
                {
                    MusteriId = customer.Id, SatisId = sale.Id, Tarix = saleDate,
                    EmeliyyatNovu = EmeliyyatNovu.Satis, Mebleg = total,
                    Qeyd = $"{Prefix} nisyə satış"
                });
            }
        }
        await db.SaveChangesAsync();

        Musteri debtor = customers[0];
        debtor.UmumiBorc += 120m;
        db.NisyeHereketleri.Add(new NisyeHereketi
        {
            MusteriId = debtor.Id, Tarix = today.AddDays(-30), EmeliyyatNovu = EmeliyyatNovu.IlkinBorc,
            Mebleg = 120m, Qeyd = $"{Prefix} əvvəlki borc nümunəsi"
        });
        debtor.UmumiBorc -= 35m;
        db.NisyeHereketleri.Add(new NisyeHereketi
        {
            MusteriId = debtor.Id, Tarix = today.AddDays(-1).AddHours(18), EmeliyyatNovu = EmeliyyatNovu.Odenis,
            Mebleg = 35m, Qeyd = $"{Prefix} nağd borc ödənişi"
        });
        db.KassaHareketleri.AddRange(
            new KassaHareketi { HareketNovu = KassaHareketiNovu.Daxilolma, EmeliyyatNovu = EmeliyyatNovu.Gelir, NovbeId = shift.Id, OdenisMetodu = OdenisMetodu.Nağd, Mebleg = cashSales, Tarix = today.AddDays(-1).AddHours(21), Qeyd = $"{Prefix} nağd satış cəmi", IstifadeciId = admin.Id },
            new KassaHareketi { HareketNovu = KassaHareketiNovu.Daxilolma, EmeliyyatNovu = EmeliyyatNovu.Odenis, NovbeId = shift.Id, OdenisMetodu = OdenisMetodu.Nağd, Mebleg = 35m, Tarix = today.AddDays(-1).AddHours(18), Qeyd = $"{Prefix} borc ödənişi", IstifadeciId = admin.Id });
        shift.GozlenilenMebleg += cashSales + 35m;
        shift.FaktikiMebleg = shift.GozlenilenMebleg;

        Satis returnedSale = await db.Satislar.FirstAsync(s => s.NovbeId == shift.Id && s.OdenisMetodu == OdenisMetodu.Nağd);
        SatisDetali returnedDetail = await db.SatisDetallari.FirstAsync(d => d.SatisId == returnedSale.Id);
        var returned = new Qaytarma
        {
            SatisId = returnedSale.Id, KassirId = admin.Id, Tarix = today.AddDays(-1).AddHours(19),
            UmumiMebleg = returnedDetail.Qiymet, Sebeb = $"{Prefix} qablaşdırma zədəsi",
            QaytarmaDetallari = new List<QaytarmaDetali>
            {
                new() { MehsulId = returnedDetail.MehsulId, Miqdar = 1, Qiymet = returnedDetail.Qiymet, UmumiMebleg = returnedDetail.Qiymet }
            }
        };
        db.Qaytarmalar.Add(returned);
        Mehsul returnedProduct = products.Single(p => p.Id == returnedDetail.MehsulId);
        returnedProduct.MovcudSay += 1;
        db.StokHareketleri.Add(new StokHareketi
        {
            MehsulId = returnedProduct.Id, HareketTipi = StokHareketTipi.Daxilolma,
            SenedNovu = SenedNovu.Qaytarma, Miqdar = 1, AlisQiymeti = returnedProduct.AlisQiymeti,
            SatisQiymeti = returnedDetail.Qiymet, Tarix = returned.Tarix,
            Qeyd = $"{Prefix} satış qaytarma", IstifadeciId = admin.Id
        });
        db.KassaHareketleri.Add(new KassaHareketi
        {
            HareketNovu = KassaHareketiNovu.Cixis, EmeliyyatNovu = EmeliyyatNovu.Qaytarma,
            Mebleg = returned.UmumiMebleg, Tarix = returned.Tarix, NovbeId = shift.Id,
            OdenisMetodu = OdenisMetodu.Nağd, Qeyd = $"{Prefix} qaytarma", IstifadeciId = admin.Id
        });
        shift.GozlenilenMebleg -= returned.UmumiMebleg;
        shift.FaktikiMebleg = shift.GozlenilenMebleg;

        db.TemirSifarisleri.AddRange(Enumerable.Range(0, 4).Select(index => new Temir
        {
            MusteriAdi = customers[index].TamAd, MusteriTelefonu = customers[index].TelefonNomresi,
            CihazAdi = index % 2 == 0 ? "Barkod skaneri" : "Qəbz printeri",
            SeriyaNomresi = $"{Prefix}-SR-{index + 1:000}",
            ProblemTesviri = index % 2 == 0 ? "Oxuma xətası" : "Kağız çəkmir",
            QebulTarixi = today.AddDays(-4 + index),
            TamamlanmaTarixi = index == 3 ? today : null,
            Status = index switch { 0 => TemirStatusu.Gözləmədə, 1 => TemirStatusu.Təmirdə, 2 => TemirStatusu.Hazırdır, _ => TemirStatusu.TəhvilVerildi },
            TemirXerci = 10m + index * 5m, ServisHaqqi = 15m,
            YekunMebleg = 25m + index * 5m, IsciId = admin.Id, ZemanetMuddeti = 30
        }));

        db.IsciPerformanslari.AddRange(workers.Select((worker, index) => new IsciPerformans
        {
            IsciId = worker.Id, Tarix = today.AddDays(-index), QeydDovru = today.ToString("yyyy-MM"),
            Qiymet = 4 + index % 2, Qeydler = $"{Prefix} aylıq qiymətləndirmə",
            Emsallar = "Satış, xidmət, davamiyyət", Teklifler = "Məhsul təlimi"
        }));
        db.IsciIznleri.AddRange(
            new IsciIzni { IsciId = workers[0].Id, IzinNovu = IzinNovu.Mezuniyyet, BaslamaTarixi = today.AddDays(5), BitmeTarixi = today.AddDays(8), IzinGunu = 4, Sebeb = $"{Prefix} planlı məzuniyyət", Status = IzinStatusu.Gozlemede, Qeydler = "Ekran nümunəsi" },
            new IsciIzni { IsciId = workers[1].Id, IzinNovu = IzinNovu.Tehsil, BaslamaTarixi = today.AddDays(-5), BitmeTarixi = today.AddDays(-3), IzinGunu = 3, Sebeb = $"{Prefix} təlim", Status = IzinStatusu.Tesdiqlenib, TesdiqEdenIsciId = workers[0].Id, TesdiqTarixi = today.AddDays(-7), Qeydler = "Təsdiqli nümunə" });
        db.EmekHaqqilari.AddRange(workers.Select((worker, index) => new EmekHaqqi
        {
            IsciId = worker.Id, Dovr = today.AddMonths(-1).ToString("yyyy-MM"),
            HesablanmaTarixi = today.AddDays(-3), EsasMaas = worker.Maas, Bonuslar = 40m + 10m * index,
            ElaveOdenisler = 0, IcazeTutulmasi = 0, DigerTutulmalar = 0,
            Status = index == 0 ? EmekHaqqiStatusu.Odenilmis : EmekHaqqiStatusu.Hesablanmis,
            OdenisTarixi = index == 0 ? today.AddDays(-1) : null,
            IstifadeciId = admin.Id, Qeyd = $"{Prefix} əmək haqqı nümunəsi"
        }));
        db.Xercler.AddRange(new[]
        {
            (XercNovu.Kommunal, "Elektrik", 45m),
            (XercNovu.Kira, "Mağaza icarəsi", 320m),
            (XercNovu.OfisAvadanliqi, "Kağız rulonları", 18m)
        }.Select((item, index) => new Xerc
        {
            Novu = item.Item1, Ad = $"{Prefix} {item.Item2}", Mebleg = item.Item3,
            Tarix = today.AddDays(-index), SenedNomresi = $"{Prefix}-XR-{index + 1:000}",
            Qeyd = $"{Prefix} xərc", IstifadeciId = admin.Id
        }));

        var bonus = new MusteriBonus
        {
            MusteriId = customers[1].Id, ToplamBal = 12m, IstifadeEdilmisBal = 2m,
            SonBalQazanmaTarixi = today.AddDays(-1), SonBalIstifadeTarixi = today,
            Seviyye = MusteriSeviyyesi.Gumus,
            BonusQeydleri = new List<BonusQeydi>
            {
                new() { EmeliyyatNovu = BonusEmeliyyatNovu.Qazanma, BalMiqdari = 12m, EmeliyyatTarixi = today.AddDays(-1), Aciklama = $"{Prefix} alış bonusu" },
                new() { EmeliyyatNovu = BonusEmeliyyatNovu.Istifade, BalMiqdari = 2m, EmeliyyatTarixi = today, Aciklama = $"{Prefix} bonus istifadəsi" }
            }
        };
        db.MusteriBonuslari.Add(bonus);
        await db.SaveChangesAsync();
        await EnsureDemoExpenseCashMovementsAsync(db);
        await transaction.CommitAsync();
        Console.WriteLine("TEST-UI nümunələri əlaqələri ilə əlavə edildi.");
    }

    private static async Task<int> EnsureDemoExpenseCashMovementsAsync(AzAgroPOSDbContext db)
    {
        // Əvvəlki nümunələrdə xərc və ödənilmiş maaş kassa çıxışı olmadan yazılmışdı.
        var paidPayrolls = await db.EmekHaqqilari
            .Where(p => p.Qeyd != null && p.Qeyd.StartsWith(Prefix) &&
                        p.Status == EmekHaqqiStatusu.Odenilmis)
            .ToListAsync();
        foreach (EmekHaqqi payroll in paidPayrolls)
        {
            string documentNumber = $"{Prefix}-EH-{payroll.Id:000}";
            if (await db.Xercler.AnyAsync(x => x.SenedNomresi == documentNumber)) continue;
            db.Xercler.Add(new Xerc
            {
                Novu = XercNovu.EmekHaqqi,
                Ad = $"{Prefix} ödənilmiş əmək haqqı #{payroll.Id}",
                Mebleg = payroll.YekunEmekHaqqi,
                Tarix = payroll.OdenisTarixi ?? payroll.HesablanmaTarixi,
                SenedNomresi = documentNumber,
                Qeyd = $"{Prefix} maaş kassa uzlaşması",
                IstifadeciId = payroll.IstifadeciId
            });
        }
        await db.SaveChangesAsync();

        var demoExpenses = await db.Xercler
            .Where(x => x.SenedNomresi != null &&
                        (x.SenedNomresi.StartsWith($"{Prefix}-XR-") ||
                         x.SenedNomresi.StartsWith($"{Prefix}-EH-")))
            .ToListAsync();
        int added = 0;
        foreach (Xerc expense in demoExpenses)
        {
            bool exists = await db.KassaHareketleri.AnyAsync(k =>
                k.EmeliyyatNovu == EmeliyyatNovu.Xerc && k.EmeliyyatId == expense.Id);
            if (exists) continue;
            db.KassaHareketleri.Add(new KassaHareketi
            {
                HareketNovu = KassaHareketiNovu.Cixis,
                EmeliyyatNovu = EmeliyyatNovu.Xerc,
                EmeliyyatId = expense.Id,
                OdenisMetodu = OdenisMetodu.Nağd,
                Mebleg = expense.Mebleg,
                Tarix = expense.Tarix,
                Qeyd = $"{Prefix} xərc kassa uzlaşması",
                IstifadeciId = expense.IstifadeciId
            });
            added++;
        }
        await db.SaveChangesAsync();
        return added;
    }

    private static async Task<int> RepairDemoStockMovementSignsAsync(AzAgroPOSDbContext db)
    {
        // Çıxışlar müsbət miqdar kimi saxlanır; qalıq hesablaması onları çıxır.
        var movements = await db.StokHareketleri
            .Where(m => m.HareketTipi == StokHareketTipi.Cixis && m.Miqdar < 0 &&
                        m.Qeyd != null && m.Qeyd.StartsWith(Prefix))
            .ToListAsync();
        foreach (StokHareketi movement in movements)
            movement.Miqdar = Math.Abs(movement.Miqdar);
        await db.SaveChangesAsync();
        return movements.Count;
    }
}

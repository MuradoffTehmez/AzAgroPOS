# AzAgroPOS texniki audit və düzəliş vəziyyəti

**Tarix:** 6 noyabr 2026
**Əhatə:** WinForms, menecerlər, EF Core modeli və miqrasiyalar, `.\SQLEXPRESS` bazasında oxuma yoxlamaları, avtomatik testlər. Bütün formaların canlı vizual sınağı və real printer sınağı aparılmayıb.

## Tapılan səbəblər

| Sahə | Təsdiqlənmiş səbəb | Görülən iş |
|---|---|---|
| Alış sifarişləri | Ayrı scope-da yalnız asinxron dispose dəstəkləyən obyektin sinxron bağlanması `IAsyncDisposable` xətası verirdi | Scope `await using` ilə bağlanır |
| “Hazır” mətnləri | Baza formu status etiketi və status taymeri onu yenidən yazırdı | Boş status mətninə keçirildi |
| Admin üçün `NisyeVer` | Kodda olan icazə köhnə SQL kataloqunda yox idi | Admin yoxlaması rol ID-sinə bağlandı; idempotent icazə kataloqu miqrasiyası əlavə edildi |
| Qəbz rekvizitləri | Çap servisi şirkət və printer konfiqurasiyasını istifadə etmirdi | Cari ayarlar çap zamanı oxunur; satış nömrəsindən qəbz axtarışı və təkrar çap var |
| Nisyə ödənişi | Borc azalsa da, kassa və növbə hərəkəti yaradılmırdı | Nağd/kart seçimi və borc, kassa, növbə yazıları vahid tranzaksiyada bağlandı |
| Mənfəət | Satış detallarının yüklənməməsi və bugünkü alış qiymətindən istifadə səhv maya yaradırdı | Satış anının alış qiyməti detalda saxlanır, hesabat bu dəyəri oxuyur |
| Stok | Decimal miqdar int stoka itki ilə çevrilirdi | Satış, qaytarma və alış sənədində tam müsbət miqdar tələb olunur; stok və müştəri üçün `rowversion` əlavə edildi |
| Kredit limiti | Ekran sabit 10 000 AZN həddini yoxlayırdı | Müştərinin fərdi limiti server əməliyyatında da yoxlanır |
| Əvvəlki borc | İlkin tarix və yaradan şəxs yox idi, icazə yalnız ekranda yoxlanırdı | Tarix, qeyd və istifadəçi yazılır; menecerdə admin/rol icazəsi yoxlanır |
| Göstəricilər | Dashboardda üç sahə `N/A`, sorğu xətası bəzi sahələrdə `0` idi | Aylıq satış, təmir və tədarükçü borcu hesablanır; sorğu xətası ayrıca göstərilir |
| Ana menyu | Uzun sol düymə siyahısı məzmunu daraldırdı | Qruplu `MenuStrip` quruldu; aktiv səhifə və səlahiyyət vəziyyəti sinxronlaşdırıldı |
| Menyu örtüşməsi | `MenuStrip` ilə tab məzmunu eyni `Dock` sahəsində qalırdı | Menyu və tablar ayrı yerləşmə sətirlərinə keçirildi; keçiddə qısa açılma effekti əlavə edildi |
| Yeni müştərinin yenilənməsi | Sahələr təmizlənsə də saxlanma cədvəlin `CurrentRow` ID-sini götürürdü | Yeni/redaktə ID-si ayrıldı, yeni müştəri satış dialoqundan yaradıldıqda avtomatik seçilir |

Əlavə olaraq rol icazələrini dəyişmək üçün admin ekranı, istifadəçi adının redaktəsi, sessiya müddəti və giriş loqu, nisyə ödənişinin Z hesabatında ayrıca göstərilməsi, anbar cədvəli sütunları və qəbzdə faktiki yekun məbləğ düzəldildi.

## Maliyyə məntiqi

Nisyə satış **satış dövriyyəsinə** daxildir, lakin müştəri ödəməyənə qədər **nağd kassa gəliri** deyil. Borc ödənəndə seçilən nağd/kart üsulu ilə kassa və növbə hərəkəti yaradılır. Köhnə satışların maya qiyməti bazada saxlanmadığına görə həmin dövr üçün mənfəət avtomatik uydurulmur; hesabat belə qeydlərdə xəbərdarlıq verir. Tarixi maya qiyməti yalnız etibarlı mənbədən bərpa edilə bilər.

## Hələ təsdiq tələb edən və ya qalan işlər

1. **İnteqrasiya testi:** 62 avtomatik test keçir. Nisyə ödənişi, növbə bağlanması, qəbz çapı və stokun eyni vaxtlı dəyişməsi canlı bazada uçdan uca sınanmalıdır.
3. **Konfiqurasiya:** Avtomatik yedəkləmə, tema və dil kimi parametrlərin real davranışa tətbiqi ayrıca tamamlanmalıdır. Şirkət rekvizitləri, ƏDV, çap və sessiya müddəti bağlanıb.
4. **Köhnə məlumatlar:** Tarixi satış detallarının maya qiyməti, yeni Z hesabatındakı əvvəlki borc ödənişləri və köhnə audit loqları geriyə dönük etibarlı şəkildə doldurula bilmir. Köçürmə planı və ehtiyat nüsxəsi tələb olunur.
5. **UI və avadanlıq:** Bütün ekran ölçüləri/DPI, printer modelləri və real qəbz kağızında vizual yoxlama aparılmalıdır. Digər geniş cədvəllərdə sütunların görünüşü də yoxlanmalıdır.
6. **Əməliyyat sərhədləri:** Borc ödənişinin təkrar göndərilməsinə qarşı ayrıca idempotent açar, əvvəlki borc üçün düzəliş/geri qaytarma axını və sessiyaların uzaqdan ləğvi hələ yoxdur.

## Yoxlama qeydləri

- `dotnet build AzAgroPOS.sln --no-restore -p:OutputPath=bin\CodexVerify\ -m:1`: uğurlu, 0 xəta.
- `dotnet build AzAgroPOS.Teqdimat -c Release --no-restore`: uğurlu, 0 xəta.
- `dotnet build AzAgroPOS.Tests -c Release --no-restore`: uğurlu, 0 xəta.
- `dotnet ef migrations script ... --configuration Release --no-build`: uğurlu; `rowversion` SQL-i yoxlanıb.
- `dotnet test AzAgroPOS.Tests -c Release --no-build`: 62 keçdi, 0 uğursuz.
- `dotnet ef database update --configuration Release --no-build`: dörd yeni miqrasiya `.\SQLEXPRESS` bazasına tətbiq edildi.
- `git diff --check`: boşluq xətası yoxdur.

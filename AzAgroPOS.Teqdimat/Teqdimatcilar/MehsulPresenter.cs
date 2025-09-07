// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Varliglar;
using Microsoft.Extensions.DependencyInjection;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class MehsulPresenter
    {
        private readonly IMehsulIdareetmeView _view;
        private readonly MehsulManager _mehsulManager;
        private readonly KateqoriyaMeneceri _kateqoriyaMeneceri;
        private readonly BrendMeneceri _brendMeneceri;
        private readonly TedarukcuMeneceri _tedarukcuMeneceri;
        private IEnumerable<MehsulDto>? _butunMehsullarCache;

        public MehsulPresenter(IMehsulIdareetmeView view, MehsulManager mehsulManager, 
            KateqoriyaMeneceri kateqoriyaMeneceri, BrendMeneceri brendMeneceri, TedarukcuMeneceri tedarukcuMeneceri)
        {
            _view = view;
            _mehsulManager = mehsulManager;
            _kateqoriyaMeneceri = kateqoriyaMeneceri;
            _brendMeneceri = brendMeneceri;
            _tedarukcuMeneceri = tedarukcuMeneceri;

            // Hadisələrə abunə oluruq (Subscribing to events)
            _view.FormYuklendi_Istek += async (s, e) => await FormuYukle();
            _view.MehsulElaveEt_Istek += async (s, e) => await MehsulElaveEt();
            _view.MehsulYenile_Istek += async (s, e) => await MehsulYenile();
            _view.MehsulSil_Istek += async (s, e) => await MehsulSil();
            _view.FormuTemizle_Istek += (s, e) => FormuTemizle();
            _view.CedvelSecimiDeyisdi_Istek += (s, e) => CedvelSeciminiDoldur();
            _view.Axtaris_Istek += (s, e) => AxtarisEt();
            _view.StokKoduGeneralasiyaIstek += async (s, e) => await StokKoduGeneralasiyaEt();
            _view.BarkodGeneralasiyaIstek += async (s, e) => await BarkodGeneralasiyaEt();
            _view.Kopyala_Istek += (s, e) => Kopyala();
        }

        private async Task FormuYukle()
        {
            _view.OlcuVahidleriniGoster(Enum.GetValues(typeof(OlcuVahidi)));

            // Kateqoriyaları yükləyirik
            var kateqoriyaNetice = await _kateqoriyaMeneceri.ButunKateqoriyalariGetirAsync();
            if (kateqoriyaNetice.UgurluDur)
                _view.KateqoriyalariGoster(kateqoriyaNetice.Data);

            // Brendləri yükləyirik
            var brendNetice = await _brendMeneceri.ButunBrendleriGetirAsync();
            if (brendNetice.UgurluDur)
                _view.BrendleriGoster(brendNetice.Data);

            // Tedarukçuları yükləyirik
            var tedarukcuNetice = await _tedarukcuMeneceri.ButunTedarukculeriGetirAsync();
            if (tedarukcuNetice.UgurluDur)
                _view.TedarukculeriGoster(tedarukcuNetice.Data);

            // Bütün məhsulları yükləyirik (cache üçün)
            var netice = await _mehsulManager.ButunMehsullariGetirAsync();
            if (netice.UgurluDur)
            {
                _butunMehsullarCache = netice.Data;
                _view.MehsullariGoster(_butunMehsullarCache);
            }
            _view.FormuTemizle();
        }

        private async Task MehsulElaveEt()
        {
            if (string.IsNullOrWhiteSpace(_view.MehsulAdi))
            {
                _view.MesajGoster("Məhsul adı boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var yeniMehsul = ViewDanMehsulYarat();
            var netice = await _mehsulManager.MehsulYaratAsync(yeniMehsul);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Məhsul uğurla əlavə edildi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await FormuYukle();
                FormuTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MehsulYenile()
        {
            if (string.IsNullOrEmpty(_view.MehsulId) || _view.MehsulId == "0")
            {
                _view.MesajGoster("Yeniləmək üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var movcudMehsul = ViewDanMehsulYarat();
            var netice = await _mehsulManager.MehsulYenileAsync(movcudMehsul);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Məhsul məlumatları uğurla yeniləndi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await FormuYukle();
                FormuTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task MehsulSil()
        {
            if (string.IsNullOrEmpty(_view.MehsulId) || _view.MehsulId == "0")
            {
                _view.MesajGoster("Silmək üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cavab = _view.MesajGoster("Seçilmiş məhsulu silmək istədiyinizə əminsiniz?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                var netice = await _mehsulManager.MehsulSilAsync(ParseInt(_view.MehsulId));
                if (netice.UgurluDur)
                {
                    await FormuYukle();
                    FormuTemizle();
                }
                else
                {
                    _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Kopyala()
        {
            if (string.IsNullOrEmpty(_view.MehsulId))
            {
                _view.MesajGoster("Kopyalamaq üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _view.MehsulId = string.Empty;
            _view.StokKodu = string.Empty;
            _view.Barkod = string.Empty;
            _view.MesajGoster("Məhsul kopyalandı. Zəhmət olmasa, yeni Stok Kodu və Barkod daxil edib yadda saxlayın.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormuTemizle()
        {
            _view.MehsulId = string.Empty;
            _view.MehsulAdi = string.Empty;
            _view.StokKodu = string.Empty;
            _view.Barkod = string.Empty;
            _view.PerakendeSatisQiymeti = string.Empty;
            _view.TopdanSatisQiymeti = string.Empty;
            _view.TekEdedSatisQiymeti = string.Empty;
            _view.AlisQiymeti = string.Empty;
            _view.MovcudSay = string.Empty;
            _view.MinimumStok = string.Empty;
        }

        private async Task StokKoduGeneralasiyaEt()
        {
            var netice = await _mehsulManager.StokKoduGeneralasiyaEtAsync(_view.MehsulAdi);
            if (netice.UgurluDur)
                _view.StokKodu = netice.Data;
            else
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private async Task BarkodGeneralasiyaEt()
        {
            var netice = await _mehsulManager.BarkodGeneralasiyaEtAsync();
            if (netice.UgurluDur)
                _view.Barkod = netice.Data;
            else
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AxtarisEt()
        {
            if (_butunMehsullarCache == null) return;
            var axtarisMetni = _view.AxtarisMetni.ToLower();
            var filterlenmis = string.IsNullOrWhiteSpace(axtarisMetni)
                ? _butunMehsullarCache
                : _butunMehsullarCache.Where(m =>
                    m.Ad.ToLower().Contains(axtarisMetni) ||
                    m.StokKodu.ToLower().Contains(axtarisMetni) ||
                    m.Barkod.ToLower().Contains(axtarisMetni));
            _view.MehsullariGoster(filterlenmis);
        }

        private void CedvelSeciminiDoldur()
        {
            if (!string.IsNullOrEmpty(_view.MehsulId) && _butunMehsullarCache != null)
            {
                var secilmisMehsul = _butunMehsullarCache.FirstOrDefault(m => m.Id == int.Parse(_view.MehsulId));
                if (secilmisMehsul != null)
                {
                    _view.MehsulAdi = secilmisMehsul.Ad;
                    _view.StokKodu = secilmisMehsul.StokKodu;
                    _view.Barkod = secilmisMehsul.Barkod;
                    _view.PerakendeSatisQiymeti = secilmisMehsul.PerakendeSatisQiymeti.ToString("F2");
                    _view.TopdanSatisQiymeti = secilmisMehsul.TopdanSatisQiymeti.ToString("F2");
                    _view.TekEdedSatisQiymeti = secilmisMehsul.TekEdedSatisQiymeti.ToString("F2");
                    _view.AlisQiymeti = secilmisMehsul.AlisQiymeti.ToString("F2");
                    _view.MovcudSay = secilmisMehsul.MovcudSay.ToString();
                    _view.MinimumStok = secilmisMehsul.MinimumStok.ToString();
                }
            }
        }

        private decimal ParseDecimal(string value) => decimal.TryParse(value, out var result) ? result : 0;
        private int ParseInt(string value) => int.TryParse(value, out var result) ? result : 0;

        private MehsulDto ViewDanMehsulYarat()
        {
            return new MehsulDto
            {
                Id = string.IsNullOrEmpty(_view.MehsulId) ? 0 : ParseInt(_view.MehsulId),
                Ad = _view.MehsulAdi,
                StokKodu = _view.StokKodu,
                Barkod = _view.Barkod,
                PerakendeSatisQiymeti = ParseDecimal(_view.PerakendeSatisQiymeti),
                TopdanSatisQiymeti = ParseDecimal(_view.TopdanSatisQiymeti),
                TekEdedSatisQiymeti = ParseDecimal(_view.TekEdedSatisQiymeti),
                AlisQiymeti = ParseDecimal(_view.AlisQiymeti),
                MovcudSay = ParseInt(_view.MovcudSay),
                MinimumStok = ParseInt(_view.MinimumStok),
                OlcuVahidi = _view.SecilmisOlcuVahidi,
                KateqoriyaId = _view.SecilmisKateqoriyaId,
                BrendId = _view.SecilmisBrendId,
                TedarukcuId = _view.SecilmisTedarukcuId
            };
        }
    }
}
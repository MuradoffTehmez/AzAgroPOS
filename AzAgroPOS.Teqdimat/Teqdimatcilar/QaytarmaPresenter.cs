// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/QaytarmaPresenter.cs
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class QaytarmaPresenter
    {
        private readonly IQaytarmaView _view;
        private readonly QaytarmaManager _qaytarmaManager;
        private readonly SatisManager _satisManager;
        private readonly MehsulManager _mehsulManager;
        private readonly MaliyyeManager _maliyyeManager;

        public QaytarmaPresenter(IQaytarmaView view, QaytarmaManager qaytarmaManager, SatisManager satisManager, MehsulManager mehsulManager, MaliyyeManager maliyyeManager)
        {
            _view = view;
            _qaytarmaManager = qaytarmaManager;
            _satisManager = satisManager;
            _mehsulManager = mehsulManager;
            _maliyyeManager = maliyyeManager;

            AbuneOl();
        }

        private void AbuneOl()
        {
            _view.SatisAxtarIstek += async (s, e) => await SatisAxtar();
            _view.QaytarmaEmeliyyatiIstek += async (s, e) => await QaytarmaEmeliyyati();
        }

        private async Task SatisAxtar()
        {
            var satisNomresi = _view.SatisNomresi;
            if (string.IsNullOrWhiteSpace(satisNomresi))
            {
                _view.MesajGoster("Zəhmət olmasa, satış nömrəsini daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Satış nömrəsinə görə satış məlumatlarını axtarırıq
            var satisNetice = await _satisManager.SatisGetirAsync(satisNomresi);
            if (satisNetice.UgurluDur)
            {
                _view.SatisMehsullariniGoster(satisNetice.Data.SatilanMehsullar);
            }
            else
            {
                _view.MesajGoster("Satış tapılmadı: " + satisNetice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _view.SatisMehsullariniGoster(new List<SatisSebetiElementiDto>());
            }
        }

        private async Task QaytarmaEmeliyyati()
        {
            var secilmisMehsullar = _view.SecilmisMehsullar;
            if (secilmisMehsullar == null || secilmisMehsullar.Count == 0)
            {
                _view.MesajGoster("Zəhmət olmasa, qaytarmaq üçün ən azı bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var satisNomresi = _view.SatisNomresi;
            if (string.IsNullOrWhiteSpace(satisNomresi) || !int.TryParse(satisNomresi, out int satisId))
            {
                _view.MesajGoster("Zəhmət olmasa, düzgün satış nömrəsi daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sebeb = _view.QaytarmaSebebi;
            if (string.IsNullOrWhiteSpace(sebeb))
            {
                _view.MesajGoster("Zəhmət olmasa, qaytarma səbəbini daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kassir ID və aktiv növbə ID-ni əldə edin
            int kassirId = Yardimcilar.AktivSessiya.AktivIstifadeci?.Id ?? 0;
            int? aktivNovbeId = Yardimcilar.AktivSessiya.AktivNovbeId;

            // Qaytarma məhsullarını formatlayaq (SatisSebetiElementiDto-dan uyğun formata)
            var qaytarilanMehsullar = secilmisMehsullar.Select(m => (m.MehsulId, (int)m.Miqdar, m.VahidinQiymeti)).ToList();

            // Seçilmiş məhsulları qaytarmaq
            var netice = await _qaytarmaManager.QaytarmaYaratAsync(satisId, qaytarilanMehsullar, sebeb, kassirId, aktivNovbeId);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Qaytarma əməliyyatı uğurla tamamlandı.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _view.MesajGoster("Qaytarma əməliyyatı zamanı xəta baş verdi: " + netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
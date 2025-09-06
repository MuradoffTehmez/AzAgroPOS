// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/QaytarmaPresenter.cs
// using-lər
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class QaytarmaPresenter
    {
        private readonly IQaytarmaView _view;
        private readonly SatisManager _satisManager;
        private readonly MehsulManager _mehsulManager;

        public QaytarmaPresenter(IQaytarmaView view, SatisManager satisManager, MehsulManager mehsulManager)
        {
            _view = view;
            _satisManager = satisManager;
            _mehsulManager = mehsulManager;

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

            // Seçilmiş məhsulları qaytarmaq
            var netice = await _satisManager.QaytarmaEmeliyyatiAsync(secilmisMehsullar, satisId, sebeb, kassirId, aktivNovbeId);

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
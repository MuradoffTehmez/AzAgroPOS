using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
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

            // Burada satış nömrəsinə görə satış məlumatlarını axtarmaq lazımdır.
            // Hazırda bu funksionallıq tam tətbiq edilməyib.
            // Sadəcə placeholder kimi boş bir siyahı göstəririk.
            // TODO: Satış nömrəsinə görə satış məlumatlarını axtarmaq.
            var tapilanMehsullar = new List<SatisSebetiElementiDto>();
            _view.SatisMehsullariniGoster(tapilanMehsullar);
        }

        private async Task QaytarmaEmeliyyati()
        {
            var secilmisMehsullar = _view.SecilmisMehsullar;
            if (secilmisMehsullar == null || secilmisMehsullar.Count == 0)
            {
                _view.MesajGoster("Zəhmət olmasa, qaytarmaq üçün ən azı bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Burada seçilmiş məhsulları qaytarmaq lazımdır.
            // Anbar qalığını artırmaq və finans məlumatlarını yeniləmək lazımdır.
            // Hazırda bu funksionallıq tam tətbiq edilməyib.
            // TODO: Seçilmiş məhsulları qaytarmaq, anbarı və finansı yeniləmək.
            _view.MesajGoster("Qaytarma əməliyyatı uğurla tamamlandı.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
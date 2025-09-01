using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class MusteriPresenter
    {
        private readonly IMusteriView _view;
        private readonly MusteriManager _manager;
        private List<MusteriDto> _musteriCache;

        public MusteriPresenter(IMusteriView view)
        {
            _view = view;
            var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
            _manager = new MusteriManager(unitOfWork);

            _musteriCache = new List<MusteriDto>();

            _view.FormYuklendi += async (s, e) => await FormuYukle();
            _view.MusteriSecildi += (s, e) => MusteriFormunuDoldur();
            _view.YeniMusteriIstek += (s, e) => _view.FormuTemizle();
            _view.YaddaSaxlaIstek += async (s, e) => await YaddaSaxla();
            _view.SilIstek += async (s, e) => await Sil();
            _view.AxtarIstek += (s, e) => Axtar();
        }

        private async Task FormuYukle()
        {
            var netice = await _manager.ButunMusterileriGetirAsync();
            if (netice.UgurluDur)
            {
                _musteriCache = netice.Data;
                _view.MusterileriGoster(_musteriCache);
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxIcon.Error);
            }
            _view.FormuTemizle();
        }

        private void Axtar()
        {
            var axtarisMetni = _view.AxtarisMetni.ToLower();
            if (string.IsNullOrWhiteSpace(axtarisMetni))
            {
                _view.MusterileriGoster(_musteriCache);
                return;
            }

            var netice = _musteriCache.Where(m =>
                m.TamAd.ToLower().Contains(axtarisMetni) ||
                m.TelefonNomresi.Contains(axtarisMetni)
            ).ToList();

            _view.MusterileriGoster(netice);
        }

        private void MusteriFormunuDoldur()
        {
            if (_view.SecilmisMusteriId > 0)
            {
                var musteri = _musteriCache.FirstOrDefault(m => m.Id == _view.SecilmisMusteriId);
                if (musteri != null)
                {
                    _view.TamAd = musteri.TamAd;
                    _view.Telefon = musteri.TelefonNomresi;
                    _view.Unvan = musteri.Unvan;
                    _view.KreditLimiti = musteri.KreditLimiti.ToString("F2");
                }
            }
        }

        private async Task YaddaSaxla()
        {
            if (string.IsNullOrWhiteSpace(_view.TamAd) || string.IsNullOrWhiteSpace(_view.Telefon))
            {
                _view.MesajGoster("Tam ad və Telefon nömrəsi mütləq daxil edilməlidir.", "Xəbərdarlıq", MessageBoxIcon.Warning);
                return;
            }

            var musteriDto = new MusteriDto
            {
                Id = _view.SecilmisMusteriId,
                TamAd = _view.TamAd,
                TelefonNomresi = _view.Telefon,
                Unvan = _view.Unvan,
                KreditLimiti = decimal.TryParse(_view.KreditLimiti, out var limit) ? limit : 0
            };

            EmeliyyatNeticesi netice;
            if (musteriDto.Id > 0)
            {
                netice = await _manager.MusteriYenileAsync(musteriDto);
            }
            else
            {
                netice = await _manager.MusteriYaratAsync(musteriDto);
            }

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Əməliyyat uğurla tamamlandı.", "Uğurlu", MessageBoxIcon.Information);
                await FormuYukle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxIcon.Error);
            }
        }

        private async Task Sil()
        {
            if (_view.SecilmisMusteriId <= 0)
            {
                _view.MesajGoster("Silmək üçün siyahıdan müştəri seçin.", "Xəbərdarlıq", MessageBoxIcon.Warning);
                return;
            }

            var netice = await _manager.MusteriSilAsync(_view.SecilmisMusteriId);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Müştəri uğurla silindi.", "Uğurlu", MessageBoxIcon.Information);
                await FormuYukle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxIcon.Error);
            }
        }
    }
}
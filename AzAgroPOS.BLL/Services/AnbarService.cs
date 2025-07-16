using System;
using System.Collections.Generic;
using System.Linq;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.DAL;
using AzAgroPOS.DAL.Interfaces;

namespace AzAgroPOS.BLL.Services
{
    public class AnbarService : IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnbarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #region Anbar Management

        public List<Anbar> GetAllActive()
        {
            return _unitOfWork.Anbarlar.GetAllActive();
        }

        public List<Anbar> GetAll()
        {
            return _unitOfWork.Anbarlar.GetAll();
        }

        public Anbar GetById(int id)
        {
            return _unitOfWork.Anbarlar.GetById(id);
        }

        public int AddAnbar(Anbar anbar)
        {
            try
            {
                // Generate unique code if not provided
                if (string.IsNullOrEmpty(anbar.Kod))
                {
                    anbar.Kod = GenerateAnbarKod();
                }

                // Validate unique fields
                if (_unitOfWork.Anbarlar.KodMevcudMu(anbar.Kod, anbar.Id))
                    throw new InvalidOperationException("Bu kod artıq mövcuddur");

                var result = _unitOfWork.Anbarlar.Add(anbar);
                _unitOfWork.Complete();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public void UpdateAnbar(Anbar anbar)
        {
            try
            {
                if (_unitOfWork.Anbarlar.KodMevcudMu(anbar.Kod, anbar.Id))
                    throw new InvalidOperationException("Bu kod artıq mövcuddur");

                _unitOfWork.Anbarlar.Update(anbar);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void DeleteAnbar(int id)
        {
            try
            {
                if (!CanDeleteAnbar(id))
                    throw new InvalidOperationException("Bu anbar silinə bilməz - məhsul qalıqları mövcuddur");

                _unitOfWork.Anbarlar.Delete(id);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public bool CanDeleteAnbar(int id)
        {
            return _unitOfWork.Anbarlar.CanDelete(id);
        }

        #endregion

        #region Stock Management

        public List<AnbarQalik> GetAnbarQaliqları(int anbarId)
        {
            return _unitOfWork.AnbarQaliqlari.GetByAnbar(anbarId);
        }

        public List<AnbarQalik> GetMehsulQaliqları(int mehsulId)
        {
            return _unitOfWork.AnbarQaliqlari.GetByMehsul(mehsulId);
        }

        public AnbarQalik GetQalik(int anbarId, int mehsulId)
        {
            return _unitOfWork.AnbarQaliqlari.GetByAnbarVeMehsul(anbarId, mehsulId);
        }

        public void MehsulGiriş(int anbarId, int mehsulId, decimal miqdar, decimal vahidQiymet,
            string senedNomresi, string senedTipi, int senedId, int istifadeciId, string terefkarsi = null)
        {
            try
            {
                var qalik = GetQalik(anbarId, mehsulId);
                var oncekiQalik = qalik?.MovcudMiqdar ?? 0;
                var yeniQalik = oncekiQalik + miqdar;

                // Update or create stock record
                if (qalik == null)
                {
                    var mehsul = _unitOfWork.Mehsullar.GetById(mehsulId);
                    qalik = new AnbarQalik
                    {
                        AnbarId = anbarId,
                        MehsulId = mehsulId,
                        MovcudMiqdar = miqdar,
                        MinimumMiqdar = mehsul?.MinimumMiqdar ?? 0,
                        MaksimumMiqdar = 0,
                        SonAlisQiymeti = vahidQiymet,
                        SonAlısTarixi = DateTime.Now
                    };

                    // Calculate average purchase price
                    qalik.OrtalamaAlisQiymeti = vahidQiymet;

                    _unitOfWork.AnbarQaliqlari.Add(qalik);
                }
                else
                {
                    // Update average purchase price using weighted average
                    var totalValue = (qalik.MovcudMiqdar * qalik.OrtalamaAlisQiymeti) + (miqdar * vahidQiymet);
                    var totalQuantity = qalik.MovcudMiqdar + miqdar;

                    qalik.MovcudMiqdar = yeniQalik;
                    qalik.OrtalamaAlisQiymeti = totalQuantity > 0 ? totalValue / totalQuantity : vahidQiymet;
                    qalik.SonAlisQiymeti = vahidQiymet;
                    qalik.SonAlısTarixi = DateTime.Now;
                    qalik.YenilenmeTarixi = DateTime.Now;

                    _unitOfWork.AnbarQaliqlari.Update(qalik);
                }

                // Record movement
                var hareket = new AnbarHereketi
                {
                    AnbarId = anbarId,
                    MehsulId = mehsulId,
                    HereketTipi = "Giris",
                    SenedNomresi = senedNomresi,
                    SenedTipi = senedTipi,
                    SenedId = senedId,
                    Miqdar = miqdar,
                    OncekiQalik = oncekiQalik,
                    YeniQalik = yeniQalik,
                    VahidQiymeti = vahidQiymet,
                    UmumiMebleg = miqdar * vahidQiymet,
                    Terefkarsi = terefkarsi,
                    IstifadeciId = istifadeciId
                };

                _unitOfWork.AnbarHereketleri.Add(hareket);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void MehsulCixis(int anbarId, int mehsulId, decimal miqdar,
            string senedNomresi, string senedTipi, int senedId, int istifadeciId, string terefkarsi = null)
        {
            try
            {
                var qalik = GetQalik(anbarId, mehsulId);
                if (qalik == null)
                    throw new InvalidOperationException("Məhsul anbarda mövcud deyil");

                if (qalik.ElcatanMiqdar < miqdar)
                    throw new InvalidOperationException($"Kifayət qədər məhsul yoxdur. Mövcud: {qalik.ElcatanMiqdar}");

                var oncekiQalik = qalik.MovcudMiqdar;
                var yeniQalik = oncekiQalik - miqdar;

                qalik.MovcudMiqdar = yeniQalik;
                qalik.SonSatısTarixi = DateTime.Now;
                qalik.YenilenmeTarixi = DateTime.Now;

                _unitOfWork.AnbarQaliqlari.Update(qalik);

                // Record movement
                var hareket = new AnbarHereketi
                {
                    AnbarId = anbarId,
                    MehsulId = mehsulId,
                    HereketTipi = "Cixis",
                    SenedNomresi = senedNomresi,
                    SenedTipi = senedTipi,
                    SenedId = senedId,
                    Miqdar = miqdar,
                    OncekiQalik = oncekiQalik,
                    YeniQalik = yeniQalik,
                    VahidQiymeti = qalik.OrtalamaAlisQiymeti,
                    UmumiMebleg = miqdar * qalik.OrtalamaAlisQiymeti,
                    Terefkarsi = terefkarsi,
                    IstifadeciId = istifadeciId
                };

                _unitOfWork.AnbarHereketleri.Add(hareket);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void MiqdarDuzelishi(int anbarId, int mehsulId, decimal yeniMiqdar,
            string aciklama, int istifadeciId)
        {
            try
            {
                var qalik = GetQalik(anbarId, mehsulId);
                if (qalik == null)
                    throw new InvalidOperationException("Məhsul anbarda mövcud deyil");

                var oncekiQalik = qalik.MovcudMiqdar;
                var ferq = yeniMiqdar - oncekiQalik;

                qalik.MovcudMiqdar = yeniMiqdar;
                qalik.YenilenmeTarixi = DateTime.Now;

                _unitOfWork.AnbarQaliqlari.Update(qalik);

                // Record movement
                var hareket = new AnbarHereketi
                {
                    AnbarId = anbarId,
                    MehsulId = mehsulId,
                    HereketTipi = "Duzelish",
                    SenedNomresi = $"DUZ-{DateTime.Now:yyyyMMddHHmmss}",
                    SenedTipi = "InventarizasyaDuzelishi",
                    Miqdar = Math.Abs(ferq),
                    OncekiQalik = oncekiQalik,
                    YeniQalik = yeniMiqdar,
                    VahidQiymeti = qalik.OrtalamaAlisQiymeti,
                    UmumiMebleg = Math.Abs(ferq) * qalik.OrtalamaAlisQiymeti,
                    Aciklama = aciklama,
                    IstifadeciId = istifadeciId
                };

                _unitOfWork.AnbarHereketleri.Add(hareket);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Stock Monitoring

        public List<AnbarQalik> GetMinimumSeviyyedenAsagi()
        {
            return _unitOfWork.AnbarQaliqlari.GetMinimumSeviyyedenAsagi();
        }

        public List<AnbarQalik> GetMaksimumSeviyyedenYuxari()
        {
            return _unitOfWork.AnbarQaliqlari.GetMaksimumSeviyyedenYuxari();
        }

        public List<AnbarQalik> GetStoktanKenarda()
        {
            return _unitOfWork.AnbarQaliqlari.GetStoktanKenarda();
        }

        public void UpdateStokSeviyeleri(int anbarId, int mehsulId, decimal minMiqdar, decimal maksMiqdar)
        {
            try
            {
                var qalik = GetQalik(anbarId, mehsulId);
                if (qalik != null)
                {
                    qalik.MinimumMiqdar = minMiqdar;
                    qalik.MaksimumMiqdar = maksMiqdar;
                    qalik.YenilenmeTarixi = DateTime.Now;
                    _unitOfWork.AnbarQaliqlari.Update(qalik);
                    _unitOfWork.Complete();
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Inter-Warehouse Transfer

        public int CreateTransfer(AnbarTransfer transfer)
        {
            try
            {
                if (transfer.MenbAnbarId == transfer.HedefAnbarId)
                    throw new InvalidOperationException("Mənbə və hədəf anbar eyni ola bilməz");

                transfer.TransferNomresi = GenerateTransferNomresi();
                transfer.Status = "Hazırlıq";

                var result = _unitOfWork.AnbarTransferleri.Add(transfer);
                _unitOfWork.Complete();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public void AddTransferDetali(int transferId, int mehsulId, decimal miqdar)
        {
            try
            {
                var transfer = _unitOfWork.AnbarTransferleri.GetById(transferId);
                if (transfer == null)
                    throw new InvalidOperationException("Transfer tapılmadı");

                if (transfer.Status != "Hazırlıq")
                    throw new InvalidOperationException("Yalnız hazırlıq mərhələsində olan transferlərə məhsul əlavə edilə bilər");

                // Check source warehouse stock
                var qalik = GetQalik(transfer.MenbAnbarId, mehsulId);
                if (qalik == null || qalik.ElcatanMiqdar < miqdar)
                    throw new InvalidOperationException("Mənbə anbarda kifayət qədər məhsul yoxdur");

                var mehsul = _unitOfWork.Mehsullar.GetById(mehsulId);
                var detali = new AnbarTransferDetali
                {
                    AnbarTransferId = transferId,
                    MehsulId = mehsulId,
                    MehsulAdi = mehsul.Ad,
                    MehsulSKU = mehsul.SKU,
                    Miqdar = miqdar,
                    VahidAdi = mehsul.Vahid?.Ad ?? "Ədəd",
                    VahidQiymeti = qalik.OrtalamaAlisQiymeti,
                    UmumiMebleg = miqdar * qalik.OrtalamaAlisQiymeti
                };

                _unitOfWork.AnbarTransferleri.AddDetali(detali);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void SendTransfer(int transferId, int istifadeciId)
        {
            try
            {
                var transfer = _unitOfWork.AnbarTransferleri.GetByIdWithDetails(transferId);
                if (transfer == null)
                    throw new InvalidOperationException("Transfer tapılmadı");

                if (transfer.Status != "Hazırlıq")
                    throw new InvalidOperationException("Yalnız hazırlıq mərhələsində olan transferlər göndərilə bilər");

                if (!transfer.TransferDetallari.Any())
                    throw new InvalidOperationException("Transfer boşdur");

                // Reserve quantities in source warehouse
                foreach (var detali in transfer.TransferDetallari)
                {
                    var qalik = GetQalik(transfer.MenbAnbarId, detali.MehsulId);
                    if (qalik.ElcatanMiqdar < detali.Miqdar)
                        throw new InvalidOperationException($"Kifayət qədər məhsul yoxdur: {detali.MehsulAdi}");

                    qalik.RezervMiqdar += detali.Miqdar;
                    _unitOfWork.AnbarQaliqlari.Update(qalik);
                }

                transfer.Status = "Göndərilmiş";
                transfer.GonderenIstifadeciId = istifadeciId;
                transfer.GondermeTarixi = DateTime.Now;
                transfer.YenilenmeTarixi = DateTime.Now;

                _unitOfWork.AnbarTransferleri.Update(transfer);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void ReceiveTransfer(int transferId, int istifadeciId, Dictionary<int, decimal> receivedQuantities)
        {
            try
            {
                var transfer = _unitOfWork.AnbarTransferleri.GetByIdWithDetails(transferId);
                if (transfer == null)
                    throw new InvalidOperationException("Transfer tapılmadı");

                if (transfer.Status != "Göndərilmiş")
                    throw new InvalidOperationException("Yalnız göndərilmiş transferlər qəbul edilə bilər");

                foreach (var detali in transfer.TransferDetallari)
                {
                    var receivedQty = receivedQuantities.ContainsKey(detali.MehsulId) ? receivedQuantities[detali.MehsulId] : 0;
                    if (receivedQty > detali.Miqdar)
                        throw new InvalidOperationException($"Qəbul edilən miqdar göndərilən miqdarddan çox ola bilməz: {detali.MehsulAdi}");

                    if (receivedQty > 0)
                    {
                        // Remove from source warehouse
                        MehsulCixis(transfer.MenbAnbarId, detali.MehsulId, receivedQty,
                            transfer.TransferNomresiFormatli, "Transfer", transfer.Id, istifadeciId,
                            transfer.HedefAnbar.Ad);

                        // Add to destination warehouse
                        MehsulGiriş(transfer.HedefAnbarId, detali.MehsulId, receivedQty, detali.VahidQiymeti,
                            transfer.TransferNomresiFormatli, "Transfer", transfer.Id, istifadeciId,
                            transfer.MenbAnbar.Ad);

                        detali.QebulEdilenMiqdar = receivedQty;
                        _unitOfWork.AnbarTransferleri.UpdateDetali(detali);
                    }

                    // Release reserved quantity
                    var sourceQalik = GetQalik(transfer.MenbAnbarId, detali.MehsulId);
                    sourceQalik.RezervMiqdar = Math.Max(0, sourceQalik.RezervMiqdar - detali.Miqdar);
                    _unitOfWork.AnbarQaliqlari.Update(sourceQalik);
                }

                transfer.Status = "Qəbul Edilmiş";
                transfer.QebulEdenIstifadeciId = istifadeciId;
                transfer.QebulTarixi = DateTime.Now;
                transfer.YenilenmeTarixi = DateTime.Now;

                _unitOfWork.AnbarTransferleri.Update(transfer);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        public void CancelTransfer(int transferId, string reason)
        {
            try
            {
                var transfer = _unitOfWork.AnbarTransferleri.GetByIdWithDetails(transferId);
                if (transfer == null)
                    throw new InvalidOperationException("Transfer tapılmadı");

                if (!transfer.IptalEdileibilir)
                    throw new InvalidOperationException("Bu transfer iptal edilə bilməz");

                // Release reserved quantities if transfer was sent
                if (transfer.Status == "Göndərilmiş")
                {
                    foreach (var detali in transfer.TransferDetallari)
                    {
                        var qalik = GetQalik(transfer.MenbAnbarId, detali.MehsulId);
                        qalik.RezervMiqdar = Math.Max(0, qalik.RezervMiqdar - detali.Miqdar);
                        _unitOfWork.AnbarQaliqlari.Update(qalik);
                    }
                }

                transfer.Status = "İptal Edilmiş";
                transfer.Aciklama = $"İptal səbəbi: {reason}";
                transfer.YenilenmeTarixi = DateTime.Now;

                _unitOfWork.AnbarTransferleri.Update(transfer);
                _unitOfWork.Complete();
            }
            catch
            {
                throw;
            }
        }

        #endregion

        #region Movement Logs

        public List<AnbarHereketi> GetAnbarHereketleri(int anbarId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return _unitOfWork.AnbarHereketleri.GetByAnbar(anbarId, startDate, endDate);
        }

        public List<AnbarHereketi> GetMehsulHereketleri(int mehsulId, DateTime? startDate = null, DateTime? endDate = null)
        {
            return _unitOfWork.AnbarHereketleri.GetByMehsul(mehsulId, startDate, endDate);
        }

        public List<AnbarHereketi> GetAllHereketler(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _unitOfWork.AnbarHereketleri.GetAll(startDate, endDate);
        }

        #endregion

        #region Reports and Statistics

        public AnbarStatistikleri GetAnbarStatistikleri(int anbarId)
        {
            return _unitOfWork.Anbarlar.GetStatistikalar(anbarId);
        }

        public List<object> GetStokDurumRaporu(int? anbarId = null)
        {
            return _unitOfWork.AnbarQaliqlari.GetStokDurumRaporu(anbarId);
        }

        public List<object> GetAnbarHereketRaporu(DateTime startDate, DateTime endDate, int? anbarId = null)
        {
            return _unitOfWork.AnbarHereketleri.GetHereketRaporu(startDate, endDate, anbarId);
        }

        #endregion

        #region Helper Methods

        private string GenerateAnbarKod()
        {
            var lastKod = _unitOfWork.Anbarlar.GetLastKod();
            if (string.IsNullOrEmpty(lastKod))
                return "ANB001";

            var numPart = lastKod.Substring(3);
            if (int.TryParse(numPart, out int num))
            {
                return $"ANB{(num + 1):D3}";
            }
            return "ANB001";
        }

        private string GenerateTransferNomresi()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmss");
        }

        public List<AnbarTransfer> GetAllTransfers()
        {
            return _unitOfWork.AnbarTransferleri.GetAll();
        }

        #endregion

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
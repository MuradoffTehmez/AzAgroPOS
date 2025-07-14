using System;
using System.Collections.Generic;
using System.Linq;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using AzAgroPOS.DAL.Repositories;

namespace AzAgroPOS.BLL.Services
{
    public class TedarukcuService : IDisposable
    {
        private readonly TedarukcuRepository _tedarukcuRepository;
        private readonly AlisOrderRepository _alisOrderRepository;
        private readonly AlisSenedRepository _alisSenedRepository;
        private readonly TedarukcuOdemeRepository _odemeRepository;

        public TedarukcuService()
        {
            _tedarukcuRepository = new TedarukcuRepository();
            _alisOrderRepository = new AlisOrderRepository();
            _alisSenedRepository = new AlisSenedRepository();
            _odemeRepository = new TedarukcuOdemeRepository();
        }

        public List<Tedarukcu> GetAllActive()
        {
            return _tedarukcuRepository.GetAllActive();
        }

        public List<Tedarukcu> GetActiveCustomers()
        {
            return _tedarukcuRepository.GetAll().Cast<Tedarukcu>().Where(t => t.Status == SystemConstants.Status.Active).ToList();
        }

        public List<Tedarukcu> GetAll()
        {
            return _tedarukcuRepository.GetAll();
        }

        public Tedarukcu GetById(int id)
        {
            return _tedarukcuRepository.GetById(id);
        }

        public List<Tedarukcu> SearchTedarukcu(string searchTerm)
        {
            return _tedarukcuRepository.Search(searchTerm);
        }

        public int AddTedarukcu(Tedarukcu tedarukcu)
        {
            // Generate unique code if not provided
            if (string.IsNullOrEmpty(tedarukcu.Kod))
            {
                tedarukcu.Kod = GenerateTedarukcuKod();
            }

            // Validate unique fields
            if (_tedarukcuRepository.KodMevcudMu(tedarukcu.Kod, tedarukcu.Id))
                throw new InvalidOperationException("Bu kod artıq mövcuddur");

            if (!string.IsNullOrEmpty(tedarukcu.VOEN) && 
                _tedarukcuRepository.VOENMevcudMu(tedarukcu.VOEN, tedarukcu.Id))
                throw new InvalidOperationException("Bu VOEN artıq mövcuddur");

            return _tedarukcuRepository.Add(tedarukcu);
        }

        public void UpdateTedarukcu(Tedarukcu tedarukcu)
        {
            // Validate unique fields
            if (_tedarukcuRepository.KodMevcudMu(tedarukcu.Kod, tedarukcu.Id))
                throw new InvalidOperationException("Bu kod artıq mövcuddur");

            if (!string.IsNullOrEmpty(tedarukcu.VOEN) && 
                _tedarukcuRepository.VOENMevcudMu(tedarukcu.VOEN, tedarukcu.Id))
                throw new InvalidOperationException("Bu VOEN artıq mövcuddur");

            _tedarukcuRepository.Update(tedarukcu);
        }

        public void DeleteTedarukcu(int id)
        {
            // Check if supplier has any related records
            if (!CanDeleteTedarukcu(id))
                throw new InvalidOperationException("Bu tədarükçü silinə bilməz - əlaqəli qeydlər mövcuddur");

            _tedarukcuRepository.Delete(id);
        }

        public bool CanDeleteTedarukcu(int id)
        {
            return _tedarukcuRepository.CanDelete(id);
        }

        public void UpdateCariBorc(int tedarukcuId, decimal yeniBorc)
        {
            var tedarukcu = _tedarukcuRepository.GetById(tedarukcuId);
            if (tedarukcu != null)
            {
                tedarukcu.CariBorc = yeniBorc;
                _tedarukcuRepository.Update(tedarukcu);
            }
        }

        public void ArtirCariBorc(int tedarukcuId, decimal mebleg)
        {
            var tedarukcu = _tedarukcuRepository.GetById(tedarukcuId);
            if (tedarukcu != null)
            {
                tedarukcu.CariBorc += mebleg;
                _tedarukcuRepository.Update(tedarukcu);
            }
        }

        public void AzaltCariBorc(int tedarukcuId, decimal mebleg)
        {
            var tedarukcu = _tedarukcuRepository.GetById(tedarukcuId);
            if (tedarukcu != null)
            {
                tedarukcu.CariBorc = Math.Max(0, tedarukcu.CariBorc - mebleg);
                _tedarukcuRepository.Update(tedarukcu);
            }
        }

        public List<Tedarukcu> GetKreditLimitiAsilanlar()
        {
            return _tedarukcuRepository.GetKreditLimitiAsilanlar();
        }

        public List<Tedarukcu> GetBorcluTedarukciler()
        {
            return _tedarukcuRepository.GetBorcluTedarukciler();
        }

        public TedarukcuStatistikleri GetTedarukcuStatistikleri(int tedarukcuId, DateTime? startDate = null, DateTime? endDate = null)
        {
            var statistikalar = new TedarukcuStatistikleri();
            
            var tedarukcu = _tedarukcuRepository.GetById(tedarukcuId);
            if (tedarukcu == null) return statistikalar;

            // Purchase orders statistics
            var orders = _alisOrderRepository.GetByTedarukcu(tedarukcuId, startDate, endDate);
            statistikalar.UmumiOrderSayi = orders.Count;
            statistikalar.TesdiqlenmisgOrderSayi = orders.Count(o => o.Status == "Təsdiqlənmiş");
            statistikalar.TeslimEdilmişOrderSayi = orders.Count(o => o.Status == "Teslim Edilmiş");
            statistikalar.UmumiOrderMeblegi = orders.Sum(o => o.NetMebleg);

            // Purchase documents statistics
            var senedler = _alisSenedRepository.GetByTedarukcu(tedarukcuId, startDate, endDate);
            statistikalar.UmumiSenedSayi = senedler.Count;
            statistikalar.QebulEdilmişSenedSayi = senedler.Count(s => s.Status == "Qəbul Edilmiş");
            statistikalar.UmumiSenedMeblegi = senedler.Sum(s => s.NetMebleg);

            // Payment statistics
            var odemeler = _odemeRepository.GetByTedarukcu(tedarukcuId, startDate, endDate);
            statistikalar.UmumiOdemeSayi = odemeler.Count;
            statistikalar.UmumiOdemeMeblegi = odemeler.Where(o => o.Status == "Tamamlandı").Sum(o => o.OdemeMeblegi);

            // Current balances
            statistikalar.CariBorc = tedarukcu.CariBorc;
            statistikalar.KreditLimiti = tedarukcu.KreditLimiti;
            statistikalar.QalanKreditLimiti = tedarukcu.QalanKreditLimiti;

            return statistikalar;
        }

        private string GenerateTedarukcuKod()
        {
            var lastKod = _tedarukcuRepository.GetLastKod();
            if (string.IsNullOrEmpty(lastKod))
                return "TED001";

            var numPart = lastKod.Substring(3);
            if (int.TryParse(numPart, out int num))
            {
                return $"TED{(num + 1):D3}";
            }
            return "TED001";
        }

        public List<object> GetTedarukcuPerformansRaporu(DateTime startDate, DateTime endDate)
        {
            return _tedarukcuRepository.GetPerformansRaporu(startDate, endDate);
        }

        public List<AlisOrder> GetAllAlisOrders()
        {
            return _alisOrderRepository.GetAll();
        }

        public List<AlisSeined> GetAllAlisSenedleri()
        {
            return _alisSenedRepository.GetAll();
        }

        public void Dispose()
        {
            // Repository sinifləri IDisposable tətbiq etmədiyi üçün sadəcə boş buraxırıq
            // Gələcəkdə repository siniflərinə IDisposable əlavə edilərsə, burada dispose ediləcək
        }
    }

    public class TedarukcuStatistikleri
    {
        public int UmumiOrderSayi { get; set; }
        public int TesdiqlenmisgOrderSayi { get; set; }
        public int TeslimEdilmişOrderSayi { get; set; }
        public decimal UmumiOrderMeblegi { get; set; }
        
        public int UmumiSenedSayi { get; set; }
        public int QebulEdilmişSenedSayi { get; set; }
        public decimal UmumiSenedMeblegi { get; set; }
        
        public int UmumiOdemeSayi { get; set; }
        public decimal UmumiOdemeMeblegi { get; set; }
        
        public decimal CariBorc { get; set; }
        public decimal KreditLimiti { get; set; }
        public decimal QalanKreditLimiti { get; set; }
    }
}
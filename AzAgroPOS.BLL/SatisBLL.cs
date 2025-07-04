// Fayl: AzAgroPOS.BLL/SatisBLL.cs
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class SatisBLL
    {
        private readonly SatisDAL _dal = new SatisDAL();

        public bool Add(Satis satis, out string message)
        {
            if (satis.SatisMehsullari.Count == 0)
            {
                message = "Satış üçün səbət boşdur.";
                return false;
            }

            int yeniId = _dal.Add(satis);
            if (yeniId > 0)
            {
                message = $"Satış uğurla tamamlandı. Qəbz Nömrəsi: {yeniId}";
                return true;
            }

            message = "Satış zamanı xəta baş verdi.";
            return false;
        }
        
        public List<Satis> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _dal.GetByDateRange(startDate, endDate);
        }
    }
}
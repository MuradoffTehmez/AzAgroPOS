using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dal = new DashboardDAL();

        /// <summary>
        /// Dashboard üçün əsas statistik göstəriciləri gətirir.
        /// </summary>
        /// <returns>Statistik məlumatları ehtiva edən obyekt.</returns>
        public DashboardStats GetDashboardStats() => _dal.GetDashboardStats();

        /// <summary>
        /// Son 7 günün satış məbləğlərini tarixə görə qruplaşdıraraq qaytarır.
        /// </summary>
        /// <returns>Tarix və Məbləğ cütlüklərini ehtiva edən lüğət.</returns>
        public Dictionary<DateTime, decimal> GetSalesForLast7Days()
        {
            return _dal.GetSalesForLast7Days();
        }
    }
}
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;

namespace AzAgroPOS.BLL
{
    public class DashboardBLL
    {
        private readonly DashboardDAL _dal = new DashboardDAL();
        public DashboardStats GetDashboardStats() => _dal.GetDashboardStats();
    }
}
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class SatisMehsullariBLL
    {
        private readonly SatisMehsullariDAL _dal = new SatisMehsullariDAL();
        public List<SatisMehsulu> GetBySatisId(int satisId) => _dal.GetBySatisId(satisId);
    }
}
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class VahidBLL
    {
        private readonly VahidDAL _dal = new VahidDAL();
        public List<Vahid> GetAll() => _dal.GetAll();
    }
}
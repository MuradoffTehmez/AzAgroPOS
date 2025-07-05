using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class RolBLL
    {
        private readonly RolDAL _dal = new RolDAL();
        public List<Rol> GetAll() => _dal.GetAll();
    }
}
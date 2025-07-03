using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class KateqoriyaBLL
    {
        private readonly KateqoriyaDAL _dal = new KateqoriyaDAL();
        public List<Kateqoriya> GetAll() => _dal.GetAll();
    }
}
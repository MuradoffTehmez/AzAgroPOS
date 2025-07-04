// Fayl: AzAgroPOS.BLL/TemirStatusuBLL.cs
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class TemirStatusuBLL
    {
        private readonly TemirStatusuDAL _dal = new TemirStatusuDAL();
        public List<TemirStatusu> GetAll() => _dal.GetAll();
    }
}
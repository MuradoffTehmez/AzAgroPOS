// Fayl: AzAgroPOS.BLL/MusteriBLL.cs
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class MusteriBLL
    {
        private readonly MusteriDAL _dal = new MusteriDAL();

        public List<Musteri> SearchByNameOrPhone(string searchTerm)
        {
            return _dal.SearchByNameOrPhone(searchTerm);
        }
    }
}
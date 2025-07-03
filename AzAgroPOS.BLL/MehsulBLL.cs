using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class MehsulBLL
    {
        private readonly MehsulDAL _dal = new MehsulDAL();

        public List<Mehsul> GetAll() => _dal.GetAll();

        public bool Add(Mehsul mehsul, out string message)
        {
            // Gələcəkdə burada yoxlamalar ola bilər. Məsələn:
            if (string.IsNullOrWhiteSpace(mehsul.Ad))
            {
                message = "Məhsul adı boş ola bilməz.";
                return false;
            }
            if (mehsul.SatisQiymeti < mehsul.AlisQiymeti)
            {
                message = "Satış qiyməti alış qiymətindən az ola bilməz.";
                return false;
            }

            int newId = _dal.Add(mehsul);
            if (newId > 0)
            {
                message = "Məhsul uğurla əlavə edildi.";
                return true;
            }

            message = "Məhsul əlavə edilərkən xəta baş verdi.";
            return false;
        }
    }
}
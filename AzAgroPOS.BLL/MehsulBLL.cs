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

        public bool Update(Mehsul mehsul, out string message)
        {
            if (mehsul.Id <= 0)
            {
                message = "Yeniləmək üçün məhsul seçilməyib.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(mehsul.Ad))
            {
                message = "Məhsul adı boş ola bilməz.";
                return false;
            }

            if (_dal.Update(mehsul))
            {
                message = "Məhsul uğurla yeniləndi.";
                return true;
            }

            message = "Məhsul yenilənərkən xəta baş verdi.";
            return false;
        }

        public bool Delete(int mehsulId, out string message)
        {
            if (mehsulId <= 0)
            {
                message = "Silmək üçün məhsul seçilməyib.";
                return false;
            }

            if (_dal.Delete(mehsulId))
            {
                message = "Məhsul uğurla silindi.";
                return true;
            }

            message = "Məhsul silinərkən xəta baş verdi.";
            return false;
        }
    }
}
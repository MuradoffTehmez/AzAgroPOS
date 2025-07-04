using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class TemirBLL
    {
        private readonly TemirDAL _dal = new TemirDAL();

        public List<Temir> GetAll() => _dal.GetAll();

        public bool Add(Temir temir, out string message)
        {
            if (temir.MusteriId == 0) { message = "Müştəri seçilməlidir."; return false; }
            if (string.IsNullOrWhiteSpace(temir.CihazAdi)) { message = "Cihazın adı boş ola bilməz."; return false; }
            if (string.IsNullOrWhiteSpace(temir.ProblemTesviri)) { message = "Problem təsviri boş ola bilməz."; return false; }

            int newId = _dal.Add(temir);
            message = newId > 0 ? $"Yeni təmir sifarişi uğurla yaradıldı. Qeydiyyat Nömrəsi: {newId}" : "Sifariş yaradılarkən xəta baş verdi.";
            return newId > 0;
        }

        public bool Update(Temir temir, out string message)
        {
            if (temir.Id == 0) { message = "Yeniləmək üçün sifariş seçilməyib."; return false; }
            if (temir.MusteriId == 0) { message = "Müştəri seçilməlidir."; return false; }
            if (string.IsNullOrWhiteSpace(temir.CihazAdi)) { message = "Cihazın adı boş ola bilməz."; return false; }

            bool result = _dal.Update(temir);
            message = result ? "Sifariş uğurla yeniləndi." : "Sifariş yenilənərkən xəta baş verdi.";
            return result;
        }

        public bool Delete(int temirId, out string message)
        {
            if (temirId == 0)
            {
                message = "Silmək üçün sifariş seçilməyib.";
                return false;
            }

            bool result = _dal.Delete(temirId);
            message = result ? "Sifariş uğurla silindi." : "Sifariş silinərkən xəta baş verdi.";
            return result;
        }
        
        public bool CompleteRepair(int temirId, decimal yekunXerc, out string message)
        {
            if (temirId == 0)
            {
                message = "Sifariş seçilməyib.";
                return false;
            }

            if (_dal.CompleteRepair(temirId, yekunXerc))
            {
                message = "Təmir sifarişi uğurla tamamlandı.";
                return true;
            }

            message = "Sifariş tamamlanarkən xəta baş verdi.";
            return false;
        }
    }
}
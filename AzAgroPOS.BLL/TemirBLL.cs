// Fayl: AzAgroPOS.BLL/TemirBLL.cs
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;

namespace AzAgroPOS.BLL
{
    public class TemirBLL
    {
        private readonly TemirDAL _dal = new TemirDAL();
        public bool Add(Temir temir, out string message)
        {
            if (temir.MusteriId == 0) { message = "Müştəri seçilməlidir."; return false; }
            if (string.IsNullOrWhiteSpace(temir.CihazAdi)) { message = "Cihazın adı boş ola bilməz."; return false; }

            int newId = _dal.Add(temir);
            message = newId > 0 ? $"Yeni təmir sifarişi uğurla yaradıldı. Qeydiyyat Nömrəsi: {newId}" : "Sifariş yaradılarkən xəta baş verdi.";
            return newId > 0;
        }
    }
}
// Fayl: AzAgroPOS.BLL/TemirHisseleriBLL.cs
using AzAgroPOS.DAL;
using AzAgroPOS.Entities;
using System.Collections.Generic;

namespace AzAgroPOS.BLL
{
    public class TemirHisseleriBLL
    {
        private readonly TemirHisseleriDAL _dal = new TemirHisseleriDAL();

        public List<TemirHissesi> GetByTemirId(int temirId) => _dal.GetByTemirId(temirId);

        public bool Add(TemirHissesi hisse, out string message)
        {
            // Burada anbar qalığını yoxlamaq üçün əlavə məntiq yazıla bilər
            if (_dal.Add(hisse))
            {
                message = "Ehtiyat hissəsi uğurla əlavə edildi.";
                return true;
            }
            message = "Ehtiyat hissəsi əlavə edilərkən xəta baş verdi.";
            return false;
        }
    }
}
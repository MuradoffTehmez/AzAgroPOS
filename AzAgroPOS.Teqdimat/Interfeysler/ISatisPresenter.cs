using AzAgroPOS.Teqdimat.Yardimcilar;

namespace AzAgroPOS.Teqdimat.Interfeysler
{
    public interface ISatisPresenter
    {
        void GozleyenSatisiSec(GozleyenSatis satis);
        System.Threading.Tasks.Task<bool> MehsulSilAsync(int mehsulId);

        /// <summary>
        /// Müştəri borcuna görə uyğun rəng adını qaytarır
        /// </summary>
        /// <param name="borc">Müştəri borcu</param>
        /// <returns>Rəng adı ("Red", "Orange" və ya "Black")</returns>
        string GetMusteriBorcRengi(decimal borc);
    }
}
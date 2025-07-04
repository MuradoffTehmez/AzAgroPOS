// Yeni Fayl: AzAgroPOS.Entities/SalesCartItem.cs
namespace AzAgroPOS.Entities
{
    public class SalesCartItem
    {
        public int ProductId { get; set; }
        public string Ad { get; set; }
        public decimal Miqdar { get; set; }
        public decimal VahidQiymet { get; set; }
        public decimal YekunMebleg => Miqdar * VahidQiymet;
    }
}
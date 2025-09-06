namespace AzAgroPOS.Mentiq.DTOs
{
    public enum EndirimScope
    {
        Cart,
        SelectedItem
    }

    public enum EndirimType
    {
        Percentage,
        FixedAmount
    }

    public class EndirimParametrləriDto
    {
        public EndirimScope Scope { get; set; }
        public EndirimType Type { get; set; }
        public decimal Value { get; set; }
    }
}
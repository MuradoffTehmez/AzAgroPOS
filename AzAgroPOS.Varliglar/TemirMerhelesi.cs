namespace AzAgroPOS.Varliglar
{
    public class TemirMerhelesi : BazaVarligi
    {
        public int TemirId { get; set; }
        public virtual Temir Temir { get; set; } = null!;
        public DateTime Tarix { get; set; }
        public string Aciqlama { get; set; } = string.Empty;
        public TemirStatusu Status { get; set; }
    }
}
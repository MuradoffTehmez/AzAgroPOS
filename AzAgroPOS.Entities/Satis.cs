// Fayl: AzAgroPOS.Entities/Satis.cs
using System;
using System.Collections.Generic;

namespace AzAgroPOS.Entities
{
    public class Satis
    {
        public int Id { get; set; }
        public DateTime SatisTarixi { get; set; }
        public int? MusteriId { get; set; }
        public int IstifadeciId { get; set; }
        public decimal YekunMebleg { get; set; }
        public decimal OdenmisMebleg { get; set; }
        public List<SatisMehsulu> SatisMehsullari { get; set; } = new List<SatisMehsulu>();
        public List<Odenis> Odenisler { get; set; } = new List<Odenis>();
    }
}
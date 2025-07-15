using System;
using System.ComponentModel.DataAnnotations;

namespace AzAgroPOS.Entities.Domain
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        public DateTime YaranmaTarixi { get; set; } = DateTime.Now;
        
        public DateTime YenilenmeTarixi { get; set; } = DateTime.Now;
        
        public bool SilinibMi { get; set; } = false;
    }
}
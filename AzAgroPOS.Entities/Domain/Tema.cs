using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Temalar")]
    public class Tema
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tema adı mütləqdir")]
        [StringLength(50, ErrorMessage = "Tema adı maksimum 50 simbol ola bilər")]
        [Column(TypeName = "varchar(50)")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Arxaplan rəngi mütləqdir")]
        [StringLength(7, ErrorMessage = "Arxaplan rəngi HEX formatda olmalıdır (#FFFFFF)")]
        [Column(TypeName = "varchar(7)")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6})$", ErrorMessage = "Arxaplan rəngi HEX formatda olmalıdır (#FFFFFF)")]
        public string ArxaplanRengi { get; set; }

        [Required(ErrorMessage = "Mətn rəngi mütləqdir")]
        [StringLength(7, ErrorMessage = "Mətn rəngi HEX formatda olmalıdır (#000000)")]
        [Column(TypeName = "varchar(7)")]
        [RegularExpression(@"^#([A-Fa-f0-9]{6})$", ErrorMessage = "Mətn rəngi HEX formatda olmalıdır (#000000)")]
        public string MetinRengi { get; set; }

        [StringLength(100, ErrorMessage = "Icon maksimum 100 simbol ola bilər")]
        [Column(TypeName = "varchar(100)")]
        public string Icon { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime YaradilmaTarixi { get; set; }

        [Required(ErrorMessage = "Status mütləqdir")]
        [StringLength(20, ErrorMessage = "Status maksimum 20 simbol ola bilər")]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } = "Aktiv";

        public virtual ICollection<Istifadeci> Istifadeciler { get; set; } = new List<Istifadeci>();
    }
}
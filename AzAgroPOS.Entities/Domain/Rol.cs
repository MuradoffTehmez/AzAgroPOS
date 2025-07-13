using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Roller")]
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol adı mütləqdir")]
        [StringLength(50, ErrorMessage = "Rol adı maksimum 50 simbol ola bilər")]
        [Column(TypeName = "varchar(50)")]
        public string Ad { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime YaradilmaTarixi { get; set; }

        [StringLength(500, ErrorMessage = "Açıqlama maksimum 500 simbol ola bilər")]
        [Column(TypeName = "varchar(500)")]
        public string Aciklama { get; set; }

        [Required(ErrorMessage = "Status mütləqdir")]
        [StringLength(20, ErrorMessage = "Status maksimum 20 simbol ola bilər")]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } = "Aktiv";

        public virtual ICollection<Istifadeci> Istifadeciler { get; set; } = new List<Istifadeci>();
        public virtual ICollection<RolIcazesi> RolIcazeleri { get; set; } = new List<RolIcazesi>();
    }
}
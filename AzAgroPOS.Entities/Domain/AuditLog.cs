using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("AuditLoglar")]
    public class AuditLog
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Istifadeci")]
        public int? IstifadeciId { get; set; }

        [Required(ErrorMessage = "Əməliyyat mütləqdir")]
        [StringLength(100, ErrorMessage = "Əməliyyat adı maksimum 100 simbol ola bilər")]
        [Column(TypeName = "varchar(100)")]
        public string Emeliyyat { get; set; }

        [StringLength(1000, ErrorMessage = "Detal maksimum 1000 simbol ola bilər")]
        [Column(TypeName = "text")]
        public string Detal { get; set; }

        [StringLength(45, ErrorMessage = "IP ünvanı maksimum 45 simbol ola bilər")]
        [Column(TypeName = "varchar(45)")]
        public string IP { get; set; }

        [Required(ErrorMessage = "Tarix mütləqdir")]
        [Column(TypeName = "datetime")]
        public DateTime Tarix { get; set; }

        [StringLength(50, ErrorMessage = "Browser məlumatı maksimum 50 simbol ola bilər")]
        [Column(TypeName = "nvarchar(50)")]
        public string Browser { get; set; }

        [StringLength(50, ErrorMessage = "Platforma məlumatı maksimum 50 simbol ola bilər")]
        [Column(TypeName = "nvarchar(50)")]
        public string Platform { get; set; }

        public virtual Istifadeci Istifadeci { get; set; }
    }
}
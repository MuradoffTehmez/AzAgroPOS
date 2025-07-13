using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzAgroPOS.Entities.Domain
{
    [Table("RolIcazeleri")]
    public class RolIcazesi
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Rol ID mütləqdir")]
        [ForeignKey("Rol")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "Modul mütləqdir")]
        [StringLength(50, ErrorMessage = "Modul adı maksimum 50 simbol ola bilər")]
        [Column(TypeName = "varchar(50)")]
        public string Modul { get; set; }

        [Required(ErrorMessage = "Əməliyyat mütləqdir")]
        [StringLength(50, ErrorMessage = "Əməliyyat adı maksimum 50 simbol ola bilər")]
        [Column(TypeName = "varchar(50)")]
        public string Emeliyyat { get; set; }

        [Required(ErrorMessage = "İcazə statusu mütləqdir")]
        public bool IcazeVerilib { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime YaradilmaTarixi { get; set; }

        [StringLength(500, ErrorMessage = "Açıqlama maksimum 500 simbol ola bilər")]
        [Column(TypeName = "varchar(500)")]
        public string Aciklama { get; set; }

        public virtual Rol Rol { get; set; }
    }
}
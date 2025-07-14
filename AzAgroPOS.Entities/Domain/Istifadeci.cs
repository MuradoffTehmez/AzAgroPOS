using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AzAgroPOS.Entities.Constants;

namespace AzAgroPOS.Entities.Domain
{
    [Table("Istifadeciler")]
    public class Istifadeci
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad mütləqdir")]
        [StringLength(50, ErrorMessage = "Ad maksimum 50 simbol ola bilər")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Soyad mütləqdir")]
        [StringLength(50, ErrorMessage = "Soyad maksimum 50 simbol ola bilər")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Email mütləqdir")]
        [StringLength(100, ErrorMessage = "Email maksimum 100 simbol ola bilər")]
        [EmailAddress(ErrorMessage = "Email formatı düzgün deyil")]
        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parol hash mütləqdir")]
        [StringLength(256, ErrorMessage = "Parol hash maksimum 256 simbol ola bilər")]
        [Column(TypeName = "varchar(256)")]
        public string ParolHash { get; set; }

        [ForeignKey("Rol")]
        public int? RolId { get; set; }

        [ForeignKey("Tema")]
        public int? TemaId { get; set; }

        [Required(ErrorMessage = "Status mütləqdir")]
        [StringLength(20, ErrorMessage = "Status maksimum 20 simbol ola bilər")]
        [Column(TypeName = "varchar(20)")]
        public string Status { get; set; } = SystemConstants.Status.Active;

        [Column(TypeName = "datetime")]
        public DateTime YaradilmaTarixi { get; set; }

        [NotMapped]
        public string TamAd => $"{Ad} {Soyad}";

        [NotMapped]
        public string Role => Rol?.Ad ?? "User";

        [StringLength(256)]
        public string RememberMeToken { get; set; }

        public DateTime? RememberMeTokenExpiry { get; set; }

        public virtual Rol Rol { get; set; }
        public virtual Tema Tema { get; set; }
        public DateTime SonGiris { get; set; }
        public DateTime YenilenmeTarixi { get; set; }
    }
}
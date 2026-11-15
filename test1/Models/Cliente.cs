using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test1.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La cédula o identificación es obligatoria.")]
        [StringLength(20)]
        [Display(Name = "Cédula / identificación")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios.")]
        [StringLength(100)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios.")]
        [StringLength(100)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Ingresa un correo electrónico válido.")]
        [StringLength(150)]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(30)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(30)]
        [Display(Name = "Género")]
        public string Genero { get; set; }

        [StringLength(250)]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [StringLength(100)]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Display(Name = "Activo")]
        public bool Activo { get; set; } = true;
    }
}

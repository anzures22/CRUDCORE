using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class AlumnoModel
    {
        [Required(ErrorMessage = "El campo Matricula es obligatorio")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "El campo Nombre completo es obligatorio")]
        public string NombreC { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El campo Correo electrónico no es una dirección válida")]
        public string CorreoE { get; set; }
    }
}

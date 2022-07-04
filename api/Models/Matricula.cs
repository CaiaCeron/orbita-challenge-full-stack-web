using System.ComponentModel.DataAnnotations;

namespace matricula_api.Models
{
    public class Matricula
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public long RegAcademico { get; set; } 

        public String Name { get; set; }

        public String Email { get; set; }
        [Required]
        public long Cpf { get; set; }

        public DateTime RegisterCreated { get; set; }

    }
}

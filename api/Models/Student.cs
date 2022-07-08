using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Registro academico deve ser inserido!")]
        [RegularExpression(@"^[ 0-9 ]*$", ErrorMessage = "O Registro academico deve conter apenas numeros!")]
        public string Ra { get; set; } = null!;

        [Required(ErrorMessage = "O Nome deve ser inserido!")]
        [MinLength(3, ErrorMessage = "O Nome deve conter no mínimo 3 caracteres!")]
        [MaxLength(50, ErrorMessage = "O Nome deve conter no máximo 50 caracteres!")]
        public string Name { get; set;} = null!;

        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "O CPF deve ser inserido!")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 digitos!")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 digitos!")]
        [RegularExpression(@"^[ 0-9 ]*$", ErrorMessage = "O CPF deve conter apenas numeros!")]
        public string Cpf { get; set; } = null!;


    }
}

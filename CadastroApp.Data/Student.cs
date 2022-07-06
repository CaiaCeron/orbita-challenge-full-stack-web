using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Data
{
    public class Student
    {

        public int Id { get; set; }

        [Required]
        public string AcademicRegistry { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Cpf { get; set; }

        public string Email { get; set; }

    }
}

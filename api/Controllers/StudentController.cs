using api.Models;
using api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private IStudentServices _iStudentServices;

        public StudentController(IStudentServices iStudentServices)
        {
            _iStudentServices = iStudentServices;
        }


        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudents()
        {
            try
            {
                var students = await _iStudentServices.GetStudents();
                return Ok(students);
            }
            catch
            {
                return BadRequest("Requisição inválida.");
            }
        }

        [HttpGet("AlunosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudentsByName([FromQuery] string name)
        {
            try
            {
                var student = await _iStudentServices.GetStudentsByName(name);
                if (student == null)
                {
                    return NotFound($"Não a registros com o critério {name}");
                }
                return Ok(student);
            }
            catch
            {
                return BadRequest("Requisição inválida.");
            }
        }
        [HttpGet("{id:int}", Name="GetStudent")]
        public async Task<ActionResult<IAsyncEnumerable<Student>>> GetStudent(int id)
        {
            try
            {
                var student = await _iStudentServices.GetStudent(id);
                if (student == null)
                {
                    return NotFound($"Não a registros do ID={id}");
                }
                return Ok(student);
            }
            catch
            {
                return BadRequest("Requisição inválida.");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Student student)
        {
            try
            {
                await _iStudentServices.CreateStudent(student);          
                return CreatedAtRoute(nameof(GetStudent), new {id = student.Id }, student);//Retorna o recurso recem criado.
            }
            catch
            {
                return BadRequest("Requisição inválida.");
            }

        }

        [HttpPut("{id:int}")] //Indormar todos os dados com a alteração.
        public async Task<ActionResult> Update(int id, [FromBody] Student student)
        {
            try
            {
                if (student.Id == id)
                {
                    await _iStudentServices.UpdateStudent(student);
                    return Ok($"Aluno com ID={id} atualizado com sucesso!");
                }
                else
                {
                    return BadRequest("Incosistencia nos dados!");
                }
            }
            catch
            {
                return BadRequest("Requisição inválida.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                
               var student = await _iStudentServices.GetStudent(id);
               if(student != null)
                {
                   await _iStudentServices.DeleteStudent(student);
                   return Ok($"Aluno de ID={id} foi excluido!");
                }
                else
                {
                    return NotFound($"Aluno com id={id} não foi encontrado");
                }   
            }
            catch
            {
                return BadRequest("Requisição inválida.");
            }
        }
    }
}

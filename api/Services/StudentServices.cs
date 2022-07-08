using api.Models;
using api.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly AppDbContext _context;

        public StudentServices(AppDbContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                return await _context.students.ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Student>> GetStudentsByName(string name)
        {
            IEnumerable<Student> students;
            if (!string.IsNullOrWhiteSpace(name))
            {
                students = await _context.students.Where(n => n.Name.Contains(name)).ToListAsync();
            }
            else
            {
                students = await GetStudents(); 
            }
            return students;
        }

        public async Task<Student> GetStudent(int id)
        {
           var student = await _context.students.FindAsync(id);
           return student;
        }


        public async Task CreateStudent(Student student)
        {
            _context.students.Add(student); //Salvar dados na variavel context.
            await _context.SaveChangesAsync(); //Salvar no Banco de dados.
        }

        public async Task UpdateStudent(Student student)
        {
            _context.Entry(student).State = EntityState.Modified; //Sinalizando que o estado de aluno foi modificado.
            await _context.SaveChangesAsync(); //Salvar no Banco de dados.
        }

        public async Task DeleteStudent(Student student)
        {
            _context.students.Remove(student);
            await _context.SaveChangesAsync();
        }       
    }
}

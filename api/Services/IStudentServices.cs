using api.Models;

namespace api.Services
{
    public interface IStudentServices
    {
        Task<IEnumerable<Student>> GetStudents();

        Task<IEnumerable<Student>> GetStudentsByName(string name);

        Task<Student> GetStudent(int id);

        Task CreateStudent(Student student);

        Task UpdateStudent(Student student);

        Task DeleteStudent(Student student);
    }
}

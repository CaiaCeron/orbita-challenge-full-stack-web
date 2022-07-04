using Microsoft.EntityFrameworkCore;
using matricula_api.Models;

namespace matricula_api.Data
{
    public class MatriculaDbContext : DbContext
    {
        public MatriculaDbContext(DbContextOptions<MatriculaDbContext> options)
            :base(options)

        { 
        }

        public DbSet<Matricula> Matriculas { get; set; }
    }
}

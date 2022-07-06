using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroApp.Data
{
    public class CadastroDataContext : DbContext
    {
        public CadastroDataContext(DbContextOptions<CadastroDataContext> options) 
            :base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }


        public DbSet<Student> Students { get; set; }

    }
}

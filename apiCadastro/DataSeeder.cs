using CadastroApp.Data;

namespace apiCadastro
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<CadastroDataContext>();
            context.Database.EnsureCreated();
            AddStudents(context);

        }

        private static void AddStudents(CadastroDataContext context)
        {
            var students = context.Students.FirstOrDefault();
            if (students != null) return;


            context.Students.Add(new Student
            {
                AcademicRegistry = "000001",
                Name = "Caiã Ceron",
                Cpf = "03688094042",
                Email = "caiaceron@gmail.com",
            });

            context.Students.Add(new Student
            {
                AcademicRegistry = "000002",
                Name = "Marcella Macedo",
                Cpf = "03625278294",
                Email = "marcella@gmail.com",
            });


            context.SaveChanges();
        }



    }
}

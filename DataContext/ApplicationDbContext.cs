using CrudWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi.DataContext
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                        
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<DepartamentoModel> Departamentos { get; set;}
    }
}

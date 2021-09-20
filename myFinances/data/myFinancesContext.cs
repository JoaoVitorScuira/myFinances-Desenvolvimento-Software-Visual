using Microsoft.EntityFrameworkCore;
using myFinances.models;
namespace myFinances.Data
{
public class myFinancesContext : DbContext {

 protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
      builder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=myFinances;Integrated Security=True");
    }

 public DbSet<myFinances.models.Usuario> Usuario { get; set; }

 public DbSet<myFinances.models.Adm> Adm { get; set; }

 public DbSet<myFinances.models.Despesa> Despesa { get; set; }

 public DbSet<myFinances.models.Movimentacao> Movimentacao { get; set; }

 public DbSet<myFinances.models.Pessoa> Pessoa { get; set; }

 public DbSet<myFinances.models.Receita> Receita { get; set; }
}
}
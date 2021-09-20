using Microsoft.EntityFrameworkCore;
using myFinances.models;
namespace myFinances.Data
{
public class ExemploContext : DbContext {
//public ExemploContext() : base("ConexaoExemplo"){}
public DbSet<Pessoa> Pessoas { get; set; }
public DbSet<Usuario> Usuarios { get; set; }


protected override void OnConfiguring(DbContextOptionsBuilder dbcob) {
dbcob.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
}
}
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    { //Criar migrations em tempo de projeto
      string connectionString = "Server=localhost;Port=3306;Database=DPSP;User Id=root;Password=@12345678#;";
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
      return new MyContext(optionsBuilder.Options);
    }
  }
}
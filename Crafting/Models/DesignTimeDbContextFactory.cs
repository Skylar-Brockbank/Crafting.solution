using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Crafting.Models
{
  public class CraftingSystemContextFactory : IDesignTimeDbContextFactory<CraftingSystemContext>
  {

    CraftingSystemContext IDesignTimeDbContextFactory<CraftingSystemContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<CraftingSystemContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new CraftingSystemContext(builder.Options);
    }
  }
}
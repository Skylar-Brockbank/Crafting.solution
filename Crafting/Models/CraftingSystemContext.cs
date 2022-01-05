using Microsoft.EntityFrameworkCore;

namespace Crafting.Models
{
  public class CraftingSystemContext : DbContext
  {
    public DbSet<Item> Items {get; set;}
    public DbSet<Recipe> Recipes {get; set;}
    public DbSet<Ingredient> Ingredients {get; set;}
    public DbSet<Product> Products {get; set;}

    public CraftingSystemContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}
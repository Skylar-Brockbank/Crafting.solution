namespace Crafting.Models
{
  public class Recipe
  {
    public Item()
    {
      this.Ingredients = new HashSet<Ingredient>();
      this.Products = new HashSet<Ingredient>();
    }

    public int RecipeId {get; set;}
    public string Name {get; set;}
    public virtual ICollection<Ingredient> Ingredients {get;}
    public virtual ICollection<Product> Products {get;}
  }
}
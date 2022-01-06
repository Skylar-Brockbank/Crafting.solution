using System.Collections.Generic;

namespace Crafting.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.Ingredients = new HashSet<Ingredient>();
      this.Products = new HashSet<Product>();
    }

    public int RecipeId {get; set;}
    public string Name {get; set;}
  
    public virtual ICollection<Ingredient> Ingredients {get;}
    public virtual ICollection<Product> Products {get;}
  }
}
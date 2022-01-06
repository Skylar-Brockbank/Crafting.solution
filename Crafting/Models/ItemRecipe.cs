using System.ComponentModel.DataAnnotations.Schema;

namespace Crafting.Models
{  
  public abstract class ItemRecipe
  {
    public int ItemId {get; set;}
    public virtual Item Item {get; set;}
    public int RecipeId { get; set;}
    public virtual Recipe Recipe {get; set;}
  } 

  public class Ingredient : ItemRecipe
  {
    public int IngredientId {get; set;}
  }
  public class Product : ItemRecipe
  {
    public int ProductId {get; set;}
  }
}

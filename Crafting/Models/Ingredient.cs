namespace Crafting.Models
{
  public class Ingredient
  {
    public int IngredientId { get; set; }
    public int RecipeId { get; set;}
    public int ItemId {get; set;}
    public virtual Item Item {get;}
    public virtual Recipe Recipe {get;}
  } 
}
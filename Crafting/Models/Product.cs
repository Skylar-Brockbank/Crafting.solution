namespace Crafting.Models
{
  public class Product
  {
    public int ProductId { get; set;}
    public int RecipeId {get; set;}
    public int ItemId {get; set;}
    public virtual Item Item;
    public virtual Recipe Recipe;
  }
}
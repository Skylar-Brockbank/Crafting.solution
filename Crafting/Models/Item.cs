using System.Collections.Generic;

namespace Crafting.Models
{
  public class Item
  {
    public Item()
    {
      this.Ingredients = new HashSet<Ingredient>();
      this.Products = new HashSet<Product>();
    }

    public int ItemId {get; set;}
    public int Quantity {get; set;} = 0;
    public string ItemName {get; set;}
    public virtual ICollection<Ingredient> Ingredients {get;}
    public virtual ICollection<Product> Products {get;}

    public bool CheckQuantity(int quantity)
    {
      return quantity < Quantity;
    }

    public void UseQuantity(int quantity)
    {
      if (CheckQuantity(quantity))
      {
        Quantity -= quantity;
      }
    }

    public void AddQuantity(int quantity)
    {
      Quantity += quantity;
    }
  }
}
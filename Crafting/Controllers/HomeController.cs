using Crafting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Crafting.Controllers
{
  public class HomeController : Controller
  {
     private readonly CraftingSystemContext _db;
    
    public HomeController(CraftingSystemContext db)
    {
      _db = db;
    }
    [HttpGet("/")]
    public ActionResult Index()
    {
      ViewBag.Inventory = (from item in _db.Items where item.Quantity > 0 select item).ToList();
      ViewBag.Recipes = _db.Recipes
        .Include(recipe => recipe.Ingredients)
        .ThenInclude(ingredient => ingredient.Item)
        .Include(recipe => recipe.Products)
        .ThenInclude(product => product.Item)
        .ToList();
      return View();
    }

    [HttpGet("/LoadRecipe/{id}")]
    public ActionResult LoadRecipe(int id)
    {
      Recipe model = _db.Recipes
        .Include(recipe => recipe.Ingredients)
        .ThenInclude(ingredient => ingredient.Item)
        .Include(recipe => recipe.Products)
        .ThenInclude(product => product.Item)
        .FirstOrDefault(recipe => recipe.RecipeId == id);
      return PartialView("_RecipeDetails", model);
    }
    [HttpPost ("/Craft/{id}")]
    public ActionResult Craft(int id)
    {
      Recipe target = _db.Recipes
        .Include(recipe => recipe.Ingredients)
        .ThenInclude(ingredient => ingredient.Item)
        .Include(recipe => recipe.Products)
        .ThenInclude(product => product.Item)
        .FirstOrDefault(recipe => recipe.RecipeId == id);
      foreach(Ingredient ingredient in target.Ingredients)
      {
        ingredient.Item.UseQuantity(1);
        _db.Entry(ingredient.Item).State = EntityState.Modified;
        _db.SaveChanges();
      }
      foreach(Product product in target.Products)
      {
        product.Item.AddQuantity(1);
        _db.Entry(product.Item).State = EntityState.Modified;
        _db.SaveChanges();
      }      
      return RedirectToAction("Index");
    }
  }
}
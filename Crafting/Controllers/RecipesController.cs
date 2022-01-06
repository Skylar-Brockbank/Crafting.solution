using Crafting.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Crafting.Controllers
{
  public class RecipesController : Controller
  {
    private readonly CraftingSystemContext _db;
    
    public RecipesController(CraftingSystemContext db)
    {
      _db = db;
    }
    
    public ActionResult Index()
    {
      return View(_db.Recipes.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.Items = _db.Items.ToList();
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Recipe recipe, IFormCollection joins)
    {
      _db.Recipes.Add(recipe);
      _db.SaveChanges();
      int temp;
      foreach(var join in joins)
      {
        if(int.TryParse(join.Value, out temp))
        {
          for(int i = 0; i < int.Parse(join.Value); i++)
          {
            string itemId = join.Key.Remove(0, 1);
            if (join.Key[0] == 'I')
            {
              _db.Ingredients.Add(new Ingredient {RecipeId = recipe.RecipeId, ItemId = int.Parse(itemId)});
            }
            else if (join.Key[0] == 'P')
            {
              _db.Products.Add(new Product {RecipeId = recipe.RecipeId, ItemId = int.Parse(itemId)});
            }
          }
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Recipe target = _db.Recipes
        .Include(recipe => recipe.Ingredients)
        .ThenInclude(ingredient => ingredient.Item)
        .Include(recipe => recipe.Products) 
        .ThenInclude(product => product.Item)
        .FirstOrDefault(recipe => recipe.RecipeId == id);
      return View(target);
    }

    // public ActionResult Edit(int id)
    // {
    //   //edit the rId object
    // }
    // [HttpPost]
    // public ActionResult Edit(Recipe recipe)
    // {
    //   //make the change
    // }
  }
}
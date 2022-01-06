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
      int temp = 0;
      bool tableSwitch = true;
      foreach(var join in joins)
      {
        if(int.TryParse(join.Key, out temp))
        {
          if(join.Key == "0")
          {
            tableSwitch = false;
            break;
          }
          for(int i = 0; i < int.Parse(join.Value); i++)
          {
            if(tableSwitch)
            {
              _db.Ingredients.Add(new Ingredient {RecipeId = recipe.RecipeId, ItemId = int.Parse(join.Key)});
            } 
            else
            {
              _db.Products.Add(new Product {RecipeId = recipe.RecipeId, ItemId = int.Parse(join.Key)});
            }
          }
        }
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
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
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
    
    // public ActionResult Index()
    // {
    //   return View();
    // }

    public ActionResult Create()
    {
      ViewBag.Items = _db.Items.ToList();
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Recipe recipe, IFormCollection joins)
    {
      Console.WriteLine(recipe);
      foreach(var join in joins)
      {
        Console.WriteLine(join);
      }
      return RedirectToAction("Create");
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
using Microsoft.AspNetCore.Mvc;

namespace Crafting.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
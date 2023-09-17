using Microsoft.AspNetCore.Mvc;
using PackerTracker.Models;
using System.Collections.Generic;

namespace PackerTracker.Controllers
{
  public class GearBagController : Controller
  {

   [HttpGet("/gearbag")]
    public ActionResult Index()
    {
      List<Gear> allGearBag = Gear.GetAll();
      return View(allGearBag);
    }

    [HttpGet("/gearbag/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/gearbag")]
    public ActionResult Create(string description)
    {
      Gear myGear = new Gear(description);
      return RedirectToAction("Index");
    }
    
    [HttpPost("/gearbag/delete")]
    public ActionResult DeleteAll()
    {
      Gear.ClearAll();
      return View();
    }

    [HttpPost("/gearbag/deleteselected")]
    public IActionResult DeleteGear([FromForm(Name = "gearIds")] List<int> selectedGearIds)     
    {
           foreach (var selectedGearId in selectedGearIds)
        {
            var gearItem = Gear.Find(selectedGearId);

            if (gearItem != null)
            {
                Gear.Remove(gearItem);
            }
        }

         return RedirectToAction("Index");
    }

    [HttpGet("/gearbag/{id}")]
    public ActionResult Show(int id)
    {
      Gear foundGear = Gear.Find(id);
      return View(foundGear);
    }

  }
}

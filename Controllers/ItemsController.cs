using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tamagotchi.Models;

namespace Tamagotchi.Controllers
{
    public class ItemsController : Controller
    {
        [HttpGet("/items")]
        public ActionResult Index()
        {
            List<Item> allItems = Item.GetAll();
            return View(allItems);
        }

        [HttpGet("/items/new")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost("/items")]
        public ActionResult Create(string name)
        {
            Item myItem = new Item(name);
            return RedirectToAction("Index");
        }

        [HttpPost("/items/delete")]
        public ActionResult DeleteAll()
        {
            Item.ClearAll();
            return View();
        }

        [HttpGet("/items/{id}")]
        public ActionResult Show(int id)
        {
            Item item = Item.Find(id);
            return View(item);
        }

        [HttpPost("/items/food/{id}")]
        public ActionResult UpdateFood(int id)
        {
            Item tamagotchi = Item.Find(id);
            tamagotchi.SetFood(tamagotchi.GetFood()+1);
            return View("Show", tamagotchi);
        }

        [HttpPost("/items/sleep/{id}")]
        public ActionResult UpdateSleep(int id)
        {
            Item tamagotchi = Item.Find(id);
            tamagotchi.SetSleep(tamagotchi.GetSleep()+1);
            return View("Show", tamagotchi);
        }

        [HttpPost("/items/happiness/{id}")]
        public ActionResult UpdateHappiness(int id)
        {
            Item tamagotchi = Item.Find(id);
            tamagotchi.SetHappiness(tamagotchi.GetHappiness()+1);
            return View("Show", tamagotchi);
        }

        [HttpPost("/items/time")]
        public ActionResult UpdateTime()
        {
            List<Item> allItems = Item.GetAll();
            foreach(Item tamagotchi in allItems)
            {
                tamagotchi.SetHappiness(tamagotchi.GetHappiness()-1);
                tamagotchi.SetFood(tamagotchi.GetFood()-1);
                tamagotchi.SetSleep(tamagotchi.GetSleep()-1);
                if (tamagotchi.GetHappiness() <= 0 || tamagotchi.GetFood() <= 0 || tamagotchi.GetSleep() <=0)
                {
                    tamagotchi.SetLife(false);
                }
            }
            return View("Index", allItems);
        }
    }
}

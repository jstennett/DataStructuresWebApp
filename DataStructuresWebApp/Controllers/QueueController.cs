using DataStructuresWebApp.Models;
using DataStructuresWebApp.ViewModels;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresWebApp.Controllers { 

    public class QueueController : Controller
    {
        // GET: Queue
        public ActionResult Index()
        {
            IndexController.mainMenu.actionMethods.Clear();
            IndexController.mainMenu.actionMethods.Add(new Navigation(){ Name = "Add one item to Queue", ActionMethod = "AddOneItemTo", Controller = "Queue" });
            IndexController.mainMenu.actionMethods.Add(new Navigation(){ Name = "Add huge list of items to Queue", ActionMethod = "AddHugeList", Controller = "Queue" });
            IndexController.mainMenu.actionMethods.Add(new Navigation(){ Name = "Display Queue", ActionMethod = "Display", Controller = "Queue" });
            IndexController.mainMenu.actionMethods.Add(new Navigation(){ Name = "Delete from Queue", ActionMethod = "DeleteFrom", Controller = "Queue" });
            IndexController.mainMenu.actionMethods.Add(new Navigation(){ Name = "Clear Queue", ActionMethod = "Clear", Controller = "Queue" });
            IndexController.mainMenu.actionMethods.Add(new Navigation(){ Name = "Search Queue", ActionMethod = "Search", Controller = "Queue" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Return", ActionMethod = "Return", Controller = "Index" });

            return View(IndexController.mainMenu);
        }

        public ActionResult AddOneItemTo()
        {
            generatePerson();

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult AddHugeList()
        {
            IndexController.mainMenu.queuePersons.Clear();

            for (int i = 0; i < 2000; i++)
            {
                generatePerson();
            }

            return View("Index", IndexController.mainMenu);
        }

       public ActionResult DeleteFrom()
        {
            IndexController.mainMenu.queuePersons.Dequeue();

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult Clear()
        {
            IndexController.mainMenu.queuePersons.Clear();

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult Search()
        {
            var search = IndexController.mainMenu.queuePersons.Any(x => x.name == "Phil");
            if (search)
            {

            }

            return View("Index", IndexController.mainMenu);
        }



        public void generatePerson()
        {
            Random random = new Random();
            PlaceNameGenerator place = new PlaceNameGenerator();
            PersonNameGenerator person = new PersonNameGenerator();
            IndexController.mainMenu.queuePersons.Enqueue(new Person()
            {
                name = person.GenerateRandomMaleFirstAndLastName(),
                age = random.Next(100),
                location = place.GenerateRandomPlaceName()
            });
        }

    }
}
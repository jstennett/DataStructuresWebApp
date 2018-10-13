using DataStructuresWebApp.Models;
using DataStructuresWebApp.ViewModels;
using DataStructuresWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomNameGeneratorLibrary;

namespace DataStructuresWebApp.Controllers
{
    public class DictionaryController : Controller
    {
        Random random = new Random();
        PlaceNameGenerator place = new PlaceNameGenerator();
        PersonNameGenerator person = new PersonNameGenerator();

        // GET: Dictionary
        public ActionResult Index()
        {
            IndexController.mainMenu.actionMethods.Clear();
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add one item to Dictionary", ActionMethod = "AddOneItemTo", Controller = "Dictionary" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add huge list of items to Dictionary", ActionMethod = "AddHugeList", Controller = "Dictionary" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Display Dictionary", ActionMethod = "Index", Controller = "Dicitonary" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Delete from Dictionary", ActionMethod = "DeleteFrom", Controller = "Dictionary" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Clear Dictionary", ActionMethod = "Clear", Controller = "Dictionary" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Search Dictionary", ActionMethod = "Search", Controller = "Dictionary" });
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
            IndexController.mainMenu.dictionaryPersons.Clear();

            for (int i = 0; i < 2000; i++)
            {
                generatePerson();
            }

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult DeleteFrom()
        {
            if (IndexController.mainMenu.dictionaryPersons.Count > 0)
            {
                IndexController.mainMenu.dictionaryPersons.Remove(IndexController.mainMenu.dictionaryPersons.Count - 1);
            }
            else
            {
                IndexController.mainMenu.message = "There are no more items to delete!";
            }

            return View("Index", IndexController.mainMenu);
        }

        public void generatePerson()
        {
            IndexController.mainMenu.message = null;

            IndexController.mainMenu.queuePersons.Enqueue(new Person()
            {
                newEntry = "New Entry " + (IndexController.mainMenu.queuePersons.Count + 1).ToString(),
                name = person.GenerateRandomMaleFirstAndLastName(),
                age = random.Next(1, 101),
                location = place.GenerateRandomPlaceName()
            });
        }
    }
}
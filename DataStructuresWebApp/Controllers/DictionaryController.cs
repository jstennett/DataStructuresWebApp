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
            IndexController.mainMenu.message = null;
            IndexController.mainMenu.actionMethods.Clear();

            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Add one item to Dictionary",
                ActionMethod = "AddOneItemTo",
                Controller = "Dictionary"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Add huge list of items to Dictionary",
                ActionMethod = "AddHugeList",
                Controller = "Dictionary"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Display Dictionary",
                ActionMethod = "Index",
                Controller = "Dictionary"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Delete from Dictionary",
                ActionMethod = "DeleteFrom",
                Controller = "Dictionary"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Clear Dictionary",
                ActionMethod = "Clear",
                Controller = "Dictionary"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Search Dictionary",
                ActionMethod = "Search",
                Controller = "Dictionary"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Return",
                ActionMethod = "Return",
                Controller = "Index"
            });

            return View(IndexController.mainMenu);
        }

        public ActionResult AddOneItemTo()
        {
            IndexController.mainMenu.message = null;

            generatePerson();

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult AddHugeList()
        {
            IndexController.mainMenu.message = null;
            IndexController.mainMenu.dictionaryPersons.Clear();

            for (int i = 0; i < 2000; i++)
            {
                generatePerson();
            }

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult DeleteFrom()
        {
            IndexController.mainMenu.message = null;

            if (IndexController.mainMenu.dictionaryPersons.Count > 0)
            {
                IndexController.mainMenu.dictionaryPersons.Remove
                    (
                        "New Index " + (IndexController.mainMenu.dictionaryPersons.Count).ToString()
                    );
            }
            else
            {
                IndexController.mainMenu.message = "There are no more items to delete!";
            }

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult Search()
        {
            IndexController.mainMenu.message = null;
            IndexController.mainMenu.searchDictionaryPersons.Clear();

            foreach (Person item in IndexController.mainMenu.dictionaryPersons.Values)
            {
                if (item.name.Contains("Fred"))
                {
                    IndexController.mainMenu.searchDictionaryPersons.Add
                        (
                            IndexController.mainMenu.dictionaryPersons.FirstOrDefault(x => x.Value.name == item.name).Key,
                            item
                        );
                }
            }

            return View("Search", IndexController.mainMenu);
        }

        public ActionResult Clear()
        {
            IndexController.mainMenu.message = null;

            IndexController.mainMenu.dictionaryPersons.Clear();

            return View("Index", IndexController.mainMenu);
        }

        public void generatePerson()
        {
            IndexController.mainMenu.message = null;

            IndexController.mainMenu.dictionaryPersons.Add
            (
                "New Index " + (IndexController.mainMenu.dictionaryPersons.Count + 1).ToString(), 
                new Person()
                {
                    name = person.GenerateRandomMaleFirstAndLastName(),
                    age = random.Next(1, 101),
                    location = place.GenerateRandomPlaceName()
                }
            );
        }
    }
}
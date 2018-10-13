using DataStructuresWebApp.Models;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresWebApp.Controllers
{
    public class StackController : Controller
    {
        Random random = new Random();
        PlaceNameGenerator place = new PlaceNameGenerator();
        PersonNameGenerator person = new PersonNameGenerator();

        // GET: Stack
        public ActionResult Index()
        {
            IndexController.mainMenu.message = null;
            IndexController.mainMenu.actionMethods.Clear();

            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add one item to Stack", ActionMethod = "AddOneItemTo", Controller = "Stack" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add huge list of items to Stack", ActionMethod = "AddHugeList", Controller = "Stack" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Display Stack", ActionMethod = "Index", Controller = "Stack" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Delete from Stack", ActionMethod = "DeleteFrom", Controller = "Stack" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Clear Stack", ActionMethod = "Clear", Controller = "Stack" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Search Stack", ActionMethod = "Search", Controller = "Stack" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Return", ActionMethod = "Return", Controller = "Index" });

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
            IndexController.mainMenu.stackPersons.Clear();

            for (int i = 0; i < 2000; i++)
            {
                generatePerson();
            }

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult DeleteFrom()
        {
            IndexController.mainMenu.message = null;

            if (IndexController.mainMenu.stackPersons.Count > 0)
            {
                IndexController.mainMenu.stackPersons.Pop();
            }
            else
            {
                IndexController.mainMenu.message = "There are no more items to delete!";
            }

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult Clear()
        {
            IndexController.mainMenu.message = null;

            IndexController.mainMenu.stackPersons.Clear();

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult Search()
        {
            IndexController.mainMenu.message = null;

            Stack<Person> tempQueue = new Stack<Person>();

            IndexController.mainMenu.searchStackPersons.Clear();

            foreach (Person item in IndexController.mainMenu.stackPersons)
            {
                tempQueue.Push(item);
            }

            for (int i = 0; i < IndexController.mainMenu.stackPersons.Count; i++)
            {
                if (IndexController.mainMenu.stackPersons.Peek().name.Contains("Fred"))
                {
                    IndexController.mainMenu.searchStackPersons.Push(IndexController.mainMenu.stackPersons.Peek());
                    IndexController.mainMenu.stackPersons.Clear();
                }
                else
                {
                    IndexController.mainMenu.stackPersons.Pop();
                }
            }

            foreach (Person item in tempQueue)
            {
                IndexController.mainMenu.stackPersons.Push(item);
            }

            return View("Search", IndexController.mainMenu);
        }

        public void generatePerson()
        {
            IndexController.mainMenu.message = null;

            IndexController.mainMenu.stackPersons.Push(new Person()
            {
                newEntry = "New Entry " + (IndexController.mainMenu.stackPersons.Count + 1).ToString(),
                name = person.GenerateRandomMaleFirstAndLastName(),
                age = random.Next(1, 101),
                location = place.GenerateRandomPlaceName()
            });
        }
    }
}
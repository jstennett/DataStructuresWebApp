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
        Random random = new Random();
        PlaceNameGenerator place = new PlaceNameGenerator();
        PersonNameGenerator person = new PersonNameGenerator();

        // GET: Queue
        public ActionResult Index()
        {
            IndexController.mainMenu.message = null;
            IndexController.mainMenu.actionMethods.Clear();
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Add one item to Queue",
                ActionMethod = "AddOneItemTo",
                Controller = "Queue"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Add huge list of items to Queue",
                ActionMethod = "AddHugeList",
                Controller = "Queue"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Display Queue",
                ActionMethod = "Index",
                Controller = "Queue"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Delete from Queue",
                ActionMethod = "DeleteFrom",
                Controller = "Queue"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Clear Queue",
                ActionMethod = "Clear",
                Controller = "Queue"
            });
            IndexController.mainMenu.actionMethods.Add(new Navigation()
            {
                Name = "Search Queue",
                ActionMethod = "Search",
                Controller = "Queue"
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

            IndexController.mainMenu.queuePersons.Clear();

            for (int i = 0; i < 2000; i++)
            {
                generatePerson();
            }

            return View("Index", IndexController.mainMenu);
        }

       public ActionResult DeleteFrom()
       {
            IndexController.mainMenu.message = null;

            if (IndexController.mainMenu.queuePersons.Count > 0)
            {
                IndexController.mainMenu.queuePersons.Dequeue();
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

            IndexController.mainMenu.queuePersons.Clear();

            return View("Index", IndexController.mainMenu);
        }

        public ActionResult Search()
        {
            IndexController.mainMenu.message = null;

            Queue<Person> tempQueue = new Queue<Person>();

            IndexController.mainMenu.searchQueuePersons.Clear();

            foreach (Person item in IndexController.mainMenu.queuePersons)
            {
                tempQueue.Enqueue(item);
            }

            for (int i = 0; i < IndexController.mainMenu.queuePersons.Count; i++)
            {
                if (IndexController.mainMenu.queuePersons.Peek().name.Contains("Fred"))
                {
                    IndexController.mainMenu.searchQueuePersons.Enqueue(IndexController.mainMenu.queuePersons.Peek());
                    IndexController.mainMenu.queuePersons.Clear();
                }
                else
                {
                    IndexController.mainMenu.queuePersons.Dequeue();
                }
            }

            foreach (Person item in tempQueue)
            {
                IndexController.mainMenu.queuePersons.Enqueue(item);
            }

            return View("Search", IndexController.mainMenu);
        }

        public void generatePerson()
        {
            IndexController.mainMenu.message = null;

            IndexController.mainMenu.queuePersons.Enqueue(new Person()
            {
                newEntry = "New Entry " + (IndexController.mainMenu.queuePersons.Count + 1).ToString(),
                name = person.GenerateRandomMaleFirstAndLastName(),
                age = random.Next(1,101),
                location = place.GenerateRandomPlaceName()
            });
        }
    }
}
using DataStructuresWebApp.Models;
using DataStructuresWebApp.ViewModels;
using DataStructuresWebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresWebApp.Controllers
{
    public class DictionaryController : Controller
    {
        // GET: Dictionary
        public ActionResult Index()
        {
            IndexController.mainMenu.actionMethods.Clear();
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add one item to Dictionary", ActionMethod = "AddOneItemTo", Controller = "DictionaryController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add huge list of items to Dictionary", ActionMethod = "AddHugeList", Controller = "DictionaryController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Display Dictionary", ActionMethod = "Display", Controller = "DicitonaryController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Delete from Dictionary", ActionMethod = "DeleteFrom", Controller = "DictionaryController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Clear Dictionary", ActionMethod = "Clear", Controller = "DictionaryController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Search Dictionary", ActionMethod = "Search", Controller = "DictionaryController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Return", ActionMethod = "Return", Controller = "Index" });

            return View(IndexController.mainMenu);
        }
    }
}
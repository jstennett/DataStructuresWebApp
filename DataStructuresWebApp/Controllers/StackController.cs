using DataStructuresWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresWebApp.Controllers
{
    public class StackController : Controller
    {
        
        // GET: Stack
        public ActionResult Index()
        {
            IndexController.mainMenu.actionMethods.Clear();
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add one item to Stack", ActionMethod = "AddOneItemTo", Controller = "StackController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Add huge list of items to Stack", ActionMethod = "AddHugeList", Controller = "StackController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Display Stack", ActionMethod = "Display", Controller = "StackController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Delete from Stack", ActionMethod = "DeleteFrom", Controller = "StackController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Clear Stack", ActionMethod = "Clear", Controller = "StackController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Search Stack", ActionMethod = "Search", Controller = "StackController" });
            IndexController.mainMenu.actionMethods.Add(new Navigation() { Name = "Return", ActionMethod = "Return", Controller = "Index" });

            return View(IndexController.mainMenu);
        }
    }
}
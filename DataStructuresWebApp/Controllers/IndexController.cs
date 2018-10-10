using DataStructuresWebApp.Models;
using DataStructuresWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresWebApp.Controllers
{
    public class IndexController : Controller
    {
        public MainMenu mainMenu = new MainMenu();
        
        // GET: Index
        public ActionResult Index()
        {
            mainMenu.friends.Add(new Friends() { Name = "bill" });
            mainMenu.friends.Add(new Friends() { Name = "bill" });
            mainMenu.friends.Add(new Friends() { Name = "bill" });
            mainMenu.friends.Add(new Friends() { Name = "bill" });
            mainMenu.friends.Add(new Friends() { Name = "bill" });
            mainMenu.friends.Add(new Friends() { Name = "bill" });

            mainMenu.navigations.Add(new Navigation() { Name = "Stack", ActionMethod = "DeleteName", Controller = "Index" });
            mainMenu.navigations.Add(new Navigation() { Name = "Exit", ActionMethod = "DeleteName", Controller = "Index" });
            mainMenu.navigations.Add(new Navigation() { Name = "Queue", ActionMethod = "DeleteName", Controller = "Index" });
            mainMenu.navigations.Add(new Navigation() { Name = "Kill Bill", ActionMethod = "DeleteName", Controller = "Index" });

            TempData["Friends"] = mainMenu;
            return View(mainMenu);
        }

        public ActionResult DeleteName()
        {
            MainMenu DeleteData = TempData["Friends"] as MainMenu;
            if (DeleteData.friends.Count > 0)
            {
                DeleteData.friends.RemoveAt(DeleteData.friends.Count - 1);
            }
            TempData["Friends"] = DeleteData;

            return View("Index", DeleteData);
        }


    }
}
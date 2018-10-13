using DataStructuresWebApp.Models;
using DataStructuresWebApp.ViewModels;
using System.Web.Mvc;

namespace DataStructuresWebApp.Controllers
{
    public class IndexController : Controller
    {
        public static MainMenu mainMenu = new MainMenu();
        
        // GET: Index
        public ActionResult Index()
        {
            if (mainMenu.navigations.Count < 1)
            {
                mainMenu.navigations.Add(new Navigation() { Name = "Home", ActionMethod = "Index", Controller = "Index" });
                mainMenu.navigations.Add(new Navigation() { Name = "Stack", ActionMethod = "Index", Controller = "Stack" });
                mainMenu.navigations.Add(new Navigation() { Name = "Queue", ActionMethod = "Index", Controller = "Queue" });
                mainMenu.navigations.Add(new Navigation() { Name = "Dictionary", ActionMethod = "Index", Controller = "Dictionary" });

                mainMenu.exit = new Navigation() { Name = "Exit", ActionMethod = "Exit", Controller = "Index" };
            }

            return View(mainMenu);
        }

        public ActionResult Exit()
        {

            return Redirect("https://www.byu.edu/");
        }

        public ActionResult Return()
        {

            return View("Index", mainMenu);
        }
    }
}
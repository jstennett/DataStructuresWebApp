using DataStructuresWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataStructuresWebApp.ViewModels
{
    public class MainMenu
    {
        public List<Navigation> navigations = new List<Navigation>();
        public List<Navigation> actionMethods = new List<Navigation>();
        public Navigation exit;
        public Queue<Person> queuePersons = new Queue<Person>();
        public Queue<Person> searchQueuePersons = new Queue<Person>();
        public Stack<Person> stackPersons = new Stack<Person>();
        public Stack<Person> searchStackPersons = new Stack<Person>();
        public Dictionary<int, Person> dictionaryPersons = new Dictionary<int, Person>();
        public string message { get; set; }

    }
}
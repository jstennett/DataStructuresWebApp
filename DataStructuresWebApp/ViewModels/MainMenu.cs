﻿using DataStructuresWebApp.Models;
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
        public Stack<Person> stackNames = new Stack<Person>();
        public Dictionary<int, Person> dictionarynames = new Dictionary<int, Person>();

    }
}
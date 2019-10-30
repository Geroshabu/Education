using System;
using System.Collections.Generic;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
	    var users = new List<User>
	    {
	        new User("Alice", 20),
		new User("Bob", 30),
		new User("Charlie", 40),
		new User("Dave", 19),
		new User("Ellen", 30),
		new User("Frank", 50)
	    };
	    List<string> names = new Exercise2().GetOrderedAdultUserNames(users);
            foreach (var name in names)
	    {
	        Console.WriteLine(name);
	    }
        }
    }
}

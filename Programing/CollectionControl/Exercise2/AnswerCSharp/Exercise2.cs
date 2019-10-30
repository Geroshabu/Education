using System.Collections.Generic;
using System.Linq;

namespace Exercise2
{
    class Exercise2
    {
        public List<string> GetOrderedAdultUserNames(List<User> users)
	{
	    return users
	        .Where(user => user.Age >= 20)
		.OrderBy(user => user.Age)
		.Select(user => user.Name)
		.ToList();
	}
    }
}
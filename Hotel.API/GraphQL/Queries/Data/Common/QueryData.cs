using Hotel.Data;
using Hotel.Data.Models;
using Hotel.Data.Models.Users.Common;
using Hotel.Data.Models.Users.Guests;
using System.ComponentModel;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace Hotel.API.GraphQL.Queries.Data.Common
{
    
    public class QueryData
    {       
        public string Test(string item)
        {
            return item;
        }
    }
}
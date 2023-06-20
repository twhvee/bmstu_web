using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RevWorld
{
    /*
    public enum Permission : int
    {
        Guest,
        User,
        Author,
        Admin
    }
    */
    public class Connection
    {
        public static string GetConnection(string perms, IConfiguration config)
        {
            if (perms == "Guest")
            {
                return config["Connections:ConnectGuest"];
            }
            else if (perms == "User")
            {
                return config["Connections:ConnectUser"];
            }
            else if (perms == "Author")
            {
                return config["Connections:ConnectAuthor"];
            }
            else
            {
                return config["Connections:ConnectAdmin"];
            }

        }
    }
}

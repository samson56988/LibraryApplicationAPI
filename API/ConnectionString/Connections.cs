﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace API.ConnectionString
{
    public class Connections
    {
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["LibraryApplication"].ConnectionString;

        }
    }
}
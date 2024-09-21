using PROJECT_PSD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_PSD.Repository
{
    public class Singleton
    {
        public static LocalDatabaseEntities instance;

        public static LocalDatabaseEntities GetInstance()
        {
            if (instance == null)
            {
                instance = new LocalDatabaseEntities();
            }
            return instance;
        }
    }
}
﻿using Classroom2.Controllers;
using System.Web;
using System.Web.Mvc;

namespace Classroom2
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LanguageFilter());
        }
    }
}

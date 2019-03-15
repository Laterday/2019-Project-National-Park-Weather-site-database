using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL.Interfaces
{
    public interface IParkSQLDAL
    {
        List<Park> GetParks();
        Park GetParkDetails(string parkCode);
        List<SelectListItem> GetUniqueParkNames();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Infrastructure;
static internal class Constants
{
    public static string BookstoreDatabase = "BookstoreDatabase";
    public static string ContentRootPlaceholder = "%CONTENTROOTPATH%";
    public static string ContentRootPath = Directory.GetCurrentDirectory();
}


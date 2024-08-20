using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; 

namespace DrivingSchool_DataAccessLayer
{
    public static class clsConnectionStr
    {
        public static string ConnectionStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}

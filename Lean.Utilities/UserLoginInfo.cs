using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.Utilities
{
    public partial class UserLoginInfo
    {
        public string UserID { get; set; }
        public string Lean_App { get; set; }
     //   public string Domain { get; set; }  //syelamanchali--commented for oAuth Autentication
        public string Display_Name { get; set; }
        public string LoginType { get; set; }
    }
}

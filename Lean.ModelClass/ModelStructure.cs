using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lean.ModelClass
{
    public partial class Line
    {
        public int idLine { get; set; }
        public string Line1 { get; set; }
        public int Capability { get; set; }
        public string Planner { get; set; }
        public string Lean_Application { get; set; }
    }
    public partial class LeanApp
    {
        public string Lean_Application { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public int id_site { get; set; }
        public string Description { get; set; }
        public string Acronym { get; set; }
    }
}

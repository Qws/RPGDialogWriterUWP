using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class InteractableObject
    {
        public InteractableObject()
        {
            this.Branches = new List<Branch>();
        }
        public string Name
        {
            get;
            set;
        }
        public List<Branch> Branches { get; set; }
    }
}   

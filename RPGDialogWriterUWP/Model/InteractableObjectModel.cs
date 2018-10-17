using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class InteractableObjectModel
    {
        public InteractableObjectModel()
        {
            this.Branches = new List<BranchModel>();
        }
        public string Name
        {
            get;
            set;
        }
        public List<BranchModel> Branches { get; set; }
    }
}   

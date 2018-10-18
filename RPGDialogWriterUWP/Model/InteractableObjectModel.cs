using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace RPGDialogWriterUWP.Model
{
    class InteractableObjectModel
    {
        public InteractableObjectModel()
        {
            this.Branches = new ObservableCollection<BranchModel>();
        }
        public string Name
        {
            get;
            set;
        }
        public ObservableCollection<BranchModel> Branches { get; set; }
    }
}   

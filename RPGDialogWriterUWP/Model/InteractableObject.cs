using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace RPGDialogWriterUWP.Model
{
    class InteractableObject
    {
        public InteractableObject()
        {
            this.Branches = new ObservableCollection<Branch>();
        }
        public string Name
        {
            get;
            set;
        }
        public ObservableCollection<Branch> Branches { get; set; }
    }
}   

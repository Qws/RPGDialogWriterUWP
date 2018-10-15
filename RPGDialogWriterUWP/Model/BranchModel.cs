using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class BranchModel
    {
        public string Name { get; set; }
        public List<MessageModel> Messages { get; set; }
    }
}

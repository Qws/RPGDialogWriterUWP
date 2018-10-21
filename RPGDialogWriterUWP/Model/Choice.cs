using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class Choice
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
        public string Function { get; set; }
        public string Branch { get; set; }
    }
}

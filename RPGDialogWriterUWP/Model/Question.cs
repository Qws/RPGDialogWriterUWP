using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class Question : Message
    {
        public string Question { get; set; }
        public List<Choice> Choices { get; set; }
    }
}

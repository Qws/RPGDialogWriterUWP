using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class Question : Message
    {
        public string Text { get; set; }
        public List<Choice> Choices { get; set; }
    }
}

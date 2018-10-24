using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class Question : Message
    {
        public List<Choice> Choices { get; set; }
    }
}

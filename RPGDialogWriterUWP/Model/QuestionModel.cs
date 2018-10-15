using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class QuestionModel : MessageModel
    {
        public string Question { get; set; }
        public List<ChoiceModel> Choices { get; set; }
    }
}

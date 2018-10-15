using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.Model
{
    class StoryChapterModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public List<InteractableObjectModel> InteractableObjects { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }
    }
}

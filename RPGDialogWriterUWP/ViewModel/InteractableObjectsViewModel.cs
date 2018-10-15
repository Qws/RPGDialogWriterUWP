using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

namespace RPGDialogWriterUWP.ViewModel
{
    class InteractableObjectsViewModel
    {
        private Model.StoryChapterModel storyChapterModel;
        private Model.MapModel mapModel;
        private List<Model.InteractableObjectModel> interactableObjectModels = new List<Model.InteractableObjectModel>();

        public InteractableObjectsViewModel()
        {
            
        }

        private void FillDataWithJSON()
        {
            StorageFile file;
        }
    }
}

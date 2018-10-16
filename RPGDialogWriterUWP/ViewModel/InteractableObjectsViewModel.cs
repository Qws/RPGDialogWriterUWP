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
        private Model.StoryModel storyChapterModel;
        private Model.MapModel mapModel;
        private List<Model.InteractableObjectModel> interactableObjectModels = new List<Model.InteractableObjectModel>();

        public delegate void DelegateInteractableObject();
        public DelegateInteractableObject InteractableObjectCommand;

        public InteractableObjectsViewModel()
        {
            
        }
        
        public void GoToInteractObjectPage()
        {

        }

        private void FillDataWithJSON()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Storage;

namespace RPGDialogWriterUWP.ViewModel
{
    class InteractableObjectsViewModel : BaseViewModel
    {
        private ObservableCollection<Model.Branch> branches;
        public ObservableCollection<Model.Branch> Branches
        {
            get { return this.branches; }
            set
            {
                this.branches = value;
                this.OnPropertyChanged("branches");
            }
        }

        private Model.InteractableObject selectedInteractableObject;
        public Model.InteractableObject SelectedInteractableObject
        {
            get {return selectedInteractableObject; }
            set
            {
                if (this.selectedInteractableObject != null)
                {

                    if (this.selectedInteractableObject.Branches != null)
                    {
                        if (this.selectedInteractableObject.Branches.Count > 0)
                        {
                            this.branches = new ObservableCollection<Model.Branch>();
                            foreach (var branch in this.selectedInteractableObject.Branches)
                            {
                                this.Branches.Add(branch);
                            }
                        }
                    }

                    this.selectedInteractableObject = value;
                    this.OnPropertyChanged("selectedInteractableObjects");
                }
                else
                {
                    this.selectedInteractableObject = value;
                    this.OnPropertyChanged("selectedInteractableObjects");
                }
            }
        }

        private ObservableCollection<Model.InteractableObject> interactableObjects;
        public ObservableCollection<Model.InteractableObject> InteractableObjects
        {
            get { return this.interactableObjects; }
            set
            {
                this.interactableObjects = value;
                this.OnPropertyChanged("interactableObjects");
            }
        }

        private string mapStoryTitle;
        public string MapStoryTitle
        {
            get { return this.mapStoryTitle; }
            set
            {
                this.mapStoryTitle = value;
                this.OnPropertyChanged("mapStoryTitle");
            }
        }

        private string description;
        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                this.OnPropertyChanged();
            }
        }

        public InteractableObjectsViewModel()
        {
            
        }

        public InteractableObjectsViewModel(Model.MapStory pSelectedMapStory)
        {
            InteractableObjects = new ObservableCollection<Model.InteractableObject>();
            Branches = new ObservableCollection<Model.Branch>();
            if(selectedInteractableObject == null)
            {
                this.selectedInteractableObject = new Model.InteractableObject();
                SelectedInteractableObject = new Model.InteractableObject();
            }

            this.SelectedMapStory = pSelectedMapStory;
            foreach (var obj in pSelectedMapStory.Story.InteractableObjects)
            {
                this.InteractableObjects.Add(obj);
            }
            this.MapStoryTitle = pSelectedMapStory.Story.Title;
            this.description = pSelectedMapStory.Story.Description;
        }
    }
}

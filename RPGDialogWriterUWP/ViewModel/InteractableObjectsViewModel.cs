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
        private string newIOName;
        public string NewIOName
        {
            get
            {
                return this.newIOName;
            }
            set
            {
                this.newIOName = value;
                this.OnPropertyChanged();
            }
        }

        public void AddInteractableObject()
        {
            Model.InteractableObject newIO = new Model.InteractableObject();
            newIO.Name = NewIOName;
            InteractableObjects.Add(newIO);
        }

        private Model.Branch selectedBranch;
        public Model.Branch SelectedBranch
        {
            get { return this.selectedBranch; }
            set
            {
                this.selectedBranch = value;
                this.OnPropertyChanged("SelectedBranch");
            }
        }

        private ObservableCollection<Model.Branch> branches;
        public ObservableCollection<Model.Branch> Branches
        {
            get { return this.branches; }
            set
            {
                this.branches = value;
                this.OnPropertyChanged();
            }
        }

        private Model.InteractableObject selectedInteractableObject;
        public Model.InteractableObject SelectedInteractableObject
        {
            get
            {
                if(this.selectedInteractableObject == null)
                {
                    return new Model.InteractableObject();
                }
                return selectedInteractableObject;
            }
            set
            {
                if (value != null)
                {
                    this.selectedInteractableObject = value;
                    this.OnPropertyChanged("SelectedInteractableObjects");

                    if (Branches == null)
                    {
                        Branches = new ObservableCollection<Model.Branch>();
                    }

                    if (this.selectedInteractableObject.Branches != null)
                    {
                        if (this.selectedInteractableObject.Branches.Count > 0)
                        {
                            
                            //Clearing the Branches so it won't stack each time the selected Interactable Object changes..
                            this.Branches.Clear();
                            foreach (var branch in this.selectedInteractableObject.Branches)
                            {
                                this.Branches.Add(branch);
                            }
                        }
                        else
                        {
                            //There is no branches, so it will be cleared.
                            this.Branches.Clear();
                        }
                    }
                    
                    else
                    {
                        this.selectedInteractableObject.Branches = new List<Model.Branch>();
                    }
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
                this.OnPropertyChanged("InteractableObjects");
            }
        }

        private string mapStoryTitle;
        public string MapStoryTitle
        {
            get { return this.mapStoryTitle; }
            set
            {
                this.mapStoryTitle = value;
                this.OnPropertyChanged("MapStoryTitle");
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
            //Branches = new ObservableCollection<Model.Branch>();

            this.SelectedMapStory = pSelectedMapStory;
            foreach (var obj in pSelectedMapStory.Story.InteractableObjects)
            {
                this.InteractableObjects.Add(obj);
            }
            this.MapStoryTitle = pSelectedMapStory.Story.Title;
            this.description = pSelectedMapStory.Story.Description;
            this.SelectedInteractableObject = this.interactableObjects[0];
        }
    }
}

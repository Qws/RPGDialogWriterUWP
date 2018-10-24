using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGDialogWriterUWP.ViewModel
{
    class BranchViewModel : ViewModel.BaseViewModel
    {
        private string title;
        public string Title
        {
            get
            {
                title = "Branch Editing: "+CurrentBranch.Name;
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private Model.Branch currentBranch;
        public Model.Branch CurrentBranch
        {
            get { return currentBranch; }
            set
            {
                currentBranch = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Model.Message> messageList;
        public ObservableCollection<Model.Message> MessageList
        {
            get
            {
                return this.messageList;
            }
            set
            {
                this.messageList = value;
                OnPropertyChanged();
            }
        }


        public BranchViewModel(Model.MapStory pMapStory, Model.Branch pBranch)
        {
            this.SelectedMapStory = pMapStory;
            this.CurrentBranch = pBranch;
            var message = new Model.Message();
            this.MessageList = new ObservableCollection<Model.Message>();

            if(CurrentBranch.Messages == null)
            {
                CurrentBranch.Messages = new List<Model.Message>();
            }

            foreach (var m in CurrentBranch.Messages)
            {
                if(m.GetType() == typeof(Model.Message))
                {
                    message = m as Model.Message;
                    MessageList.Add(message);
                }

                else if(m.GetType() == typeof(Model.Question))
                {
                    message = m as Model.Question;
                    MessageList.Add(message);
                }
                else
                {
                    var dialog = new Windows.UI.Popups.MessageDialog("Error, unsupported Message type is tried to be added into the MessageList.");
                }
            }
        }
    }
}

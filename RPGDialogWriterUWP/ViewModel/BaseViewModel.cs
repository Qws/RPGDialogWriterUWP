using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;



namespace RPGDialogWriterUWP.ViewModel
{
    class BaseViewModel : INotifyPropertyChanged
    {


            private Model.MapStory selectedMapStory;
            public BaseViewModel()
            {
                if (SelectedMapStory == null)
                {
                    SelectedMapStory = new Model.MapStory();
                }
            }
            public Model.MapStory SelectedMapStory
            {
                get
                {
                    if (this.selectedMapStory != null)
                    {
                        return this.selectedMapStory;
                    }
                    else
                    {
                        return new Model.MapStory();
                    }
                }
                set
                {
                    this.selectedMapStory = value;
                    this.OnPropertyChanged();
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            public void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                if (this.PropertyChanged != null)
                {

                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    
}

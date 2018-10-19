using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

using Windows.Data.Json;

namespace RPGDialogWriterUWP.ViewModel
{
    class MapStoryViewModel : INotifyPropertyChanged
    {
        public Model.MapStory MapStoryModel;

        public event PropertyChangedEventHandler PropertyChanged;

        public MapStoryViewModel()
        {
            MapStoryModel = new Model.MapStory();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

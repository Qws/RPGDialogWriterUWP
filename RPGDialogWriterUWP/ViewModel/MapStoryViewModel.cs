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
        public Model.StoryChapterModel StoryChapterModel { get; set; }
        public string Author { get; set; }

        private Model.MapModel mapModel;
        private Model.StoryChapterModel storyChapterModel;
        private string author;
        private DateTime datetime;

        public event PropertyChangedEventHandler PropertyChanged;

        public MapStoryViewModel()
        {
            
        }

        private async void CreateMapStoryJson()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync(mapModel.Name + "_" + storyChapterModel.Title + ".json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
 
        }

        private async Task CreateJSONFileAsync()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile sampleFile = await storageFolder.CreateFileAsync( mapModel.Name + "_" +storyChapterModel.Title + ".json", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            
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

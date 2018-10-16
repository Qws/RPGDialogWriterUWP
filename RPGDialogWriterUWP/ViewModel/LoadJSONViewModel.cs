using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Windows.Data.Json;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace RPGDialogWriterUWP.ViewModel
{
    class LoadJSONViewModel
    {
        public string Title { get; set; }
        public string ErrorMessage { get; set; }
        public Model.MapStoryModel MapStory { get; set; }

        public delegate void ChangeWindowDelegate(Model.MapStoryModel mapStoryModel);
        public ChangeWindowDelegate changeWindowDelegate;


        public LoadJSONViewModel()
        {
            MapStory = new Model.MapStoryModel();
        }

        public async void StartFilePicker()
        {
            var picker = new Windows.Storage.Pickers.FileOpenPicker();
            picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
            picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            picker.FileTypeFilter.Add(".json");

            Windows.Storage.StorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {                
                if(file.FileType == ".json")
                {
                    
                    this.MapStory = await JSONtoModels(file);
                    ErrorMessage = this.MapStory.StoryModel.Title;
                    //changeWindowDelegate(this.MapStory);
                }
                else
                {
                    ErrorMessage = "file format is not supported. The editor reads .JSON files only.";
                }
            }
            else
            {
                ErrorMessage = "Error, no file is found.";
                //this.textBlock.Text = "Operation cancelled.";
            }
        }

        private async Task<Model.MapStoryModel> JSONtoModels(Windows.Storage.StorageFile file)
        {
            IRandomAccessStreamWithContentType data = await file.OpenReadAsync();
            //var dialog = new MessageDialog(data);
            //await dialog.ShowAsync();
            string  textdata = data.ToString();

            StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            //file.Path
            //Windows.Storage.StorageFile sampleFile =
            //await storageFolder.GetFileAsync("sample.txt");
            var dialog = new MessageDialog(textdata);
            await dialog.ShowAsync();

            JsonObject jsonObj = new JsonObject();
            jsonObj = JsonObject.Parse(textdata);
            MapStory.StoryModel.Title = jsonObj.GetNamedString("Title");
            return MapStory;
        }
    }
}

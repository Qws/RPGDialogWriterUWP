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

            StorageFile file;
            file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                if (file.FileType == ".json")
                {
                    if (MapStory != null)
                    {

                        this.MapStory.StoryModel = new Model.StoryModel();
                        this.MapStory.MapModel = new Model.MapModel();
                        this.MapStory = await JSONtoModels(file);
                        ErrorMessage = this.MapStory.StoryModel.Title;
                    }

                    else
                    {
                        ErrorMessage = "MapStory is null... tell it to the devs of the software";
                    }
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
            var dialog = new MessageDialog("");
            if (file == null)
            {
                dialog = new MessageDialog("Error, file is null!");
                await dialog.ShowAsync();
            }

            if (MapStory != null)
            {
                this.MapStory.StoryModel.Title = "LOL";
                return this.MapStory;
            }
            else
            {
                dialog = new MessageDialog("Error, MapStory is null!");
                await dialog.ShowAsync();
                MapStory = new Model.MapStoryModel();
                return MapStory;
            }
        }
    }
}

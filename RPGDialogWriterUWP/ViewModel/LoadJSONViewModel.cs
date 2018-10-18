﻿using System;
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
            if (file != null)
            {
                string data = await Windows.Storage.FileIO.ReadTextAsync(file);
                JsonObject jsonObj = new JsonObject();
                jsonObj = JsonObject.Parse(data);

                MapStory.StoryModel.Title = jsonObj.GetNamedString("title");
                MapStory.StoryModel.Description = jsonObj.GetNamedString("description");
                MapStory.StoryModel.Author = jsonObj.GetNamedString("author");

                //JsonObject, to access Json Api for Interactable Object.
                JsonObject interactableObjects = new JsonObject();

                //Model, which will be put into the MapStory Model.
                Model.InteractableObjectModel interactableObjectModel = new Model.InteractableObjectModel();
                interactableObjects = jsonObj.GetNamedObject("interactableobjects");
                //Multiple Interactable Objects usually. Has to dismantle and save them all into objects of the major Model: MapStory Model.
                foreach (var obj in interactableObjects)
                {
                    //Interactable Object (characters, enemies, bosses, friends, talking chair, etc)
                    interactableObjectModel.Name = obj.Key;
                    JsonObject jsonInteracatbleObject = new JsonObject();
                    jsonInteracatbleObject = JsonObject.Parse(obj.Value.ToString());
                    // Each interactable Objects has multiple branches, options, states, feelings etc...
                    foreach(var branch in jsonInteracatbleObject)
                    {
                        //Branch has a name.
                        Model.BranchModel branchModel = new Model.BranchModel();
                        branchModel.Name = branch.Key;
                        JsonObject jsonObjBranch = new JsonObject();
                        jsonObjBranch = JsonObject.Parse(branch.Value.ToString());



                        //BranchModel added into the InteractableObjectModel. This process will repeatedly for the other branches.
                        interactableObjectModel.Branches.Add(branchModel);
                        //var dialogJson is not really a true JsonObject, it has only 2 properties (Key and Value).
                        //Those values have to be converted to Strings from a so called: "KeyValuePair".
                        foreach (var dialogJson in jsonObjBranch)
                        {
                            JsonObject dialogJsonObject = JsonObject.Parse(dialogJson.Value.ToString());

                            if(dialogJsonObject.ContainsKey("question"))
                            {
                                Model.QuestionModel questionModel = new Model.QuestionModel();
                                questionModel.Name = dialogJsonObject.GetNamedValue("name").ToString();
                                questionModel.Question = dialogJsonObject.GetNamedValue("question").ToString();
                                if(dialogJsonObject.ContainsKey("emote"))
                                {
                                    questionModel.Emote = dialogJsonObject.GetNamedValue("emote").ToString();
                                }
                                JsonObject jsonObjChoices = new JsonObject();

                                if (JsonObject.TryParse(dialogJsonObject.GetNamedValue("choices").ToString(), out jsonObjChoices))
                                {
                                    foreach (var choiceJson in jsonObjChoices)
                                    {
                                        JsonObject jsonObjectChoice = JsonObject.Parse(choiceJson.Value.ToString());
                                        Model.ChoiceModel choiceModel = new Model.ChoiceModel();
                                        choiceModel.Name = jsonObjectChoice.GetNamedValue("name").ToString();

                                        //Recommend to have this... if it's empty, make a notification in the GUI.
                                        if(jsonObjChoices.ContainsKey("description"))
                                        {

                                            choiceModel.Description = jsonObjectChoice.GetNamedValue("description").ToString();
                                        }
                                        //Target is optional.
                                        if (jsonObjectChoice.ContainsKey("target"))
                                        {
                                            choiceModel.Target = jsonObjectChoice.GetNamedValue("target").ToString();
                                        }
                                        //Branch is optional... what's the real difference tho?
                                        if (jsonObjectChoice.ContainsKey("branch"))
                                        {
                                            choiceModel.Branch = jsonObjectChoice.GetNamedValue("branch").ToString();
                                        }
                                    }
                                }
                                else
                                {
                                    MessageDialog msgbox = new MessageDialog("Error! There should be Choices jsonObject in the question JsonObject.");
                                    await msgbox.ShowAsync();
                                }
                            }

                            if (int.TryParse(dialogJson.Key, out int dialognumber))
                            {
                                
                            }

                            else
                            {

                            }

                        }
                        //has chain of messages that the player has to go through.
                        //continue here ->
                        //extra info: go through another foreach. This time for the real dialogs.
                    }
                }
            }

            

            else
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

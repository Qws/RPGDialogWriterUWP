﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RPGDialogWriterUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InteractableObjectsMenu : Page
    {
        ViewModel.MapStoryViewModel MapStoryViewModel;
        Model.Story storyModel = new Model.Story();

        public InteractableObjectsMenu()
        {
            MapStoryViewModel = new ViewModel.MapStoryViewModel();
            //InteractableObjectsViewModel = new ViewModel.InteractableObjectsViewModel();
            //InteractableObjectsViewModel.InteractableObjectCommand = () => 
            //{
            //    var param =  ListViewInteractableObjects.SelectedItem as Model.InteractableObjectModel;
            //    Frame.Navigate(typeof(View.InteractableObjectViewer));
            //};
            this.InitializeComponent();
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if(e.Parameter is Model.MapStory)
            {
                Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("Ye! It's a StoryModel!");
                await messageDialog.ShowAsync();
                this.storyModel = e.Parameter as Model.Story;
            }

            else

            {
                Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("Nope... wrong parameters is passed to the navigation?");
                await messageDialog.ShowAsync();
                
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}

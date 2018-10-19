using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RPGDialogWriterUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ViewModel.LoadJSONViewModel jSONViewModel;


        

        public MainPage()
        {
            jSONViewModel = new ViewModel.LoadJSONViewModel();
            this.InitializeComponent();
        }

        private void btnNewStoryMapChapter_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.NewMapStoryView));
        }

        private async void btnLoadNewMapStoryAsync_Click(object sender, RoutedEventArgs e)
        {
            Model.MapStory mapStory = await jSONViewModel.StartFilePicker();
            Frame.Navigate(typeof(View.InteractableObjectsMenu), mapStory);
        }
    }
}

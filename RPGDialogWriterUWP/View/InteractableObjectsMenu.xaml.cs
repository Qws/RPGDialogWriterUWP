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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RPGDialogWriterUWP.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class InteractableObjectsMenu : Page
    {
        ViewModel.InteractableObjectsViewModel ioVM;

        public InteractableObjectsMenu()
        {
            if(ioVM == null)
            {
                ioVM = new ViewModel.InteractableObjectsViewModel();
                ioVM.InteractableObjects = new System.Collections.ObjectModel.ObservableCollection<Model.InteractableObject>();
                ioVM.SelectedInteractableObject = new Model.InteractableObject();
            }
            //ioVM = new ViewModel.InteractableObjectsViewModel();
            
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
                ioVM = new ViewModel.InteractableObjectsViewModel(e.Parameter as Model.MapStory);
                var objWtfiSThis = GridViewInteractableObject.SelectedItem;

            }

            else

            {
                Windows.UI.Popups.MessageDialog messageDialog = new Windows.UI.Popups.MessageDialog("Nope... wrong parameters is passed to the navigation?");
                await messageDialog.ShowAsync();
                
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void ListViewInteractableObjects_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.ioVM.SelectedInteractableObject = (sender as ListView).SelectedItem as Model.InteractableObject;
        }

        private void BtnSelectInteractableObject_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = sender as Button;
            ioVM.SelectedInteractableObject = btnSender.DataContext as Model.InteractableObject;
            this.GridViewInteractableObject.SelectedItem = btnSender.DataContext;

        }

        private void BtnSelectedBranch_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = sender as Button;
            ioVM.SelectedBranch = btnSender.DataContext as Model.Branch;
            this.GridViewInteractableObject.SelectedItem = btnSender.DataContext;
        }


        private void BtnToggleAddIOGUI_Click(object sender, RoutedEventArgs e)
        {
            if (StackPanelNewIOGUI.Visibility == Visibility.Collapsed)
            {
                this.StackPanelNewIOGUI.Visibility= Visibility.Visible;
            }
            else
            {
                this.StackPanelNewIOGUI.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnRemoveIO_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem btnsender = sender as MenuFlyoutItem;
            Model.InteractableObject ioremoving = btnsender.DataContext as Model.InteractableObject;
            ioVM.RemoveInteractableObject(ioremoving);
        }
        

        private void BtnSelectInteractableObject_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            if (element != null)
            {
                FlyoutBase.ShowAttachedFlyout(element);
            }
        }
    }
}

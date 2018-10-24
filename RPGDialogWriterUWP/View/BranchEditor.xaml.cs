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
    public sealed partial class BranchEditor : Page
    {
        ViewModel.BranchViewModel BVM;
        public BranchEditor()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            Model.MapStory mapStory = new Model.MapStory();
            Model.Branch branch = new Model.Branch();
            base.OnNavigatedTo(e);

            if(e.Parameter.GetType() == typeof(object[]))
            {
                object[] parameter = e.Parameter as object[];
                mapStory = parameter[0] as Model.MapStory;
                branch = parameter[1] as Model.Branch;
                
            }

            BVM = new ViewModel.BranchViewModel(mapStory, branch);
        }
    }
}

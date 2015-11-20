using Windows.UI.Core;
using Windows.UI.Xaml.Navigation;
using MediaPlayerFramework_LiveTree.Windows10.ViewModel;

namespace MediaPlayerFramework_LiveTree.Windows10
{
    public sealed partial class MainPage
    {
        public MainViewModel Vm => (MainViewModel)DataContext;

        public MainPage()
        {
            InitializeComponent();

            Loaded += (s, e) =>
            {
                //When player is ending show the Control
                player.MediaEnded += Player_MediaEnded;
            };
        }

        private void Player_MediaEnded(object sender, Microsoft.PlayerFramework.MediaPlayerActionEventArgs e)
        {
            Vm.IsRateMyVideoVisible = true;
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }
    }
}

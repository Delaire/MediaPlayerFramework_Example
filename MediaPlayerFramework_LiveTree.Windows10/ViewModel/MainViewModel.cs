using System;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Threading;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MediaPlayerFramework_LiveTree.Windows10.Model;

namespace MediaPlayerFramework_LiveTree.Windows10.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public const string ClockPropertyName = "Clock";
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private string _clock = "Starting...";
        private int _counter;
        private RelayCommand _incrementCommand;
        private RelayCommand<string> _navigateCommand;
        private string _originalTitle;
        private bool _runClock;
        private RelayCommand _sendMessageCommand;
        private RelayCommand _showDialogCommand;
        private string _welcomeTitle = string.Empty;

        public string Clock
        {
            get
            {
                return _clock;
            }
            set
            {
                Set(ClockPropertyName, ref _clock, value);
            }
        }

        public RelayCommand IncrementCommand
        {
            get
            {
                return _incrementCommand
                    ?? (_incrementCommand = new RelayCommand(
                    () =>
                    {
                        WelcomeTitle = string.Format("Counter clicked {0} times", ++_counter);
                    }));
            }
        }

        public RelayCommand<string> NavigateCommand
        {
            get
            {
                return _navigateCommand
                       ?? (_navigateCommand = new RelayCommand<string>(
                           p => _navigationService.NavigateTo(ViewModelLocator.SecondPageKey, p),
                           p => !string.IsNullOrEmpty(p)));
            }
        }

        public RelayCommand SendMessageCommand
        {
            get
            {
                return _sendMessageCommand
                    ?? (_sendMessageCommand = new RelayCommand(
                    () =>
                    {
                        Messenger.Default.Send(
                            new NotificationMessageAction<string>(
                                "Testing",
                                reply =>
                                {
                                    WelcomeTitle = reply;
                                }));
                    }));
            }
        }

        public RelayCommand ShowDialogCommand
        {
            get
            {
                return _showDialogCommand
                       ?? (_showDialogCommand = new RelayCommand(
                           async () =>
                           {
                               var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                               await dialog.ShowMessage("Hello Universal Application", "it works...");
                           }));
            }
        }

        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }

            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        public MainViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            Initialize();
        }

        private async Task Initialize()
        {
            try
            {
                var item = await _dataService.GetData();
                _originalTitle = item.Title;
                WelcomeTitle = item.Title;
            }
            catch (Exception ex)
            {
                // Report error here
                WelcomeTitle = ex.Message;
            }
        }

        private bool _isRateMyVideoVisible = false;
        public bool IsRateMyVideoVisible
        {
            get
            {
                return _isRateMyVideoVisible;
            }
            set
            {
                Set(ref _isRateMyVideoVisible, value);
            }
        }

        public RelayCommand UpVoteCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    await dialog.ShowMessage("Custom Player", "Up Voted.");

                    //TODO: add more logic here
                });
            }
        }

        public RelayCommand NeutralVoteCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    await dialog.ShowMessage("Custom Player", "Neutral Voted.");

                    //TODO: add more logic here
                });
            }
        }

        public RelayCommand DownVoteCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    await dialog.ShowMessage("Custom Player", "Down Voted.");

                    //TODO: add more logic here
                });
            }
        }

    }
}
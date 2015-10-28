using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace MediaPlayerFramework_Custom.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private bool _isCustomControlVisible = false;
        public bool IsCustomControlVisible
        {
            get { return _isCustomControlVisible; }
            set { Set(() => IsCustomControlVisible, ref _isCustomControlVisible, value); }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
           
        }


        public RelayCommand ShowElementCommand
        {
            get
            {
                return new RelayCommand(ShowElements);
            }
        }

        private void ShowElements()
        {
            IsCustomControlVisible = true;
        }


        public RelayCommand HideElementCommand
        {
            get
            {
                return new RelayCommand(HideElements);
            }
        }  

        private void HideElements()
        {
            IsCustomControlVisible = false;
        }

        public ICommand CustomElementCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    //do something here
                });
            }
        }
    }
}
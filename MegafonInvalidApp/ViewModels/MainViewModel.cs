using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using MegafonInvalidApp.ViewModels.Resolver;
using MegafonInvalidApp.NavigationHelper;
using MegafonInvalidApp.ViewModels.Helper;

namespace MegafonInvalidApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Constants

        public static readonly string ChooseVM = "Choose";
        public static readonly string AutorizationVM = "Autorization";
        public static readonly string StartVM = "Start";
        public static readonly string RegistrationVM = "Registrastion";
        public static readonly string Registration2VM = "Registrastion2";
        public static readonly string Registration3VM = "Registrastion3";

        #endregion

        #region Fields

        private readonly IViewModelsResolver _resolver;
        private ICommand _goToPathCommand;
        private ICommand _goToChooseCommand;
        private ICommand _goToAuthCommand;
        private ICommand _goToStartCommand;
        private ICommand _goToRegistrationCommand;
        private ICommand _goToRegistration2Command;
        private ICommand _goToRegistration3Command;


        private readonly INotifyPropertyChanged _chooseViewModel;
        private readonly INotifyPropertyChanged _authViewModel;
        private readonly INotifyPropertyChanged _startViewModel;
        private readonly INotifyPropertyChanged _registrationViewModel;
        private readonly INotifyPropertyChanged _registration2ViewModel;
        private readonly INotifyPropertyChanged _registration3ViewModel;

        #endregion


        #region Properties


        public ICommand GoToPathCommand
        {
            get { return _goToPathCommand; }
            set
            {
                _goToPathCommand = value;
                RaisePropertyChanged("GoToPathCommand");
            }
        }
     
        public ICommand GoToChooseCommand
        {
            get
            {
                return _goToChooseCommand;
            }
            set
            {
                _goToChooseCommand = value;
                RaisePropertyChanged(nameof(GoToChooseCommand));
            }
        }
        
        public ICommand GoToAuthCommand
        {
            get { return _goToAuthCommand; }
            set
            {
                _goToAuthCommand = value;
                RaisePropertyChanged(nameof(GoToAuthCommand));
            }
        }

        public ICommand GoToStartCommand
        {
            get { return _goToStartCommand; }
            set
            {
                _goToStartCommand = value;
                RaisePropertyChanged(nameof(GoToStartCommand));
            }
        }

        public ICommand GoToRegistrationCommand
        {
            get { return _goToRegistrationCommand; }
            set
            {
                _goToRegistrationCommand = value;
                RaisePropertyChanged(nameof(GoToRegistrationCommand));
            }
        }

        public ICommand GoToRegistration2Command
        {
            get { return _goToRegistration2Command; }
            set
            {
                _goToRegistration2Command = value;
                RaisePropertyChanged(nameof(GoToRegistration2Command));
            }
        }

        public ICommand GoToRegistration3Command
        {
            get { return _goToRegistration3Command; }
            set
            {
                _goToRegistration3Command = value;
                RaisePropertyChanged(nameof(GoToRegistration3Command));
            }
        }


        public INotifyPropertyChanged ChooseViewModel
        {
            get { return _chooseViewModel; }
        }

        public INotifyPropertyChanged AuthViewModel
        {
            get { return _authViewModel; }
        }

        public INotifyPropertyChanged StartViewModel
        {
            get { return _startViewModel; }
        }

        public INotifyPropertyChanged RegistrationViewModel
        {
            get { return _registrationViewModel; }
        }

        public INotifyPropertyChanged Registration2ViewModel
        {
            get { return _registration2ViewModel; }
        }

        public INotifyPropertyChanged Registration3ViewModel
        {
            get { return _registration3ViewModel; }
        }



        #endregion


        #region Constructors

        public MainViewModel(IViewModelsResolver resolver)
        {
            _resolver = resolver;
            _chooseViewModel = _resolver.GetViewModelInstance(ChooseVM);
            _authViewModel = _resolver.GetViewModelInstance(AutorizationVM);
            _startViewModel = _resolver.GetViewModelInstance(StartVM);
            _registrationViewModel = _resolver.GetViewModelInstance(RegistrationVM);
            _registration2ViewModel = _resolver.GetViewModelInstance(Registration2VM);
            _registration3ViewModel = _resolver.GetViewModelInstance(Registration3VM);

            InitializeCommands();
        }

        #endregion



        private void InitializeCommands()
        {
            
            GoToPathCommand = new RelayCommand<string>(GoToPathCommandExecute);

            GoToAuthCommand = new RelayCommand<INotifyPropertyChanged>(GoToAuthCommandExecute);

            GoToChooseCommand = new RelayCommand<INotifyPropertyChanged>(GoToChooseCommandExecute);

            GoToStartCommand = new RelayCommand<INotifyPropertyChanged>(GoToStartCommandExecute);
            
            GoToRegistrationCommand = new RelayCommand<INotifyPropertyChanged>(GoToRegistrationCommandExecute);

            GoToRegistration2Command = new RelayCommand<INotifyPropertyChanged>(GoToRegistration2CommandExecute);

            GoToRegistration3Command = new RelayCommand<INotifyPropertyChanged>(GoToRegistration3CommandExecute);
        }

        private void GoToPathCommandExecute(string alias)
        {
            if (string.IsNullOrWhiteSpace(alias))
            {
                return;
            }
            
            Navigator.Navigate(alias);
        }

        private void GoToAuthCommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigator.Navigate(Navigator.AutorizationName, AuthViewModel);
        }

        private void GoToChooseCommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigator.Navigate(Navigator.ChooseName, ChooseViewModel);
        }

        private void GoToStartCommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigator.Navigate(Navigator.RegistrationName, StartViewModel);
        }
        private void GoToRegistrationCommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigator.Navigate(Navigator.RegistrationName, RegistrationViewModel);
        }
        private void GoToRegistration2CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigator.Navigate(Navigator.RegistrationName, Registration2ViewModel);
        }
        private void GoToRegistration3CommandExecute(INotifyPropertyChanged viewModel)
        {
            Navigator.Navigate(Navigator.RegistrationName, Registration3ViewModel);
        }
    }
}

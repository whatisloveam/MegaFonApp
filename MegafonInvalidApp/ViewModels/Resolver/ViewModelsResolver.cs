using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MegafonInvalidApp.ViewModels.Resolver
{
    public class ViewModelsResolver : IViewModelsResolver
    {

        private readonly Dictionary<string, Func<INotifyPropertyChanged>> _vmResolvers = new Dictionary<string, Func<INotifyPropertyChanged>>();

        public ViewModelsResolver()
        {
            _vmResolvers.Add(MainViewModel.AutorizationVM, () => new AuthViewModel());
            _vmResolvers.Add(MainViewModel.StartVM, () => new StartViewModel());
            _vmResolvers.Add(MainViewModel.ChooseVM, () => new ChooseViewModel());
            _vmResolvers.Add(MainViewModel.RegistrationVM, () => new RegistrationViewModel());
            _vmResolvers.Add(MainViewModel.Registration2VM, () => new Registration2ViewModel());
            _vmResolvers.Add(MainViewModel.Registration3VM, () => new Registration3ViewModel());
        }

        public INotifyPropertyChanged GetViewModelInstance(string alias)
        {
            if (_vmResolvers.ContainsKey(alias))
            {
                return _vmResolvers[alias]();
            }

            return _vmResolvers[MainViewModel.AutorizationVM]();
        }
    }
}

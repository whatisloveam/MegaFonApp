using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace MegafonInvalidApp.NavigationHelper
{
    internal class PageResolver
    {
        private readonly Dictionary<string, Func<Page>> _pagesResolvers = new Dictionary<string, Func<Page>>();

        public PageResolver()
        {
            _pagesResolvers["default"] = () => new Page();
            _pagesResolvers[Navigator.AutorizationName] = () => new Autorization();
            _pagesResolvers[Navigator.StartName] = () => new StartTest();
            _pagesResolvers[Navigator.ChooseName] = () => new Choose();
        }

        public PageResolver(Dictionary<string, Func<Page>> pages)
            :base()
        {
            _pagesResolvers = pages;
        }

        public Page GetPageInstance(string alias)
        {
            if (_pagesResolvers.ContainsKey(alias))
            {
                return _pagesResolvers[alias]();
            }
            return _pagesResolvers["default"]();
        }
    }
}
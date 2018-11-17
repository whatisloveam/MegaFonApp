using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MegafonInvalidApp.NavigationHelper
{
    public class Navigator
    {
        public static readonly string ChooseName = "Choose";
        public static readonly string AutorizationName = "Autorization";
        public static readonly string StartName = "Start";
        public static readonly string RegistrationName = "Registrastion";
        public static readonly string Registration2Name = "Registrastion2";
        public static readonly string Registration3Name = "Registrastion3";


        private readonly PageResolver _resolver;

        private static volatile Navigator _instance;
        private static readonly object SyncRoot = new object();

        private Navigator()
        {
            _resolver = new PageResolver();
        }

        private static Navigator Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock(SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new Navigator();
                    }
                }
                return _instance;
            }
        }

        private NavigationService _navService;

        public static NavigationService Service
        {
            get => Instance._navService;
            set
            {
                if (Instance._navService != null)
                {
                    Instance._navService.Navigated -= Instance._navService_Navigated;
                }
                Instance._navService = value;

                Instance._navService.Navigated += Instance._navService_Navigated;
            }
        }

        public static void Navigate(Page page, object context)
        {

            if (Instance._navService == null || page == null)
            {
                return;
            }
            Instance._navService.Navigate(page, context);
        }

        public static void Navigate(Page page)
        {
            Navigate(page, null);
        }
        public static void Navigate(string uri, object context)
        {
            if (Instance._navService == null || uri == null)
            {
                return;
            }
            var page = Instance._resolver.GetPageInstance(uri);
            Navigate(page, context);

        }


        void _navService_Navigated(object sender, NavigationEventArgs e)
        {
            if (!(e.Content is Page page))
            {
                return;
            }
            page.DataContext = e.ExtraData;
        }

        public static void Navigate(string uri)
        {
            Navigate(uri, null);
        }
    }
}

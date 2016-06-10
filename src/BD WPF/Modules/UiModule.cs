using System.Windows.Navigation;
using BD_WPF.Pages;
using BD_WPF.ViewModel;
using GalaSoft.MvvmLight.Views;

using Ninject.Modules;

namespace BD_WPF.Modules
{
    public class UiModule : NinjectModule
    {
        public override void Load()
        {

            Kernel.Bind<MainViewModel>().ToSelf().InSingletonScope();

            Kernel.Bind<IDialogService>().To<DialogService>();
            Kernel.Bind<INavigationService>().ToConstant(CreateNavigationService());
        }

        private static NavigationService CreateNavigationService()
        {
            var navigationService = new NavigationService();
            navigationService.Configure("Main", typeof(MainWindow));

            return navigationService;
        }
    }
}
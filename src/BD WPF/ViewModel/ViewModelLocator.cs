/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:BD_WPF"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System.Diagnostics.CodeAnalysis;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace BD_WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public static Bootstrapper BootStrapper;

        static ViewModelLocator()
        {
            InitializeBootstraper();
        }

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        public MainViewModel Main
        {
            get { return BootStrapper.Kernel.Get<MainViewModel>(); }
        }

      
        public static void InitializeBootstraper()
        {
            if (BootStrapper != null) return;
            BootStrapper = new Bootstrapper();
            BootStrapper.Initialize();
        }
        //public ViewModelLocator()
        //{
        //    //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        //    //////if (ViewModelBase.IsInDesignModeStatic)
        //    //////{
        //    //////    // Create design time view services and models
        //    //////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
        //    //////}
        //    //////else
        //    //////{
        //    //////    // Create run time view services and models
        //    //////    SimpleIoc.Default.Register<IDataService, DataService>();
        //    //////}

        //    //SimpleIoc.Default.Register<MainViewModel>();
        //}

      
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
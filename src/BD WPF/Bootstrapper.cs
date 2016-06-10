using System;
using BD_WPF.Modules;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace BD_WPF
{
    public class Bootstrapper : IDisposable
    {
        public IKernel Kernel { get; set; }

        public void Dispose()
        {
            Kernel.Dispose();
        }

        public void Initialize()
        {
            Kernel = ConfigureAppKernel();
        }

        private IKernel ConfigureAppKernel()
        {
            var kernel = new StandardKernel();
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            if (ViewModelBase.IsInDesignModeStatic)
            {
                kernel.Load<UiModule>();
            }
            else
            {
                kernel.Load<UiModule>();
            }

            return kernel;
        }
    }
}
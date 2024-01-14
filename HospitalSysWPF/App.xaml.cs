using HospitalSysWPF.ViewModels;
using HospitalSysWPF.Views;
using Prism.Ioc;
using Prism.Services.Dialogs;
using System;
using System.Windows;

namespace HospitalSysWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            var dialog = Container.Resolve<IDialogService>();
            dialog.ShowDialog("LoginView", callback =>
            {
                if (callback.Result != ButtonResult.OK)
                {
                    //Application.Current.Shutdown();
                    Environment.Exit(0);
                    return;
                }
                //MessageBox.Show("登录成功！");
                base.OnInitialized();
            });
            
        }
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<LoginView, LoginViewModel>();
            containerRegistry.RegisterDialog<ListSettingsView, ListSettingsViewModel>();

            containerRegistry.RegisterForNavigation<SystemManagerView>();
            containerRegistry.RegisterForNavigation<DoctorsView>();
            containerRegistry.RegisterForNavigation<ManagerView>();
            containerRegistry.RegisterForNavigation<PriceView>();
            containerRegistry.RegisterForNavigation<HospitalManagerView>();
            containerRegistry.RegisterForNavigation<DrugStoreView>();
            containerRegistry.RegisterForNavigation<MedicineManagerView>();
            containerRegistry.RegisterForNavigation<FinanceManagerView>();
        }
    }
}

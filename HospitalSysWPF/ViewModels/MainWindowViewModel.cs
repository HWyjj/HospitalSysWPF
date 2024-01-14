using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace HospitalSysWPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "医疗信息管理系统";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand<string> NavigateCommand { get;private set; }

        private readonly IRegionManager regionManager;
        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string obj)
        {
            regionManager.Regions["MainContent"].RequestNavigate(obj);
        }
    }
}

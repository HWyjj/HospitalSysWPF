using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSysWPF.ViewModels
{
    public class SystemManagerViewModel : BindableBase
    {
        public DelegateCommand<string> ShowCommand { get;private set; }
        private readonly IDialogService dialogService;
        public SystemManagerViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            ShowCommand = new DelegateCommand<string>(Show);
        }

        private void Show(string obj)
        {
            dialogService.ShowDialog(obj);
        }
    }
}

﻿using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSysWPF.ViewModels
{
    public class ListSettingsViewModel : BindableBase, IDialogAware
    {
        public string Title { get; set; } = "挂号单设置";

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
        private string lSTitle;

        public string LSTitle
        {
            get { return lSTitle; }
            set { lSTitle = value; RaisePropertyChanged(); }
        }



        public ListSettingsViewModel()
        {
            LSTitle = "挂单号";
        }
    }
}

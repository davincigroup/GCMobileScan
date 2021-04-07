using App1.Models;
using App1.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        string _strengthFormRoute = string.Empty;
        public string strengthFormRoute
        {
            get { return _strengthFormRoute; }
            set { SetProperty(ref _strengthFormRoute, value);}
        }


        //manufacturer_name
        string _manufacturer_name = string.Empty;
        public string manufacturer_name
        {
            get { return _manufacturer_name; }
            set { SetProperty(ref _manufacturer_name, value); }
        }

        string _packageDesc = string.Empty;
        public string packageDesc
        {
            get { return _packageDesc; }
            set { SetProperty(ref _packageDesc, value); }
        }

        ProductInfo _NDC = new ProductInfo();
        public ProductInfo NDC
        {
            get { return _NDC; }
            set { SetProperty(ref _NDC, value); }
        }

        Packaging _p = new Packaging();
        public Packaging p
        {
            get { return _p; }
            set { SetProperty(ref _p, value); }
        }
        
        Openfda _FDA = new  Openfda();
        public Openfda FDA
        {
            get { return _FDA; }
            set { SetProperty(ref _FDA, value);
}
        }
        

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}

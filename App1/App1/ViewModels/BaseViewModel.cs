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
            set { SetProperty(ref _FDA, value); }
        }


        // verify
        VRSRequest _VRSRequest = new VRSRequest();
        public VRSRequest VRSRequest
        {
            get { return _VRSRequest; }
            set { SetProperty(ref _VRSRequest, value); }
        }


        VRSResponse _VRSResponse  = new VRSResponse();
        public VRSResponse VRSResponse
        {
            get { return _VRSResponse; }
            set { SetProperty(ref _VRSResponse, value); }
        }

        string _GTIN = string.Empty;
        public string GTIN
        {
            get { return _GTIN; }
            set { SetProperty(ref _GTIN, value); }
        }

        string _lot = string.Empty;
        public string lot
        {
            get { return _lot; }
            set { SetProperty(ref _lot, value); }
        }

        string _ser = string.Empty;
        public string ser
        {
            get { return _ser; }
            set { SetProperty(ref _ser, value); }
        }

        string _exp = string.Empty;
        public string exp
        {
            get { return _exp; }
            set { SetProperty(ref _exp, value); }
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

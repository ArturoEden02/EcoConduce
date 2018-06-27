
namespace ecoConduce.ViewModels
{
    using ecoConduce.Models;
    using ecoConduce.Services;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ScootersViewModel : BaseViewModel
    {
        #region services
        private ApiService apiService;
        private string latitud;
        private string longitud;
        #endregion
        #region attributes
        private ObservableCollection<Scooter> scooters;
        private bool isRefreshing;
        private string order;
        #endregion

        #region properties
        public ObservableCollection<Scooter> Scooters
        {
            get { return this.scooters; }
            set { SetValue(ref this.scooters, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { SetValue(ref this.isRefreshing, value); }
        }

        public string Order
        {
            get { return this.order; }
            set { SetValue(ref this.order, value); }
        }
        #endregion

        #region constructors
        public ScootersViewModel(string lt, string lg)
        {
            this.latitud = lt;
            this.longitud = lg;
            this.apiService = new ApiService();
            this.LoadScooters();
        }

        #endregion

        #region MyRegion

        private async void LoadScooters()
        {
            this.IsRefreshing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var response = await this.apiService.GetList<Scooter>("https://beta.econduce.mx",
                "/api",
                "/estaciones/get_nearest_map_features.json?latitude=" + latitud + "&longitude=" + longitud, "apikey", "a5fcd0fa781a793183dcb66c12978a47");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var list = (List<Scooter>)response.Result;
            this.Scooters = new ObservableCollection<Scooter>(list);
            this.Order = "Order by range";
            this.IsRefreshing = false;
        }


        private void OrderBy()
        {
            
        }

        #endregion

        #region commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadScooters);
            }
        }

        public ICommand OrderCommand
        {
            get
            {
                return new RelayCommand(OrderBy);
            }
        }

        #endregion
    }
}


namespace ecoConduce.ViewModels
{
    using ecoConduce.Models;
    using ecoConduce.Services;
    using GalaSoft.MvvmLight.Command;
    using System.Linq;
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
        private ObservableCollection<ScooterItemViewModel> scooters;
        private List<Scooter> scooterList;
        private bool isRefreshing;
        private string order;
        private List<Scooter> resp;
        #endregion

        #region properties
        public ObservableCollection<ScooterItemViewModel> Scooters
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

        public List<Scooter> Resp
        {
            get { return this.resp; }
            set { SetValue(ref this.resp, value); }
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
            if (!string.IsNullOrEmpty(this.Order) && this.Order != "See Parked Scooters")
            {
                this.scooterList = (List<Scooter>)response.Result;
                this.Resp = this.scooterList;
                var orderByP = from scoo in this.scooterList
                               orderby scoo.Properties.Distance ascending
                               orderby scoo.Properties.Range descending
                               where scoo.Type != "free_float"
                               select scoo;
                this.scooterList = orderByP.ToList();
                this.Scooters = new ObservableCollection<ScooterItemViewModel>(this.ToLanItemViewModel());
                this.Order = "See Free Float Scooters";
                this.IsRefreshing = false;
                return;
            }
            this.scooterList = (List<Scooter>)response.Result;
            this.Resp = this.scooterList;
            var orderBy = from scoo in this.scooterList
                          orderby scoo.Properties.Distance ascending
                          orderby scoo.Properties.Range descending
                          where scoo.Type == "free_float"
                          select scoo;
            this.scooterList = orderBy.ToList();
            this.Scooters = new ObservableCollection<ScooterItemViewModel>(this.ToLanItemViewModel());
            this.Order = "See Parked Scooters";
            this.IsRefreshing = false;
        }


        private void OrderBy()
        {
            this.IsRefreshing = true;
            if (this.Order == "See Parked Scooters")
            {
                this.scooterList = this.Resp;
                var orderByP = from scoo in this.scooterList
                               orderby scoo.Properties.Distance ascending
                               orderby scoo.Properties.Range descending
                               where scoo.Type != "free_float"
                               select scoo;
                this.scooterList = orderByP.ToList();
                this.Scooters = new ObservableCollection<ScooterItemViewModel>(this.ToLanItemViewModel());
                this.Order = "See Free Float Scooters";
                this.IsRefreshing = false;
                return;
            }
            this.scooterList = this.Resp;
            var orderBy = from scoo in this.scooterList
                          orderby scoo.Properties.Distance ascending
                          orderby scoo.Properties.Range descending
                          where scoo.Type == "free_float"
                          select scoo;
            this.scooterList = orderBy.ToList();
            this.Scooters = new ObservableCollection<ScooterItemViewModel>(this.ToLanItemViewModel());
            this.Order = "See Parked Scooters";
            this.IsRefreshing = false;
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

        #region Methods

        private IEnumerable<ScooterItemViewModel> ToLanItemViewModel()
        {
            return this.scooterList.Select(l => new ScooterItemViewModel
            {
                Type = l.Type,
                Properties = l.Properties,
                Geometry = l.Geometry,
            });
        }

        #endregion
    }
}
namespace ecoConduce.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using System.ComponentModel;
    using ecoConduce.Views;

    public class PrincipalViewModel : INotifyPropertyChanged
    {
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region attributes

        public string latitude { get; set; }
        private string longitude { get; set; }
        public bool isEnabled { get; set; }

        #endregion

        #region properties
        public string Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (this.latitude != value)
                {
                    this.latitude = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(Latitude)));
                }
            }
        }
        public string Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (this.longitude != value)
                {
                    this.longitude = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(Longitude)));
                }
            }
        }
        public bool IsEnabled
        {
            get
            {
                return this.isEnabled;
            }
            set
            {
                if (this.isEnabled != value)
                {
                    this.isEnabled = value;
                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(IsEnabled)));
                }
            }
        }
        #endregion

        #region constructors
        public PrincipalViewModel()
        {
            this.IsEnabled = true;
            this.Latitude = "19.3901384";
            this.Longitude = "-99.1663497";
        }
        #endregion

        #region Commands
        public ICommand TrackCommand
        {
            get
            {
                return new RelayCommand(Track);
            }
        }

        #endregion

        #region methods

        private async void Track()
        {
            if (string.IsNullOrEmpty(this.Latitude))
            {
                await Application.Current.MainPage.DisplayAlert("Error"
                    , "You mus enter an latitude"
                    , "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Longitude))
            {
                await Application.Current.MainPage.DisplayAlert("Error"
                    , "You must enter an longitude"
                    , "Accept");
                return;
            }

            MainViewModel.GetInstance().Scooters = new ScootersViewModel(this.Latitude, this.Longitude);
            await Application.Current.MainPage.Navigation.PushAsync(new Scooters());
        }

        #endregion

    }
}

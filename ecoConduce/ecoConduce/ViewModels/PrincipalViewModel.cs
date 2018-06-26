namespace ecoConduce.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;

    class PrincipalViewModel : BaseViewModel
    {
        #region atributo
        private string latitude = "arturo.aragonsanchez@hotmail.com";
        private string longitude = "1234";
        #endregion

        #region propiedades
        public string Latitude
        {
            get { return this.latitude; }
            set { SetValue(ref this.latitude, value); }
        }
        public string Longitude
        {
            get { return this.longitude; }
            set { SetValue(ref this.longitude, value); }
        }

        #endregion

        #region comandos
        public ICommand TrackCommand
        {
            get
            {
                return new RelayCommand(Track);
            }
        }

        private async void Track()
        {
            if (string.IsNullOrEmpty(this.Latitude))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "You must enter an latitude"
                    , "Accept");
                return;
            }
            if (string.IsNullOrEmpty(this.Longitude))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error"
                    , "You must enter an longitude"
                    , "Accept");
                return;
            }
            this.Latitude = string.Empty;
            this.Longitude = string.Empty;
        }
        #endregion
    }
}

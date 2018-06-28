namespace ecoConduce.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ScooterItemViewModel : Scooter
    {
        #region commands
        public ICommand SelectScooterCommand
        {
            get
            {
                return new RelayCommand(SelectScooter);
            }
        }

        private async void SelectScooter()
        {
            MainViewModel.GetInstance().Scooter = new ScooterViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new ScooterPage());
        }
        #endregion
    }
}

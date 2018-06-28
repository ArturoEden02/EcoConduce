
namespace ecoConduce.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ScooterViewModel
    {
        #region Commands

        #region Properties
        public Scooter Scooter { get; set; }
        #endregion

        #region Constructors
        public ScooterViewModel(Scooter scooter)
        {
            this.Scooter = scooter;
        }
        #endregion

        #endregion
    }
}

namespace ecoConduce.ViewModels
{
    using Models;

    public class ScooterViewModel
    {
        #region Properties

        public Scooter Scooter { get; set; }

        #endregion

        #region Constructors

        public ScooterViewModel(Scooter scooter)
        {
            this.Scooter = scooter;
        }

        #endregion

    }
}
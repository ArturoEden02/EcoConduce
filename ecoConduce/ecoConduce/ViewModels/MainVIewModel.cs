namespace ecoConduce.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class MainViewModel
    {
        #region viewModels
        public PrincipalViewModel Principal
        {
            get;
            set;
        }

        public ScootersViewModel Scooters
        {
            get;
            set;
        }
        #endregion

        #region constructors
        public MainViewModel()
        {
            instance = this;
            this.Principal = new PrincipalViewModel();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}

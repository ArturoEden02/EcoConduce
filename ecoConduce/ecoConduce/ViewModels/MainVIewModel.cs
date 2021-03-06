﻿namespace ecoConduce.ViewModels
{

    public class MainViewModel
    {
        #region ViewModels

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

        public ScooterViewModel Scooter
        {
            get;
            set;
        }

        #endregion

        #region Constructors

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
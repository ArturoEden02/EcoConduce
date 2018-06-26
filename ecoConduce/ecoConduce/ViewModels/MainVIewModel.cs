namespace ecoConduce.ViewModels
{
    class MainViewModel
    {
        #region ViewModels
        public PrincipalViewModel principal { get; set; }
        #endregion
        #region Constructores
        public MainViewModel()
        {
            instance = this;
            this.principal = new PrincipalViewModel();
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

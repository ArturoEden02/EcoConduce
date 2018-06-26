namespace ecoConduce.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using ViewModels;
    public class InstanceLocator
    {
        #region properties
        public MainViewModel Main
        {
            get;
            set;
        }
        #endregion

        #region constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
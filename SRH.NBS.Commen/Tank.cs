using System;

namespace SRH.NBS.Commen
{
    public abstract class Tank
    {
        #region Private Fields

        #endregion

        #region Constructor
        public Tank()
        {
            Id = Guid.NewGuid().ToString();
        }

        #endregion
        #region Public Properties
        public string Id {
            get;
            protected set;
        }
        public string Name { get; set; }
        public double AddedVolume { get; set; }
        public double DeductedVolume { get; set; }
        public double CurrentVolume { get { return AddedVolume-DeductedVolume; }}

        public double Temperature { get; set; }

        #endregion

        #region Public Methods
        public void ResetVolume()
        {
            AddedVolume = 0;
            DeductedVolume = 0;
        }
        #endregion
    }
}

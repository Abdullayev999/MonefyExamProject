using System;

namespace Monefy
{
    [Serializable]
    public class Rootobject
    {
        public Rates rates { get; set; }
        public string _base { get; set; }
        public string date { get; set; }
    }
    [Serializable]
    public class Rates
    {
        public decimal AZN
        {
            get => USD * 1.7m;
            set { azn = value / 1.7m; }
        }
        public decimal RUB { get; set; }
        public decimal USD { get; set; }
        public decimal TRY { get; set; }
        public decimal EUR { get; set; }

        private decimal azn;
    }
}
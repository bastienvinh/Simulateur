using System;

namespace Simulateur.Data
{
    class BankBook
    {
        private uint rate; // taux
        private uint time; // saving duration 
        private uint minRate; // minimum threshold
        private uint ceiling; // maximum ceiling
        private uint paymentMonth; //minimum payment by month
        private bool taxSubject; // subject to taxation, True == yes False ==no

        public uint RATE
        {
            get
            {
                return rate;
            }
            set
            {
                if (rate <= 100 && rate >= 0)
                    rate = value;
            }
        }
        public uint TIME
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
        public uint MINRATE
        {
            get
            {
                return minRate;
            }
            set
            {
                minRate = value;

            }
        }
        public uint CEILING
        {
            get
            {
                return ceiling;
            }
            set
            {
                ceiling = value;
            }
        }
        public uint PAYMENTMONTH
        {
            get
            {
                return paymentMonth;
            }
            set
            {
                paymentMonth = value;
            }
        }
        public bool TAXSUBJECT
        {
            get
            {
                return taxSubject;
            }
            set
            {
                taxSubject = value;
            }
        }
    }
}

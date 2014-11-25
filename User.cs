using System.Text;

namespace Simulateur.Data
{
    class User
    {
        private uint initPay; //down payment
        private uint monthPay; //monthly payment
        private uint duration; //saving duration (by Month)
        private uint total; //total

        public uint INITPAY
        {
            get
            {
                return initPay;
            }
            set
            {
                initPay = value;

            }
        }
        public uint MONTHPAY
        {
            get
            {
                return monthPay;
            }
            set
            {
                monthPay = value;

            }
        }
        public uint DURATION
        {
            get
            {
                return duration;
            }
            set
            {
                duration = value;

            }
        }
        public uint TOTAL
        {
            get
            {
                return INITPAY + (MONTHPAY * DURATION);
            }
            set
            {
                total = value;

            }
        }
    };
}

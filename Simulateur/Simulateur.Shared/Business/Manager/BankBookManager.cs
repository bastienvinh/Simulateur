using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Storage;
using Simulateur.Data;
using Simulateur.Data.BLL;

namespace Simulateur.Business
{
	public static class BankBookManager
	{

        #region Constantes
        private const decimal MAX_RATE_YOUNG = 1;
        private const decimal MAX_CEILLING_YOUNG = 50000;
        private const decimal MIN_MONEY_YOUNG = 100;
        private const decimal MIN_TRANSFER_PAY_YOUNG = 30;
        #endregion

		#region Static Attributes
		private static List<BankBook> __bankBooks;
		#endregion

		#region Properties
		public static List<BankBook> BankBooks
		{
			get { return __bankBooks; }
		}
		#endregion


		#region Operations
		public async static Task LoadAllDatasAsync()
		{
			__bankBooks = await BLLBankBooks.GetAllAsync();
		}

        public static List<BankBook> GetListByFilter(Filter filter)
        {
            List<BankBook> res = new List<BankBook>();
            if (__bankBooks != null)
            {
                foreach (BankBook b in __bankBooks)
                {
                    // Filter
                    if (b.Rate <= MAX_RATE_YOUNG)
                    {
                        res.Add(b);
                    }
                    if (b.MaxCeilling >= filter.Capital)
                    {
                        res.Add(b);
                    }
                    if (b.MinimumMoney > MIN_MONEY_YOUNG)
                    {
                        res.Add(b);
                    }
                    if (b.MinTransferPayment > MIN_TRANSFER_PAY_YOUNG)
                    {
                        res.Add(b);
                    }
                    if (b.IsIllimited)
                    {
                        res.Add(b);
                    }
                }

            }
            return res;
        }
        public static decimal CountCapital (Filter filter, BankBook bankbook)
        {           
            decimal newCapital = filter.Capital;
            decimal moneyPerYear = filter.MonthPay * 12;
            decimal pricePerYearMangement = bankbook.PricePerMonth * 12;
            for (int i = 0; i < filter.Duration;++i)
            {
                newCapital += moneyPerYear - pricePerYearMangement;
                newCapital *= (1 + bankbook.Rate);
            }        
                return newCapital;
        }
		#endregion

	}
}
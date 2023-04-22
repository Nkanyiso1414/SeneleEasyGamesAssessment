using System;
using System.Collections.Generic;
using System.Text;

namespace Senele.Solution.ApplicationContractsLayer.Transactions.DTO
{
	public class TransactionDto
	{
		public decimal Amount { get; set; }
		public int TransactionTypeID { get; set; }
		public int ClientID { get; set; }
		public string Comment { get; set; }
	}
}

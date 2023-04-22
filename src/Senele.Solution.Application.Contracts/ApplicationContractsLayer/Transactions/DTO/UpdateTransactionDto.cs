using System;
using System.Collections.Generic;
using System.Text;

namespace Senele.Solution.ApplicationContractsLayer.Transactions.DTO
{
	public class UpdateTransactionDto
	{
		public int TransactionID { get; set; }
		public string Comment { get; set; }
	}
}

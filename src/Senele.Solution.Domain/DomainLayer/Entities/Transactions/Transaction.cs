using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senele.Solution.DomainLayer.Entities.Transactions
{
	public class Transaction
	{
		public decimal Amount { get; set; }
		public int TransactionTypeID { get; set; }
		public int ClientID { get; set; }
		public string Comment { get; set; }
	}
}

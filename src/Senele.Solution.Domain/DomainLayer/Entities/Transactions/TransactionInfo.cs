using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senele.Solution.DomainLayer.Entities.Transactions
{
	public class TransactionInfo:Transaction
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string TransactionTypeName { get; set; }
		public int TransactionID { get; set; }

    }
}

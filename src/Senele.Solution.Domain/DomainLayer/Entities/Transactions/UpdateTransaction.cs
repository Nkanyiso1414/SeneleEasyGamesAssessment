using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senele.Solution.DomainLayer.Entities.Transactions
{
	public class UpdateTransaction
	{
		public int TransactionID { get; set; }
		public string Comment { get; set; }
	}
}

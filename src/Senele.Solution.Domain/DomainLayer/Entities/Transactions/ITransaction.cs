using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Senele.Solution.DomainLayer.Entities.Transactions
{
	public class ITransaction : Entity<int>
	{
		public decimal Amount { get; set; }
		public int TransactionTypeID { get; set; }
		public int ClientID { get; set; }
		public string Comment { get; set; }
	}
}

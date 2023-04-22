using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Senele.Solution.DomainLayer.Entities.TransactionTypes
{
	public class ITransactionType : Entity<int>
	{
		public int TransactionTypeID { get; set; }
		public string TransactionTypeName { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Senele.Solution.ApplicationContractsLayer.Transactions.DTO
{
	public class TransactionInfoDto:TransactionDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
        public string TransactionTypeName { get; set; }
        public int TransactionID { get; set; }
    }
}

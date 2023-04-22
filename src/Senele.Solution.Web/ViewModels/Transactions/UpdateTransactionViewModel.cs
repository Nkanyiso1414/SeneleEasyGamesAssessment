namespace Senele.Solution.Web.ViewModels.Transactions
{
	public class UpdateTransactionViewModel
	{
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TransactionTypeName { get; set; }
        public int TransactionID { get; set; }
		public string Comment { get; set; }
        public decimal Amount { get; set; }
    }
}

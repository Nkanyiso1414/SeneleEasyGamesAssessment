namespace Senele.Solution.Web.ViewModels.Transactions
{
	public class TransactionViewModel
	{
		public decimal Amount { get; set; }
		public int TransactionTypeID { get; set; }
		public int ClientID { get; set; }
		public string Comment { get; set; }
	}
}

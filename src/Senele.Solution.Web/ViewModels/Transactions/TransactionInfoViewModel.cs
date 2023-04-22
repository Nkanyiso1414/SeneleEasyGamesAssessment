namespace Senele.Solution.Web.ViewModels.Transactions
{
	public class TransactionInfoViewModel:TransactionViewModel
	{
		public string Name { get; set; }
		public string Surname { get; set; }
        public string TransactionTypeName { get; set; }
        public int TransactionID { get; set; }
    }
}

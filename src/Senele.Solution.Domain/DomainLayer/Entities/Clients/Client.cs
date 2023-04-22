using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senele.Solution.DomainLayer.Entities.Clients
{
	public class Client
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public decimal ClientBalance { get; set; }
	}
}

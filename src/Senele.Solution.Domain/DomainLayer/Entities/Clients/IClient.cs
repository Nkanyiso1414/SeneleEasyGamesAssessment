using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace Senele.Solution.DomainLayer.Entities.Clients
{
	public class IClient: Entity<int>
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public decimal ClientBalance { get; set; }
	}
}

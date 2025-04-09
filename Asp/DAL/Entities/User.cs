using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public class User
	{
		public Guid User_Id { get; set; }
		public string Pseudo {  get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public DateTime? Deactivation_Date { get; set; }
	}
}

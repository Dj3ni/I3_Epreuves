using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
	public  class GameCopy
	{
		public int Game_Copy_Id { get; set; }
		public int Game_Id { get; set; }
		public Guid User_Id { get; set; }
		public string State { get; set; } // with int, better(less memory) but we need to parse between DAL and BLL, no time
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
	public enum StateEnum
	{
		New,
		Incomplete,
		Damaged
	};
	public class GameCopy
	{

		public int Game_Copy_Id { get; set; }
		public int Game_Id { get; set; }
		public Guid User_Id { get; set; }
		public StateEnum State { get; set; }
		public string Owner { get; set; }
		public string Game_Title { get; set;}

		public GameCopy(int game_Copy_Id, int game_Id, Guid user_Id, string state)
		{
			Game_Copy_Id = game_Copy_Id;
			Game_Id = game_Id;
			User_Id = user_Id;
			//State = state;
			State = Enum.Parse<StateEnum>(state);
		}

		/// <summary>
		/// We take the BLL User to get his Pseudo and set it to GameCopy Owner
		/// </summary>
		/// <param name="user">BLL User</param>
		/// <exception cref="ArgumentNullException"></exception>
		public void SetOwner(User user)
		{
			if (user is null) throw new ArgumentNullException(nameof(user));
			Owner = user.Pseudo;
		}

		/// <summary>
		/// We take the BLL Boardgame to get its Title and set it to GameCopy Title
		/// </summary>
		/// <param name="game">BLL Boardgame</param>
		/// <exception cref="ArgumentNullException"></exception>
		public void SetTitle(Boardgame game)
		{
			if (game is null) throw new ArgumentNullException(nameof(game));
			Game_Title = game.Game_Title;
		}
	}
}

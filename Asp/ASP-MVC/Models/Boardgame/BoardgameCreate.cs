using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Boardgame
{
	public class BoardgameCreate
	{
		[DisplayName("Title: ")]
		[Required(ErrorMessage ="A game without title? No way!")]
		public string Game_Title { get; set; }

		[DisplayName("Description")]
		[Required(ErrorMessage = "Invite people to play this game please, write something about it!")]
		public string Description { get; set; }

		[DisplayName("Start playing at age : ")]
		[Required(ErrorMessage = "It's imperative to know the minimum players")]
		[Range(1,19, ErrorMessage =" You need to give a reasonable age between 1 and 18 year")]
		public int MinAge { get; set; }


		[DisplayName("Over that you'r too old to play this: ")]
		[Required(ErrorMessage ="Maximum age was asked by the PM and it's compulsory, sorry")]
		[Range(1, 100,ErrorMessage ="You need to give a reasonnable age between 1 and 99 years")]
		public int MaxAge { get; set; }

		[DisplayName("Minimum friends around the table: ")]
		[Required(ErrorMessage ="How can you skip this? Minimum players is compulsory!")]
		[Range(1,int.MaxValue, ErrorMessage ="You have to be at least with yourself to play a game!")]
		public int MinPlayers { get; set; }

		[DisplayName("Maximum players: ")]
		[Required(ErrorMessage ="We know, it's hard to set a player limit but you have to.")]
		[Range(1,int.MaxValue,ErrorMessage ="You have to at least be able to play against yourself!")]
		public int MaxPlayers { get; set; }

		[DisplayName("Fun part duration, without rules explanation: ")]
		public int? Duration { get; set; }

		[ScaffoldColumn(false)]
		[BindNever]
		public Guid Registerer {get; set; }
		
	

	}
}

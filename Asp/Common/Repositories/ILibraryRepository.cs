using Common.Repositories.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
	public interface ILibraryRepository <TGameCopy> : ICRUDRepository<TGameCopy, int>
	{
		IEnumerable<TGameCopy> GetByUserId(Guid user_id);
		IEnumerable<TGameCopy> GetByGameId(int game_id);
	}
}

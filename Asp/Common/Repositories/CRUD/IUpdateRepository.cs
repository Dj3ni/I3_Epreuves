using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.CRUD
{
	public interface IUpdateRepository <TEntity, TId>
	{
		void Update(TId id, TEntity entity);
	}
}

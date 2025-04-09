using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories.CRUD
{
	public interface ILibraryRepository <TLibrary>: 
		IInsertRepository<TLibrary,int>,
		IUpdateRepository<TLibrary, int>
	{

	}
}

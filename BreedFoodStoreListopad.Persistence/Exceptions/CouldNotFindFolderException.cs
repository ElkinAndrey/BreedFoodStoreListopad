using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreedFoodStoreListopad.Persistence.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если не удалось найти файл по указанному пути
	/// </summary>
	public sealed class CouldNotFindFolderException : DirectoryNotFoundException
    {
        /// <summary>
        /// Ошибка, возникающая если не удалось найти файл по указанному пути
        /// </summary>
        public CouldNotFindFolderException() :
            base($"Не удалось найти файл по указанному пути")
        {

        }
    }
}

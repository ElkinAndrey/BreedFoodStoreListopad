using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
    /// Ошибка, возникающая при попытке добавить не картинку
    /// </summary>
    public sealed class NotImageException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая при попытке добавить не картинку
        /// </summary>
        public NotImageException() :
            base($"Выбранный файл не является картинкой")
        {

        }
    }
}

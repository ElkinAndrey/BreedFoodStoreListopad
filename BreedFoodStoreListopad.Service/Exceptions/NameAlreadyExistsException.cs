namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если такое имя уже существует
	/// </summary>
	public sealed class NameAlreadyExistsException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если такое имя уже существует
        /// </summary>
        public NameAlreadyExistsException() :
            base($"Указанное имя уже существует")
        {

        }
    }
}

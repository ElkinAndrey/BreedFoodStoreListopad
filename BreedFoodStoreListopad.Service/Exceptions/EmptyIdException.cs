namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если не был выбран id
	/// </summary>
	public sealed class EmptyIdException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не был выбран id
        /// </summary>
        public EmptyIdException() :
            base($"Уникальный id не выбран")
        {

        }
    }
}

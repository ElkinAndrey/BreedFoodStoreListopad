namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если не был добавлен файл
	/// </summary>
	public sealed class EmptyFileException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не был добавлен файл
        /// </summary>
        public EmptyFileException() :
            base($"Файл не выбран")
        {

        }
    }
}

namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если не было указано пустое имя
	/// </summary>
	public sealed class EmptyNameException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не было указано пустое имя
        /// </summary>
        public EmptyNameException() :
            base($"Было введено пустое значение имени")
        {

        }
    }
}

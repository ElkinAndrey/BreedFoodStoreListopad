namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если не была выбрана дата
	/// </summary>
	public sealed class EmptyDateException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не была выбрана дата
        /// </summary>
        public EmptyDateException() :
            base($"Дата не выбрана")
        {

        }
    }
}

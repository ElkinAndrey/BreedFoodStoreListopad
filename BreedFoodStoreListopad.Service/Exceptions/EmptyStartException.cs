namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если не указано начало отчета
	/// </summary>
	public sealed class EmptyStartException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не указано начало отчета
        /// </summary>
        public EmptyStartException() :
            base($"Не указано начало отчета")
        {

        }
    }
}

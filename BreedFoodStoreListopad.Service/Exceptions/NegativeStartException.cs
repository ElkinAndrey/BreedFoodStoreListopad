namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если начало отчета меньше 0
	/// </summary>
	public sealed class NegativeStartException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если начало отчета было меньше 0
        /// </summary>
        public NegativeStartException(long start) :
            base($"Начало отчета \"{start}\" меньше 0")
        {

        }
    }
}

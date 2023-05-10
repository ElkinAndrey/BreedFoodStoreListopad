namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если длина среза меньше 0
	/// </summary>
	public sealed class NegativeLengthException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если длина среза меньше 0
        /// </summary>
        public NegativeLengthException(long length) :
            base($"Длина среза \"{length}\" меньше 0")
        {

        }
    }
}

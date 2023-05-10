namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
    /// Ошибка, возникающая если не указана длина среза
    /// </summary>
    public sealed class EmptyLengthException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не указана длина среза
        /// </summary>
        public EmptyLengthException() :
            base($"Не указана длина среза")
        {

        }
    }
}

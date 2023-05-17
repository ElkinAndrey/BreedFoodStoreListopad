namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если введенное имя слишком длинное
	/// </summary>
	public sealed class NameTooLongException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если введенное имя слишком длинное
        /// </summary>
        public NameTooLongException() :
            base($"Введенное имя слишком длинное")
        {

        }

        /// <summary>
        /// Ошибка, возникающая если введенное имя слишком длинное
        /// </summary>
        /// <param name="expectedLength">Ожидаемая длина</param>
        public NameTooLongException(int expectedLength) :
            base($"Введенное имя слишком длинное. Ожидаемая длина {expectedLength}")
        {

        }

        /// <summary>
        /// Ошибка, возникающая если введенное имя слишком длинное
        /// </summary>
        /// <param name="expectedLength">Ожидаемая длина</param>
        /// <param name="actualLength">Фактическая длина</param>
        public NameTooLongException(int expectedLength, int actualLength) :
            base($"Было введено имя длиной {actualLength} символов. Максимальная длина {expectedLength}")
        {

        }
    }
}

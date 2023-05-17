
namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
    /// Ошибка, возникающая если не была выбрана дата
    /// </summary>
    public sealed class NameContainsInvalidCharacterException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если не была выбрана дата
        /// </summary>
        /// <param name="ch">Недопустимый символ</param>
        public NameContainsInvalidCharacterException(char ch) :
            base($"Имя содержит недопустимый символ '{ch}'")
        {

        }
    }
}

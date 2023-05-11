namespace BreedFoodStoreListopad.Service.Exceptions
{
    /// <summary>
	/// Ошибка, возникающая если у файла неверный MIME тип
	/// </summary>
	public sealed class MIMETypesException : Exception
    {
        /// <summary>
        /// Ошибка, возникающая если у файла неверный MIME тип
        /// </summary>
        public MIMETypesException() :
            base($"Неверный MIME тип файла на сервере")
        {

        }
    }
}

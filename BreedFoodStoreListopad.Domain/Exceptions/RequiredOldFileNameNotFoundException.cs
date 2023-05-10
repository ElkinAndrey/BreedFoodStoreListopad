namespace BreedFoodStoreListopad.Domain.Exceptions
{
	/// <summary>
	/// Ошибка, возникающая если, при выборе старого названия картинки, индекс выходит за границу
	/// </summary>
	public sealed class RequiredOldFileNameNotFoundException : Exception
	{
		/// <summary>
		/// Ошибка, возникающая если, при выборе старого названия картинки, индекс выходит за границу
		/// </summary>
		public RequiredOldFileNameNotFoundException() :
			base($"Не найдено нужное старое имя файла")
		{

		}
	}
}

namespace BreedFoodStoreListopad.Domain.Exceptions
{
	/// <summary>
	/// Ошибка, возникающая если, при выборе старого названия категории, индекс выходит за границу
	/// </summary>
	public sealed class RequiredOldNameNotFoundException : Exception
	{
		/// <summary>
		/// Ошибка, возникающая если, при выборе старого названия категории, индекс выходит за границу
		/// </summary>
		public RequiredOldNameNotFoundException() :
			base($"Не найдено нужное старое имя")
		{

		}
	}
}

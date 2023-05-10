namespace BreedFoodStoreListopad.Domain.Exceptions
{
	/// <summary>
	/// Ошибка, возникающая если в категорию не было добавленно ни одного имени
	/// </summary>
	public sealed class CategoryHasNoNameException : Exception
	{
		/// <summary>
		/// Ошибка, возникающая если в категорию не было добавленно ни одного имени
		/// </summary>
		public CategoryHasNoNameException() :
			base($"У категории нет имен")
		{

		}
	}
}

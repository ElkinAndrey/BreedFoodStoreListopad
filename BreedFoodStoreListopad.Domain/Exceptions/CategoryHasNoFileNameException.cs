namespace BreedFoodStoreListopad.Domain.Exceptions
{
	/// <summary>
	/// Ошибка, возникающая если в категорию не было добавленно ни одной картинки
	/// </summary>
	public sealed class CategoryHasNoFileNameException : Exception
	{
		/// <summary>
		/// Ошибка, возникающая если в категорию не было добавленно ни одной картинки
		/// </summary>
		public CategoryHasNoFileNameException() :
			base($"У категории нет имен картинок!")
		{

		}
	}
}

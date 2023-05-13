using BreedFoodStoreListopad.Domain.Exceptions;

namespace BreedFoodStoreListopad.Domain.Entities
{
	/// <summary>
	/// Категория товара
	/// </summary>
	public class Category
	{
		/// <summary>
		/// Папка с картинками категории
		/// </summary>
		public static string ImagesFolder { get; } = "categories";

		/// <summary>
		/// Название категории
		/// </summary>
		private string name;

		/// <summary>
		/// Название картинки категории
		/// </summary>
		private string fileName;

		/// <summary>
		/// Уникальный Id категории
		/// </summary>
		public Guid Id { get; set; } = Guid.NewGuid();

		/// <summary>
		/// Название категории
		/// </summary>
		public string Name
		{
			get
			{
				if (name is not null)
					return name;
				throw new CategoryHasNoNameException();
			}
			set
			{
				if (name is not null)
					OldNames.Add(name);
				name = value;
			}
		}

		/// <summary>
		/// Старые названия категории
		/// </summary>
		public List<string> OldNames { get; set; } = new List<string>();

		/// <summary>
		/// Название картинки категории
		/// </summary>
		public string FileName
		{
			get
			{
				if (fileName is not null)
					return fileName;
				throw new CategoryHasNoFileNameException();
			}
			set
			{
				if (fileName is not null)
					OldFileNames.Add(fileName);
				fileName = value;
			}
		}

		/// <summary>
		/// Старые названия картинок категории
		/// </summary>
		public List<string> OldFileNames { get; set; } = new List<string>();

		/// <summary>
		/// Полный путь к картинке категории
		/// </summary>
		public string FilePath { get => $"{FolderPath}/{FileName}"; }

        /// <summary>
        /// Полный путь к папке с картинками 
        /// </summary>
        public string FolderPath { get => $"{ImagesFolder}/{Id}"; }

        /// <summary>
        /// Если объект в мусорной корзине, то true.
        /// </summary>
        public DateTime? DeletionDate { get; set; } = null;

        /// <summary>
        /// Категория товара
        /// </summary>
        public Category() { }

		/// <summary>
		/// Категория товара
		/// </summary>
		/// <param name="name">Название категории</param>
		/// <param name="fileName">Название картинки категории</param>
		public Category(string name, string fileName)
		{
			Name = name;
			FileName = fileName;
		}

		/// <summary>
		/// Установить старое название категории
		/// </summary>
		/// <param name="oldNameIndex">Индекс старого названия</param>
		/// <exception cref="RequiredOldNameNotFoundException">Ошибка выхода за границы</exception>
		public void SetOldName(int oldNameIndex)
		{
			if (oldNameIndex < 0 || oldNameIndex >= OldNames.Count)
				throw new RequiredOldNameNotFoundException();
			Name = OldNames[oldNameIndex];
			OldNames.RemoveAt(oldNameIndex);
		}

		/// <summary>
		/// Установить старое название картинки 
		/// </summary>
		/// <param name="oldFileNameIndex">Индекс старого названия картинки</param>
		/// <exception cref="RequiredOldFileNameNotFoundException">Ошибка выхода за границы</exception>
		public void SetOldFileName(int oldFileNameIndex)
		{
			if (oldFileNameIndex < 0 || oldFileNameIndex >= OldFileNames.Count)
				throw new RequiredOldFileNameNotFoundException();
			FileName = OldFileNames[oldFileNameIndex];
			OldFileNames.RemoveAt(oldFileNameIndex);
		}
	}
}

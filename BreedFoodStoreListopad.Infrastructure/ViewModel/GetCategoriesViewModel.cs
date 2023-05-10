namespace BreedFoodStoreListopad.Infrastructure.ViewModel
{
    /// <summary>
    /// Параметры получения среза категорий
    /// </summary>
    public class GetCategoriesViewModel
    {
        /// <summary>
        /// Начало отчета
        /// </summary>
        public int? Start { get; set; }

        /// <summary>
        /// Длина среза
        /// </summary>
        public int? Length { get; set; }
    }
}

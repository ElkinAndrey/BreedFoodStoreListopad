namespace BreedFoodStoreListopad.Infrastructure.ViewModel
{
    /// <summary>
    /// Параметры для перемещения в корзину
    /// </summary>
    public class MoveToTrashViewModel
    {
        /// <summary>
        /// Уникальны Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Дата перемещения
        /// </summary>
        public DateTime? MoveDate { get; set; }
    }
}

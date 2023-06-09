namespace BreedFoodStoreListopad.Domain.Entities
{
    /// <summary>
    /// Старое имя
    /// </summary>
    public class OldName
    {
        /// <summary>
        /// Уникальный Id
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Старое имя
        /// </summary>
        public string Name { get; set; } 

        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime RemovalDate { get; set; }
    }
}



namespace ProperNutrition.Domain.Entities
{
    public class DishEntity
    {
        public Guid Id { get; set; }    

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public Guid CreatedById { get; set; }

        public virtual UserEntity CreatedBy { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public Guid CategoryId { get; set; }

        public virtual CategoryEntity Category { get; set; } = null!;

        public virtual ICollection<DishProductEntity> Products { get; set; } = [];

        public virtual ICollection<UserEntity> LikedBy { get; set; } = [];
    }
}

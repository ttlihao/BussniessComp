using GuYou.Repositories.Base;
using GuYou.Repositories.Models;

public class Review : BaseEntity
{
    public int ReviewId { get; set; }
    public string UserId { get; set; }
    public int? CoffeeMixId { get; set; } // Foreign key to CoffeeMix
    public string Content { get; set; }
    public int Rating { get; set; }
    public int LikeCount { get; set; }
    public virtual User User { get; set; }
    public virtual CoffeeMix CoffeeMix { get; set; } // Added to represent the relationship
    public virtual ICollection<ReviewLike> ReviewLikes { get; set; }
}

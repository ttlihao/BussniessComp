using GuYou.Contracts.Base;
using GuYou.Repositories.Models;

public class CoffeeMix : BaseEntity
{ 
    public int CoffeeMixId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public double WeightInKilograms { get; set; }
    public virtual ICollection<CoffeeMixDetail> CoffeeMixDetails { get; set; }
    public virtual ICollection<Review> Reviews { get; set; } // Added to represent the relationship
}

using System.ComponentModel.DataAnnotations;

public partial class ProductDetail
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Images1 is required.")]
    public string? Images1 { get; set; }

    public string? Color { get; set; }
    public string? Brand { get; set; }
    public string? Model { get; set; }
    public DateOnly? ModelYear { get; set; }
    public string? Description { get; set; }
    public string? Images2 { get; set; }

    
    public virtual Product Product { get; set; }
}

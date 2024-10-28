using System.ComponentModel.DataAnnotations.Schema;

namespace API.DataEntities;

[Table("Photos")]
public class Photo{
    public int Id { get; set; }

    public required string Url { get; set; }

    public bool IsMain { get; set; }

    public string? PblicId { get; set; }

    // EF Navigations Properties
    //Para One-to-many relation
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = null!;
}
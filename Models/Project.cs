using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hw.Models;

public class Project : IValidatableObject
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(200), MinLength(5)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();

    public ICollection<TeamMember> TeamMembers { get; set; } = new List<TeamMember>();

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndDate < StartDate)
        {
            yield return new ValidationResult(
                "End date must be after the start date.",
                new[] { nameof(EndDate) }
            );
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace hw.Models;

public class TaskItem
{
    [Key]
    public Guid Id { get; set; }

    [Required, MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public DateTime DueDate { get; set; }

    [Required, MaxLength(50)]
    public string Status { get; set; } = "New";

    [Required]
    public Guid ProjectId { get; set; }

    public Project? Project { get; set; }

    public Guid? AssignedToId { get; set; }

    public TeamMember? AssignedTo { get; set; }
}

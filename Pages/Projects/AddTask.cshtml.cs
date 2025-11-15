using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace hw.Pages.Projects;

public class AddTaskModel : PageModel
{
    private readonly AppDbContext _context;

    public AddTaskModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public TaskItem Task { get; set; } = new()
    {
        DueDate = DateTime.UtcNow.Date.AddDays(7),
        Status = "New"
    };

    public Project? Project { get; private set; }

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        Project = await _context.Projects.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        if (Project == null)
        {
            return RedirectToPage("/Projects/Index");
        }

        Task.ProjectId = Project.Id;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Project = await _context.Projects.FindAsync(Task.ProjectId);
        if (Project == null)
        {
            ModelState.AddModelError(string.Empty, "Project not found.");
            return Page();
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        Task.CreatedDate = DateTime.UtcNow;
        Task.DueDate = DateTime.SpecifyKind(Task.DueDate, DateTimeKind.Utc);

        _context.Tasks.Add(Task);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Projects/Index");
    }
}

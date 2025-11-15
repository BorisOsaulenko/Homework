using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace hw.Pages.Projects;

public class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Project Project { get; private set; } = null!;

    public IList<TaskItem> Tasks { get; private set; } = new List<TaskItem>();

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var project = await _context
            .Projects
            .AsNoTracking()
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (project == null)
        {
            return RedirectToPage("/Projects/Index");
        }

        Project = project;
        Tasks = project.Tasks.OrderBy(t => t.DueDate).ToList();

        return Page();
    }
}

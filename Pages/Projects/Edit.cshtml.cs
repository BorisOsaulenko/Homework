using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw.Pages.Projects;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Project Project { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var project = await _context.Projects.FindAsync(id);
        if (project == null)
        {
            return RedirectToPage("/Projects/Index");
        }

        Project = project;
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var project = await _context.Projects.FindAsync(Project.Id);
        if (project == null)
        {
            return RedirectToPage("/Projects/Index");
        }

        project.Name = Project.Name;
        project.Description = Project.Description;
        project.StartDate = DateTime.SpecifyKind(Project.StartDate, DateTimeKind.Utc);
        project.EndDate = DateTime.SpecifyKind(Project.EndDate, DateTimeKind.Utc);

        await _context.SaveChangesAsync();

        return RedirectToPage("/Projects/Index");
    }
}

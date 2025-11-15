using hw.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw.Pages.Projects;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Project Project { get; set; } =
        new() { StartDate = DateTime.UtcNow.Date, EndDate = DateTime.UtcNow.Date };

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        Project.StartDate = DateTime.SpecifyKind(Project.StartDate, DateTimeKind.Utc);
        Project.EndDate = DateTime.SpecifyKind(Project.EndDate, DateTimeKind.Utc);

        _context.Projects.Add(Project);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Index");
    }
}

namespace CollaborativeWhiteboard.Web.Models;

public class WhiteboardViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public string BackgroundColor { get; set; }
    // ... other properties needed by the views.
}

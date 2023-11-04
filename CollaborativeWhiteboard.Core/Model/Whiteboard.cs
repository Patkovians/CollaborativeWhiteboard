using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeWhiteboard.Core.Model;

public class Whiteboard
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public string BackgroundColor { get; set; } = "FFFFFF"; // Default white
    public int Width { get; set; } = 1920;  // Default width
    public int Height { get; set; } = 1080; // Default height
    public Guid OwnerId { get; set; }  // Assuming the owner is identified with a GUID
}

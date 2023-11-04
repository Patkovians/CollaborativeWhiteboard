using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeWhiteboard.DataInfrastructure.Entity;

public class WhiteboardEntity
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime CreationDate { get; set; }
    public string BackgroundColor { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public Guid OwnerId { get; set; }

    // Include any additional properties specific to EF Core or database operations.
}

using CollaborativeWhiteboard.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeWhiteboard.Core.Interfaces;

public interface IWhiteboardService
{
    Task<Whiteboard> CreateWhiteboardAsync(Whiteboard whiteboard);
}

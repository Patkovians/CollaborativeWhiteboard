using CollaborativeWhiteboard.Core.Interfaces;
using CollaborativeWhiteboard.Core.Model;
using CollaborativeWhiteboard.DataInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollaborativeWhiteboard.Core.Services;

public class WhiteboardService : IWhiteboardService
{
    private readonly IWhiteboardRepository _whiteboardRepository;

    // Constructor Injection
    public WhiteboardService(IWhiteboardRepository whiteboardRepository)
    {
        _whiteboardRepository = whiteboardRepository;
    }

    public async Task<Whiteboard> CreateWhiteboardAsync(Whiteboard whiteboard)
    {
        if (whiteboard == null)
            throw new ArgumentNullException(nameof(whiteboard));

        // Here you can add any business rules or logic before saving the whiteboard
        // For example: Validate the whiteboard properties, check if a whiteboard with the same name exists, etc.

        return await _whiteboardRepository.AddAsync(whiteboard);
    }

    // Implement other methods as required.
}

using CollaborativeWhiteboard.Core.Model;

namespace CollaborativeWhiteboard.DataInfrastructure.Repository;

public interface IWhiteboardRepository
{
    Task<Whiteboard> AddAsync(Whiteboard whiteboard);
    Task<Whiteboard> GetByIdAsync(Guid id);
    // Other typical CRUD operations: Update, Delete, List, etc.
}

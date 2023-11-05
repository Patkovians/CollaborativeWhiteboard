using AutoMapper;
using CollaborativeWhiteboard.Core.Model;
using CollaborativeWhiteboard.DataInfrastructure.DataContext;
using CollaborativeWhiteboard.DataInfrastructure.Entity;

namespace CollaborativeWhiteboard.DataInfrastructure.Repository;

public class WhiteboardRepository : IWhiteboardRepository
{
    private readonly WhiteboardDbContext _context;
    private readonly IMapper _mapper;

    // Constructor Injection
    public WhiteboardRepository(WhiteboardDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<Whiteboard> AddAsync(Whiteboard whiteboard)
    {
        if (whiteboard == null)
            throw new ArgumentNullException(nameof(whiteboard));

        var whiteboardEntity = _mapper.Map<WhiteboardEntity>(whiteboard);
        _context.Whiteboards.Add(whiteboardEntity);
        await _context.SaveChangesAsync();
        return _mapper.Map<Whiteboard>(whiteboardEntity);
    }

    public async Task<Whiteboard> GetByIdAsync(Guid id)
    {
        var whiteboardEntity = await _context.Whiteboards.FindAsync(id);
        return _mapper.Map<Whiteboard>(whiteboardEntity);
    }

    // Implement other CRUD operations and more specific data access methods.
}
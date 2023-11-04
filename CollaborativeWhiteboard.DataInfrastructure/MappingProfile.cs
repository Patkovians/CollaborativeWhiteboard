using AutoMapper;
using CollaborativeWhiteboard.Core.Model;
using CollaborativeWhiteboard.DataInfrastructure.Entity;

namespace CollaborativeWhiteboard.Common;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Whiteboard, WhiteboardEntity>().ReverseMap();
    }
}

using AutoMapper;

namespace Application.Mapping
{
    public interface IMapCongigurator
    {
        void ConfigureMapping(Profile profile);
    }
}

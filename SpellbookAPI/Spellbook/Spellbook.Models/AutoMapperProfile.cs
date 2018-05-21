using AutoMapper;

namespace Spellbook.Models
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Spell, SpellDTO>();
        }
    }
}

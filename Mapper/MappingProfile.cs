using AutoMapper;
using Dto.Message;
using Entities;
using DomainEntities;
using Persistence.Collections;
using Dto.ReceiveMessage;

namespace Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<DomainEntities.Message, Entities.Message>()
                .ForMember(dest => dest.to,
                           opt => opt.MapFrom(src => src.To))
                .ForMember(dest => dest.type,
                           opt => opt.MapFrom(src => "template"))
                .ForMember(dest => dest.messaging_product,
                           opt => opt.MapFrom(src => "whatsapp"))
                .ForMember(dest => dest.template,
                           opt => opt.MapFrom(src => new Template
                           {
                               name = "hello_world",
                               language = new Language
                               {
                                   code = "en_US"
                               }
                           }));

            CreateMap<MessageDataDtoRequest, DomainEntities.Message>()
                .ForMember(dest => dest.Text,
                           opt => opt.MapFrom(src => src.Text.ToString()))
                .ForMember(dest => dest.To,
                           opt => opt.MapFrom(src => src.To.ToString())).ReverseMap();

            CreateMap<MessageCollection, DomainEntities.Message>()
                .ForMember(dest => dest.Text,
                           opt => opt.MapFrom(src => src.Text))                
                .ForMember(dest => dest.Date,
                           opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.From,
               opt => opt.MapFrom(src => src.From)).ReverseMap();

            CreateMap<Dto.ReceiveMessage.Message,DomainEntities.Message>()
                        .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.from))
                        .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.text.body))
                        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => DateTimeOffset.FromUnixTimeSeconds(long.Parse(src.timestamp)).DateTime));

            CreateMap<DomainEntities.Message, MessageDataDtoResponse>()
                        .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.From))
                        .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date)).ReverseMap();
        }
    }
}
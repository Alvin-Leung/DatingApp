using System;
using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile 
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dto => dto.PhotoUrl, opt => {
                    opt.MapFrom(model => model.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dto => dto.Age, opt => {
                    opt.MapFrom(model => model.DateOfBirth.CalculateAge());
                });

            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dto => dto.Age, opt => {
                    opt.MapFrom(model => model.DateOfBirth.CalculateAge());
                });
            
            CreateMap<UserForUpdateDto, User>();
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}
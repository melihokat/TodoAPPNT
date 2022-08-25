using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNT.Dtos.WorkDtos;
using TodoAppNT.Entities.Concrete;

namespace TodoAppNT.Business.Mapping.AutoMapper
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorkListDto>().ReverseMap();
            CreateMap<Work, WorkCreateDto>().ReverseMap();
            CreateMap<Work, WorkUpdateDto>().ReverseMap();
            CreateMap<WorkListDto, WorkUpdateDto>().ReverseMap();
        }
    }
}

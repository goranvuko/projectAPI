using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.DTOs.Projects;
using Core.Entities;

namespace BusinessLayer.Mappings
{
    public class MappingProjects : Profile
    {
        public MappingProjects()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(dest => dest.ProjectStatus, opt => opt.MapFrom(src => Enum.GetName(src.ProjectStatus.GetType(), src.ProjectStatus))); // for mapping projectStatus to appear as a string in response
            
            CreateMap<CreateProjectDto, Project>();

            CreateMap<UpdateProjectDto, Project>();

            CreateMap<Project, int>().ConvertUsing(src => src.Id);
        }
    }
}
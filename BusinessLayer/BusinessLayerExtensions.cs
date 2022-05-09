using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Mappings;
using BusinessLayer.Services.Projects;
using BusinessLayer.Services.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class BusinessLayerExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var profileList = new List<Profile>();

            profileList.Add(new MappingTasks());
            profileList.Add(new MappingProjects());

            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<IProjectService, ProjectService>();

            services.AddAutoMapper(c => c.AddProfiles(profileList), typeof(List<Profile>));
            
            
            return services;
        }
    }
}

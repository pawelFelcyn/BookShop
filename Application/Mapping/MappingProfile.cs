﻿using AutoMapper;
using System;
using System.Linq;
using System.Reflection;

namespace Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetTypes()
                        .Where(t => typeof(IMapCongigurator).IsAssignableFrom(t)
                        && !t.IsInterface).ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(nameof(IMapCongigurator.ConfigureMapping));

                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}

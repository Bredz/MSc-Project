using MastersProject.Core.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MastersProject.Core.Common.Infrastructure
{
    /// <summary>
    /// Second step
    /// </summary>
    public static class AutoMapperConfig//:Infrastructure.Tasks.IRunAtInit
    {
        public  static void Execute(Assembly obj)
        {
            var types = obj.GetTypes();//.GetExecutingAssembly().GetExportedTypes();
            LoadStandardMappingTypes(types);
            LoadCustomsMappingTypes(types);
        }

        private static void LoadCustomsMappingTypes(IEnumerable<Type> types)
        {
            //1.Using reflections to find all types that implement IHaveCustomMappings interfacce
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
                        !t.IsInterface &&
                        !t.IsAbstract
                        select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();
            //2.create map automatically for auto mapper
            foreach (var m in maps)
            {
                m.CreateMappings(AutoMapper.Mapper.Configuration);
                //m.CreateMappings(AutoMapper.Mapper.Configuration)
            }
        }

        private static void LoadStandardMappingTypes(IEnumerable<Type> types)
        {
            //1.Using reflections to find all types that implement IMapFrom<> interfacce 
            var maps = (from t in types
                        from i in t.GetInterfaces()
                        where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
                        !t.IsInterface && 
                        !t.IsAbstract
                        select new { 
                        Source=i.GetGenericArguments()[0],
                        Destination=t
                        }
                          ).ToArray();
            //2.create map automatically for auto mapper
            foreach (var m in maps)
            {
                AutoMapper.Mapper.CreateMap(m.Source, m.Destination);
                AutoMapper.Mapper.CreateMap(m.Destination, m.Source);
            }
        }
    }
}
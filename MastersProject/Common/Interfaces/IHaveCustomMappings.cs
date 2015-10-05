using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.Common.Interfaces
{
   public interface IHaveCustomMappings
    {
        void CreateMappings(AutoMapper.IConfiguration configuration);
    }
}

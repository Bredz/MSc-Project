using MastersProject.Core.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MastersProject.Core.Common.Interfaces
{
    /// <summary>
    /// This will examine the entities in the change tracker and check if each entity implements IObjectState
    /// it is nescessary for entities to implement this interface, this is how the api deals with updating graphs in Entity Framework
    /// </summary>
    public interface IObjectState
    {
        ObjectState State { get; set; }
    }
}

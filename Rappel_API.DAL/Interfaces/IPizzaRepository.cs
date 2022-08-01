using Rappel_API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.DAL.Interfaces;

namespace Rappel_API.DAL.Interfaces
{
    public interface IPizzaRepository : IRepository<int, PizzaEntity>
    {
        // Méthode Repository custom
    }
}

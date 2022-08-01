using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.DAL.Interfaces;

namespace Rappel_API.DAL.Entities
{
    public class PizzaEntity : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PizzaType { get; set; }
    }
}

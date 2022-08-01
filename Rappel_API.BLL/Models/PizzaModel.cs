using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappel_API.BLL.Models
{
    public class PizzaModel
    {
        public enum PizzaTypeEnum
        {
            TOMATO_BASE,
            CREAM_BASE,
            CALZONE
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PizzaTypeEnum PizzaType { get; set; }

    }
}

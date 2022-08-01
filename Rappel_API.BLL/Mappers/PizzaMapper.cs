using Rappel_API.BLL.Models;
using Rappel_API.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappel_API.BLL.Mappers
{
    internal static class PizzaMapper
    {
        public static PizzaEntity ToDAL(this PizzaModel model)
        {
            string pizzaType;
            switch (model.PizzaType)
            {
                case PizzaModel.PizzaTypeEnum.TOMATO_BASE:
                    pizzaType = "Base Tomate";
                    break;
                case PizzaModel.PizzaTypeEnum.CREAM_BASE:
                    pizzaType = "Base Crème";
                    break;
                case PizzaModel.PizzaTypeEnum.CALZONE:
                    pizzaType = "Calzone";
                    break;
                default:
                    throw new Exception("Type de pizza non géré (╯▔皿▔)╯ ");
            }

            return new PizzaEntity
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                PizzaType = pizzaType
            };
        }


        public static PizzaModel ToBLL(this PizzaEntity entity)
        {
            PizzaModel.PizzaTypeEnum pizzaType;

            switch (entity.PizzaType)
            {
                case "Base Tomate":
                    pizzaType = PizzaModel.PizzaTypeEnum.TOMATO_BASE;
                    break;
                case "Base Crème":
                    pizzaType = PizzaModel.PizzaTypeEnum.CREAM_BASE;
                    break;
                case "Calzone":
                    pizzaType = PizzaModel.PizzaTypeEnum.CALZONE;
                    break;
                default:
                    throw new Exception("Type de pizza non géré (ﾟДﾟ*)ﾉ ");
            }

            return new PizzaModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                PizzaType = pizzaType
            };
        }
    }
}

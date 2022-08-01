using Rappel_API.BLL.Interfaces;
using Rappel_API.BLL.Mappers;
using Rappel_API.BLL.Models;
using Rappel_API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappel_API.BLL.Services
{
    public class PizzaService : IPizzaService
    {
        private const decimal REDUC_PRICE = 7.95m;


        private IPizzaRepository _PizzaRepository;
        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _PizzaRepository = pizzaRepository;
        }

        private PizzaModel ApplyReduc(PizzaModel pizza)
        {
            // Reduc le Mercredi
            if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
                pizza.Price = REDUC_PRICE;
            }

            return pizza;
        }

        public IEnumerable<PizzaModel> GetAll()
        {
            return _PizzaRepository.GetAll()
                        .Select(p => p.ToBLL())
                        .Select(p => ApplyReduc(p));
        }

        public PizzaModel GetById(int id)
        {
            PizzaModel pizza = _PizzaRepository.GetById(id).ToBLL();

            return ApplyReduc(pizza);
        }

        public PizzaModel Insert(PizzaModel model)
        {
            int id = _PizzaRepository.Insert(model.ToDAL());
            model.Id = id;

            return model;
        }

        public bool Delete(int id)
        {
            return _PizzaRepository.Delete(id);
        }
    }
}

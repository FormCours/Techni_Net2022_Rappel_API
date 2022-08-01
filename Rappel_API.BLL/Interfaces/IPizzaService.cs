using Rappel_API.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappel_API.BLL.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<PizzaModel> GetAll();
        PizzaModel GetById(int id);


        PizzaModel Insert(PizzaModel model);
        bool Delete(int id);
    }
}

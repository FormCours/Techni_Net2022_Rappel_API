using Rappel_API.DAL.Entities;
using Rappel_API.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools.DAL.Repositories;

namespace Rappel_API.DAL.Repositories
{
    public class PizzaRepository : RepositoryBase<int, PizzaEntity>, IPizzaRepository
    {
        public PizzaRepository(IDbConnection connection)
            : base(connection, "V_Pizza", "Id")
        { }
        
        protected override PizzaEntity Convert(IDataRecord record)
        {
            return new PizzaEntity
            {
                Id = (int) record["Id"],
                Name = (string) record["Name"],
                PizzaType = (string) record["PizzaType"],
                Price = (decimal) record["Price"]
            };
        }

        public override int Insert(PizzaEntity entity)
        {
            using(IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "SP_Pizza_Insert";
                command.CommandType = CommandType.StoredProcedure;

                AddParameter(command, "@Name", entity.Name);
                AddParameter(command, "@Price", entity.Price);
                AddParameter(command, "@PizzaType", entity.PizzaType);

                _Connection.Open();
                return (int) command.ExecuteScalar()!;
                // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-forgiving
            }
        }

        public override bool Update(int id, PizzaEntity entity)
        {
            throw new NotImplementedException();
        }

        public override bool Delete(int id)
        {
            using(IDbCommand command = _Connection.CreateCommand())
            {
                command.CommandText = "SP_Pizza_Delete";
                command.CommandType = CommandType.StoredProcedure;
                AddParameter(command, "@Pizza_Id", id);

                _Connection.Open();
                return command.ExecuteNonQuery() == 1;
            }
        }
    }
}

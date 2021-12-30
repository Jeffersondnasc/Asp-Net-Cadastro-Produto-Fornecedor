using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectCRUD.Repositories
{
    public abstract class AbstractRepository<T>
    {
        protected string ConnectionString { get; }

        public AbstractRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
    }
}

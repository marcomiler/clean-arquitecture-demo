using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
using AtlanticCity.Core.Interfaces.Repositories.PruebaCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Interfaces.ICore
{
    public interface IUnitOfWork 
    {
        IProductRepository IProductRepository { get; }
        ICategoryRepository ICategoryRepository { get; }
        IActorRepository IActorRepository { get; }
      
    }
}

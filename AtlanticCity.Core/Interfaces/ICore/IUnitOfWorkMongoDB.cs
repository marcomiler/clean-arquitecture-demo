using AtlanticCity.Core.Interfaces.IRepositories.PruebaCA;
using System;
using System.Collections.Generic;
using System.Text;

namespace AtlanticCity.Core.Interfaces.ICore
{
    public interface IUnitOfWorkMongoDB
    {
        IEstadoRepository IEstadoRepository { get; }
    }
}

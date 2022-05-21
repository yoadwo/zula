using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zula.API.Interfaces.Repositories.ImageMetadataRepository;

namespace Zula.API.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IImageMetadataRepository ImageMetaDataRepo { get; }
        Task CompleteAsync();

    }
}

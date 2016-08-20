using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Abstract
{
    public interface ICreatorRepository
    {
        IEnumerable<Creator> Creators { get; }
    }
}

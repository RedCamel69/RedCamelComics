using RedCamel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedCamel.Domain.Entities;

namespace RedCamel.Domain.Concrete
{
    public class ConventionRepository : IConventionRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Convention> Conventions()
        {
            return context.Conventions;
        }

        public IEnumerable<Convention> Conventions(string where)
        {
            return context.Conventions
                .Where(x => x.Country.ToUpper().Trim() == where.ToUpper().Trim());
        }
    }
}

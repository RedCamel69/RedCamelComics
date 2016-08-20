using RedCamel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedCamel.Domain.Abstract
{
    public interface IShopSearchRepository
    {
        IEnumerable<ShopSearch> Shops(string where);
        IEnumerable<ShopSearch> Shops();
        void SaveShop(ShopSearch s);
    }
}

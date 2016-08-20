using RedCamel.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RedCamel.Domain.Entities;
using System.Data.SqlClient;

namespace RedCamel.Domain.Concrete
{
    public class ShopSearchRepository : IShopSearchRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<ShopSearch> Shops()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ShopSearch> Shops(string where)
        {

           
                var location = new SqlParameter("@where", where);


                var result = context.Database
                        .SqlQuery<ShopSearch>("sp_ShopSearch1 @where", location)
                        .ToList();

                return result;
       
        }

        public void SaveShop(ShopSearch shop)
        {
            if (shop.Id == 0)
            {
                context.Shops.Add(shop);
            }
            else
            {
                ShopSearch dbEntry = context.Shops.Find(shop.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = shop.Name;
                    dbEntry.Address = shop.Address;
                    dbEntry.County = shop.County;
                    dbEntry.Latitude = shop.Latitude;
                    dbEntry.Longitude = shop.Longitude;
                    dbEntry.PostCode = shop.PostCode;
                    dbEntry.Town = shop.Town;
                    dbEntry.Phone = shop.Phone;
                    
                }
            }
            context.SaveChanges();
        }
        
    }
}


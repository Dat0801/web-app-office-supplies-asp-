using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using VanPhongPham.Models;
namespace BLL
{
    public class ProductBLL
    {
        readonly ProductDAL productDAL = new ProductDAL();
        public List<product> GetProducts()
        {
            return productDAL.GetProducts();
        }

        public List<attribute> GetAttributes()
        {
            return productDAL.GetAttributes();
        }

        public List<category> GetCategories()
        {
            return productDAL.GetCategories();
        }

        public List<attribute_value> GetAttributeValues(string attribute_id)
        {
            return productDAL.GetAttributeValues(attribute_id);
        }

        public string GenerateProductId()
        {
            return productDAL.GenerateProductId();
        }
    }
}

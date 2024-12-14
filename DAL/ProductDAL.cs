using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanPhongPham.Models;
namespace DAL
{
    public class ProductDAL
    {
        private readonly DB_VanPhongPhamDataContext _context;

        public ProductDAL()
        {
            _context = new DB_VanPhongPhamDataContext();
        }
        public List<product> GetProducts()
        {
            return _context.products.Where(p => p.status == true && p.category.status == true).ToList();
        }

        public List<attribute> GetAttributes()
        {
            return _context.attributes.Where(att => att.status == true).ToList();
        }

        public List<category> GetCategories()
        {
            return _context.categories.Where(c => c.status == true).ToList();
        }

        public List<attribute_value> GetAttributeValues(string attribute_id)
        {
            return _context.attribute_values.Where(att => att.status == true && att.attribute.status == true && att.attribute_id == attribute_id).ToList();
        }

        public string GenerateProductId()
        {
            product product = _context.products.ToList().LastOrDefault();
            int num = int.Parse(product.product_id.Substring(3)) + 1;
            string product_id = "PRO";
            if (num < 10)
                product_id = "PRO00";
            else if (num < 100)
                product_id = "PRO0";
            product_id += num;
            return product_id;
        }
    }
}

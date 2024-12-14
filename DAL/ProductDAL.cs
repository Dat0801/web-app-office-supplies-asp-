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

        public bool AddImages(image image)
        {
            try
            {
                _context.images.InsertOnSubmit(image);
                _context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddProduct(product product)
        {
            try
            {
                product.price = string.IsNullOrEmpty(product.price.ToString()) ? 0 : product.price;
                product.promotion_price = string.IsNullOrEmpty(product.promotion_price.ToString()) ? 0 : product.promotion_price;
                product.purchase_price = string.IsNullOrEmpty(product.purchase_price.ToString()) ? 0 : product.purchase_price;
                product.stock_quantity = string.IsNullOrEmpty(product.stock_quantity.ToString()) ? 0 : product.stock_quantity;
                product.sold = string.IsNullOrEmpty(product.sold.ToString()) ? 0 : product.sold;
                product.avgRating = string.IsNullOrEmpty(product.avgRating.ToString()) ? 0 : product.avgRating;
                product.visited = string.IsNullOrEmpty(product.visited.ToString()) ? 0 : product.visited;
                product.created_at = string.IsNullOrEmpty(product.created_at.ToString()) ? DateTime.Now : product.created_at;
                _context.products.InsertOnSubmit(product);
                _context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool AddProductAttributeValue(product_attribute_value product_Attribute_Value)
        {
            try
            {
                _context.product_attribute_values.InsertOnSubmit(product_Attribute_Value);
                _context.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}

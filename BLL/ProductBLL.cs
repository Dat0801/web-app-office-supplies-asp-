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

        public bool AddImages(image image)
        {
            return productDAL.AddImages(image);
        }

        public bool AddProduct(product product)
        {
            return productDAL.AddProduct(product);
        }

        public bool AddProductAttributeValue(product_attribute_value product_Attribute_Value)
        {
            return productDAL.AddProductAttributeValue(product_Attribute_Value);
        }
    }
}

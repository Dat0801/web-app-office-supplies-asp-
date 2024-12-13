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
    }
}

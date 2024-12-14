using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VanPhongPham.Models;

namespace DAL
{
    public class SupplierDAL
    {
        private readonly DB_VanPhongPhamDataContext _context;

        public SupplierDAL()
        {
            _context = new DB_VanPhongPhamDataContext();
        }
        public List<supplier> GetSuppliers()
        {
            return _context.suppliers.Where(s => s.status == true).ToList();
        }
        public List<supplier> AddSupplier(supplier supplier)
        {
            _context.suppliers.InsertOnSubmit(supplier);
            _context.SubmitChanges();
            return _context.suppliers.Where(s => s.status == true).ToList();
        }
        

    }
}

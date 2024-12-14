using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using VanPhongPham.Models;
namespace BLL
{
    public class SupplierBLL
    {
        private readonly SupplierDAL _supplierDAL;

        public SupplierBLL()
        {
            _supplierDAL = new SupplierDAL();
        }
        public List<supplier> GetSuppliers()
        {
            return _supplierDAL.GetSuppliers();
        }
        public List<supplier> AddSupplier(supplier supplier)
        {
            return _supplierDAL.AddSupplier(supplier);
        }
    }
}

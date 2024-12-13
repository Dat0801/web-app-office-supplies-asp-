using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using VanPhongPham.Models;

namespace DAL
{
    public class UserDAL
    {
        private readonly DB_VanPhongPhamDataContext _context;

        public UserDAL()
        {
            _context = new DB_VanPhongPhamDataContext();
        }
        public user CheckLoginAdmin(string username, string password)
        {
            string hashedPassword = HashPasswordMD5(password);
            return _context.users.FirstOrDefault(u => u.username == username && u.password == hashedPassword && u.status == true);
        }

        private string HashPasswordMD5(string password)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Chuyển mảng byte sang chuỗi hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Chuyển đổi mỗi byte thành 2 ký tự hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}

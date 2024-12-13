using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using VanPhongPham.Models;
namespace BLL
{
    public class UserBLL
    {
        UserDAL userDAL = new UserDAL();
        public user CheckLoginAdmin(string username, string password)
        {
            return userDAL.CheckLoginAdmin(username, password);
        }
    }
}

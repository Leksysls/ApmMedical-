using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
    public class RolesController
    {
        Core db = new Core();

        public  int GetRole(string loginUser)
        {
            int roles = db.context.Users.AsNoTracking().FirstOrDefault(u => (u.login == loginUser)).id_role;
            return roles;
        }
        /// <summary>
        /// Получение данных о ролях
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о ролях
        /// </returns>
        public List<role> GetRoles()
        {
            return db.context.role.ToList();
        }


    }
}

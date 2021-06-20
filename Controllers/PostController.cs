using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
    public class PostController
    {
        Core db = new Core();
        public List<Posts> GetPosts()
        {
            List<Posts> specialtysList = db.context.Posts.ToList();

            return specialtysList;
        }

        /// <summary>
        /// Добавление новой специальности
        /// </summary>
        /// <param name="departmentName">Название специальности</param>
        /// <returns>
        /// true - если добавление прошло успешно
        /// Exception("Произошла ошибка при добавлении!") - если произошла ошибка
        /// </returns
        public bool AddDepartments(string departmentName)
        {
            try
            {
                Posts Adddepart = new Posts
                {
                    name_post = departmentName

                };
                db.context.Posts.Add(Adddepart);
                db.context.SaveChanges();

                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении!");
            }
        }

        /// <summary>
        /// Обновление специальности
        /// </summary>

        /// <param name="departmentName">Название специальности</param>
        /// <param name="depart">Старые данные специальности</param>
        /// <returns>
        /// true - если обновление прошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произошла ошибка
        /// </returns
        public bool UpdateSpecialtys(string departmentName, Posts depart)
        {
            try
            {

                Posts editdepart = db.context.Posts.Where(x => x.id_post == depart.id_post).FirstOrDefault();
                editdepart.name_post = departmentName;

                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при обновлении!");
            }
        }
    }
}

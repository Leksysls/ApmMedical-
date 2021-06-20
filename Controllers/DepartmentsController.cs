using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
    public class DepartmentsController
    {
        Core db = new Core();
        public List<Departments> GetDepartments()
        {
            List<Departments> specialtysList = db.context.Departments.ToList();

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
                Departments Adddepart = new Departments
                {
                    name_department = departmentName

                };
                db.context.Departments.Add(Adddepart);
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
        /// <param name="departmentid">Код специальности</param>
        /// <param name="departmentName">Название специальности</param>
        /// <param name="depart">Старые данные специальности</param>
        /// <returns>
        /// true - если обновление прошло успешно
        /// Exception("Произошла ошибка при обновлении!") - если произошла ошибка
        /// </returns
        public bool UpdateSpecialtys(string departmentName, Departments depart)
        {
            try
            {

                Departments editdepart = db.context.Departments.Where(x => x.id_department == depart.id_department).FirstOrDefault();
                editdepart.name_department = departmentName;

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

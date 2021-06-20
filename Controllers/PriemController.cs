using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
    public class PriemController
    {
        Core db = new Core();
        public List<Info_reception> GetSchedule()
        {
            List<Info_reception> specialtysList = db.context.Info_reception.ToList();

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
        public bool Addreception_schedule(TimeSpan departmentName)
        {
            try
            {
                Info_reception Adddepart = new Info_reception
                {
                    reception_schedule = departmentName

                };
                db.context.Info_reception.Add(Adddepart);
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
        public bool UpdateSpecialtys(TimeSpan departmentName, Info_reception depart)
        {
            try
            {

                Info_reception editdepart = db.context.Info_reception.Where(x => x.id_reception == depart.id_reception).FirstOrDefault();
                editdepart.reception_schedule = departmentName;

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

using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
   public class DoctorController
    {



        readonly Core db = new Core();



        /// <summary>
        /// Получение данных о Врачах
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о Врачах
        /// </returns>
        public List<Info_doctors> GetDoctors()
        {
            return db.context.Info_doctors.ToList();
        }


        public bool AddNewInfoDoctors(int iddeparts, int idreception, int idpost, int idward, int idUser)
        {
            try
            {
                Info_doctors InfoDoctors = new Info_doctors
                {
                    id_department = iddeparts,
                    id_reception = idreception,
                    id_post = idpost,
                    id_ward = idward,
                    id_user = idUser,
                };

                db.context.Info_doctors.Add(InfoDoctors);
                db.context.SaveChanges();

                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добавлении нового преподавателя");
            }
        }







    }
}
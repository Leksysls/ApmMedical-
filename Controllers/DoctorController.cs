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
        readonly UsersController userObj = new UsersController();


        /// <summary>
        /// Получение данных о Врачах
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о Врачах
        /// </returns>
        public List<Users> GetDoctors()
        {
            return db.context.Users.ToList();
        }
        /// <summary>
        /// Получение данных о Врачах
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о Врачах
        /// </returns>
        public List<Info_doctors> GetOfice()
        {
            return db.context.Info_doctors.ToList();
        }
       
        
        /// <summary>
        /// Получение данных о докторах
        /// </summary>
        /// <returns>
        /// Лист с данными о докторах
        /// </returns>
        public List<Info_doctors> GetRunners()
        {
            return db.context.Info_doctors.ToList();
        }
        
        

    }
}
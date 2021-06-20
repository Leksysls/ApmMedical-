using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ApmMedical.Controllers
{
    public class PacientClass
    {
        readonly Core db = new Core();


        /// <summary>
        /// Получение данных о Пациентах
        /// </summary>
        /// <returns>
        /// Возвращает лист с данными о Пациентах
        /// </returns>
        public List<Info_patient> GetPacient()
        {
            return db.context.Info_patient.ToList();
        }
        /// <summary>
        /// Получение данных о Поле
        /// </summary>

        public List<Sex> GetSex()
        {
            return db.context.Sex.ToList();
        }
        public List<Sex> GetSexSelected(int sexid)
        {
            return GetSex().Where(x => x.id_sex == sexid).ToList();
        }
       

      
        


        /// <summary>
        /// Добавление нового Пациента в БД
        /// </summary>
        /// <param name="userFirstName">Входная строка содержащая имя Пациента</param>
        /// <param name="userLastName">Входная строка содержащая фамилию Пациента</param>
        /// <param name="userOtherName">Входная строка содержащая отчество Пациента</param>


        public bool AddPacient( string userFirstName, string userLastName, string userOtherName,DateTime yearPacient,int sexPacient,int bloodPacient)
        {
            try
            {
                Info_patient newPacient = new Info_patient
                {
                    fitstname_patient = userFirstName,
                    surname_patient = userLastName,
                    lastname_patient = userOtherName,
                    year_patient = yearPacient,
                    id_sex = sexPacient,
                    id_blood = bloodPacient
                };

                db.context.Info_patient.Add(newPacient);
                db.context.SaveChanges();

                return true;
            }
            catch
            {
                throw new Exception("Произошла ошибка при добалении нового пользователя!");
            }
        }

        /// <summary>
        /// Обновление данных пациента в БД
        /// </summary>
        /// <param name="firstname">
        /// Имя пациента
        /// </param>
        /// <param name="lastname">
        /// Фамилия пациента
        /// </param>
        /// <param name="othername">
        /// Отчество пациента
        /// </param>
        /// </param>
        /// <returns>
        /// Возвращает:
        /// true - если обновление произошло успешно
        /// Exception("Ошибка при изменении данных пациента.") - если при обновлении произошла ошибка
        /// </returns>
        public bool UpdatePacientInfo( string firstname, string lastname, string othername,DateTime yearpacient,int genderpacient,int bloodpacient, Info_patient patient)
        {
            try
            {
                Info_patient currentPacient = db.context.Info_patient.Where(x => x.id_patient == patient.id_patient).FirstOrDefault();


                currentPacient.fitstname_patient = firstname;
                currentPacient.surname_patient = lastname;
                currentPacient.lastname_patient = othername;
                currentPacient.year_patient = yearpacient;
                currentPacient.id_sex = genderpacient;
                currentPacient.id_blood = bloodpacient;

                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка при изменении данных пользователя.");
            }
        }

    }
}

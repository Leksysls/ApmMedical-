using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
    public class TemperaturController
    {
        Core db = new Core();
        /// <summary>
        /// Получение данных о Температурном листе
        /// </summary>
        /// <returns>
        /// Лист с данными о Крови
        /// </returns>
        public List<Card_patiet> GetTemperature()
        {
            return db.context.Card_patiet.ToList();

        }
    }
}

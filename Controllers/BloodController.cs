using ApmMedical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmMedical.Controllers
{
    public class BloodController
    {
        readonly Core db = new Core();
        /// <summary>
        /// Получение данных о полах
        /// </summary>
        /// <returns>
        /// Лист с данными о полах
        /// </returns>
        public List<Bloods> GetBloods()
        {
            return db.context.Bloods.ToList();
        }
    }
}

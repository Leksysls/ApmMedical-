using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCheckLib
{
    /// <summary>
    /// Проверка правильности заполнения полей
    /// </summary>
    public class StringCheckClass
    {
        Regex regex;
        Match match;
        /// <summary>
        /// Проверка правильности Email
        /// </summary>
        /// <param name="emailString">Email</param>
        /// <returns>
        /// true - если Email верный
        /// false - если Email неверный
        /// </returns>
        public bool EmailCheck(string emailString)
        {
            regex = new Regex(@"^[_a-z0-9-\+-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,})$");
            match = regex.Match(emailString);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверка правильности пароля
        /// </summary>
        /// <param name="passwordString">Пароль</param>
        /// <returns>
        /// true - если пароль верный
        /// false - если пароль неверный
        /// </returns>
        public bool PasswordCheck(string passwordString)
        {
            regex = new Regex(@"(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[a-z])(?=.*[A-Z])[0-9a-zA-Z!@#$%^&*]{6,}");
            match = regex.Match(passwordString);
            if (match.Success)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Проверка правильности имени
        /// </summary>
        /// <param name="nameString">Имя</param>
        /// <returns>
        /// true - если имя верное
        /// false - если имя неверное
        /// </returns>
        public bool NameCheck(string nameString)
        {
            regex = new Regex(@"^[а-яА-Я\sa-zA-Z]{3,}$");
            match = regex.Match(nameString);
            if (match.Success)
                return true;
            else
                return false;
        }

    }
}
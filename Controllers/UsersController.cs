using ApmMedical.Models;
using StringCheckLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApmMedical.Controllers
{
    public class UsersController
    {
        
        Core db = new Core();



            /// <summary>
            /// Получение данных всех пользователей из БД
            /// </summary>
            /// <returns>
            /// Возвращает массив с данными пользователей
            /// </returns>
            public List<Users> GetUsers()
            {
                List<Users> userList = db.context.Users.ToList();
                return userList;
            }


        /// <summary>
        /// Добавление нового пользователя в БД
        /// </summary>
        /// <param name="userEmail">Входная строка содержащая Email пользователя</param>
        /// <param name="userFirstName">Входная строка содержащая имя пользователя</param>
        /// <param name="userLastName">Входная строка содержащая фамилию пользователя</param>
        /// <param name="userOtherName">Входная строка содержащая отчество пользователя</param>
        /// <param name="roleId">ID роли пользователя</param>
        /// <param name="userPassword">Пароль пользователя</param>
        /// <returns>
        /// Возврашает ID добаленного пользователя
        /// </returns>
        public int AddUser(string userEmail, string userFirstName, string userLastName, string userOtherName,  int roleId, string userPassword)
        {
            try
            {
                Users newUser = new Users
                {
                    login = userEmail,
                    user_firstname = userFirstName,
                    user_lastname = userLastName,
                    user_othername = userOtherName,
                    id_role = roleId,
                    password = userPassword
                };

                db.context.Users.Add(newUser);
                db.context.SaveChanges();

                return GetUserId(userEmail);
            }
            catch
            {
                throw new Exception("Произошла ошибка при добалении нового пользователя!");
            }
        }

        /// <summary>
        /// Проверка Email на совпадение в БД
        /// </summary>
        /// <param name="checkedEmail">
        /// Проверяемый Email
        /// </param>
        /// <returns>
        /// Возвращает:
        /// true - если совпадений не найдено
        /// false - если найдено совпадение
        /// </returns>
        public bool CheckEmailDuplication(string checkedEmail)
        {
            int usersCount = GetUsers().Where(x => x.login == checkedEmail).Count();
            if (usersCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        

        /// <summary>
        /// Обновление данных пользователя в БД
        /// </summary>
        /// <param name="email">
        /// Email пользователя
        /// </param>
        /// <param name="firstname">
        /// Имя пользователя
        /// </param>
        /// <param name="lastname">
        /// Фамилия пользователя
        /// </param>
        /// <param name="othername">
        /// Отчество пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <returns>
        /// Возвращает:
        /// true - если обновление произошло успешно
        /// Exception("Ошибка при изменении данных пользователя.") - если при обновлении произошла ошибка
        /// </returns>
        public bool UpdateUserInfo(string email, string firstname, string lastname, string othername,  string password)
        {
            try
            {
                Users currentUser = db.context.Users.Where(x => x.login == email).FirstOrDefault();

                currentUser.user_firstname = firstname;
                currentUser.user_lastname = lastname;
                currentUser.user_othername = othername;
                


                if (!String.IsNullOrWhiteSpace(password))
                {
                    currentUser.password = password;
                }

                db.context.SaveChanges();
                return true;
            }
            catch
            {
                throw new Exception("Ошибка при изменении данных пользователя.");
            }
        }

        /// <summary>
        /// Получение ID пользователя
        /// </summary>
        /// <param name="userEmail">
        /// Входная строка содержащая Email пользователя
        /// </param>
        /// <returns>
        /// Возвращает ID пользователя
        /// </returns>
        public int GetUserId(string userEmail)
        {
            try
            {
                return GetUsers().Where(x => x.login == userEmail).FirstOrDefault().id_user;
            }
            catch
            {
                throw new Exception("Ошибка при выводе ID пользователя!");
            }
        }

        /// <summary>
        /// Получении данных пользователей по роли
        /// </summary>
        /// <param name="roleId">
        /// Роль пользователей
        /// </param>
        /// <returns>
        /// Возвращает лист данных пользователей
        /// </returns>
        public List<Users> GetUsersByRole(int roleId)
        {
            return GetUsers().Where(x => x.id_role == roleId).ToList();
        }



        /// <summary>
        /// Логика авторизации 
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Auth(string login, string password)
        {
            
                StringCheckClass isLogin = new StringCheckClass();
                bool isCorrectLogin = isLogin.EmailCheck(login);
                StringCheckClass isPass = new StringCheckClass();
                bool isCorrcetPass = isPass.PasswordCheck(password);

                if (isCorrectLogin != true || isCorrcetPass != true)
                {

                MessageBox.Show("Некоректно заполнены поля");
                    return false;
                }
                
                var user = db.context.Users.AsNoTracking().FirstOrDefault(u => (u.login == login) && (u.password == password));
                if (user == null)
                {
                    
                    MessageBox.Show("Пользователя с такими данными не существует");
                    return false;
                }

                return true;
            
            
        }
    }

}

    

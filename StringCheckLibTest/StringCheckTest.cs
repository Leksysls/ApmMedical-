using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringCheckLib;

namespace StringCheckLibTest
{
    [TestClass]
    public class StringCheckTest
    {
        /// <summary>
        /// Проверка строки Логина(Email) на пустую строку
        /// </summary>
        [TestMethod]
        public void CheckEmail_Empty_ReturnFalse()
        {
            ///Arrange 
            string emptyString = String.Empty;
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezEmail = isLastName.EmailCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezEmail);

        }
        /// <summary>
        /// Проверка строки Логина(Email) на правильный логин
        /// </summary>
        [TestMethod]
        public void CheckEmail_isLatinSpaceTire_ReturnTrue()
        {
            ///Arrange
            string emptyString = "email@mail.ru";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezEmail = isLastName.EmailCheck(emptyString);
            ///Assert
            Assert.IsTrue(rezEmail);

        }
        /// <summary>
        /// Проверка строки Логина(Email) на не правильный логин
        /// </summary>
        [TestMethod]
        public void CheckEmail_isLatinFailName_ReturnFalse()
        {
            ///Arrange
            string emptyString = "em@a.,il@ma@il.ru";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezEmail = isLastName.EmailCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezEmail);

        }
        /// <summary>
        /// Проверка строки Логина(Email) на русские буквы в логине
        /// </summary>
        [TestMethod]
        public void CheckEmail_isRusBukvi_ReturnFalse()
        {
            ///Arrange
            string emptyString = "емаил@маил.ru";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezEmail = isLastName.EmailCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezEmail);

        }
        /// <summary>
        /// Проверка строки Логина(Email) на Спец символы в логине
        /// </summary>
        [TestMethod]
        public void CheckEmail_isSpecSimbols_ReturnFalse()
        {
            ///Arrange
            string emptyString = "em%$#ail@mail.ru";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezEmail = isLastName.EmailCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezEmail);

        }
        /// <summary>
        /// Проверка строки пароля(Password) на пустую строку
        /// </summary>
        [TestMethod]
        public void CheckPassword_Empty_ReturnFalse()
        {
            ///Arrange 
            string emptyString = String.Empty;
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezPass = isLastName.PasswordCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezPass);

        }
        /// <summary>
        /// Проверка строки пароля(Password) на русские буквы в пароле
        /// </summary>
        [TestMethod]
        public void CheckPassword_isRusSimbol_ReturnFalse()
        {
            ///Arrange 
            string emptyString = "абракодабра123";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezPass = isLastName.PasswordCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezPass);

        }
        /// <summary>
        /// Проверка строки пароля(Password) на спец символы в пароле 
        /// </summary>
        [TestMethod]
        public void CheckPassword_isSpecSimbol_ReturnFalse()
        {
            ///Arrange 
            string emptyString = "chapa%lax";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezPass = isLastName.PasswordCheck(emptyString);
            ///Assert
            Assert.IsFalse(rezPass);

        }
        /// <summary>
        /// Проверка строки пароля(Password) на правильный пароль
        /// </summary>
        [TestMethod]
        public void CheckPassword_isLatinSpaceTire_ReturnTrue()
        {
            ///Arrange 
            string emptyString = "chapalax123";
            ///Act
            StringCheckClass isLastName = new StringCheckClass();
            bool rezPass = isLastName.PasswordCheck(emptyString);
            ///Assert
            Assert.IsTrue(rezPass);

        }




    }
}


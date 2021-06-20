using System;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringCheckLib
{
    public class FileManagerClass
    {
        /// <summary>
        /// Получение пути до файла
        /// </summary>
        /// <param name="title">Заголовок - диалогового окна</param>
        /// <param name="filter">Фильтр - диалогового окна</param>
        /// <param name="openFile">Диалоговое окно</param>
        /// <returns>
        /// Путь до выбранного файла
        /// </returns>
        private string GetFilePath(string title, string filter, OpenFileDialog openFile)
        {
            openFile.Title = title;
            openFile.Filter = filter;
            if (openFile.ShowDialog() == true)
            {
                return openFile.FileName;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Получение пути до файла
        /// </summary>
        /// <param name="title">Заголовок - диалогового окна</param>
        /// <param name="filter">Фильтр - диалогового окна</param>
        /// <param name="saveFile">Диалоговое окно</param>
        /// <returns>
        /// Путь до выбранного файла
        /// </returns>
        private string GetFilePath(string title, string filter, SaveFileDialog saveFile)
        {
            saveFile.Title = title;
            saveFile.Filter = filter;
            if (saveFile.ShowDialog() == true)
            {
                return saveFile.FileName;
            }
            else
            {
                return null;
            }
        }

       

        /// <summary>
        /// Выгрузка заданных данных в CSV файл
        /// </summary>
        /// <param name="data">
        /// Словарь с выгружаемыми данными
        /// </param>
        /// <returns>
        /// true - если выгрузка прошла успешно
        /// false - если выгрузка не произошла
        /// Exception("Произошла ошибка при сохранении данных") - если произошла ошибка
        /// </returns>
        public bool DownLoadToCsvFile(Dictionary<string, List<string>> data)
        {
            SaveFileDialog file = new SaveFileDialog();
            string nameFile = GetFilePath("Сохранение файла csv", "Text files(.csv)|.csv", file);
            if (nameFile != null)
            {
                try
                {
                    using (StreamWriter wr = new StreamWriter(nameFile,true,Encoding.UTF8))
                    {

                        wr.WriteLine(String.Join(";", data.Keys.ToList()));


                        List<List<string>> dataValues = data.Values.ToList();
                        for (int i = 0; i < dataValues[0].Count; i++)
                        {
                            List<string> dataRow = new List<string>();
                            foreach (var item in data.Keys.ToList())
                            {
                                dataRow.Add(data[item][i]);
                            }
                            wr.WriteLine(String.Join(";", dataRow));
                        }
                    }
                    return true;
                }
                catch
                {
                    throw new Exception("Произошла ошибка при сохранении данных");
                }
            }

            return false;
        }
    }
}

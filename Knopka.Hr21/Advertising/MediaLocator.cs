using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Knopka.Hr21.Advertising
{
    public class MediaLocator
    {
        public List<string> StrForFiles = new List<string>();
        // В конструктор передаются данные о рекламоносителях и локациях.
        // ===== пример данных =====
        // Яндекс.Директ:/ru
        // Бегущая строка в троллейбусах Екатеринбурга:/ru/svrd/ekb
        // Быстрый курьер:/ru/svrd/ekb
        // Ревдинский рабочий:/ru/svrd/revda,/ru/svrd/pervik
        // Газета уральских москвичей:/ru/msk,/ru/permobl/,/ru/chelobl
        // ===== конец примера данных =====
        // inputStream будет уничтожен после вызова конструктора.
        public MediaLocator(Stream inputStream)
        {
            using (StreamReader reader = new StreamReader(inputStream))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    StrForFiles.Add(line);
                }
            }
        }

        // В метод передаётся локация.
        // Надо вернуть все рекламоносители, которые действуют в этой локации.
        // Например, GetMediasForLocation("/ru/svrd/pervik") должен вернуть две строки:
        // "Яндекс.Директ", "Ревдинский рабочий"
        // Порядок строк не имеет значения.
        public IEnumerable<string> GetMediasForLocation(string location)
        {
            List<string> outResult = new List<string>();
            foreach (string strLn in StrForFiles)
            {
                string out_rek = returnStr(strLn, location);
                if (out_rek != null) 
                {
                    outResult.Add(out_rek);
                }
            }
            return outResult;
        }

        private string returnStr(string line, string strLocation)
        {
            string res = null;
            string[] strM = line.Split(":")[1].Split(",");
            if (strM.Length != 0)
            {
                foreach (string obj in strM)
                {
                    string pattern = obj;
                    Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                    MatchCollection matches = regex.Matches(strLocation);
                    if (matches.Count != 0)
                    {
                        res = line.Split(":")[0];
                    }
                }
            }
            return res;
        }
    }
}
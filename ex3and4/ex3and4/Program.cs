using System;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace ex3and4
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////
            // ЗАДАНИЕ 3
            ///////////////////////////////////////
            /*
            //min max avegare
            List<float> bal = new List<float>();
            StreamReader sr = File.OpenText("humans.txt");
            string rl = "";

            while ((rl = sr.ReadLine()) != null)
            {
                string[] words = rl.Split(new char[] { ' ' });
                bal.Add(float.Parse(words[4]));
            }
            var minValue = bal.Min();
            var maxValue = bal.Max();
            var averageValue = bal.Average();

            Console.WriteLine("Минимальный балл - " + minValue + " Максимальный балл - " + maxValue + " Средний балл - " + averageValue);
           
            
            //sort
            List<Students> st = new List<Students>();
            List<string> hum = new List<string>();
            string[] endReadFile = File.ReadAllLines("humans.txt");
           
            foreach (var str in endReadFile)
            {
                hum.AddRange(str.Split(' '));
                st.Add(new Students
                {
                    LastName = hum[0],
                    Name = hum[1],
                    Otchestvo = hum[2],
                    Group = hum[3],
                    Greate = Convert.ToDouble(hum[4])
                });
                hum.Clear();
            }
           
            Console.WriteLine("Как хотите отсортировать список? :");
            Console.WriteLine("1 - По имени\n2 - По группе\n3 - По баллу");
            int Choise = Convert.ToInt32(Console.ReadLine());
            var sort = st.OrderBy(i => i.Name);
            switch(Choise)
            {
                case 1:
                    sort = st.OrderBy(i => i.Name);
                    break;
                case 2:
                    sort = st.OrderBy(i => i.Group);
                    break;
                case 3:
                    sort = st.OrderBy(i => i.Greate);
                    break;
                default:
                    Console.WriteLine("Вы ошиблись :(");
                    break;
            }

            if (Choise > 0 && Choise < 4)
            {
                foreach (var item in sort)
                {
                    Console.WriteLine(item.LastName + " " + item.Name + " " + item.Otchestvo + " " + item.Group + " " + item.Greate);
                    File.AppendAllText("humans.txt", String.Format(item.LastName + " " + item.Name + " " + item.Otchestvo + " " + item.Group + " " + item.Greate));
                }
            }
            else Console.WriteLine("Вам стоит попробовать заново");
            
            sr.Close();
            */
            ///////////////////////////////////////
            //ЗАДАНИЕ 4
            ///////////////////////////////////////
            List<string> hum = new List<string>();
            List<Students> st = new List<Students>();
            StreamReader sr = File.OpenText("humans.txt");
            string[] endReadFile = File.ReadAllLines("humans.txt");
            foreach (var str in endReadFile)
            {
                hum.AddRange(str.Split(' '));
                st.Add(new Students
                {
                    LastName = hum[0],
                    Name = hum[1],
                    Otchestvo = hum[2],
                    Group = hum[3],
                    Greate = Convert.ToDouble(hum[4])
                });
                hum.Clear();
            }
            //группировка по группе людей с балом выше 4
            var studentsGroups = st.GroupBy(p => p.Group).Select(g => new { Group = g.Key, Greate = g.Count(a => a.Greate > 4), LastName = g.Select(p => p).Where(a => a.Greate > 4), Name = g.Select(p => p).Where(a => a.Greate > 4), Otchestvo = g.Select(p => p).Where(a => a.Greate > 4) });
            //вывод результата
            foreach (var group in studentsGroups)
            {
                Console.WriteLine($"{group.Group} : {group.Greate}");
                //foreach (Students find in st.Where(a => a.Greate > 4))
                    foreach (var item in group.LastName)
                        Console.WriteLine(item.LastName + " " + item.Name + " " + item.Otchestvo);
                Console.WriteLine();
            }
            sr.Close();
        }
    }
}

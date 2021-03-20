using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    class Quest
    {
        int counter;
        public List<Animals> AnimalsColl { get; set; }
        public Quest(string filePath)
        {
            AnimalsColl = new List<Animals>();


            using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
            {
                String line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] textArray = line.Split(',');
                    var animals = new Animals
                    {
                        NamePerson = textArray[0],
                        TypeAnim = textArray[1],
                        NameAnimal = textArray[2],
                        Age = Convert.ToInt32(textArray[3])

                    };
                    if (animals.NameAnimal == "") animals.NameAnimal = "безымянный";
                    AnimalsColl.Add(animals);
                    counter++;
                }
            }
        }
        public int CounTypesAnimal(string nameType, string namePerson) => AnimalsColl.Where(p => p.TypeAnim == nameType & p.NamePerson == namePerson).Count();
        public int Count(string name) => AnimalsColl.Where(p => p.NameAnimal == name).Count();
        public int OldAge(string name)
        {
            int max = AnimalsColl[0].Age;
            for (int i = 0; i < AnimalsColl.Count; i++)
            {
                if (AnimalsColl[i].TypeAnim == name)
                {
                    max = AnimalsColl[i].Age;
                    continue;
                }
            }
            for (int i = 0; i < AnimalsColl.Count; i++)
            {
                if (AnimalsColl[i].TypeAnim == name)
                {
                    if (max < AnimalsColl[i].Age)
                    {
                        max = AnimalsColl[i].Age;
                    }
                }

            }
            return max;
        }
        public int YoungAge(string name)
        {
            int min = AnimalsColl[0].Age;
            for (int i = 0; i < AnimalsColl.Count; i++)
            {
                if (AnimalsColl[i].TypeAnim == name)
                {
                    min = AnimalsColl[i].Age;
                    continue;
                }
            }
            for (int i = 0; i < AnimalsColl.Count; i++)
            {
                if (AnimalsColl[i].TypeAnim == name)
                {
                    if (min > AnimalsColl[i].Age)
                    {
                        min = AnimalsColl[i].Age;
                    }
                }

            }
            return min;
        }
        public int AnimPers(string NamePers)
        {
            List<string> ts = new List<string>();
            for (int i = 0; i < AnimalsColl.Count; i++)
            {
                if (AnimalsColl[i].NamePerson == NamePers)
                {
                    ts.Add(AnimalsColl[i].TypeAnim);
                }
            }
           

            return ts.Distinct().Count();
        }
        public void PersAnim(string NameAnim)
        {
            List<string> ts = new List<string>();
            for (int i = 0; i < AnimalsColl.Count; i++)
            { 
                if(AnimalsColl[i].TypeAnim == NameAnim)
                    ts.Add(AnimalsColl[i].NamePerson);
            }
           ts = ts.Distinct().ToList();
            for (int i = 0; i < ts.Count; i++)
            {
                Console.WriteLine(ts[i]);
            }
        }
        public int AnimalCount(string Klicha)
        {
            List<string> ts = new List<string>();
            for (int i = 0; i < AnimalsColl.Count; i++)
            { 
                if(AnimalsColl[i].NameAnimal == Klicha)
                {
                    ts.Add(AnimalsColl[i].TypeAnim);
                }
            }
           
            return ts.Distinct().Count();
        }
    }
    class Animals
    {
        public string NamePerson { get; set; }
        public string TypeAnim { get; set; }
        public string NameAnimal { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{NamePerson} {TypeAnim} {NameAnimal} {Age}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Quest session = new Quest(@"C:\Users\nanan\RiderProjects\Animals\Animals\Input.txt");
            foreach (var ind in session.AnimalsColl)
                Console.WriteLine(ind.ToString());

            Console.WriteLine("=========1==========");
            Console.WriteLine("Введите имя владельца");
            string namepers = Console.ReadLine();
            Console.WriteLine(session.AnimPers(namepers));


            Console.WriteLine("=========2==========");
            Console.WriteLine("Введите вид животного");
            string animname = Console.ReadLine();
            session.PersAnim(animname);

            Console.WriteLine("=========3==========");
            Console.WriteLine("Введите кличку");
            string klick1 = Console.ReadLine();

            Console.WriteLine(session.AnimalCount(klick1));

            Console.WriteLine($"Самая молодая крыса {session.YoungAge("крыса")}, Самая старая крыса {session.OldAge("крыса")}");

















        // Console.WriteLine("Введите тип животного");
            // string typeAnimal = Console.ReadLine();
            // Console.WriteLine("Введите имя владельца");
            // string namePersone = Console.ReadLine();
            // int c = session.CounTypesAnimal(typeAnimal, namePersone);
            // //  животные определенного типа у заданного владельца
            // Console.WriteLine("У владельца {0}  {1} - {2}", namePersone, typeAnimal, c);
            // Console.WriteLine("====================");
            //
            // Console.WriteLine("Введите кличку");
            // string klick = Console.ReadLine();
            // int con = session.Count(klick);
            // // сколько раз встречается заданная кличка
            // Console.WriteLine($"{klick} встречается {con} раз");
            // Console.WriteLine("====================");
            // Console.WriteLine("Введите тип животного для поиска самого старого:");
            // string typeAnim = Console.ReadLine();
            // int con_2 = session.OldAge(typeAnim);
            // Console.WriteLine("Введите тип животного для поиска самого молодого:");
            // string typeAnimyoung = Console.ReadLine();
            // int con_young = session.YoungAge(typeAnimyoung);
            // Console.WriteLine("[Old] + Возраст {1} вида {0}", typeAnim, con_2);
            // Console.WriteLine("[Young] + Возраст {1} вида {0}", typeAnimyoung, con_young);
            // Console.ReadKey();
        }
    }


}
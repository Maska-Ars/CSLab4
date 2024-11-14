using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


class Tests
{
    public static void Test1()
    {
        Console.WriteLine("Тест задания 1");

        List<dynamic> l1 = new List<dynamic>() { 1, 2, 3 };
        List<dynamic> l2 = new List<dynamic>() { 4, 5, 6 };

        Console.Write("l1: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Console.Write("l2: ");
        foreach (int i in l2)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Lab4.Task1(l1, l2);
        Console.Write("l1 с l2: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine();


        l1.Clear();
        l2.Clear();

        l1 = new List<dynamic>() { 4, 5, 6 };
        l2 = new List<dynamic>() { 1, 2, 3 };

        Console.Write("l1: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Console.Write("l2: ");
        foreach (int i in l2)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Lab4.Task1(l1, l2);
        Console.Write("l1 с l2: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine();


        l1.Clear();
        l2.Clear();

        l1 = new List<dynamic>() { 1, 3, 6 };
        l2 = new List<dynamic>() { 2, 4, 5 };

        Console.Write("l1: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Console.Write("l2: ");
        foreach (int i in l2)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Lab4.Task1(l1, l2);
        Console.Write("l1 с l2: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine();


        l1.Clear();
        l2.Clear();

        Console.Write("l1: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Console.Write("l2: ");
        foreach (int i in l2)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();

        Lab4.Task1(l1, l2);
        Console.Write("l1 с l2: ");
        foreach (int i in l1)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine();

    }

    public static void Test2()
    {
        Console.WriteLine("Тест задания 2");

        List<dynamic> l = new List<dynamic>() { 
            1, 2, 1, 3, 1
        };

        LinkedList<dynamic> ll = new LinkedList<dynamic>(l);
        Console.Write("l: ");
        foreach (var i in ll)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine($"Количество элементов с равными соседями: {Lab4.Task2(ll)}");
        Console.WriteLine();

        l = new List<dynamic>() {
            "a", "b", "c", 1
        };

        ll = new LinkedList<dynamic>(l);
        Console.Write("l: ");
        foreach (var i in ll)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine($"Количество элементов с равными соседями: {Lab4.Task2(ll)}");
        Console.WriteLine();

        l = new List<dynamic>();

        ll = new LinkedList<dynamic>(l);
        Console.Write("l: ");
        foreach (var i in ll)
        {
            Console.Write($"{i}, ");
        }
        Console.WriteLine();
        Console.WriteLine($"Количество элементов с равными соседями: {Lab4.Task2(ll)}");
        Console.WriteLine();



    }

    public static void Test3()
    {
        Console.WriteLine("Тест задания 3");
        HashSet<string> dishes = new HashSet<string>() {
            "пицца", "суп", "салат", "десерт", "напиток"
        };

        List<List<string>> visitorOrders = new List<List<string>>() { 
            new List<string>() { "суп", "салат", "напиток" },
            new List<string>() { "салат", "напиток" },
            new List<string>() { "десерт", "напиток" },
            new List<string>() { "салат", "напиток"},
            new List<string>() { "напиток" }

        };

        Console.Write("Блюда в меню: ");
        foreach (string dish in dishes) 
        { 
            Console.Write($"{dish}, ");
        }
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Заказы посетителей:");
        foreach (List<string> order in visitorOrders)
        {
            foreach (string dish in order)
            {
                Console.Write($"{dish}, ");
            }


            Console.WriteLine();
        }

        Console.WriteLine();

        Lab4.Task3(dishes, visitorOrders);


    }

    public static void Test4()
    {
        Console.WriteLine("Тест задания 4");
        for (int i = 0; i < 3; i++) 
        {
            Lab4.Task4($"test4_{i+1}.txt");
        }
    }


    public static List<Person> GenPeople()
    {
        string[] secondNames = new string[10] {
            "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов",
            "Попов", "Соколов", "Васильев", "Зайцев", "Морозов"
        };

        string[] names = new string[10] {
            "Александр", "Максим", "Дмитрий", "Иван", "Сергей",
            "Алексей", "Андрей", "Антон", "Евгений", "Владислав"
        };

        Random random = new Random();

        List<Person> people = [];

        foreach (string secondName in secondNames)
        {
            foreach (string name in names)
            {
                Person person = new Person();
                person.name = name;
                person.secondName = secondName;

                int[] marks = new int[4];

                for (int i = 0; i < 4; i++)
                {
                    marks[i] = random.Next(0, 10);
                }

                person.marks = marks;


                people.Add(person);
            }
        }
        return people;
    }

    public static void WriteXML(List<Person> people, string file)
    {

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));

        FileStream fs = new FileStream(file, FileMode.OpenOrCreate);

        xmlSerializer.Serialize(fs, people);
        fs.Close();

    }

    public static void Test5()
    {
        List<Person> people = GenPeople();
        WriteXML(people, "test5.xml");

        Lab4.Task5("test5.xml");

    }
}


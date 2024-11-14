using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;


class Lab4
{
    public static void Task1(List<dynamic> l1, List<dynamic> l2)
    {
        int j = 0;
        int i = 0;
        while (j != l2.Count)
        {
            while (i != l1.Count && l1[i] < l2[j])
            {
                i++;
            }
            if (i == l1.Count) { l1.Add(l2[j]); }
            else { l1.Insert(i, l2[j]); }
            
            j++;
        }
    }

    public static int Task2(LinkedList<dynamic> l)
    {
        int k = 0;

        var currentNode = l.First;

        while (currentNode != null)
        {
            if (currentNode.Previous != null && currentNode.Next != null && Equals(currentNode.Next.Value,currentNode.Previous.Value))
            {
                k++;
            }
            currentNode = currentNode.Next;
        }
        return k;
    }

    public static void Task3(HashSet<string> dishes, List<List<string>> visitorOrders)
    {
        Dictionary<string, int> kd = new Dictionary<string, int>();
        foreach (string dish in dishes) 
        {
            kd.Add(dish, 0);
        }

        foreach (List<string> order  in visitorOrders) 
        { 
            foreach (string dish in dishes)
            {
                if (order.Contains(dish))
                {
                    kd[dish] += 1;
                }
            }
        }

        Console.Write("Все заказали: ");
        foreach (var dish in kd)
        {
            if (dish.Value == visitorOrders.Count) 
            { 
                Console.Write($"{dish.Key}, ");
                kd.Remove(dish.Key);
            
            }
        }
        Console.WriteLine();
        Console.Write("Некоторые заказали: ");
        foreach (var dish in kd)
        {
            if (dish.Value != 0)
            {
                Console.Write($"{dish.Key}, ");
                kd.Remove(dish.Key);
            }
        }
        Console.WriteLine();
        Console.Write("Никто не заказал: ");
        foreach (var dish in kd)
        {
            Console.Write($"{dish.Key}, ");
        }
        Console.WriteLine();


    }

    public static void Task4(string file)
    {
        string text;

        if (!File.Exists(file)) 
        {
            Console.WriteLine("Данного файла не существует!");
            return;
        }


        StreamReader reader = new StreamReader(file);
        text = reader.ReadToEnd();

        reader.Close();


        Console.WriteLine($"Текст в файле {file}:");
        Console.WriteLine(text);
        Console.WriteLine();


        text = text.ToLower();

        string[] words = text.Split(' ');

        HashSet<char> set = new HashSet<char>() { 
            'б', 'в', 'г', 'д', 'ж', 'з', 'й', 'к', 'л', 'м', 'н', 'п', 'р', 'с', 'т', 'ф', 'х', 'ц', 'ч', 'ш', 'щ' 
        };

        foreach (char c in set)
        {
            int k = 0;
            foreach (string word in words)
            {
                if (word.Contains(c)) { k++; }
            }
            if (k != 1) { set.Remove(c); }
        }

        Console.WriteLine($"Согласные буквы входящие ровно в одно слово: {string.Join(", ",set)}");
        Console.WriteLine();
    }

    private static List<Person> ReadXML(string file)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Person>));
        FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
        
        fs.Position = 0;

        List<Person>? l = xmlSerializer.Deserialize(fs) as List<Person>;

        fs.Close();

        if (l is null)
        {
            return [];
        }

        return l;
        
    }

    public static void Task5(string file)
    {

        if (!File.Exists(file))
        {
            Console.WriteLine("Данного файла не существует!");
            return;
        }

        List<Person> people = ReadXML(file);
        SortedList<int, List<Person>> sl = new SortedList<int, List<Person>>();

        foreach (Person person in people) 
        {
            int k = 0;
            foreach (int i in person.marks) { k += i; }
            if (!sl.ContainsKey(k))
            {
                sl.Add(k, new List<Person>() { person });
            }
            else
            {
                sl[k].Add(person);
            }
            
        }

        Console.WriteLine("Победители:");
        for (int i = sl.Count - 1; i > sl.Count - 4; i--) 
        {
            Console.WriteLine($"{sl.Count-i} место: ");
            foreach (Person person in sl[sl.GetKeyAtIndex(i)])
            {
                Console.WriteLine($"{person.secondName} {person.name} {person.marks.Sum()}");
            }
        }

        Console.WriteLine();

    }
}
using System;
using System.Collections.Generic;
using System.Reflection;

namespace GarbageCollectorHomeWork
{
    class Program
    {
        static void Main(string[] args)
        {

            Type consoleType = typeof(Console);

            List<string> methods = new List<string>();

            Console.WriteLine("Все методы класса Console:");
            foreach (MethodInfo method in consoleType.GetMethods())
            {
                if (!methods.Contains(method.Name) && method.Name.Substring(0, 4) != "get_" && method.Name.Substring(0, 4) != "set_")
                {
                    Console.WriteLine($"{method.Name}");
                    methods.Add(method.Name);
                }
            }
            Console.ReadLine();
            Console.Clear();


            Book book = new Book()
            {
                Name = "Оно",
                NumberPages = 560
            };
            Type type = book.GetType();

            Console.WriteLine($"Class name = {type.Name}");
            foreach (var property in type.GetProperties())
            {
                var methodInfo = type.GetMethod($"get_{property.Name}");

                var result = methodInfo.Invoke(book, new object[0]);
                Console.WriteLine($"{property.Name} = {result}");

            }

            Console.ReadLine();
            Console.Clear();





            int length = new int(), startIndex = new int();
            Type stringType = typeof(String);

            
            MethodInfo methodSubstr = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int)});

            Console.Write($"Строка: ");
            string myString = Console.ReadLine();
            Console.Write("Введите начальный индекс: ");

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out startIndex) && startIndex >=0)
                    break;
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение!!!");
                    Console.Clear();
                }
            }
            while (true)
            {
                Console.Write("Введите длину: ");
                if (int.TryParse(Console.ReadLine(), out length) && length + startIndex <= myString.Length && length >=0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели неправильное значение!!!");
                    Console.Clear();
                }
            }

            Console.WriteLine(methodSubstr.Invoke(myString, new object[] { startIndex, length }));

            Console.ReadLine();
            Console.Clear();


            Type listType = typeof(List<>);
            foreach (ConstructorInfo constructor in listType.GetConstructors())
            {
                if (constructor.IsPublic)
                    Console.Write("Public");
                else if ((constructor.IsPrivate))
                    Console.Write("Private");
                if (constructor.IsStatic)
                    Console.Write(" Static ");
                Console.Write($"{constructor.Name} (");
                foreach (var parametr in constructor.GetParameters()) {
                    Console.Write($" {parametr.ParameterType} {parametr.Name} ");
                }
                Console.Write(")\n");

            }

        }


    }
}

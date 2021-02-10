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
        }
    }
}

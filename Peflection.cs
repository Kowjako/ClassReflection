using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main()
        {
            Type myType = Type.GetType("ConsoleApplication14.User", false, true);
            Console.WriteLine("All Methods : ");
            foreach(MethodInfo methods in myType.GetMethods())
            {
                string modificator = "";
                if (methods.IsStatic) modificator += "static";
                if (methods.IsVirtual) modificator += "virtual";
                Console.Write($"{modificator} {methods.ReturnType.Name} {methods.Name} (");
                ParameterInfo[] param = methods.GetParameters();
                for (int i = 0; i < param.Length; i++)
                {
                    Console.Write($"{param[i].ParameterType.Name} {param[i].Name}");
                    if (i + 1 < param.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("All Constructors : ");
            foreach (ConstructorInfo methods in myType.GetConstructors())
            {
                Console.Write($"{myType.Name} (");
                ParameterInfo[] param = methods.GetParameters();
                if (param.Length == 0) Console.Write("Default Ctor");
                else
                for (int i = 0; i < param.Length; i++)
                {
                    Console.Write($"{param[i].ParameterType.Name} {param[i].Name}");
                    if (i + 1 < param.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
            Console.WriteLine("All Properties : ");
            foreach(PropertyInfo props in myType.GetProperties())
            {
                Console.WriteLine($"{props.PropertyType.Name} {props.Name}");
            }
            Console.WriteLine("All Fields : ");
            foreach(FieldInfo field in myType.GetFields())
            {
                Console.Write($"{field.FieldType.Name} {field.Name}");
            }
            Console.ReadKey();
        }
    }
    class User
    {
        public int Age { get; private set; }
        public string Name;
        public string GetName()
        {
            return Name;
        }
        public User(int a, string n)
        {
            Name = n;
            Age = a;
        }
        public User() { }
        public void Display()
        {
            Console.WriteLine($"Name = {Name} Age = {Age}");
        }
        public int Payment(int hours, int perhour)
        {
            return hours * perhour;
        }
    }
}

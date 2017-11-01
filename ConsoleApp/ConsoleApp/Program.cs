using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {

    class Program {
        static void Main(string[] args) {
            var opers = GetLibraries();

            var calc = new Calculator();

            foreach (var op in opers) {
                calc.Operations.Add(op);
            }
            for (; ; ) {
                Console.WriteLine("Выберите операцию");
                var count = 0;
                foreach (var oper in calc.Operations) {
                    Console.WriteLine($"{++count}. {oper.Name}");
                }
                try {
                    var operKey = Console.ReadLine();
                    var operId = Convert.ToInt32(operKey);
                    var operation = calc.Operations.ElementAt(operId - 1);

                    Console.WriteLine("Введите числа, над которыми хотите произвести вычисления, через \nзапятую и без пробелов");
                    var stringWithNumbers = Console.ReadLine();
                    var resultFormat = stringWithNumbers.Replace(" ", "");
                    var result = resultFormat.Split(',');

                    double[] numbers = new double[result.Length];

                    for (int i = 0; i < numbers.Length; i++) {
                        if (result[i] != "")
                            numbers[i] = Double.Parse(result[i], CultureInfo.InvariantCulture);
                    }

                    Console.WriteLine($"Результат: {operation.Excecute(numbers)}");
                } catch (ArithmeticException) {
                    Console.WriteLine("Введено недопустипое количество чисел");
                } catch (Exception ex) {
                    Console.WriteLine("Error! Введите корректные данные");
                    Console.WriteLine($"Подробнее: {ex.Message}");
                }

            }
        }

        static IEnumerable<IOperation> GetLibraries() {

            var result = new List<IOperation>();
            // найти текущую дерикторию
            var dir = Environment.CurrentDirectory + "\\Exts";
            if (!Directory.Exists(dir))
                return result;
            // найти все файлы типа *.dll
            var files = Directory.GetFiles(dir, "*.dll");
            var needType = typeof(IOperation);
            foreach (var item in files) {
                // загрузить их
                var dll = Assembly.LoadFrom(item);
                // распаристь их по классам
                var classes = dll.GetTypes();
                // найти нужные классы
                foreach (var cl in classes) {
                    var interfaces = cl.GetInterfaces();

                    if (interfaces.Any(i => i == needType)) {

                        var instance = Activator.CreateInstance(cl) as IOperation;
                        if (instance != null)
                            result.Add(instance);

                        // вывести на экран
                    }
                }
            }
            return result;
        }

    }

}

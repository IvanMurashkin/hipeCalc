using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary {
    public static class CalcHelper {

        public static IEnumerable<IOperation> GetOperations() {

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
                       // instance.IsCustom = true;
                        if (instance != null)
                            result.Add(instance);

                        // вывести на экран
                    }
                }
            }
            return result;
        }

        public static double[] StringConvert(string input) {
            return input.Split(new char[] { ' ', ',' }).Select(s => s.ToDouble()).ToArray();
        }

        static double ToDouble(this string input) {
            double result;
            if (!double.TryParse(input, out result))
                return double.NaN;

            return result;
        }

    }
}

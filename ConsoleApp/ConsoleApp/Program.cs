using CalcLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp {

    class Program {
        static void Main(string[] args) {
            Console.WriteLine("HipeCalc\n");
            Console.WriteLine("Выебрите цифру\n" +
                                "1-Сложение\n" +
                                "2-Вычитание\n" +
                                "3-Умножение\n" +
                                "4-Деление\n" +
                                "5-Остаток от деления\n" +
                                "6-Возведение в степень\n");

            switch (Console.ReadLine()) {

                case "1":
                    Console.WriteLine("Введите 1-ое число");
                    var operandSum1 = Console.ReadLine();
                    Console.WriteLine("Введите 2-ое число");
                    var opernadSum2 = Console.ReadLine();
                    var calcSum = new Calculator();
                    var resultSum = calcSum.Sum(operandSum1, opernadSum2);
                    Console.WriteLine(string.Format("Результат = {0}", resultSum));
                    break;
                case "2":
                    Console.WriteLine("Введите 1-ое число");
                    var operandSub1 = Console.ReadLine();
                    Console.WriteLine("Введите 2-ое число");
                    var opernadSub2 = Console.ReadLine();
                    var calcSub = new Calculator();
                    var resultSub = calcSub.Sub(operandSub1, opernadSub2);
                    Console.WriteLine(string.Format("Результат = {0}", resultSub));
                    break;
                case "3":
                    Console.WriteLine("Введите 1-ое число");
                    var operandMul1 = Console.ReadLine();
                    Console.WriteLine("Введите 2-ое число");
                    var opernadMul2 = Console.ReadLine();
                    var calcMul = new Calculator();
                    var resultMul = calcMul.Mul(operandMul1, opernadMul2);
                    Console.WriteLine(string.Format("Результат = {0}", resultMul));
                    break;
                case "4":
                    Console.WriteLine("Введите 1-ое число");
                    var operandDiv1 = Console.ReadLine();
                    Console.WriteLine("Введите 2-ое число");
                    var opernadDiv2 = Console.ReadLine();
                    var calcDiv = new Calculator();
                    var resultDiv = calcDiv.Div(operandDiv1, opernadDiv2);
                    Console.WriteLine(string.Format("Результат = {0}", resultDiv));
                    break;
                case "5":
                    Console.WriteLine("Введите 1-ое число");
                    var operandRemainder1 = Console.ReadLine();
                    Console.WriteLine("Введите 2-ое число");
                    var opernadRemainder2 = Console.ReadLine();
                    var calcRemainder = new Calculator();
                    var resultRemainder = calcRemainder.Remainder(operandRemainder1, opernadRemainder2);
                    Console.WriteLine(string.Format("Результат = {0}", resultRemainder));
                    break;
                case "6":
                    Console.WriteLine("Введите 1-ое число");
                    var operandPow1 = Console.ReadLine();
                    Console.WriteLine("Введите 2-ое число");
                    var opernadPow2 = Console.ReadLine();
                    var calcPow = new Calculator();
                    var resultPow = calcPow.Pow(operandPow1, opernadPow2);
                    Console.WriteLine(string.Format("Результат = {0}", resultPow));
                    break;
                default:
                    Console.WriteLine("Такой цифры нет");
                    break;
            }


            Console.ReadLine();
        }

    }

}

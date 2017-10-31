using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary {
    public interface IOperation {

        /// <summary>
        /// Название
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Mинимальное количество аргументов
        /// </summary>
        int MinArgsCount { get; }

        /// <summary>
        /// Выполнить операцию
        /// </summary>
        /// <param name="args">Входные данные</param>
        /// <returns>Результат</returns>
        double Excecute(double[] args);
    }
}

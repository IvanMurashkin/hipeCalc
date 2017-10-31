using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations {
    public abstract class BaseOperation : IOperation {

        public virtual double Excecute(double[] args) {
            if (args.Length < MinArgsCount)
                throw new ArithmeticException();
            return 0;
        }

        public abstract string Name { get; }

        public virtual int MinArgsCount => 1;

    }
}

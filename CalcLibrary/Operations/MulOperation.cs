using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations {
    public class MulOperation : BaseOperation {
        public override string Name => "Умножение";

        public override int MinArgsCount => 2;

        public override double Excecute(double[] args) {
            base.Excecute(args);

            var result = args[0];
            foreach (var num in args.Skip(1)) {
                result *= num;
            }
            return result;
        }
    }
}

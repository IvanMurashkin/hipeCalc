using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations {
    public class PowOperation : BaseOperation {
        public override string Name => "Возведение в степень";

        public override int MinArgsCount => 2;

        public override double Excecute(double[] args) {

            return Math.Pow(args[0], args[1]);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations {

    public class RemainderOperation : BaseOperation {

        public override string Name => "Остаток от деление";

        public override int MinArgsCount => 2;

        public override double Excecute(double[] args) {
            base.Excecute(args);

            return args[0] % args[1];
        }
    }

}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary.Operations {

    public class SumOperation : BaseOperation {

        public override string Name => "Сложение";

        public override double Excecute(double[] args) {
            return args.Sum();
        }
    }
}

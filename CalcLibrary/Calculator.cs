using CalcLibrary.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLibrary {
    public class Calculator {

        public Calculator() {

            Operations = new List<IOperation> {
                new SumOperation(),
                new SubOperation(),
                new MulOperation(),
                new DivOperation(),
                new PowOperation(), 
                new RemainderOperation()
            };


        }

        public IList<IOperation> Operations { get; set; }

        #region Утаревшее

        public string Sum(string x, string y) {

            double xd;
            if (!Double.TryParse(x, out xd)) {
                return "error";
            }
            double yd;
            if (!Double.TryParse(y, out yd))
                return "error";

            var sum = new SumOperation();

            var result = sum.Excecute(new double[] { xd, yd });

            return $"{result}";
        }

        public double? Sub(string x, string y) {
            double xd;
            if (!Double.TryParse(x, out xd))
                return null;
            double yd;
            if (!Double.TryParse(y, out yd))
                return null;

            double result = xd - yd;

            return result;
        }

        public double? Div(string x, string y) {

            double xd;
            if (!Double.TryParse(x, out xd))
                return null;

            double yd;
            if (!Double.TryParse(y, out yd) || yd == 0)
                return null;

            double result = xd / yd;

            return result;

        }

        public double? Mul(string x, string y) {

            double xd;
            if (!Double.TryParse(x, out xd))
                return null;

            double yd;
            if (!Double.TryParse(y, out yd))
                return null;

            double result = xd * yd;

            return result;
        }

        public double? Remainder(string x, string y) {

            double xd;
            if (!Double.TryParse(x, out xd))
                return null;
            double yd;
            if (!Double.TryParse(y, out yd) || yd == 0)
                return null;

            double result = xd % yd;

            return result;
        }

        public double? Pow(string x, string y) {

            double xd;
            if (!Double.TryParse(x, out xd))
                return null;
            double yd;
            if (!Double.TryParse(y, out yd))
                return null;

            if (xd == 0 && yd < 0)
                return null;

            double result = Math.Pow(xd, yd);

            return result;
        }
        #endregion
    }

}

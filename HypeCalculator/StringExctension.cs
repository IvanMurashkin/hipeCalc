using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeCalculator {
    public static class StringExctension {

        public static double ToDouble(this string input) {

            double result;
            if (!Double.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out result))
                return double.NaN;
            return result;

        }

    }
}

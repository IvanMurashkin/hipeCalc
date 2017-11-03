using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBModel.Model {
    public class OperationHistory {

        public OperationHistory() {}

        public OperationHistory(string name, 
                                string args, 
                                double? result, 
                                long excecTime) {
            Name = name;
            Args = args;
            Result = result;
            ExcecTime = excecTime;
                
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Args { get; set; }
        public double? Result { get; set; }
        public long ExcecTime { get; set; }

    }
}

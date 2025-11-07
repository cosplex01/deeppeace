using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace deeppeace.PeaceModel
{
    class PeaceModel
    {
        public int CloseTime { get; set; }
        public string ProgramName { get; set; }        

        public PeaceModel(string name, int time)
        {
            this.ProgramName = "Deep Sleep";
            this.CloseTime = 5;

            ProgramName = name;
            CloseTime = time;            
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife {
    public class NewGenerationEventArgs : EventArgs {
        public LifeBoard Generation { get; set; }

        public NewGenerationEventArgs(LifeBoard generation) {
            Generation = generation;
        }
    }
}

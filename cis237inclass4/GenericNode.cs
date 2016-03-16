using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237inclass4
{
    class GenericNode<TypeOfVariable>
    {
        public GenericNode<TypeOfVariable> Next
        {
            get;
            set;
        }

        public TypeOfVariable Data
        {
            get;
            set;
        }
    }
}

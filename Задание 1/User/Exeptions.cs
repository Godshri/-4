using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_1
{

namespace UserExeption
    {
        internal class UserExeption : Exception
        {
            public UserExeption(string message) : base(message) { }
        }
    }
}


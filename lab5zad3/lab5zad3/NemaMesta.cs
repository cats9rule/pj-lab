using System;
using System.Collections.Generic;
using System.Text;

namespace lab5zad3
{
    class NemaMesta : Exception
    {
        public NemaMesta(string poruka) : base(poruka) { }
    }
}

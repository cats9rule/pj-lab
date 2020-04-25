using System;

namespace lab4zad3
{
    class Program
    {
        static void Main()
        {
			Sajam s = new Sajam(3);

			Audi a1 = new Audi();
			s.Parkiraj(a1); // dodace na [0][0]

			BMW b1 = new BMW();
			s.Parkiraj(b1); // dodace na [0][1]

			BMW b2 = new BMW();
			s.Parkiraj(b2); // dodace na [0][2]

			Audi a2 = new Audi();
			s.Parkiraj(a2); // dodace na [1][0]

			Audi a3 = new Audi();
			s.Parkiraj(a3); // dodace na [1][1]

			Mercedes m1 = new Mercedes();
			s.Parkiraj(m1); // dodace na [2][2]

			Mercedes m2 = new Mercedes();
			s.Parkiraj(m2); // dodace na [1][2] jer je ta prva slobodna

			s.Print();

			s.PrintAll();
		}
    }
}

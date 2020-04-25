using System;
using System.Collections.Generic;
using System.Text;

namespace lab4zad3
{
    class Sajam
    {
        private Auto[,] matrica;
        private int count;
        private int n;
       
        // property za n
        public int N 
        {
            get { return n; }
            set
            {
                n = value;
            }
        }
        
        //property za count
        public int Count
        {
            get { return count; }
            set
            {
                if(value <= N * N) // broj automobila ne moze biti veci od ukupnog broja mesta!
                {
                    count = value;
                }
                else
                {
                    Console.WriteLine("Limit exceeded!");
                    count = N * N;
                }
            }
        }
        
        // indekser - za matricu
        public Auto this[int i, int j]
        {
            get
            {
                if (matrica[i, j] != null)
                {
                    return matrica[i, j];
                }
                else return null;
            }
            set
            {
                if (matrica[i, j] == null)
                {
                    matrica[i, j] = value;
                    Count++;
                }
                else
                {
                    Console.WriteLine("Mesto nije prazno.");
                }
            }
            
        }

        
        // konstruktor
        public Sajam(int dimension) 
        {
            N = dimension;
            matrica = new Auto[N, N];
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    matrica[i, j] = null;
                }
            }
            count = 0;
        }

        // funkcija za ubacivanje automobila u sajam
        public void Parkiraj(Auto obj) 
        {
            if(Count <= N * N) // ako postoji makar 1 mesto u matrici, moci ce da smesti auto
            {
                bool smestio = false;
                int i = 0;
                switch (obj.Priority)
                {
                    case 1: // Audi
                        while( i < N && !smestio)
                        {
                            for (int j = 0; j < N; j++)
                            {
                                if (this[i, j] == null) // ako je mesto prazno, smesta auto pomocu indeksera
                                {
                                    this[i, j] = obj;
                                    smestio = true;
                                    //Count++; -- ovo se resava u indekseru this[i,j]
                                    break;
                                }
                            }
                            i++;
                        }
                        break;
                    case 2: // BMW
                        while(i<N && !smestio) // ako je prethodno smestio auto na regularno mesto, ne ulazi se u petlju
                        {
                            for (int j = 0; j < N; j++)
                            {
                                if (this[i, j] == null)
                                {
                                    this[i, j] = obj;
                                    smestio = true;
                                    //Count++;
                                    break;
                                }
                            }
                            i += 3;
                        }
                        i = N - 1;
                        while (i >= 0 && !smestio)
                        {
                            for (int j = N - 1; j >= 0; j++)
                            {
                                if (this[i, j] == null)
                                {
                                    this[i, j] = obj;
                                    smestio = true;
                                    //Count++;
                                    break;
                                }
                            }
                        }
                        break;
                    case 3: // Mercedes
                        for (i = 0; i < N; i++) // uslov glavne dijagonale: i=j => nisu potrebne dve petlje
                        {
                            if (this[i, i] == null)
                            {
                                this[i, i] = obj;
                                smestio = true;
                                //Count++;
                                break;
                            }
                        }
                        i = 0;
                        while (i<N && !smestio)
                        {
                            for (int j = 0; j < N; j++)
                            {
                                if (this[i, j] == null)
                                {
                                    this[i, j] = obj;
                                    smestio = true;
                                    //Count++;
                                    break;
                                }
                            }
                            i++;
                        }
                        break;
                }
            }
        }
        
        // funkcija koja prikazuje celu matricu
        public void PrintAll()
        {
            Console.WriteLine("Izgled sajma: ");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Red " + (i + 1) + ":");
                for (int j = 0; j < N; j++)
                {
                    if (this[i, j] != null)
                    {
                        switch (this[i, j].Priority)
                        {
                            case 1:
                                Console.Write("| Audi |");
                                break;
                            case 2:
                                Console.Write("| BMW |");
                                break;
                            case 3:
                                Console.Write("| Mercedes |");
                                break;
                        }
                    }
                    else
                        Console.Write("| // |");
                }
                Console.WriteLine();
            }
        }
        
        // funkcija koja stampa samo popunjena mesta
        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j<N; j++){
                    if (this[i, j] != null)
                    {
                        Console.Write("| [" + i + "," + j + "] ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

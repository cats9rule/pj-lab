using lab4zad3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace lab5zad3
{
    class TMatrica<T> where T : Auto
    {
        private T[,] matrica;
        private int n;
        private int brel;

        public TMatrica(int dim) // konstruktor
        {
            n = dim;
            matrica = new T[n, n];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrica[i, j] = null;
                }
            }
            brel = 0;
        }

        public int N // property za dimenziju 
        {
            get { return n; }
            set
            {
                n = value;
            }
        }
        public int Brel
        {
            get { return brel; }
            set
            {
                if (value <= N * N) // broj automobila ne moze biti veci od ukupnog broja mesta!
                {
                    brel = value;
                }
                else
                {
                    throw new NemaMesta("Matrica je popunjena.");
                }
            }
        }
        public T this[int i, int j] // indekser
        {
            get
            {
                if (i < n && j < n)
                {
                    if (matrica[i, j] != null)
                    {
                        return matrica[i, j];
                    }
                    else return null;
                }
                else throw new Exception("Indeksi van granica.");
            }
            set
            {
                if (i < n && j < n)
                {
                    if (matrica[i, j] == null)
                    {
                        Brel++;
                        matrica[i, j] = value;
                    }
                    else
                    {
                        throw new Exception("Mesto nije prazno.");
                    }
                }
                else throw new Exception("Indeksi van granica.");
            }
        }

        //fja za dodavanje elemenata
        public void dodajElement(int i, int j, T elem)
        {
            this[i, j] = elem;
        }

        // funkcija za vracanje pokazivaca sa zadatog indeksa
        public T uzmiElement(int i, int j)
        {
            return this[i, j];
        }

        public void FlushMe() // setuje sve elemente matrice na null
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    matrica[i, j] = null;
                }
            }
            Brel = 0;
        }

        // funkcija koja stampa celu matricu
        public void PrintAll()
        {
            Console.WriteLine("Izgled matrice: ");
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

        // funkcija koja stampa samo neprazna mesta
        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (this[i, j] != null)
                    {
                        Console.Write("| [" + i + "," + j + "] ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void upisiSe() // upisuje prioritete automobila, ako nema automobila upisuje nulu
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("matrica.txt", false))
                {
                    sw.WriteLine(n);
                    for (int i = 0; i < n; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            if (this[i, j] != null)
                            {
                                sw.WriteLine(this[i, j].Priority);
                            }
                            else sw.WriteLine(0);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

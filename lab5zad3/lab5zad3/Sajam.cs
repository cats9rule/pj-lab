using lab5zad3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace lab4zad3
{
    class Sajam
    {
        private TMatrica<Auto> sala;
        private int velicina; // velicina sale, tj. dimenzija matrice

        // konstruktor
        public Sajam(int dimension) 
        {
            velicina = dimension;
            sala = new TMatrica<Auto>(dimension);
        }

        // funkcija za ubacivanje automobila u sajam
        public void Parkiraj(Auto obj)
        {
            bool smestio = false;
            int i = 0;
            switch (obj.Priority)
            {
                case 1: // Audi
                    while (i < velicina && !smestio)
                    {
                        for (int j = 0; j < velicina; j++)
                        {
                            if (sala.uzmiElement(i, j) == null) // ako je mesto prazno, smesta auto
                            {
                                sala.dodajElement(i, j, obj);
                                smestio = true;
                                break;
                            }
                        }
                        i++;
                    }
                    break;
                case 2: // BMW
                    while (i < velicina && !smestio)
                    {
                        for (int j = 0; j < velicina; j++)
                        {
                            if (sala.uzmiElement(i, j) == null)
                            {
                                sala.dodajElement(i, j, obj);
                                smestio = true;
                                break;
                            }
                        }
                        i += 3;
                    }
                    i = velicina - 1;
                    while (i >= 0 && !smestio) // ako je prethodno smestio auto na regularno mesto, ne ulazi se u petlju
                    {
                        for (int j = velicina - 1; j >= 0; j++)
                        {
                            if (sala.uzmiElement(i, j) == null)
                            {
                                sala.dodajElement(i, j, obj);
                                smestio = true;
                                break;
                            }
                        }
                    }
                    break;
                case 3: // Mercedes
                    for (i = 0; i < velicina; i++) // uslov glavne dijagonale: i=j => nisu potrebne dve petlje
                    {
                        if (sala.uzmiElement(i, i) == null)
                        {
                            sala.dodajElement(i, i, obj);
                            smestio = true;
                            break;
                        }
                    }
                    i = 0;
                    while (i < velicina && !smestio) // ako je prethodno smestio element, ne ulazi u petlju
                    {
                        for (int j = 0; j < velicina; j++)
                        {
                            if (sala.uzmiElement(i, j) == null)
                            {
                                sala.dodajElement(i, j, obj);
                                smestio = true;
                                break;
                            }
                        }
                        i++;
                    }
                    break;
            }
        }
        
        // funkcija koja prikazuje celu matricu
        public void printSala()
        {
            sala.PrintAll();
        }
        
        // funkcija koja stampa samo popunjena mesta
        public void printPopunjena()
        {
            sala.Print();
        }

        public void upisiUFajl()
        {
            sala.upisiSe();
        }

        public void ucitajIzFajla()
        {
         
            // cilj je da matrica bude ucitana iz fajla, tako da se prethodni sadrzaj brise
            sala.FlushMe();

            try
            {
                using (StreamReader sr = new StreamReader("matrica.txt"))
                {
                    int size = 0;
                    int.TryParse(sr.ReadLine(), out size);
                    if (size != velicina) // ako matrica koja se ucitava nije istih dimenzija, nema logike ucitavati
                        throw new Exception("Velicine matrica se ne poklapaju.");
                    for (int i = 0; i < velicina; i++)
                    {
                        for (int j = 0; j < velicina; j++)
                        {
                            int pr = 0; // prioritet auta
                            int.TryParse(sr.ReadLine(), out pr); 
                            switch (pr)
                            {
                                case 0:
                                    break;
                                case 1:
                                    Parkiraj(new Audi());
                                    break;
                                case 2:
                                    Parkiraj(new BMW());
                                    break;
                                case 3:
                                    Parkiraj(new Mercedes());
                                    break;
                            }
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

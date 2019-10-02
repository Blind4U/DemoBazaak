using System;
using System.Collections.Generic;
using System.Text;

namespace bazaakolio
{



    class Program
    {
               
        public const int Suurinpakkaluku = 6;
        public const int Pieninpakkaluku = 1;
        public const int Päämäärä = 20;


        static void Main(string[] args)
        {
            
            string kysymys;

            Tietokone tietokone = new Tietokone();


            // Aloitus ohjeet ja aloitus kysymys---------------------------------------------------

            Console.WriteLine("\nTervetuloa bazaak peliin!");
            Console.WriteLine("Tarkoitus on saada korttien summaksi 20 ja voittaa vastustajasi");
            Console.WriteLine("Jokaisella vuorolla voit päättää otatko uuden kortin, Jättää vuoron välistä, Käyttää bonus kortteja");
            Console.WriteLine("Tai ilmoittaa olevasi valmis. Huomio! Voit vain kerran pelin aikana ilmoittaa olevasi valmis");
            Console.WriteLine("Pelaat tietokonetta vastaan\n");


        kysymysalku:
            Console.WriteLine("Haluatko aloittaa pelin y/n");
            kysymys = Console.ReadLine();
            if (kysymys == "y")
            {
                Console.WriteLine("\nPeli aloitetaan\n");

            }
            else if (kysymys == "n")
            {
                Console.WriteLine("\nLopetetaan peli");
                goto loppu;
            }
            else
            {
                Console.WriteLine("\nEn ymmärtänyt. Sanoisitko uudestaan");
                goto kysymysalku;
            }



        alku:
            // Pelin aloitus jutut-------------------------------------------------------------------


            tietokone.valmispelaaja = false;
            tietokone.valmiskone = false;
            tietokone.valmismolemmat = false;


            tietokone.Summakone = 0;
            tietokone.Summapelaaja = 0;


            Console.WriteLine("Aloitetaan. Onnea peliin!");

            Console.WriteLine("BONUKSET EI KÄYTÖSSÄ TÄSSÄ VERSIOSSA!");

            // Peli alkaa----------------------------------------------------
            // Peli alkaa----------------------------------------------------


            while (true)
            {
                
                // tarkistetaan valmis tilat kommenteina testausta varten
                if (tietokone.valmispelaaja == true && tietokone.valmiskone == false)
                {
                    //Console.WriteLine("pelaaja valmis, kone ei");
                }
                else if (tietokone.valmispelaaja == false && tietokone.valmiskone == true)
                {
                    //Console.WriteLine("kone valmis, pelaaja ei");
                }
                else if (tietokone.valmispelaaja == true && tietokone.valmiskone == true)
                {
                    //Console.WriteLine("molemmat valmiit");
                    tietokone.valmismolemmat = true;
                }
                else if (tietokone.valmispelaaja == false && tietokone.valmiskone == false)
                {
                    //Console.WriteLine("kumpikaan ei ole valmis");
                }
                else
                {
                    Console.WriteLine("virhe, valmiit tilat error");
                }
                


                // jos molemmat valmiit lopetetaan while ja peli
                if (tietokone.valmismolemmat == true)
                {
                    break;
                }
                else
                {
                    //Console.WriteLine("while jatkuu");
                }

                // jos jompi kumpi ei ole valmis pelataan heidän vuorot kumminkin järjestyksessä
                // pelaaja
                if (tietokone.valmispelaaja == false)
                {
                    tietokone.Pelaajavuoro();
                }
                else
                {
                    //Console.WriteLine("ALKU pelaaja on valmis");
                }
                // kone
                if (tietokone.valmiskone == false)
                {
                    tietokone.Konevuoro();
                }
                else
                {
                    //Console.WriteLine("ALKU kone on valmis");
                }

            }





            // Peli loppuu----------------------------------------------------
            // Peli loppuu----------------------------------------------------

            Console.WriteLine("\nPeli loppui!");


            // Tulokset            
            tietokone.Tulokset();
                    

        // Lopetus kysymys
        kysymyslopetus:
            Console.WriteLine("\nHaluatko pelata uudestaan? y/n");
            kysymys = Console.ReadLine();
            if (kysymys == "y")
            {
                Console.WriteLine("\nPeli aloitetaan uudestaan\n");
                goto alku;
            }
            else if (kysymys == "n")
            {
                Console.WriteLine("\nLopetetaan peli");
            }
            else
            {
                Console.WriteLine("\nEn ymmärtänyt. Sanoisitko uudestaan");
                goto kysymyslopetus;
            }

        loppu:

            Console.WriteLine("\nPeli lopetettu");
        }


    }
}

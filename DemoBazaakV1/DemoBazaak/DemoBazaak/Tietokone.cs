using System;
using System.Collections.Generic;
using System.Text;

namespace bazaakolio
{
    class Tietokone
    {



        public int Päätös { get; set; }

        public bool valmispelaaja = false;
        public bool valmiskone = false;
        public bool valmismolemmat = false;

        public int summakone { get; set; }
        public int Summakone
        {
            get
            {
                return summakone;
            }
            set
            {
                summakone = value;
            }
        }

        public int summapelaaja { get; set; }
        public int Summapelaaja
        {
            get
            {
                return summapelaaja;
            }
            set
            {
                summapelaaja = value;
            }
        }


        public void Konevuoro()
        {
            Console.WriteLine("\nKoneen vuoro!");
            Console.WriteLine("Koneen summa on: " + Summakone);
            Console.WriteLine("pelaajan summa on: " + Summapelaaja);
            //Console.WriteLine("Uusi kortti, Ei korttia, Bonus kortti, Kone valmis");

            Koneif();

            switch (Päätös)
            {
                case 1:
                    //Console.WriteLine("Case 1");
                    KoneUusikortti();
                    break;
                case 2:
                    //Console.WriteLine("Case 2");
                    KoneEikortti();
                    break;
                case 3:
                    //Console.WriteLine("Case 3");
                    KoneBonuskortti();
                    break;
                case 4:
                    //Console.WriteLine("Case 4");
                    Mietintää();
                    break;
                case 10:
                    //Console.WriteLine("Case 10");
                    Konevalmis();
                    break;

                default:
                    Console.WriteLine("Default case/virhe");
                    break;
            }


        }

        public void Koneif()
        {
            Päätös = 0;

            if (Summakone == Program.Päämäärä)
            {
                Päätös = 10;
            }

            else if (Summakone != Program.Päämäärä)
            {
                if (Summakone <= 14)
                {
                    Päätös = 1;
                }
                else if (Summakone > 14 && Summakone < Program.Päämäärä)
                {
                    // bonus kortit
                    Päätös = 4;
                }
                else if (Summakone > Program.Päämäärä)
                {
                    // bonus kortit
                    Päätös = 10;
                }

            }

        }

        public void Mietintää()
        {

            // pelaaja on 20, pakko yrittää voittoa
            if (Summapelaaja == Program.Päämäärä)
            {
                //Console.WriteLine("pelaaja on päämäärä");
                // bonus kortit
                KoneUusikortti();
            }

            // pelaja ali päämäärän
            else if (Summapelaaja < Program.Päämäärä)
            {
                //Console.WriteLine("Pelaaja pienempi kuin päämäärä");
                if (Summakone == Summapelaaja)
                {
                    //Console.WriteLine("Kone tasoissa");
                    if (valmispelaaja == true)
                    {
                        //Console.WriteLine("pelaaja valmis ja Kone riski");
                        //bonus kortit
                        Koneriski();
                    }
                    else
                    {
                        //Console.WriteLine("pelaaja EI valmis ja Kone riski");
                        //bonus kortit
                        Koneriski();
                    }
                }
                else if (Summakone != Summapelaaja)
                {
                    //Console.WriteLine("Kone ja pelaaja eri");
                    if (Summakone > Summapelaaja)
                    {
                        if (valmispelaaja == true)
                        {
                            //Console.WriteLine("kone suurempi ja pelaaja valmis");
                            Konevalmis();
                        }
                        else
                        {
                            //Console.WriteLine("kone suurempi ja pelaaja EI valmis");
                            KoneEikortti();
                        }
                    }
                    else if (Summakone < Summapelaaja)
                    {
                        if (valmispelaaja == true)
                        {
                            //Console.WriteLine("kone pienempi ja pelaaja valmis");
                            // bonus kortteja
                            KoneUusikortti();
                        }
                        else
                        {
                            //Console.WriteLine("kone pienempi mutta pelaaja EI valmis");
                            // bonu kortteja
                            KoneUusikortti();
                        }
                    }
                    else
                    {
                        Console.WriteLine("cock");
                    }
                }

                else
                {
                    Console.WriteLine("ei mahdollista?");
                }
            }

            // pelaja yli päämäärän, odota bonusta
            else if (Summapelaaja > Program.Päämäärä)
            {
                //Console.WriteLine("Pelaaja suurempi kuin päämäärä");
                if (valmispelaaja == true)
                {
                    //Console.WriteLine("pelaaja on yli ja valmis");
                    Konevalmis();
                }
                else
                {
                    //Console.WriteLine("pelaaja on yli mutta ei valmis");
                    KoneEikortti();
                }
            }

            else
            {
                Console.WriteLine("virhe miettii");

            }

            //Console.WriteLine("mietintää metodi loppu");
        }

        public void Konevalmis()
        {
            Console.WriteLine("Kone valmis");
            valmiskone = true;
        }

        public void Koneriski()
        {
            Random random = new Random();
            int riski = random.Next(1, 100);

            if (Summakone == 16)
            {
                if (riski > 20)
                {
                    Console.WriteLine("Kone riski: " + riski);
                    KoneUusikortti();
                }
                else
                {
                    Console.WriteLine("Kone riski: " + riski);
                    Konevalmis();
                }
            }
            else if (Summakone == 17)
            {
                if (riski > 50)
                {
                    Console.WriteLine("Kone riski: " + riski);
                    KoneUusikortti();
                }
                else
                {
                    Console.WriteLine("Kone riski: " + riski);
                    Konevalmis();
                }

            }
            else if (Summakone == 18)
            {
                if (riski > 80)
                {
                    Console.WriteLine("Kone riski: " + riski);
                    KoneUusikortti();
                }
                else
                {
                    Console.WriteLine("Kone riski: " + riski);
                    Konevalmis();
                }

            }
            else if (Summakone == 19)
            {
                if (riski > 90)
                {
                    Console.WriteLine("Kone riski: " + riski);
                    KoneUusikortti();
                }
                else
                {
                    Console.WriteLine("Kone riski: " + riski);
                    Konevalmis();
                }

            }
            else
            {
                Console.WriteLine("Kone riski: " + riski);
                //Console.WriteLine("riski melkein mitätön, uusi kortti");
                KoneUusikortti();
            }
        }

        public void KoneUusikortti()
        {
            Console.WriteLine("Koneen uusi kortti");
            Random random = new Random();
            int arvottukortti = random.Next(Program.Pieninpakkaluku, Program.Suurinpakkaluku);
            Console.WriteLine("Koneen jaettu kortti on: " + arvottukortti);
            Summakone += arvottukortti;
            Console.WriteLine("Koneen summa on nyt: " + Summakone);
        }

        public void KoneEikortti()
        {
            Console.WriteLine("Kone Ei korttia");
        }

        public void KoneBonuskortti()
        {
            Console.WriteLine("bonus kortti");
        }

        public void Pelaajavuoro()
        {
            Console.WriteLine("\nSinun vuorosi!");
            string kysymys;

        kysymysuudestaan3:

            Console.WriteLine("Koneen summa on: " + Summakone);

            Console.WriteLine("Summasi on: " + Summapelaaja);

            Console.WriteLine("Uusi kortti hit(h), Ei uutta korttia stay(s), Käytä bonus kortti(b), Pelaaja valmis end(e)");
            kysymys = Console.ReadLine();
            int tilanne;

            // uusikortti
            if (kysymys == "h")
            {
                tilanne = 1;
            }
            // ei korttia
            else if (kysymys == "s")
            {
                tilanne = 2;
            }
            // bonuskortti
            else if (kysymys == "b")
            {
                tilanne = 3;
            }
            // vuoron lopetus
            else if (kysymys == "e")
            {
                tilanne = 10;
            }
            // virhe
            else
            {
                Console.WriteLine("En ymmärtänyt. Sanoisitko uudestaan");
                goto kysymysuudestaan3;
            }


            switch (tilanne)
            {
                case 1:
                    //Console.WriteLine("Case 1");
                    Uusikortti();
                    break;
                case 2:
                    //Console.WriteLine("Case 2");
                    Eikortti();
                    break;
                case 3:
                    //Console.WriteLine("Case 3");
                    Bonuskortti();
                    break;
                case 10:
                    //Console.WriteLine("Case 10");
                    Pelaajavalmis();
                    break;

                default:
                    Console.WriteLine("Default case/virhe");
                    break;
            }


        }

        public void Pelaajavalmis()
        {
            Console.WriteLine("Lopetetaan pelaajan vuoro");
            valmispelaaja = true;
        }

        public void Uusikortti()
        {
            Console.WriteLine("uusi kortti");
            Random random = new Random();
            int arvottukortti = random.Next(Program.Pieninpakkaluku, Program.Suurinpakkaluku);
            Console.WriteLine("Jaettu korttisi on: " + arvottukortti);
            Summapelaaja += arvottukortti;
            Console.WriteLine("Summasi on nyt: " + Summapelaaja);
        }

        public void Eikortti()
        {
            Console.WriteLine("Jäädään tähän");
        }

        public void Bonuskortti()
        {
            Console.WriteLine("bonus kortti");
        }


        public void Tulokset()
        {
            //Tietokone tietokone = new Tietokone();

            Console.WriteLine("Tulokset!");
            Console.WriteLine("Koneen summa oli: " + Summakone);
            Console.WriteLine("Sinun summasi oli: " + Summapelaaja);

            if (Summapelaaja == Summakone)
            {
                Console.WriteLine("Tasapeli!");

                if (Summapelaaja == Program.Päämäärä)
                {
                    Console.WriteLine("Molemmilla summa tasan päämäärä");
                }
                else if (Summapelaaja > Program.Päämäärä)
                {
                    Console.WriteLine("Molemmilla summa yli päämäärän");
                }
                else
                {
                    Console.WriteLine("Molemmilla summa alle päämäärän");
                }
            }
            else
            {
                if (Summapelaaja > Program.Päämäärä || Summakone > Program.Päämäärä)
                {
                    if (Summapelaaja > Program.Päämäärä && Summakone > Program.Päämäärä)
                    {
                        Console.WriteLine("Tasapeli!");
                        Console.WriteLine("Molemmilla summa yli päämäärän");
                    }
                    else if (Summapelaaja > Program.Päämäärä && Summakone <= Program.Päämäärä)
                    {
                        Console.WriteLine("Hävisit! Olit yli päämäärän ja kone oli päämäärässä tai sen alle");
                    }
                    else if (Summapelaaja <= Program.Päämäärä && Summakone > Program.Päämäärä)
                    {
                        Console.WriteLine("Voitit! Olit päämäärässä tai alle päämäärän ja kone oli sen yli");
                    }
                    else
                    {
                        Console.WriteLine("tuloste virhe 3");
                    }
                }
                else if (Summapelaaja == Program.Päämäärä || Summakone == Program.Päämäärä)
                {
                    if (Summapelaaja == Program.Päämäärä)
                    {
                        Console.WriteLine("Voitit! Summasi on päämäärä");
                    }
                    else
                    {
                        Console.WriteLine("Hävisit! Koneen summa on päämäärä");
                    }
                }
                else if (Summapelaaja < Program.Päämäärä && Summakone < Program.Päämäärä)
                {
                    if (Summapelaaja > Summakone)
                    {
                        Console.WriteLine("Voitit! Olit lähempänä päämäärää");
                    }
                    else if (Summapelaaja < Summakone)
                    {
                        Console.WriteLine("Hävisit! Kone oli lähempänä päämäärää");
                    }
                    else
                    {
                        Console.WriteLine("Tulos virhe laskenta 1");
                    }
                }
                else
                {
                    Console.WriteLine("Tulos virhe laskenta 2");
                }
            }
        }



    }



}


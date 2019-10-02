using System;
using System.Collections.Generic;
using System.Text;

namespace bazaakolio
{
    class Tietokone
    {

        public int Päätös { get; set; }

        public int[] BonusP;
        public int[] BonusK;



        public bool valmispelaaja = false;
        public bool valmiskone = false;
        public bool valmismolemmat = false;
        public bool koneenbonus = false;



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





        // Koneen Metodit
        public void Konevuoro()
        {
            Console.WriteLine("\nKoneen vuoro!");
            Console.WriteLine("Koneen summa on: " + Summakone);
            Console.WriteLine("pelaajan summa on: " + Summapelaaja);

            koneenbonus = false;


        BonusTulostusKone();

            Console.Write("\n");

            Koneif();

            switch (Päätös)
            {
                case 1:
                    Console.WriteLine("Case 1");
                    KoneUusikortti();
                    break;
                /*
            case 2:
                Console.WriteLine("Case 2");
                KoneEikortti();
                break;
                */
                /*
            case 3:
                //Console.WriteLine("Case 3");
                KoneBonuskortti();
                break;
                */
                case 4:
                    Console.WriteLine("Case 4");
                    Mietintää();
                    break;
                case 5:
                    Console.WriteLine("Case 5");
                    KoneYli();
                    break;
                case 10:
                    Console.WriteLine("Case 10");
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
                    Päätös = 4;
                }
                else if (Summakone > Program.Päämäärä)
                {
                    Päätös = 5;
                }
                else
                {
                    Console.WriteLine("ei casea virhe");
                    Päätös = 10;
                }
            }
            else
            {
                Console.WriteLine("ei ymmärrystä");
            }

        }

        public void Mietintää()
        {
            // Case 4
            // pelaaja on 20, pakko yrittää voittoa
            if (Summapelaaja == Program.Päämäärä)
            {
                //Console.WriteLine("pelaaja on päämäärä");
                KoneBonusKysymys();

                if (koneenbonus == false)
                {
                    KoneUusikortti();
                }
                else
                {
                    Console.WriteLine("Kone käytti bonus kortin");
                }

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
                        KoneBonusKysymys();

                        if (koneenbonus == false)
                        {
                            Koneriski();
                        }
                        else
                        {
                            Console.WriteLine("Kone käytti bonus kortin");
                        }
                    }
                    else
                    {
                        //Console.WriteLine("pelaaja EI valmis ja Kone riski");
                        KoneBonusKysymys();

                        if (koneenbonus == false)
                        {
                            Koneriski();
                        }
                        else
                        {
                            Console.WriteLine("Kone käytti bonus kortin");
                        }
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
                            KoneBonusKysymys();

                            if (koneenbonus == false)
                            {
                                KoneUusikortti();
                            }
                            else
                            {
                                Console.WriteLine("Kone käytti bonus kortin");
                            }
                        }
                        else
                        {
                            //Console.WriteLine("kone pienempi mutta pelaaja EI valmis");
                            KoneBonusKysymys();

                            if (koneenbonus == false)
                            {
                                KoneUusikortti();
                            }
                            else
                            {
                                Console.WriteLine("Kone käytti bonus kortin");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("virhe! kone ja pelaaja ei!");
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

        public void KoneYli()
        {
            Console.WriteLine("Kone on yli päämäärän");
            KoneBonusKysymys();

            if (koneenbonus == false)
            {
                Konevalmis();
            }
            else
            {
                Console.WriteLine("Kone käytti bonus kortin");
            }
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

        public void BonusTulostusKone()
        {
            /*
            Console.Write("Koneen bonus kortit:  ");

            int i = 0;
            while (i < BonusK.Length)
            {
                Console.Write(BonusK[i] + "  ");
                i++;
            }

            Console.Write("\n");
            */

            //Console.WriteLine("Koneen bonus kortit: {0}, {1}, {2} ja {3}", BonusK[0], BonusK[1], BonusK[2], BonusK[3]);

            Console.Write("Koneen bonus kortit:");

            if (BonusK[0] != 0)
            {
                Console.Write("  a) " + BonusK[0]);
                Console.Write(",");
            }

            if (BonusK[1] != 0)
            {
                Console.Write("  b) " + BonusK[1]);
                Console.Write(",");
            }

            if (BonusK[2] != 0)
            {
                Console.Write("  c) " + BonusK[2]);
                Console.Write(",");
            }

            if (BonusK[3] != 0)
            {
                Console.Write("  d) " + BonusK[3]);
            }




            if (BonusK[0] == 0 && BonusK[1] == 0 && BonusK[2] == 0 && BonusK[3] == 0)
            {
                Console.WriteLine("Koneela ei ole Bonus kortteja");
            }
            else
            {
                //Console.WriteLine("");
            }

        }

        public void KoneBonusKysymys()
        {
            // Koneen bonus tarkastus
            Console.WriteLine("Kone tarkistaa bonus kortit");
            BonusTulostusKone();
            Console.WriteLine("\n");

            // plussa kortit
            if (Summakone < Program.Päämäärä)
            {
                Console.WriteLine("plussa kortit");
                if (BonusK[0] != 0 || BonusK[1] != 0)
                {
                    Console.WriteLine("bonus kortti a ja/tai b saatavilla");
                    KoneBonuskorttiPlussa();
                }
                else
                {
                    Console.WriteLine("plussa bonus kortteja ei saatavavilla");
                }
            }
            // miinuskortit
            else if (Summakone > Program.Päämäärä)
            {
                Console.WriteLine("miinus kortit");

                if (BonusK[2] != 0 || BonusK[3] != 0)
                {
                    Console.WriteLine("bonus kortti c ja/tai d saatavilla");
                    KoneBonuskorttiMiinus();
                }
                else
                {
                    Console.WriteLine("miinus bonus kortteja ei saatavavilla");
                }
            }
            else
            {
                Console.WriteLine("kone sekaisin tilastaan");
            }
        }


        public void KoneBonuskorttiPlussa()
        {
            Console.WriteLine("Plussa Bonus kortti");

            Console.WriteLine("a on: " + BonusK[0]);
            Console.WriteLine("b on: " + BonusK[1]);
            Console.WriteLine("kone on: " + Summakone);

            // luodaan helpotus int
            int PlusSumma;
            PlusSumma = Program.Päämäärä - Summakone;

            Console.WriteLine("PlusSumma on: " + PlusSumma);

            // a vai b
            if (BonusK[0] <= PlusSumma || BonusK[1] <= PlusSumma)
            {
                if (BonusK[0] != 0 && BonusK[1] != 0)
                {
                    Console.WriteLine("molemmat käytössä");
                    if (BonusK[0] == BonusK[1])
                    {
                        Console.WriteLine("a ja b samat, käytetään a");
                        KoneBonuskortti1();
                        goto plussavalmis;
                    }
                    else if (BonusK[0] > BonusK[1])
                    {
                        Console.WriteLine("a on parempi, käytetään a");
                        KoneBonuskortti1();
                        goto plussavalmis;

                    }
                    else if (BonusK[0] < BonusK[1])
                    {
                        Console.WriteLine("b on parempi, käytetään b");
                        KoneBonuskortti2();
                        goto plussavalmis;

                    }
                    else
                    {
                        Console.WriteLine("a ja b molemmat käytössä mutta sekaisin");
                    }

                }
                else if (BonusK[0] != 0 && BonusK[1] == 0)
                {
                    Console.WriteLine("vain a käytössä");
                    KoneBonuskortti1();
                    goto plussavalmis;

                }
                else if (BonusK[0] == 0 && BonusK[1] != 0)
                {
                    Console.WriteLine("vain b käytössä");
                    KoneBonuskortti2();
                    goto plussavalmis;

                }
                else
                {
                    Console.WriteLine("a tai b ei käytössä");
                }                                                                                                            
            }
            else
            {
                Console.WriteLine("a tai b ei sopiva");
            }

            plussavalmis:

            Console.WriteLine("plus bonus loppuu");

        }

        public void KoneBonuskorttiMiinus()
        {
            Console.WriteLine("Miinus Bonus kortti");

            Console.WriteLine("c on: " + BonusK[2]);
            Console.WriteLine("d on: " + BonusK[3]);
            Console.WriteLine("kone on: " + Summakone);

            // luodaan helpotus int
            int MiinusSumma;
            MiinusSumma = Summakone - Program.Päämäärä;

            // käännetään c ja d arvot positiiviseksi
            int c;
            c = BonusK[2];
            c = Math.Abs(c);

            int d;
            d = BonusK[3];
            d = Math.Abs(d);

            int testi;
            testi = c + d;

            Console.WriteLine("MiinusSumma on: " + MiinusSumma);

            // c vai d
            if (c >= MiinusSumma || d >= MiinusSumma || testi > MiinusSumma)
            {
                if (c == 0 && d == 0)
                {
                    Console.WriteLine("c ja d käytetty jo virhe");
                }
                else if (c != 0 && d == 0)
                {
                    Console.WriteLine("vain c käytössä");
                    if (c >= MiinusSumma)
                    {
                        KoneBonuskortti3();
                        goto miinusvalmis;

                    }
                    else
                    {
                        Console.WriteLine("c ei riitä yksin");
                    }
                }
                else if (c == 0 && d != 0)
                {
                    Console.WriteLine("vain d käytössä");
                    if (d >= MiinusSumma)
                    {
                        KoneBonuskortti4();
                        goto miinusvalmis;

                    }
                    else
                    {
                        Console.WriteLine("d ei riitä yksin");
                    }
                }
                else if (c != 0 && d != 0)
                {
                    Console.WriteLine("c ja d käytössä");

                    if (c >= MiinusSumma)
                    {
                        KoneBonuskortti3();
                        goto miinusvalmis;
                    }
                    else
                    {
                        Console.WriteLine("c ei riitä yksin");
                    }
                    if (d >= MiinusSumma)
                    {
                        KoneBonuskortti4();
                        goto miinusvalmis;

                    }
                    else
                    {
                        Console.WriteLine("d ei riitä yksin");
                    }

                    if (testi >= MiinusSumma)
                    {
                        Console.WriteLine("c ja d yhdessä riittää");
                        KoneBonuskortti3();
                        KoneBonuskortti4();
                        goto miinusvalmis;

                    }
                    else
                    {
                        Console.WriteLine("c ja d yhdessäkään ei riitä virhe");
                    }
                }
                else
                {
                    Console.WriteLine("c ja d error");
                }

            }
            else
            {
                Console.WriteLine("ei mahdollista käyttää c tai d");
            }

            miinusvalmis:

            Console.WriteLine("miinus loppuu");

        }
       

        public void KoneBonuskortti1()
        {
            Console.WriteLine("Kone valitsi Bonus kortin: " + BonusK[0]);
            Summakone += BonusK[0];
            Console.WriteLine("Bonus kortin jälkeen koneen summa on: " + Summakone);
            BonusK[0] = 0;
            koneenbonus = true;

        }
        public void KoneBonuskortti2()
        {
            Console.WriteLine("Kone valitsi Bonus kortin: " + BonusK[1]);
            Summakone += BonusK[1];
            Console.WriteLine("Bonus kortin jälkeen koneen summa on: " + Summakone);
            BonusK[1] = 0;
            koneenbonus = true;

        }
        public void KoneBonuskortti3()
        {
            Console.WriteLine("Kone valitsi Bonus kortin: " + BonusK[2]);
            Summakone += BonusK[2];
            Console.WriteLine("Bonus kortin jälkeen koneen summa on: " + Summakone);
            BonusK[2] = 0;
            koneenbonus = true;

        }
        public void KoneBonuskortti4()
        {
            Console.WriteLine("Kone valitsi Bonus kortin: " + BonusK[3]);
            Summakone += BonusK[3];
            Console.WriteLine("Bonus kortin jälkeen koneen summa on: " + Summakone);
            BonusK[3] = 0;
            koneenbonus = true;

        }


















        // Pelaajan Metodit
        public void Pelaajavuoro()
        {
            Console.WriteLine("\nSinun vuorosi!");
            string kysymys;

        kysymysuudestaan3:

            Console.WriteLine("Koneen summa on: " + Summakone);

            Console.WriteLine("Summasi on: " + Summapelaaja);

            BonusTulostusPelaaja();

            Console.WriteLine("\nUusi kortti hit(h), Ei uutta korttia stay(s), Käytä bonus kortti(b), Pelaaja valmis end(e)");
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
                    Bonuskortit();
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
            Console.WriteLine("Pelaaja lopettaa");
            valmispelaaja = true;
        }

        public void Uusikortti()
        {
            Console.WriteLine("Uusi kortti");
            Random random = new Random();
            int arvottukortti = random.Next(Program.Pieninpakkaluku, Program.Suurinpakkaluku);
            Console.WriteLine("Jaettu korttisi on: " + arvottukortti);
            Summapelaaja += arvottukortti;
            Console.WriteLine("Summasi on nyt: " + Summapelaaja);
        }

        public void Eikortti()
        {
            Console.WriteLine("Ei korttia");
        }

        public void Bonuskortit()
        {
        //Console.WriteLine("Bonus kortti metodi");
        bkysymys:
            BonusTulostusPelaaja();
            Console.WriteLine("\nSummasi on nyt: " + Summapelaaja);
            Console.WriteLine("Valitse Bonus korttisi a - d tai Älä käytä Bonuskorttia n");

            string Bkysymys;
            int BkysymysNum;
            Bkysymys = Console.ReadLine();

            //int BkysymysNum = Int32.Parse(Bkysymys);            

            if (Bkysymys == "a")
            {
                BkysymysNum = 1;
            }
            else if (Bkysymys == "b")
            {
                BkysymysNum = 2;
            }
            else if (Bkysymys == "c")
            {
                BkysymysNum = 3;
            }
            else if (Bkysymys == "d")
            {
                BkysymysNum = 4;
            }
            else if (Bkysymys == "n")
            {
                BkysymysNum = 5;
            }
            else
            {
                Console.WriteLine("En ymmärtänyt");
                goto bkysymys;
            }







            switch (BkysymysNum)
            {
                case 5:
                    //Console.WriteLine("Case 0");
                    Console.WriteLine("Bonus korttia ei käytetty");
                    break;
                case 1:
                    //Console.WriteLine("Case 1");
                    PelaajanBonuskortti1();
                    break;
                case 2:
                    //Console.WriteLine("Case 2");
                    PelaajanBonuskortti2();
                    break;
                case 3:
                    //Console.WriteLine("Case 3");
                    PelaajanBonuskortti3();
                    break;
                case 4:
                    //Console.WriteLine("Case 4");
                    PelaajanBonuskortti4();
                    break;

                default:
                    Console.WriteLine("Default case/virhe");
                    break;
            }

        }
        public void PelaajanBonuskortti1()
        {
            Console.WriteLine("Valitsit Bonus kortin: " + BonusP[0]);
            Summapelaaja += BonusP[0];
            Console.WriteLine("Bonus kortin jälkeen summasi on: " + Summapelaaja);

            BonusP[0] = 0;


        }
        public void PelaajanBonuskortti2()
        {
            Console.WriteLine("Valitsit Bonus kortin: " + BonusP[1]);
            Summapelaaja += BonusP[1];
            Console.WriteLine("Bonus kortin jälkeen summasi on: " + Summapelaaja);
            BonusP[1] = 0;


        }
        public void PelaajanBonuskortti3()
        {
            Console.WriteLine("Valitsit Bonus kortin: " + BonusP[2]);
            Summapelaaja += BonusP[2];
            Console.WriteLine("Bonus kortin jälkeen summasi on: " + Summapelaaja);
            BonusP[2] = 0;


        }
        public void PelaajanBonuskortti4()
        {
            Console.WriteLine("Valitsit Bonus kortin: " + BonusP[3]);
            Summapelaaja += BonusP[3];
            Console.WriteLine("Bonus kortin jälkeen summasi on: " + Summapelaaja);
            BonusP[3] = 0;


        }

        public void BonusTulostusPelaaja()
        {
            /*
            Console.Write("Pelaajan bonus kortit:  ");

            int i = 0;
            while (i < BonusP.Length)
            {
                Console.Write(BonusP[i] + "  ");
                i++;
            }

            Console.Write("\n");
            */

            //Console.WriteLine("Pelaajan bonus kortit: a){0}, b){1}, c){2} ja d){3}", BonusP[0], BonusP[1], BonusP[2], BonusP[3]);

            Console.Write("Pelaajan bonus kortit:");

            if (BonusP[0] != 0)
            {
                Console.Write("  a) " + BonusP[0]);
                Console.Write(",");
            }

            if (BonusP[1] != 0)
            {
                Console.Write("  b) " + BonusP[1]);
                Console.Write(",");
            }

            if (BonusP[2] != 0)
            {
                Console.Write("  c) " + BonusP[2]);
                Console.Write(",");
            }

            if (BonusP[3] != 0)
            {
                Console.Write("  d) " + BonusP[3]);
            }




            if (BonusP[0] == 0 && BonusP[1] == 0 && BonusP[2] == 0 && BonusP[3] == 0)
            {
                Console.WriteLine(" Sinulla ei ole Bonus kortteja");
            }
            else
            {
                //Console.WriteLine("");
            }











        }







        // Muut Metodit
        public void Tulokset()
        {

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

        public void BonusArvonta()
        {
            //Console.WriteLine("Bonus korttien arvonta");

            BonusP = new int[4];
            BonusK = new int[4];

            Random random = new Random();

            // Bonus korttien arvonta pelaajalle
            BonusP[0] = random.Next(1, 6);
            BonusP[1] = random.Next(1, 6);
            BonusP[2] = random.Next(-6, -1);
            BonusP[3] = random.Next(-6, -1);

            // Bonus korttien arvonta koneelle
            BonusK[0] = random.Next(1, 6);
            BonusK[1] = random.Next(1, 6);
            BonusK[2] = random.Next(-6, -1);
            BonusK[3] = random.Next(-6, -1);

            //Console.WriteLine("Bonus kortit arvottu");

            BonusTulostusPelaaja();

            Console.Write("\n  ");

            BonusTulostusKone();

            Console.Write("\n");


        }












    }



}


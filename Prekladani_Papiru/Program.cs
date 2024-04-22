    using System;
    using System.Collections.Generic;

    namespace Prekladani_Papiru
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                bool pokracovani = true;
                do
                {
                    Console.WriteLine("Vítejte v programu pro určení počtu přeložení papíru k Měsíci");

                    double tloustkaPapiru = 0.1; // tloušťka v milimetrech
                    double vzdalenostKMesici = 384400 * 1000; // převod kilometrů na milimetry
                    int pocetSlozeni = 0; // aktuální počet složení
                    List<string> progressBar = new List<string>();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Vzálenost k měsíci je: {0} km", vzdalenostKMesici / 1000);
                    Console.ResetColor();

                    // cyklus pro určení počtu přeložení, cyklus bude fungovat tak dlouho dokud tloustka papíru nebude větší než vzdálenost k měsíci
                    while (tloustkaPapiru < vzdalenostKMesici && pocetSlozeni < 32)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Aktuální počet přeložení: {0}", pocetSlozeni);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Aktuální tloušťka papíru: {0} mm nebo {1} km", tloustkaPapiru, tloustkaPapiru / 1000);

                        tloustkaPapiru *= 2; // 1 přeložení papíru
                        pocetSlozeni++; // přičtení dalšího ohybu

                        // Progress bar
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("");
                        Console.WriteLine("Aktuální vzádelnost:");
                        Console.Write(string.Join("", progressBar).PadRight(32, '▒'));
                        Console.WriteLine("\n");
                        Console.ResetColor();


                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (pocetSlozeni < 32)
                        {
                        progressBar.Add("█");
                        Console.WriteLine("Klikněte pro další přeložení papíru");
                        Console.ReadKey();
                        }
                        Console.Clear();
                    }

                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Počet složení potřebných k dosažení Měsíce: {0}", pocetSlozeni);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Celková tloušťka papíru: {0} mm nebo {1} km", tloustkaPapiru, tloustkaPapiru / 1000);
                    Console.WriteLine();

                    Console.ResetColor();
                    Console.WriteLine("Děkujeme za použití programu");

                    Console.WriteLine("Chcete ukončit program? (y/n)");
                    char pokracovat = Convert.ToChar(Console.ReadLine());
                    if (pokracovat == 'n')
                    {
                        pokracovani = true;
                        Console.Clear();
                    }
                    else if (pokracovat == 'y')
                    {
                        pokracovani = false;
                    }

                } while (pokracovani == true);
                Console.ReadLine();

            }
        }
    }

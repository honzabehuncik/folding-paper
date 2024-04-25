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

                    // Definování základních parametrů
                    decimal tloustkaPapiru = 0.1m; // Tloušťka v milimetrech
                    decimal vzdalenostKMesici = 384400m * 1000000m; // Převod kilometrů na milimetry
                    int pocetSlozeni = 0; // Aktuální počet složení
                
                    // Standardní rozměry papíru
                    double delkaPapiruA0 = 1189;
                    double sirkaPapiruA0 = 841;
                    double delkaPapiruA4 = 297;
                    double sirkaPapiruA4 = 210;


                    // Progress bar v Listu znaků
                    List<string> progressBar = new List<string>();


                    // Cyklus pro určení počtu přeložení, cyklus bude fungovat tak dlouho dokud tloustka papíru nebude větší než vzdálenost k měsíci
                    while (tloustkaPapiru < vzdalenostKMesici)
                    {
                        if (pocetSlozeni % 2 == 1 && pocetSlozeni != 0) // Každé liché číslo se přeloží papír na délku kromě nuly
                        {
                            delkaPapiruA4 /= 2;
                            delkaPapiruA0 /= 2;
                        }
                        else if (pocetSlozeni % 2 == 0 && pocetSlozeni != 0) // Každé sudé číslo se přeloží papír na šířku kromě nuly 
                        {
                            sirkaPapiruA4 /= 2;
                            sirkaPapiruA0 /= 2;
                        }


                        // Logování parametrů do console
                        Console.WriteLine("Delká papíru A0 {0} mm", delkaPapiruA0);
                        Console.WriteLine("Šířka papíru A0 {0} mm", sirkaPapiruA0);
                        Console.WriteLine("Delká papíru A4 {0} mm", delkaPapiruA4);
                        Console.WriteLine("Šířka papíru A4 {0} mm", sirkaPapiruA4);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nAktuální počet přeložení: {0}", pocetSlozeni);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Aktuální tloušťka papíru: {0} mm nebo {1} km", tloustkaPapiru, tloustkaPapiru / 1000); // Tlouštka papíru zaokrouhlena na km 
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Vzálenost k měsíci je: {0} km", vzdalenostKMesici / 1000);
                        Console.ResetColor();


                        tloustkaPapiru *= 2; // 1 přeložení papíru
                        pocetSlozeni++; // přičtení dalšího ohybu


                        // Progress bar logika
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("");
                        Console.WriteLine("Aktuální vzádelnost:");
                        Console.Write(string.Join("", progressBar).PadRight(41, '▒')); // Výměna invisible symbolů za black symboly
                        Console.WriteLine("\n");
                        Console.ResetColor();


                        Console.ForegroundColor = ConsoleColor.Gray;
                        if (pocetSlozeni <= 42) // Vypisování čteverčků do progress baru
                        {
                            progressBar.Add("█"); // Přidávání symbolů do listu progress baru
                            Console.WriteLine("Klikněte pro další přeložení papíru");
                            Console.ReadKey();
                        }

                        Console.Clear();
                    }

                    // Převedení desetinného čísla na celé číslo
                    long konvertovaniTloustkyPapiru = decimal.ToInt64(tloustkaPapiru);
                    
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Počet složení potřebných k dosažení Měsíce: {0}", pocetSlozeni);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Celková tloušťka papíru: {0} mm nebo {1} km", konvertovaniTloustkyPapiru, konvertovaniTloustkyPapiru / 1000000); // Převod z mm na km

                    Console.ResetColor();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine();

                    double zaokrouhleneCisloA4sirka = Math.Round(sirkaPapiruA4, 4);  // Zaokrouhlení čísel pomocí knihovny Math.Round, čísla jsou zaokrouhleny na desetitisíciny
                    double zaokrouhleneCisloA4delka = Math.Round(delkaPapiruA4, 4);
                    double zaokrouhleneCisloA0sirka = Math.Round(sirkaPapiruA0, 4);
                    double zaokrouhleneCisloA0delka = Math.Round(delkaPapiruA0, 4);


                    // Finální result
                    Console.WriteLine(
                        "Výsledek ukazuje že je nereálné abychom byli schopni přeložit papír A4 do rozměrů {0:0.0000} x {1:0.0000} nebo největší papír který se vyrábí A0 do rozměrů {2:0.0000} x {3:0.0000}",
                        zaokrouhleneCisloA4sirka, zaokrouhleneCisloA4delka, zaokrouhleneCisloA0sirka, zaokrouhleneCisloA0delka);
                    Console.WriteLine(
                        "\nPS. čísla byla zaokrouhlena na desetitisíciny abyste z toho aspoň něco vyčetli, jak můžeme vidět čísla by dosahovala microskopických rozměrů, což bychom ani s nejpokročilejšími technologiemi dnešní doby nezvládli přeložit.");
                    Console.ResetColor();
                    Console.WriteLine("\nDěkujeme za použití programu");

                    Console.WriteLine("Chcete zapnout program znovu? (a/n)");


                    // Switch pro pokračování nebo ukončení aplikace
                    char pokracovat = Convert.ToChar(Console.ReadLine());
                    switch (pokracovat)
                    {
                        case 'a':
                            pokracovani = true;
                            Console.Clear();
                            break;
                        case 'n':
                            pokracovani = false;
                            break;
                        default:
                            Console.WriteLine("Neplatný znak, program je ukončen.");
                            return;
                    }
                } while (pokracovani == true);
                Console.ReadLine();
            }
        }
    }

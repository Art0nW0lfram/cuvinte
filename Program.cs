using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Inițializare tablou de liste pentru fiecare literă (a-z)
        List<string>[] cuvinte = new List<string>[26];
        for (int i = 0; i < 26; i++)
        {
            cuvinte[i] = new List<string>();
        }

        try
        {
            // Citire cuvinte din fișier
            string[] linii = File.ReadAllLines("cuvinte.txt");

            // Procesare fiecare cuvânt
            foreach (string linie in linii)
            {
                string[] cuvinteLinie = linie.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string cuvant in cuvinteLinie)
                {
                    if (!string.IsNullOrEmpty(cuvant))
                    {
                        char primaLitera = char.ToLower(cuvant[0]);
                        if (primaLitera >= 'a' && primaLitera <= 'z')
                        {
                            int index = primaLitera - 'a';
                            cuvinte[index].Add(cuvant);
                        }
                    }
                }
            }

            // Afișare tablou
            for (int i = 0; i < 26; i++)
            {
                char litera = (char)('a' + i);
                Console.WriteLine($"Cuvinte care incep cu '{litera}' sau '{char.ToUpper(litera)}':");
                if (cuvinte[i].Count == 0)
                {
                    Console.WriteLine(" - Niciun cuvant\n");
                }
                else
                {
                    foreach (string cuvant in cuvinte[i])
                    {
                        Console.WriteLine($" - {cuvant}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Eroare: {ex.Message}");
        }
    }
}
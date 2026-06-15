using System;
using System.IO;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Używamy pełnej ścieżki absolutnej, żeby program na pewno znalazł plik
        string blockMapPath = @"C:\Users\Administrator\source\repos\Lab09_PackagedApp\Lab09_PackagedApp\msix-contents\AppxBlockMap.xml";

        try
        {
            await using var stream = new FileStream(blockMapPath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(stream);

            int blockCount = 0;
            string? line;
            while ((line = await reader.ReadLineAsync()) is not null)
            {
                if (line.Contains("<Block")) blockCount++;
            }

            Console.WriteLine($"Liczba blokow w AppxBlockMap: {blockCount}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Błąd: Nie znaleziono pliku AppxBlockMap.xml pod podaną ścieżką!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Wystąpił błąd: {ex.Message}");
        }

        // Zatrzymuje okno konsoli, żeby nie zamknęło się od razu
        Console.ReadLine();
    }
}
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CSVCleaner
{
    public class Program
    {
        private const string PATH_IN = "In";
        private const string PATH_OUT = "Out";

        static void Main(string[] args)
        {
            WriteConsole("Iniciando CSV Cleaner", true);
            WriteConsole("Preparando diretorios", true);
            WriteConsole("Criando pasta de entrada (In)");
            Directory.CreateDirectory(PATH_IN);
            WriteConsole("Criando pasta de saída (Out) \n");
            Directory.CreateDirectory(PATH_OUT);

            var filePaths = Directory.GetFiles(PATH_IN, "*.csv");
            var qtFile = filePaths.Length;
            if (qtFile > 0)
            {
                WriteConsole($"{qtFile} arquivo(s) encontrado(s)! Iniciando Limpeza!", true);
                foreach (var path in filePaths)
                {
                    //Pegar arquivo
                    WriteConsole($"Arquivo: {Path.GetFileName(path)}");
                    WriteConsole("1 - Regatando texto!");
                    string csvText = File.ReadAllText(path);
                    //Limpar
                    WriteConsole("2 - Limpando o texto do arquivo!");
                    var cleanedText = Cleaner(csvText);
                    //Criando arquivo limpo
                    WriteConsole("3 - Gerando arquivo de saida!\n");
                    var outPath = $"{PATH_OUT}/{Path.GetFileName(path)}";
                    File.AppendAllTextAsync(outPath, cleanedText);
                }
            }
            else
            {
                WriteConsole("\nNenhum arquivo encontrado! Finalizando...");
            }
        }

        private static void WriteConsole(string text, bool isTitle = false)
        {
            if (isTitle)
            {
                Console.WriteLine("-----" + text + "-----\n");
            }
            else
            {
                Console.WriteLine(text);
            }

        }
        public static string Cleaner(string input)
        {
            if (input == null || input.Equals(string.Empty)) return string.Empty;

            var output = input.Trim()
                    .Replace("&", "e")
                    .Replace("á", "a")
                    .Replace("é", "e")
                    .Replace("í", "i")
                    .Replace("ó", "o")
                    .Replace("ú", "u")
                    .Replace("ý", "y")
                    .Replace("à", "a")
                    .Replace("è", "e")
                    .Replace("ì", "i")
                    .Replace("ò", "o")
                    .Replace("ù", "u")
                    .Replace("â", "a")
                    .Replace("ê", "e")
                    .Replace("î", "i")
                    .Replace("ô", "o")
                    .Replace("û", "u")
                    .Replace("ã", "a")
                    .Replace("õ", "o")
                    .Replace("ç", "c");

            return output;
        }
    }
}

// See https://aka.ms/new-console-template for more information
using ImageMagick;
using Magic_Icon_Builder;
using System.Text.Json;

Console.WriteLine("Magic Icon Builder\n");

int itensConcluidos = 0;
int itensFalha = 0;

// Ler configurações do arquivo JSON
Config config = JsonSerializer.Deserialize<Config>(File.ReadAllText("config.json")) ?? throw new Exception();

// Pegar todos os arquivos PNG na pasta de entrada
string[] files = Directory.GetFiles(config.InputFolder, "*.png");

if (files.Length > 0)
{
    // Define as resoluções desejadas para os ícones
    int[] sizes = [256, 128, 78, 64, 48, 32, 16];

    foreach (string file in files)
    {
        try
        {
            string filename = Path.GetFileNameWithoutExtension(file);

            Console.WriteLine($"Iniciado: {filename}");
            using (MagickImageCollection collection = [])
            {
                Console.Write($"Trabalhando em: ");

                foreach (int size in sizes)
                {
                    Console.Write($"{size}; ");

                    MagickImage image = new(file);
                    image.Resize(size, size);
                    collection.Add(image);
                }

                collection.Write(Path.Combine(config.OutputFolder, filename + ".ico"));
                itensConcluidos++;
            }

            Console.WriteLine($"\nConversão realizada com sucesso: {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nErro ao converter o arquivo {file}: {ex.Message}");
            itensFalha++;
        }
    }

    Console.WriteLine($"\nConversão concluída: {itensConcluidos} com sucesso, {itensFalha} com falha");
}
else
{
    Console.WriteLine("Não há arquivos para conversão!");
}

Console.ReadLine();
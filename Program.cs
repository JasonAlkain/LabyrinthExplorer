using System;
using LabyrinthExplorer.Infrastructure;

namespace LabyrinthExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var options = ParseArguments(args);
                using var application = GameBuilder.Build(options);
                application.Run();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"An error occurred while starting the game: {ex.Message}");
            }
        }

        private static GameBuilderOptions ParseArguments(string[] args)
        {
            var options = new GameBuilderOptions();

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].Equals("--seed", StringComparison.OrdinalIgnoreCase) && i + 1 < args.Length)
                {
                    if (int.TryParse(args[i + 1], out var seed))
                    {
                        options.Seed = seed;
                        i++;
                    }
                }
            }

            return options;
        }
    }
}

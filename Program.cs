using GameplayNamespace;
using Handlers;
using LabyrinthExplorer.Gameplay;

namespace LabyrinthExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            BaseGameplay.Setup();

            Menu._Main();

            //Console.ReadKey();
        }

    }
}

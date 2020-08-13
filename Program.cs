using GameplayNamespace;
using Handlers;

namespace LabyrinthExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gameplay = new Gameplay();
            gameplay.Setup();

            Menu._Main();

            //Console.ReadKey();
        }

    }
}

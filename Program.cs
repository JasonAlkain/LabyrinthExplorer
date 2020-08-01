using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using LabyrinthExplorer;
using GameplayNamespace;
using Handlers;
using Microsoft.VisualBasic;

namespace LabyrinthExplorer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var gameplay = new Gameplay();
            gameplay.Setup();

            Menu._Main();
        }

    }
}

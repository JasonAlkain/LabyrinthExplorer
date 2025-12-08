using System.Collections.Generic;
using System.ComponentModel;
using LabyrinthExplorer.Utilities;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player : PlayerData
    {
        private readonly IConsoleService _console;
        internal Notifier<int> _Sanity = new Notifier<int>();

        public Player(IConsoleService console)
        {
            _console = console;
            Name = string.Empty;
            Sanity = 10;

            Inventory = new List<Item>();
            _Sanity.PropertyChanged += Score_PropertyChanged;
        }

        public string Name { get; set; }

        public int Sanity
        {
            get { return _Sanity.Prop; }
            set { _Sanity.Prop = value; }
        }

        public List<Item> Inventory { get; private set; }

        private void Score_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _console.Write($"Sanity changed to: {Sanity}");
        }

        public void ShowInventory()
        {
            Inventory.ForEach(item => _console.Write($"[ {item.Name} ] "));
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public class PlayerData
    {
    }
}

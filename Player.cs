using System;
using System.Collections.Generic;
using System.ComponentModel;
using LabyrinthExplorer.Data;
using LabyrinthExplorer.Utilities;
using Utilities;

namespace LabyrinthExplorer
{
    public class Player : IDisposable
    {
        private readonly IConsoleService _console;
        private readonly Notifier<int> _Sanity = new Notifier<int>();
        private bool _disposed;

        public Player(IConsoleService console)
            : this(console, new PlayerData())
        {
        }

        public Player(IConsoleService console, PlayerData state)
        {
            _console = console;
            _Sanity.PropertyChanged += Score_PropertyChanged;
            Inventory = new List<Item>();

            LoadFromData(state);
        }

        public string Name { get; set; }

        public int Sanity
        {
            get { return _Sanity.Prop; }
            set { _Sanity.Prop = value; }
        }

        public List<Item> Inventory { get; private set; }

        public PlayerData ToData()
        {
            return new PlayerData
            {
                Name = Name,
                Sanity = Sanity,
                Inventory = CloneInventory()
            };
        }

        public void LoadFromData(PlayerData state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            Name = state.Name ?? string.Empty;
            ReplaceInventory(state.Inventory ?? new List<Item>());
            SetSanitySilently(state.Sanity);
        }

        private void Score_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _console.Write($"Sanity changed to: {Sanity}");
        }

        private void SetSanitySilently(int sanity)
        {
            _Sanity.PropertyChanged -= Score_PropertyChanged;
            _Sanity.Prop = sanity;
            _Sanity.PropertyChanged += Score_PropertyChanged;
        }

        private List<Item> CloneInventory()
        {
            var clone = new List<Item>();

            foreach (var item in Inventory)
            {
                clone.Add(CloneItem(item));
            }

            return clone;
        }

        private static Item CloneItem(Item item)
        {
            return item switch
            {
                Card card => new Card
                {
                    _CardType = card._CardType,
                    Name = card.Name,
                    Description = card.Description,
                    ID = card.ID
                },
                Weapon weapon => new Weapon
                {
                    _WeaponType = weapon._WeaponType,
                    Name = weapon.Name,
                    Description = weapon.Description,
                    ID = weapon.ID
                },
                _ => new Item
                {
                    Name = item.Name,
                    Description = item.Description,
                    ID = item.ID
                }
            };
        }

        private void ReplaceInventory(IEnumerable<Item> items)
        {
            Inventory = new List<Item>();

            foreach (var item in items)
            {
                Inventory.Add(CloneItem(item));
            }
        }

        public void ShowInventory()
        {
            Inventory.ForEach(item => _console.Write($"[ {item.Name} ] "));
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _Sanity.PropertyChanged -= Score_PropertyChanged;
                _Sanity.Dispose();
            }

            _disposed = true;
        }

        ~Player()
        {
            Dispose(false);
        }
    }

    public class PlayerData
    {
        public string Name { get; set; } = string.Empty;

        public int Sanity { get; set; } = 10;

        public List<Item> Inventory { get; set; } = new List<Item>();
    }
}

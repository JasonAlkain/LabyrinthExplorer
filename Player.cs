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
        private readonly IPlayerStateMapper _stateMapper;
        private readonly IPlayerObserver _observer;
        private readonly Notifier<int> _Sanity = new Notifier<int>();
        private bool _disposed;

        public Player(IConsoleService console)
            : this(new PlayerStateMapper(), new ConsolePlayerObserver(console), new PlayerData())
        {
        }

        public Player(IConsoleService console, PlayerData state)
            : this(new PlayerStateMapper(), new ConsolePlayerObserver(console), state)
        {
        }

        public Player(IPlayerStateMapper stateMapper, IPlayerObserver observer, PlayerData state)
        {
            _stateMapper = stateMapper ?? throw new ArgumentNullException(nameof(stateMapper));
            _observer = observer ?? throw new ArgumentNullException(nameof(observer));
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

        public PlayerData ToData() => _stateMapper.ToData(this);

        public void LoadFromData(PlayerData state)
        {
            _stateMapper.Apply(this, state);
        }

        private void Score_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            _observer.OnSanityChanged(this, Sanity);
        }

        internal void SetSanitySilently(int sanity)
        {
            _Sanity.PropertyChanged -= Score_PropertyChanged;
            _Sanity.Prop = sanity;
            _Sanity.PropertyChanged += Score_PropertyChanged;
        }
        internal void ReplaceInventory(IEnumerable<Item> items)
        {
            Inventory = new List<Item>();

            foreach (var item in items)
            {
                Inventory.Add(item);
            }
        }

        public void ShowInventory()
        {
            Inventory.ForEach(item => _observer.OnInventoryItemShown(item));
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

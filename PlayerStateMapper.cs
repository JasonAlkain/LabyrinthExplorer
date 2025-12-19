using System;
using System.Collections.Generic;
using LabyrinthExplorer.Data;

namespace LabyrinthExplorer
{
    public interface IPlayerStateMapper
    {
        PlayerData ToData(Player player);

        void Apply(Player player, PlayerData state);
    }

    public class PlayerStateMapper : IPlayerStateMapper
    {
        public PlayerData ToData(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            return new PlayerData
            {
                Name = player.Name,
                Sanity = player.Sanity,
                Inventory = CloneInventory(player.Inventory)
            };
        }

        public void Apply(Player player, PlayerData state)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            player.Name = state.Name ?? string.Empty;
            player.ReplaceInventory(CloneInventory(state.Inventory ?? new List<Item>()));
            player.SetSanitySilently(state.Sanity);
        }

        private static List<Item> CloneInventory(IEnumerable<Item> items)
        {
            var clone = new List<Item>();

            foreach (var item in items)
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
    }
}

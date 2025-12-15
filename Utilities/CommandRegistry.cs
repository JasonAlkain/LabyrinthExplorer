using System;
using System.Collections.Generic;
using System.Text;

namespace LabyrinthExplorer.Utilities
{
    public static class CommandRegistry
    {
        private static readonly IReadOnlyDictionary<string, string> GameplayAliases =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["n"] = "north",
                ["north"] = "north",
                ["e"] = "east",
                ["east"] = "east",
                ["w"] = "west",
                ["west"] = "west",
                ["s"] = "south",
                ["south"] = "south",
                ["look"] = "look",
                ["search"] = "search",
                ["take"] = "take",
                ["use"] = "use",
                ["inventory"] = "inventory",
                ["i"] = "inventory",
                ["q"] = "quit",
                ["quit"] = "quit",
                ["l"] = "quit",
                ["leave"] = "quit",
                ["dev"] = "dev",
            };

        private static readonly IReadOnlyDictionary<string, string> MenuAliases =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["n"] = "new",
                ["new"] = "new",
                ["new game"] = "new",
                ["l"] = "load",
                ["load"] = "load",
                ["load game"] = "load",
                ["q"] = "quit",
                ["quit"] = "quit",
                ["e"] = "quit",
                ["exit"] = "quit",
            };

        private static readonly IReadOnlyDictionary<string, string> DevAliases =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["item"] = "item",
                ["omen"] = "omen",
                ["leave"] = "leave",
                ["back"] = "leave",
            };

        private static readonly IReadOnlyDictionary<string, string> ConfirmationAliases =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["y"] = "yes",
                ["yes"] = "yes",
                ["n"] = "no",
                ["no"] = "no",
            };

        private static readonly IReadOnlyDictionary<string, string> DisplayNames =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["quit"] = "(q)uit/(l)eave",
                ["look"] = "look",
                ["north"] = "(n)orth",
                ["east"] = "(e)ast",
                ["west"] = "(w)est",
                ["south"] = "(s)outh",
                ["inventory"] = "(i)nventory",
                ["search"] = "search",
                ["take"] = "take",
                ["use"] = "use",
                ["dev"] = "dev",
                ["new"] = "new game",
                ["load"] = "load",
                ["item"] = "item",
                ["omen"] = "omen",
                ["leave"] = "leave",
                ["yes"] = "yes",
                ["no"] = "no",
            };

        public static string Normalize(string? input) => (input ?? string.Empty).Trim().ToLowerInvariant();

        public static bool TryMapGameplay(string input, out string command) =>
            GameplayAliases.TryGetValue(Normalize(input), out command!);

        public static bool TryMapMenu(string input, out string command) =>
            MenuAliases.TryGetValue(Normalize(input), out command!);

        public static bool TryMapDev(string input, out string command) =>
            DevAliases.TryGetValue(Normalize(input), out command!);

        public static bool TryMapConfirmation(string input, out string command) =>
            ConfirmationAliases.TryGetValue(Normalize(input), out command!);

        public static string FormatActions(IEnumerable<string> actions)
        {
            var sb = new StringBuilder();
            foreach (var action in actions)
            {
                sb.Append($"[{GetDisplayName(action)}]");
            }

            return sb.ToString();
        }

        public static string GetDisplayName(string command) =>
            DisplayNames.TryGetValue(command, out var label) ? label : command;
    }
}

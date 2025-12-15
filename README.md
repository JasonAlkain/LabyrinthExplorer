# Labyrinth Explorer
A text based game based loosely off the board game: Betrayal at House on the Hill.

You can find the packaged game on [itch.io](https://alkain-studios-llc.itch.io/cs-labyrinth-explorer) available for Windows, Linux, and Mac.

## Deterministic runs for testing

`GameSession` now uses a shared random number generator, which can be seeded for predictable behavior during tests. Pass a seed to `GameSession.CreateDefault` (or construct your own `RandomProvider`) to reproduce the same room layouts and card draws between runs:

```csharp
var session = GameSession.CreateDefault(seed: 1234);
```

Use the new `status` command in-game to review your current room, sanity, and inventory at any time.

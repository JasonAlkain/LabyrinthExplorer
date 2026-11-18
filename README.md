# Labyrinth Explorer
A text based game based loosely off the board game: Betrayal at House on the Hill.

You can find the packaged game on [itch.io](https://alkain-studios-llc.itch.io/cs-labyrinth-explorer) available for Windows, Linux, and Mac.

## Deterministic runs for testing

`GameSession` now uses a shared random number generator, which can be seeded for predictable behavior during tests. Pass a seed to `GameSession.CreateDefault` (or construct your own `RandomProvider`) to reproduce the same room layouts and card draws between runs:

```csharp
var session = GameSession.CreateDefault(seed: 1234);
```

Use the new `status` command in-game to review your current room, sanity, and inventory at any time.

## Build and test on Windows

Install a stable .NET 10 SDK. From the repository root, run:

```powershell
dotnet build LabyrinthExplorer.sln -c Release
dotnet test LabyrinthExplorer.Tests/LabyrinthExplorer.Tests.csproj -c Release --no-build
dotnet run --project LabyrinthExplorer.csproj -- --seed 1234
```

## Publish a Windows build to itch.io

Pull requests and pushes to `testing` and `master` build, test and archive a self-contained Windows x64 game. Download the artifact from the Actions run to playtest it.

For deployment, configure the GitHub Actions secret `BUTLER_API_KEY` with a Butler credential for an account that can upload to the existing game. Publish a regular GitHub Release from a commit containing this workflow after it reaches the default branch. The workflow tests the release commit, packages it, then uploads that same artifact to `alkain-studios-llc/cs-labyrinth-explorer:windows` with the release tag as its version. Prereleases only build the artifact. After the first upload, verify the Windows download on the game page.

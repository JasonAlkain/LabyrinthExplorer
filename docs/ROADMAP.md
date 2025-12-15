# Labyrinth Explorer Roadmap

This document captures near-term upgrades to move the project forward.

## Gameplay and UX
- Add a save/load flow that captures the current `GameSession` state (player, room, inventory) and offers a persistent "Continue" option from the main menu.
- Expand command help in-game with a lightweight tutorial that can be replayed from the main menu.
- Build richer feedback for room interactions (events/omens) so rooms feel distinct and risky.

## Systems and Architecture
- Introduce a small event system to broadcast gameplay events (room entered, card drawn, sanity changed) for logging and future UI hooks.
- Split random generation behind an interface per domain (rooms, cards, events) to make balancing and deterministic testing easier.
- Add JSON serialization for player and room data to support save slots and potential cloud sync.

## Testing and Tooling
- Increase coverage around command parsing and error messaging, especially for nested menus.
- Add regression tests that snapshot deterministic runs (using seeded sessions) to guard future refactors.
- Wire up CI to run tests on pushes and publish coverage to keep quality visible.

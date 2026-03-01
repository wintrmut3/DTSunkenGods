# Design Tips

## MVC

- The common thread across all of them is the same principle you've already internalized: data flows one way, the core knows nothing about its consumers.
- The clearest rule to internalize: if a Simulation file ever has using a Presentation namespace, something is wrong with the design.

>What belongs where — the guiding questions
Ask these in order:
Does this property exist if nothing else in the world exists?
TileType exists regardless of civs, buildings, time. → Belongs on the tile.
Ownership requires a civ to exist. → Belongs in a layer.

> Can this property change independently of the entity?
Tile height doesn't change (usually). → Embed it.
Ownership changes frequently, terrain doesn't. → Separate layer.

> Is this a property or a relationship?
Height is a property of a tile.
Ownership is a relationship between a tile and a civ.
Relationships always belong in a separate layer.

> Who queries this, and how?
If only one system ever needs it, embed it.
If multiple systems query it from different directions, it needs its own structure.

- Runtime are pure orchestration
- Simulation are pure logic
  - No engine dependencies
- Constructors in *Types files should only know how to validate/allocate themselves, with the population logic outside of the class
- Put logic at the lowest level whose lifetime fully contains it --> The world's lifetime is encapsulated in a session.
- The general rule for where types live: A type belongs in the layer that owns its meaning:
  - GameConfig describes world generation → Simulation
  - RenderConfig describes visual settings → Rendering
  - SceneConfig describes Unity scene setup → Runtime
  - If GameLoop is manually unpacking a struct to pass individual fields down, it means GameLoop knows too much about the internals of generation. Pass the whole config and let WorldGenerator own what it needs from it.
- Position is context, not identity. The tile is the data, the index/position is the address => Don't embed position into the worldmap
# Ape.Launcher

**Thin process host for the Ape platform** — starts `ApeSystem` with a runtime JSON and the module/plugin DLLs copied next to the executable.

[![.NET](https://img.shields.io/badge/.NET-9.0-512BD4)](https://dotnet.microsoft.com/)

In the [ape-skeleton](https://github.com/aklen/ape-skeleton) workspace this host is the `src/Ape.Launcher/` checkout:

```
ape-skeleton/
└── src/
    └── Ape.Launcher/          ← this repository
```

The launcher does not name modules. Whatever is checked out under `src/Ape.Modules` is referenced by glob and copied on build. Network `host` (scene server / participant) is a Core role, not this executable.

---

## Role in the platform

| Tier | Package | Role |
|------|---------|------|
| **1 — Core** | [Ape.Core](https://github.com/aklen/ape-core) | Framework library |
| **1 — Launcher** | **Ape.Launcher** (this repo) | `Main`: `ApeSystem.Start(configPath)` |
| **2 — Services** | `Ape.Module.*` | Optional infrastructure |
| **3 — Plugins** | `Ape.Module.*.Plugin.*` | Application logic |

---

## What's in this repository

```
Ape.Launcher/
├── Ape.Launcher.csproj
└── Program.cs
```

`Ape.Launcher.csproj` project-references `../Ape.Core/Ape.Core.csproj` (sibling under `src/` in the skeleton) and globs `../Ape.Modules/**` plus Core replica demo plugins.

This repo has **no `.sln` file**. Build it from **ape-skeleton** after `./ape sync` (Core + this launcher + any modules).

```bash
cd ape-skeleton
./ape sync
./ape build
./ape run -c path/to/config.json
```

Standalone `dotnet build Ape.Launcher.csproj` only works when `Ape.Core` sits at `../Ape.Core` relative to this folder (the skeleton layout).

---

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- **(macOS, QUIC only)** `brew install libmsquic`

---

## Acknowledgments

Ape continues ideas from [ApertusVR](https://github.com/MTASZTAKI/ApertusVR).
ApertusVR was originally co-developed by [Peter Kovacs](https://github.com/pkovacs86) and [Akos Hamori](https://github.com/aklen).

---

## License

Copyright (c) 2026 [Akos Hamori](https://github.com/aklen).

Licensed under the [Mozilla Public License 2.0 (MPL-2.0)](https://www.mozilla.org/MPL/2.0/).

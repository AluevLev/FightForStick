## 🎮 Fight for Stick

Fight for Stick is a production-grade 2D physical ragdoll action game featuring procedural animation, dynamic locomotion, and physics-driven combat.
The project showcases a complex architecture built entirely within a decoupled, Clean Architecture workflow. By utilizing a customized multi-assembly framework, the gameplay logic is completely separated from the rendering engine: IceFebruary.Pure (POCO) governs entity states, deterministic time cycles, and 2D spatial mathematics, while IceFebruary.Bridge handles runtime synchronization and visual inspector components.

------------------------------

## 🕹 Gameplay Sandbox Preview

> 💡 **Architectural Note:** *Fight for Stick* is compiled as a **deterministic physical sandbox** designed to stress-test the *IceFebruary* core infrastructure under extreme physics conditions. Rather than tracking traditional health points, the gameplay focuses entirely on interactive ragdoll balancing, procedural walking locomotion, and non-alloc impulse distributions.

<table>
  <tr>
    <td><img src="Media/Gameplay1.png" alt="Ragdoll Combat Layout" width="450" height="230"></td>
    <td><img src="Media/Gameplay2.png" alt="Procedural Weapon Mechanics" width="450" height="230"></td>
  </tr>
  <tr>
    <td colspan="2" align="center"><img src="Media/Gameplay3.png" alt="Scale Testing with Giant Entities" width="550" height="370"></td>
  </tr>
</table>

------------------------------

## ✨ Architectural Accomplishments

* Pure Object-Oriented Domain Layer: The core gameplay logic is completely written in standard C#, isolating player behavior, weapon calculations, and movement loops from engine-specific dependencies.
* Unified Control Abstraction: Leverages a single input provider strategy to drive both live player actions and automated AI agents.
* Component-Driven Capability Systems: Avoids deep inheritance hierarchies (e.g., Weapon -> AnimatedWeapon -> Saw) by utilizing granular, atomic capability contracts (IPickable, IUsable, IReleasable).
* Zero-Allocation Particle & Bullet Pooling: Utilizes highly optimized, cyclic object tracking pipelines that manage project life spans inside a fast array buffer to completely bypass runtime memory fragmentation.
* Automated Data Binding: Links Plain-Data Configurations (IRootConfig) directly with compiled visual components using external reflection parsing tools.

------------------------------

## 🛠 Subsystem & Core Gameplay Mechanics## 1. Fluent Ragdoll Assembly (StickmanBuilder)

Orchestrates the instantiation and procedural composition of complete physical character entities using a readable Fluent Interface pattern:

* SetLimbs: Processes incoming raw configuration components, builds individualized interpolation calculators (PhysicsBalancerCalculator), and instantiates automated balance drivers (PhysicsBalancer) for each skeletal limb.
* SetMovement: Generates local environmental non-alloc scanner boxes (AreaScanner) and sets up core locomotion parameters.
* SetItemHolder & SetInput: Builds dynamic attachment targets (DirectionRotor2Provider) to rotate held equipment toward target positions, and wires interface wrappers into standard frame loops.

## 2. Procedural Walking & Locomotion (EntityMotor)

Controls physical movement behaviors on multi-joint characters through pre-calculated angular strategies:

* EntityMotor: Commands skeletal leg hierarchies by defining physical bounds directly inside the constructor (rest * amplitude.Inverse), eliminating complex real-time geometric operations.
* EntityMotorHandler: Driven strictly via physical time frames (IFixedFrame). It evaluates environmental intersections, scans a single-tick jump verification component, and cycles hip targets alternatingly (OpenHips/CloseHips) based on standalone cooling timers to form natural walking gaits.

## 3. Capability-Based Equipment System

* EntityItemHolderHandler: Operates as a master equipment manager. It checks targeted activation bounds using fast squared-distance checks (Vector2.SqrDistance) to bypass resource-heavy squareroot math. It flips physical execution layers to prevent entity self-collision and pushes orientation strategies directly into the weapon chassis.
* Saw: Provides an animated tools module that alters values directly inside crash-proof tracker variables (AnimatorField<bool>), managing visual parameters safely across frame disruptions.
* Shooting & ShootingCalculator: Manages high-speed firing routines. It tracks projectile availability thresholds, activates impulse forces, and simultaneously applies exact reverse physical force vectors (GetRecoilForce) to the weapon frame to produce responsive, procedurally reactive muzzle kickbacks.

## 4. Cyclical Memory Recycling (ObjectPool)

Bypasses active runtime allocation spikes during heavy projectile-heavy combat encounters:

* ObjectPool: Instantiates a pre-allocated array of components upon level startup. The spawn engine accesses indices directly through a cyclical mathematical modulus operation (_currentObjectIndex + 1) % _pool.Length, ensuring rapid execution.
* TemporaryObject: Monitors pooled elements via an isolated frame thread. It tracks custom decay timelines, resetting active parameters to default and disabling the underlying game object immediately upon cooldown termination.

## 5. Strategy-Driven Input Layers (IInputProvider)

* UnityPlayerInputProvider: Bridges active player control vectors from hardware controllers into the logical POCO environment, evaluating parameters inside standard frame loops.
* EnemyInputProvider: Drives automated combat agents entirely within the C# domain model. It evaluates movement headings using simple relational comparisons (targetPosition.X.CompareTo(enemyPosition.X)) and alters cursor behaviors dynamically depending on weapon presence.

------------------------------

## 🎨 Workflow Automation & Compiler Proxies

The project utilizes the compilation tools provided by IceFebruary.Proxy to establish a clean boundary between visual property editing and backend execution. By declaring structures using semantic attributes ([FieldProxy], [DataObjectProxy]), the automation script extracts parameter data and emits optimized serialization components automatically into the editing workspace.

## The Inspector Lifecycle Layout

When a level loads, the data management flow processes as follows:

[Designer Config Asset] -> [Compiled Proxy Script] -> [TryGetRootConfig()] -> [Pure IRootConfig DTO] -> [Target Instance Setter]


   1. Visual Field Editors: Script parameters (e.g., specific integer identifier hashes built via the AnimatorNameToHashConverter window) are inputted visually inside scannable fields.
   2. [FieldProxy] Generation: Structures such as MovementConfig or AreaScannerConfig are automatically processed by the compile-time code generator, yielding custom serialization wrappers (e.g., SawConfig_AUTOGENERATED).
   3. [DataObjectProxy] Configuration: Global variables and physics profiles are saved into portable configuration data sheets (ScriptableObject modules), enabling developers to reuse systemic profiles (like AreaScannerSettings) across many independent targets.
   4. Automated Conversion & Disposal: During environment loading, the game assembly reads user-facing property variables, instantiates matching raw IRootConfig logical models, passes them safely to the POCO core factory managers, and deletes the visual configuration wrapper to maintain a minimal memory profile.

------------------------------

## 🧱 Framework Dependencies

This game is built on top of a modular ecosystem. To understand the underlying core systems, automated proxy generation, and high-performance execution layers used in this project, check out the main framework repositories:

* 🧊 **[IceFebruary](https://github.com/AluevLev/IceFebruary)** — The standalone, zero-allocation C# (POCO) architectural core focusing on rigid determinism and clean business logic.
* 🧊 **[UnityIceFebruary](https://github.com/AluevLev/UnityIceFebruary)** — The high-performance binding, conversion, and compile-time code-generation layer for engine integration.

------------------------------

## ⚙️ Technical Profile & Specifications

* Language Specification: C# 9.0+ / Unsafe Code block execution enabled.
* Compilation Environment: Compatible with modern standard libraries and common component-based execution environments.
* Framework Pre-requisites: Requires a direct reference path to the companion IceFebruary and UnityIceFebruary assemblies.
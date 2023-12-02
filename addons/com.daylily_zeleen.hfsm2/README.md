# HFSM2 - Alpha - Godot 4.2 stable

[中文文档](README_zh_cn.md)

A enhance version of [HFSM](https://github.com/Daylily-Zeleen/HierarchicalFiniteStateMachine).

This repository is built binary plugin, and under MIT license.
There have not plan to public source code currently.

## Features

1. Prefect visual editor.
2. Visualized debugger.
3. High perforamce, building base on GDExtension.
4. Supports hierarchical nesting and can be used in complex situations.
5. Diversified transition plans.
6. Two development modes: signal callbacks and attached state scripts.
7. Has ability of working with animaions( Can be an Animation State Mechine).
8. Attch GDScript/CSharpScript to implement State Logic.
9. Attch GDScript/CSharpScript to implement Transition Logic (full version only).

## Some usage hints

I have not time to write a prefect document and create some demos, I can only remain some hints here.

1. This plugin's basic concept is like the [3.x version](https://github.com/Daylily-Zeleen/HierarchicalFiniteStateMachine), you can refer its document.
    But be careful, the has many naming different between these two plugins, and this 4.1 version have removed some over desined, such as "agent", and so on.
2. To start edit a `HFSM` node, your should create a `FSMConfig` resource and set to `HFSM`'s property `root_fsm_config`.
3. If you have some confuse when using this plugin, you may get answers/tips at the botton left of the "HFSM Editor" panel.
4. Pressing "Shift" and "Left Button" and drag from a State to another State to create a Transition.
5. Pressing "Alt" and "Mid Button" and drag and draw a line cross through Transitions to delete them.
6. Double left clike on a Transition to select and inspect it.
7. To debug `HFSM`, you can go to `Debugger` panel's `HFSM` tab, the left side is running `HFSM`s node path, double click it to select a `HFSM` and inspect it.
8. According to the design, you should not access all `xxxConfig` classes, they are only store the HFSM structure/infomation for constructing `HFSM`.

    ```
    FSMConfig
    StateConfig
    TransitionConfig
    VariableConfig
    VariableExpressionConfig
    ```

    But this is not mandatory, if you access them, you should clearify what are you doing.

## For C# Users

1. You need build project at least onnce to elimitate error in C# scripts in `res://addons/com.daylily_zeleen.hfsm/CSharpWrappers/`.
2. It is recommended not to use with other langurage scripts.
3. If you need cross langurages programing, when you access members about `HFSM`, `State`, `Variable`, `Transition`, you should use menbers which has `Native` suffix. For example, a HFSM node with GDScript, and States in this HFSM node, it should use `GetHFSMNative()` instead of `GetHFSM()` to access HFSM node in States, and the `Node` you got from `GetHFSMNative()` can't be casted to `HFSM` in C#.

## Notices

1. Currently is not stable version, please avoid to use this plugin in release purpose, I can't guarantee that it will work properly.
2. All apis have possibility to be changed in future.
3. Currently, you can't use `GDExtensionManager`, `ResourceUID`, `IP` singletonS in expression of Transition.
4. Welcome to use and give me feedback by opening issues.

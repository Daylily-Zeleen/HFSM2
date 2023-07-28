# HFSM 2.0.0 - Alpha - for Godot 4.1 stable

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
8. Has ability of working with animaions( Can be an Animation State Mechine).
7. Attch GDScript/CSharpScript to implement State Logic.
8. Attch GDScript/CSharpScript to implement Transition Logic (full version only).

## Some usage hints:
I have not time to write a prefect document and create some demos, I can only remain some hints here.
1. This plugin's basic concept is like the [3.x version](https://github.com/Daylily-Zeleen/HierarchicalFiniteStateMachine), you can refer its document.
    But be careful, the has many naming different between these two plugins, and this 4.1 version have removed some over desined, such as "agent", and so on.
2. To start edit a `HFSM` node, your should create a `FSMConfig` resource and set to `HFSM`'s property `root_fsm_config`.
3. If you have some confuse when using this plugin, you may get answers/tips at the botton left of the "HFSM Editor" panel.
4. Pressing "Shift" and "Left Button" and drag from a State to another State to create a Transition.
5. Pressing "Alt" and "Mid Button" and drag and draw a line cross through Transitions to delete them.
6. Double left clike on a Transition to select and inspect it.
7. To debug `HFSM`, you can go to `Debugger` panel's `HFSM` tab, the left side is running `HFSM`s node path, double click it to select a `HFSM` and inspect it.
8. Currently, GDExtension can't bind unexposed classes, I must to expose all editor classes, please don't use them in your runtime code.
    Dont use these classes, they are unavailable at runtime:
    ```
    HfsmEditorPlugin
    EditorPropertyVariableConfig
    VariableConfigSelector
    StateNode
    FsmEditor
    HfsmInspectorPlugin
    HFSMEditor
    HfsmDebuggerPlugin
    HfsmDebugger
    ```
9. According to the design, you should not access all `xxxConfig` classes, they are only store the HFSM struct/info for constructing `HFSM`.
    ```
    FSMConfig
	StateConfig
	TransitionConfig
	VariableConfig
	VariableExpressionConfig
    ```
    But this is not mandatory, if you access them, you should clearify what are you doing.

## Notices:
1. Currently only support on windows, both debug and release version (I need some tutorial to build other platforms on windows, I will be very grateful if you provide to me.).
2. Currently is not stable version, please avoid to use this plugin in release purpose, I can't guarantee that it will work properly.
3. All apis have possibility to be changed in future.
4. Welcome to use and give me feedback by opening issues.
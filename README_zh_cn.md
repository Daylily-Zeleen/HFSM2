# HFSM2 - Alpha - Godot 4.2 stable

[English readme](README.md)

[HFSM](https://github.com/Daylily-Zeleen/HierarchicalFiniteStateMachine)的加强版。

该仓库是编译完成后的二进制文件插件，遵循MIT许可证。
目前没有公布源代码的计划。

## 特性

1. 完整的可视化编辑器。
2. 可视化调试器。
3. 基于GDExtension构建，高性能。
4. 支撑分层嵌套，适用于复杂场景。
5. 多种转换条件。
6. 两种开发模式：信号回调与状态脚本.
7. 能够作为动画状态机使用。
8. 能够附加GDSCript/CSharpScript来实现状态逻辑。
9. 能够附加GDSCript/CSharpScript来实现转换流逻辑。

## Some usage hints

我没有时间来编写一个详细的文档和创建一些demo，只能在此留下一些使用提示。

1. 该插件的基本概念与[3.x版本](https://github.com/Daylily-Zeleen/HierarchicalFiniteStateMachine)相似，可以参考旧版的文档。
    需要注意的是，这两个插件有多出命名差异，并且该插件删除了诸如"agent"之类的过度设计。
2. 你需要为`HFSM`的`root_fsm_config`属性设置一个`FSMConfig`资源以开始编辑。
3. 如果你在使用该插件的过程中有些疑惑，你可以参考"HFSM Editor"面板的左下角提示，也许你能够在此找到你要的答案。
4. 按住"Shift"和"Left Button"并从一个状态开始拖拽到另一个状态，以创建一个转换流。
5. 按住"Alt"和"Mid Button"拖拽出一条穿过转换流的线以删除这些转换流。
6. 双击转换流以选择和在检查器中查看它。
7. 你可以通过使用"Debugger"面板的“HFSM”标签页来帮助你进行调试（必须有调试进程才会出现该标签页）。该标签页的左侧是运行中的`HFSM`节点路径，双击选择一个`HFSM`将在右侧显式它的运行情况。
8. 根据设计意图，你不应该访问该插件中名为`xxxConfig`的类，他们用于设计时存储状态机的结构与信息，并用于运行时构建`HFSM`。

    ```
    FSMConfig
    StateConfig
    TransitionConfig
    VariableConfig
    VariableExpressionConfig
    ```

    当然这不是强制要求，如果你确实需要访问他们，请确保你知道你在做什么。

## C# 用户须知

1. 需要至少一次构建才能消除`res://addons/com.daylily_zeleen.hfsm/CSharpWrappers/`中的脚本错误提示。
2. 建议不要与其他类型脚本混用。
3. 如果你需要跨语言编程，在遇到与`HFSM`、`State`、`Variable`,`Transition`相关的成员时,请使用包装类中带有`Native`后缀的成员，例如，HFSM节点使用GDScript脚本,而其中的State为C#脚本，应该使用`GetHFSMNative()`而不是`GetHFSM()`来访问HFSM节点，并且`GetHFSMNative()`得到的`Node`不能转换为C#中的`HFSM`。

## 注意

1. 目前并非稳定岸本，请不要用于发布目的，我不能对可靠性做任何保证。
2. 所有的Api都有可能在将来被改变。
3. 暂时不能在转换流表达式中使用 `GDExtensionManager`, `ResourceUID`, `IP` 单例。
4. 欢迎使用并在issue中向我反馈任何bug。

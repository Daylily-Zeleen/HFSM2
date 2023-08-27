namespace Godot;

internal interface IHFSMClass<T>
{
    internal static Script ClassScript = null!;
}

internal static partial class HFSMUtils
{
    internal static string GetScriptPath<T>()
    {
        foreach (var attr in typeof(T).GetCustomAttributes(false))
        {
            if (attr is ScriptPathAttribute scriptPath)
            {
                return scriptPath.Path;
            }
        }

        // TODO:: Exception.
        return "";
    }

    internal static T? TryConvert<T>(GodotObject? obj) where T : class, IHFSMClass<T>
    {
        if (obj is null || !obj.IsClass(typeof(T).Name))
        {
            return null;
        }

        if (obj.GetScript().AsGodotObject() is not Script script)
        {
            obj.SetScript(IHFSMClass<T>.ClassScript);
            return obj as T;
        }
        else
        {
            while (script is not null)
            {
                if (script == IHFSMClass<T>.ClassScript)
                {
                    return obj as T;
                }

                script = script.GetBaseScript();
            }

            // TODO:: Exception.
            return null;
        }
    }

    internal static T? TryConvert<T>(Variant obj) where T : class, IHFSMClass<T>
    {
        return TryConvert<T>(obj.AsGodotObject());
    }

    internal static Collections.Array<T?> TryConvertArray<[MustBeVariant] T>(Collections.Array objList) where T : class, IHFSMClass<T>
    {
        var ret = new Collections.Array<T?>();
        foreach (var obj in objList)
        {
            ret.Add(TryConvert<T>(obj));
        }
        return ret;
    }

    internal static Collections.Array<T?> TryConvertArray<[MustBeVariant] T>(Variant objList) where T : class, IHFSMClass<T>
    {
        return TryConvertArray<T>(objList.AsGodotArray());
    }

    internal static void RequestLoadScript<T>() where T : class, IHFSMClass<T>
    {
        var path = GetScriptPath<T>();
        ResourceLoader.LoadThreadedRequest(path, "Script", true);
        LoadScriptThread<T>(path);
    }

    private static void LoadScriptThread<T>(string path) where T : class, IHFSMClass<T>
    {
        switch (ResourceLoader.LoadThreadedGetStatus(path))
        {
            case ResourceLoader.ThreadLoadStatus.Failed:
                {
                    GD.PrintErr($"Load script \"{path}\" failed.");
                    return;
                }
            case ResourceLoader.ThreadLoadStatus.InvalidResource:
                {
                    GD.PrintErr($"\"{path}\" is invalid resource.");
                    return;
                }
            case ResourceLoader.ThreadLoadStatus.Loaded:
                {
                    IHFSMClass<T>.ClassScript = (ResourceLoader.LoadThreadedGet(path) as Script)!;
                    return;
                }
            case ResourceLoader.ThreadLoadStatus.InProgress:
                {
                    Engine.GetMainLoop().Connect(SceneTree.SignalName.ProcessFrame,
                        Callable.From(() => LoadScriptThread<T>(path)), (uint)GodotObject.ConnectFlags.OneShot);
                    return;
                }
        }
    }
}
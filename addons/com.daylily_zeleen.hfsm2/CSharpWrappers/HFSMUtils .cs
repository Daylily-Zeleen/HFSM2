namespace Godot;

internal interface IHFSMClass<T> where T : class, IHFSMClass<T>
{
    internal static readonly Script ClassScript;

    static IHFSMClass()
    {
        ClassScript = HFSMUtils.LoadAndGetScript<T>();
    }
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

        throw new System.Exception(
            $"Type \"{typeof(T).Name}\" is not inherited from \"GodotObject\" and has not \"ScriptPath\" attribute.");
    }

    internal static Script LoadAndGetScript<T>() where T : class
    {
        return GD.Load<Script>(GetScriptPath<T>());
    }

    internal static T? TryConvert<T>(GodotObject? obj) where T : class, IHFSMClass<T>
    {
        if (obj is null || !obj.IsClass(typeof(T).Name))
        {
            return null;
        }

        if (obj.GetScript().AsGodotObject() is not Script script)
        {
            var id = obj.GetInstanceId();
            obj.SetScript(IHFSMClass<T>.ClassScript);
            return GodotObject.InstanceFromId(id) as T;
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

            throw new System.Exception(
                $"Cast to \"{typeof(T).FullName}\", The script of \"{obj}\" is not inherited from \"{GetScriptPath<T>()}\".");
        }
    }

    internal static T? TryConvert<T>(Variant obj) where T : class, IHFSMClass<T>
    {
        return TryConvert<T>(obj.AsGodotObject());
    }

    internal static Collections.Array<T?> TryConvertArray<[MustBeVariant] T>(Collections.Array objList)
        where T : class, IHFSMClass<T>
    {
        var ret = new Collections.Array<T?>();
        foreach (var obj in objList)
        {
            ret.Add(TryConvert<T>(obj));
        }

        return ret;
    }

    internal static Collections.Array<T?> TryConvertArray<[MustBeVariant] T>(Variant objList)
        where T : class, IHFSMClass<T>
    {
        return TryConvertArray<T>(objList.AsGodotArray());
    }


}
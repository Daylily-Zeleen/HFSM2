namespace Godot;

/// <summary>
/// Class Variable
/// </summary>
public partial class Variable : RefCounted, IHFSMClass<Variable>
{
	private static readonly StringName PropValue = "value";
	/// <summary>
	/// Peoperty value
	/// </summary>
	public Variant Value
	{
		get => Get(PropValue).As<Variant>();
		set => Set(PropValue, Variant.From(value));
	}

	private static readonly StringName FuncGetVariableName = "get_variable_name";
	/// <summary>
	/// Method func get_variable_name() -> StringName
	/// </summary>
	public StringName GetVariableName()
	{
		return Call(FuncGetVariableName).As<StringName>();
	}

	private static readonly StringName FuncGetVariableType = "get_variable_type";
	/// <summary>
	/// Method func get_variable_type() -> Variant.Type
	/// </summary>
	public Variant.Type GetVariableType()
	{
		return Call(FuncGetVariableType).As<Variant.Type>();
	}

	private static readonly StringName FuncIsTrigger = "is_trigger";
	/// <summary>
	/// Method func is_trigger() -> bool
	/// </summary>
	public bool IsTrigger()
	{
		return Call(FuncIsTrigger).As<bool>();
	}

	private static readonly StringName FuncFlushTrigger = "flush_trigger";
	/// <summary>
	/// Method func flush_trigger() -> void
	/// </summary>
	public void FlushTrigger()
	{
		Call(FuncFlushTrigger);
	}

	/// <summary>
	/// Constructor Variable()
	/// </summary>
	public Variable()
	{
		if (GetClass() != "Variable")
		{
			throw new System.Exception("In C#, You should instantiate a \"Variable\" through ClassDB and attach this script instead of creating \"Godot.Variable\"  by \"new()\".");
		}

	}

	/// <summary>
	/// Variable script.
	/// </summary>
	public static Script ClassScript => IHFSMClass<Variable>.ClassScript;
}

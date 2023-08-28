namespace Godot;

/// <summary>
/// Class HFSM
/// </summary>
public partial class HFSM : Node, IHFSMClass<HFSM>
{
	/// <summary>
	/// Enum HFSMUpdateType
	/// </summary>
	public enum HFSMUpdateType
	{
		/// <summary>
		/// HFSM_UPDATE_TYPE_IDLE_AND_PHYSICS
		/// </summary>
		HFSMUpdateTypeIdleAndPhysics = 0,
		/// <summary>
		/// HFSM_UPDATE_TYPE_IDLE
		/// </summary>
		HFSMUpdateTypeIdle = 1,
		/// <summary>
		/// HFSM_UPDATE_TYPE_PHYSICS
		/// </summary>
		HFSMUpdateTypePhysics = 2,
		/// <summary>
		/// HFSM_UPDATE_TYPE_MANUAL
		/// </summary>
		HFSMUpdateTypeManual = 3,
	}

	/// <summary>
	/// Signal updated(state: State, delta: float)
	/// </summary>
	[Signal]
	public delegate void UpdatedEventHandler(State? state, float delta);
	/// <summary>
	/// Native Signal updated(state: State, delta: float)
	/// </summary>
	[Signal]
	public delegate void UpdatedNativeEventHandler(GodotObject? state, float delta);
	private static readonly StringName SignalUpdated = "updated";
	private void SignalCallbackUpdated(GodotObject? state, float delta)
	{
		EmitSignal(SignalName.UpdatedNative, Variant.From(state), Variant.From(delta));
		EmitSignal(SignalName.Updated, Variant.From(HFSMUtils.TryConvert<State>(state)), Variant.From(delta));
	}

	/// <summary>
	/// Signal physic_updated(state: State, delta: float)
	/// </summary>
	[Signal]
	public delegate void PhysicUpdatedEventHandler(State? state, float delta);
	/// <summary>
	/// Native Signal physic_updated(state: State, delta: float)
	/// </summary>
	[Signal]
	public delegate void PhysicUpdatedNativeEventHandler(GodotObject? state, float delta);
	private static readonly StringName SignalPhysicUpdated = "physic_updated";
	private void SignalCallbackPhysicUpdated(GodotObject? state, float delta)
	{
		EmitSignal(SignalName.PhysicUpdatedNative, Variant.From(state), Variant.From(delta));
		EmitSignal(SignalName.PhysicUpdated, Variant.From(HFSMUtils.TryConvert<State>(state)), Variant.From(delta));
	}

	/// <summary>
	/// Signal transited(from_state: State, to_state: State)
	/// </summary>
	[Signal]
	public delegate void TransitedEventHandler(State? fromState, State? toState);
	/// <summary>
	/// Native Signal transited(from_state: State, to_state: State)
	/// </summary>
	[Signal]
	public delegate void TransitedNativeEventHandler(GodotObject? fromState, GodotObject? toState);
	private static readonly StringName SignalTransited = "transited";
	private void SignalCallbackTransited(GodotObject? fromState, GodotObject? toState)
	{
		EmitSignal(SignalName.TransitedNative, Variant.From(fromState), Variant.From(toState));
		EmitSignal(SignalName.Transited, Variant.From(HFSMUtils.TryConvert<State>(fromState)), Variant.From(HFSMUtils.TryConvert<State>(toState)));
	}

	/// <summary>
	/// Signal entered(state: State)
	/// </summary>
	[Signal]
	public delegate void EnteredEventHandler(State? state);
	/// <summary>
	/// Native Signal entered(state: State)
	/// </summary>
	[Signal]
	public delegate void EnteredNativeEventHandler(GodotObject? state);
	private static readonly StringName SignalEntered = "entered";
	private void SignalCallbackEntered(GodotObject? state)
	{
		EmitSignal(SignalName.EnteredNative, Variant.From(state));
		EmitSignal(SignalName.Entered, Variant.From(HFSMUtils.TryConvert<State>(state)));
	}

	/// <summary>
	/// Signal exited(state: State)
	/// </summary>
	[Signal]
	public delegate void ExitedEventHandler(State? state);
	/// <summary>
	/// Native Signal exited(state: State)
	/// </summary>
	[Signal]
	public delegate void ExitedNativeEventHandler(GodotObject? state);
	private static readonly StringName SignalExited = "exited";
	private void SignalCallbackExited(GodotObject? state)
	{
		EmitSignal(SignalName.ExitedNative, Variant.From(state));
		EmitSignal(SignalName.Exited, Variant.From(HFSMUtils.TryConvert<State>(state)));
	}

	private static readonly StringName PropUpdateType = "update_type";
	/// <summary>
	/// Peoperty update_type
	/// </summary>
	public HFSMUpdateType UpdateType
	{
		get => Get(PropUpdateType).As<HFSMUpdateType>();
		set => Set(PropUpdateType, Variant.From(value));
	}

	private static readonly StringName PropActive = "active";
	/// <summary>
	/// Peoperty active
	/// </summary>
	public bool Active
	{
		get => Get(PropActive).As<bool>();
		set => Set(PropActive, Variant.From(value));
	}

	private static readonly StringName PropAnimationPlayer = "animation_player";
	/// <summary>
	/// Peoperty animation_player
	/// </summary>
	public AnimationPlayer? AnimationPlayer
	{
		get => Get(PropAnimationPlayer).As<AnimationPlayer?>();
		set => Set(PropAnimationPlayer, Variant.From(value));
	}

	private static readonly StringName PropRootFsmConfig = "root_fsm_config";
	/// <summary>
	/// Peoperty root_fsm_config
	/// </summary>
	public GodotObject? RootFsmConfig
	{
		get => Get(PropRootFsmConfig).As<GodotObject?>();
		set => Set(PropRootFsmConfig, Variant.From(value));
	}

	private static readonly StringName FuncGetCurrentState = "get_current_state";
	/// <summary>
	/// Method func get_current_state() -> State
	/// </summary>
	public State? GetCurrentState()
	{
		return HFSMUtils.TryConvert<State>(Call(FuncGetCurrentState));
	}

	/// <summary>
	/// Native Method func get_current_state() -> State
	/// </summary>
	public GodotObject? GetCurrentStateNative()
	{
		return Call(FuncGetCurrentState).AsGodotObject();
	}

	private static readonly StringName FuncGetPreviousState = "get_previous_state";
	/// <summary>
	/// Method func get_previous_state() -> State
	/// </summary>
	public State? GetPreviousState()
	{
		return HFSMUtils.TryConvert<State>(Call(FuncGetPreviousState));
	}

	/// <summary>
	/// Native Method func get_previous_state() -> State
	/// </summary>
	public GodotObject? GetPreviousStateNative()
	{
		return Call(FuncGetPreviousState).AsGodotObject();
	}

	private static readonly StringName FuncRestart = "restart";
	/// <summary>
	/// Method func restart() -> void
	/// </summary>
	public void Restart()
	{
		Call(FuncRestart);
	}

	private static readonly StringName FuncGetVar = "get_var";
	/// <summary>
	/// Method func get_var(variable_name: StringName) -> Variable
	/// </summary>
	public Variable? GetVar(StringName variableName)
	{
		return HFSMUtils.TryConvert<Variable>(Call(FuncGetVar, variableName));
	}

	/// <summary>
	/// Native Method func get_var(variable_name: StringName) -> Variable
	/// </summary>
	public GodotObject? GetVarNative(StringName variableName)
	{
		return Call(FuncGetVar, variableName).AsGodotObject();
	}

	private static readonly StringName FuncGetVars = "get_vars";
	/// <summary>
	/// Method func get_vars() -> Array[Variable]
	/// </summary>
	public Collections.Array<Variable?> GetVars()
	{
		return HFSMUtils.TryConvertArray<Variable>(Call(FuncGetVars));
	}

	/// <summary>
	/// Native Method func get_vars() -> Array[Variable]
	/// </summary>
	public Collections.Array GetVarsNative()
	{
		return Call(FuncGetVars).AsGodotArray();
	}

	private static readonly StringName FuncGetVarValue = "get_var_value";
	/// <summary>
	/// Method func get_var_value(variable_name: StringName) -> void
	/// </summary>
	public Variant GetVarValue(StringName variableName)
	{
		return Call(FuncGetVarValue, variableName).As<Variant>();
	}

	private static readonly StringName FuncGetVarsValue = "get_vars_value";
	/// <summary>
	/// Method func get_vars_value() -> Dictionary
	/// </summary>
	public Collections.Dictionary GetVarsValue()
	{
		return Call(FuncGetVarsValue).As<Collections.Dictionary>();
	}

	private static readonly StringName FuncSetVar = "set_var";
	/// <summary>
	/// Method func set_var(variable_name: StringName, value: Variant) -> void
	/// </summary>
	public void SetVar(StringName variableName, Variant value)
	{
		Call(FuncSetVar, variableName, value);
	}

	private static readonly StringName FuncSetTrigger = "set_trigger";
	/// <summary>
	/// Method func set_trigger(trigger_name: StringName) -> void
	/// </summary>
	public void SetTrigger(StringName triggerName)
	{
		Call(FuncSetTrigger, triggerName);
	}

	private static readonly StringName FuncSetBoolean = "set_boolean";
	/// <summary>
	/// Method func set_boolean(boolean_name: StringName, value: bool) -> void
	/// </summary>
	public void SetBoolean(StringName booleanName, bool value)
	{
		Call(FuncSetBoolean, booleanName, value);
	}

	private static readonly StringName FuncSetInteger = "set_integer";
	/// <summary>
	/// Method func set_integer(interger_name: StringName, value: int) -> void
	/// </summary>
	public void SetInteger(StringName intergerName, int value)
	{
		Call(FuncSetInteger, intergerName, value);
	}

	private static readonly StringName FuncSetFloat = "set_float";
	/// <summary>
	/// Method func set_float(float_name: StringName, value: float) -> void
	/// </summary>
	public void SetFloat(StringName floatName, float value)
	{
		Call(FuncSetFloat, floatName, value);
	}

	private static readonly StringName FuncSetString = "set_string";
	/// <summary>
	/// Method func set_string(string_name: StringName, value: String) -> void
	/// </summary>
	public void SetString(StringName stringName, string value)
	{
		Call(FuncSetString, stringName, value);
	}

	private static readonly StringName FuncManualUpdate = "manual_update";
	/// <summary>
	/// Method func manual_update() -> void
	/// </summary>
	public void ManualUpdate()
	{
		Call(FuncManualUpdate);
	}

	private static readonly StringName FuncManualPhysicsUpdate = "manual_physics_update";
	/// <summary>
	/// Method func manual_physics_update() -> void
	/// </summary>
	public void ManualPhysicsUpdate()
	{
		Call(FuncManualPhysicsUpdate);
	}

	private static readonly StringName FuncRebuildHFSM = "rebuild_hfsm";
	/// <summary>
	/// Method func rebuild_hfsm() -> bool
	/// </summary>
	public bool RebuildHFSM()
	{
		return Call(FuncRebuildHFSM).As<bool>();
	}

	/// <summary>
	/// Constructor HFSM()
	/// </summary>
	public HFSM()
	{
		if (GetClass() != "HFSM")
		{
			throw new System.Exception("In C#, You should instantiate a \"HFSM\" through ClassDB and attach this script instead of creating \"Godot.HFSM\"  by \"new()\".");
		}

		var cbUpdated = new Callable(this, nameof(this.SignalCallbackUpdated));
		if (!IsConnected(SignalUpdated, cbUpdated))
		{
			Connect(SignalUpdated, cbUpdated);
		}
		var cbPhysicUpdated = new Callable(this, nameof(this.SignalCallbackPhysicUpdated));
		if (!IsConnected(SignalPhysicUpdated, cbPhysicUpdated))
		{
			Connect(SignalPhysicUpdated, cbPhysicUpdated);
		}
		var cbTransited = new Callable(this, nameof(this.SignalCallbackTransited));
		if (!IsConnected(SignalTransited, cbTransited))
		{
			Connect(SignalTransited, cbTransited);
		}
		var cbEntered = new Callable(this, nameof(this.SignalCallbackEntered));
		if (!IsConnected(SignalEntered, cbEntered))
		{
			Connect(SignalEntered, cbEntered);
		}
		var cbExited = new Callable(this, nameof(this.SignalCallbackExited));
		if (!IsConnected(SignalExited, cbExited))
		{
			Connect(SignalExited, cbExited);
		}
	}

	/// <summary>
	/// HFSM script.
	/// </summary>
	public static Script ClassScript => IHFSMClass<HFSM>.ClassScript;
}

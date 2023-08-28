namespace Godot;

/// <summary>
/// Class State
/// </summary>
public partial class State : RefCounted, IHFSMClass<State>
{
	/// <summary>
	/// Enum StateType
	/// </summary>
	public enum StateType
	{
		/// <summary>
		/// STATE_TYPE_NORMAL
		/// </summary>
		StateTypeNormal = 0,
		/// <summary>
		/// STATE_TYPE_ENTRY
		/// </summary>
		StateTypeEntry = 1,
		/// <summary>
		/// STATE_TYPE_EXIT
		/// </summary>
		StateTypeExit = 2,
		/// <summary>
		/// STATE_TYPE_MAX
		/// </summary>
		StateTypeMax = 3,
	}

	/// <summary>
	/// Signal animation_finished()
	/// </summary>
	[Signal]
	public delegate void AnimationFinishedEventHandler();
	private static readonly StringName SignalAnimationFinished = "animation_finished";
	private void SignalCallbackAnimationFinished()
	{
		EmitSignal(SignalName.AnimationFinished);
	}

	private static readonly StringName PropAnimationName = "animation_name";
	/// <summary>
	/// Peoperty animation_name
	/// </summary>
	public StringName AnimationName
	{
		get => Get(PropAnimationName).As<StringName>();
		set => Set(PropAnimationName, Variant.From(value));
	}

	private static readonly StringName PropAnimationBlendTime = "animation_blend_time";
	/// <summary>
	/// Peoperty animation_blend_time
	/// </summary>
	public float AnimationBlendTime
	{
		get => Get(PropAnimationBlendTime).As<float>();
		set => Set(PropAnimationBlendTime, Variant.From(value));
	}

	private static readonly StringName PropAnimationSpeed = "animation_speed";
	/// <summary>
	/// Peoperty animation_speed
	/// </summary>
	public float AnimationSpeed
	{
		get => Get(PropAnimationSpeed).As<float>();
		set => Set(PropAnimationSpeed, Variant.From(value));
	}

	private static readonly StringName PropAnimationReverse = "animation_reverse";
	/// <summary>
	/// Peoperty animation_reverse
	/// </summary>
	public bool AnimationReverse
	{
		get => Get(PropAnimationReverse).As<bool>();
		set => Set(PropAnimationReverse, Variant.From(value));
	}

	private static readonly StringName FuncGetName = "get_name";
	/// <summary>
	/// Method func get_name() -> StringName
	/// </summary>
	public StringName GetName()
	{
		return Call(FuncGetName).As<StringName>();
	}

	private static readonly StringName FuncGetHFSM = "get_hfsm";
	/// <summary>
	/// Method func get_hfsm() -> HFSM
	/// </summary>
	public HFSM? GetHFSM()
	{
		return HFSMUtils.TryConvert<HFSM>(Call(FuncGetHFSM));
	}

	/// <summary>
	/// Native Method func get_hfsm() -> HFSM
	/// </summary>
	public GodotObject? GetHFSMNative()
	{
		return Call(FuncGetHFSM).AsGodotObject();
	}

	private static readonly StringName FuncGetPath = "get_path";
	/// <summary>
	/// Method func get_path() -> Array[State]
	/// </summary>
	public Collections.Array<State?> GetPath()
	{
		return HFSMUtils.TryConvertArray<State>(Call(FuncGetPath));
	}

	/// <summary>
	/// Native Method func get_path() -> Array[State]
	/// </summary>
	public Collections.Array GetPathNative()
	{
		return Call(FuncGetPath).AsGodotArray();
	}

	private static readonly StringName FuncIsExited = "is_exited";
	/// <summary>
	/// Method func is_exited() -> bool
	/// </summary>
	public bool IsExited()
	{
		return Call(FuncIsExited).As<bool>();
	}

	private static readonly StringName FuncGetStateType = "get_state_type";
	/// <summary>
	/// Method func get_state_type() -> State.StateType
	/// </summary>
	public State.StateType GetStateType()
	{
		return Call(FuncGetStateType).As<State.StateType>();
	}

	private static readonly StringName FuncManualExit = "manual_exit";
	/// <summary>
	/// Method func manual_exit() -> void
	/// </summary>
	public void ManualExit()
	{
		Call(FuncManualExit);
	}

	private static readonly StringName FuncGetAnimationNameForPlaying = "get_animation_name_for_playing";
	/// <summary>
	/// Method func get_animation_name_for_playing() -> StringName
	/// </summary>
	public StringName GetAnimationNameForPlaying()
	{
		return Call(FuncGetAnimationNameForPlaying).As<StringName>();
	}

	private static readonly StringName FuncIsAnimationPlaying = "is_animation_playing";
	/// <summary>
	/// Method func is_animation_playing() -> bool
	/// </summary>
	public bool IsAnimationPlaying()
	{
		return Call(FuncIsAnimationPlaying).As<bool>();
	}

	/// <summary>
	/// Constructor State()
	/// </summary>
	public State()
	{
		if (GetClass() != "State")
		{
			throw new System.Exception("In C#, You should instantiate a \"State\" through ClassDB and attach this script instead of creating \"Godot.State\"  by \"new()\".");
		}

		var cbAnimationFinished = new Callable(this, nameof(this.SignalCallbackAnimationFinished));
		if (!IsConnected(SignalAnimationFinished, cbAnimationFinished))
		{
			Connect(SignalAnimationFinished, cbAnimationFinished);
		}
	}

	private void _initialize()
	{
		_Initialize();
	}

	/// <summary>
	/// Virtual func _initialize() -> void
	/// </summary>
	protected virtual void _Initialize()
	{
	}

	private void _entry()
	{
		_Entry();
	}

	/// <summary>
	/// Virtual func _entry() -> void
	/// </summary>
	protected virtual void _Entry()
	{
	}

	private void _update(float delta)
	{
		_Update(delta);
	}

	/// <summary>
	/// Virtual func _update(delta: float) -> void
	/// </summary>
	protected virtual void _Update(float delta)
	{
	}

	private void _physics_update(float delta)
	{
		_PhysicsUpdate(delta);
	}

	/// <summary>
	/// Virtual func _physics_update(delta: float) -> void
	/// </summary>
	protected virtual void _PhysicsUpdate(float delta)
	{
	}

	private void _exit()
	{
		_Exit();
	}

	/// <summary>
	/// Virtual func _exit() -> void
	/// </summary>
	protected virtual void _Exit()
	{
	}

	/// <summary>
	/// State script.
	/// </summary>
	public static Script ClassScript => IHFSMClass<State>.ClassScript;
}

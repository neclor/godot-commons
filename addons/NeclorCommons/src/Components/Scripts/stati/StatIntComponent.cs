using Godot;
using NeclorCommons.Components.Interfaces;


namespace NeclorCommons.Components;


[GlobalClass]
public partial class StatIntComponent : Node, IActivatable {


	[Signal]
	public delegate void MaxValueChangedEventHandler(int newMaxValue);
	[Signal]
	public delegate void OnFullEventHandler(int value);
	[Signal]
	public delegate void OnZeroEventHandler();
	[Signal]
	public delegate void ValueChangedEventHandler(int newValue);
	[Signal]
	public delegate void ValueDecreasedEventHandler(int amount);
	[Signal]
	public delegate void ValueIncreasedEventHandler(int amount);


	[ExportGroup("")]
	[Export(PropertyHint.Range, "0, 100, 1, or_greater")]
	int MaxValue {
		get => field;
		set {
			int oldValue = field;
			int MaxValue = Mathf.Max(0, value);
			if (oldValue == MaxValue) return;

			MaxValueChanged.Emit(MaxValue);
			if (value == MaxValue) {
				OnFull.Emit(value);
			}



		}

		var old_max_value: int = max_value
	max_value = maxi(0, new_max_value)
	if old_max_value == max_value: return
	max_value_changed.emit(max_value)

	var old_value: int = value
	value = value
	if old_value == value

	value == max_value: on_full.emit(value)
} = 100;




	@export_range(0, 100, 1, "or_greater") var max_value: int = 100:
	get = get_max_value,
	set = set_max_value
@export_range(0, 100, 1, "or_greater") var value: int = 100:
	get = get_value,
	set = set_value





	[ExportGroup("")]
	[Export(PropertyHint.Range, "0, 100, 1, or_greater")]
	public int Value { get; set; } = 100;



	[ExportGroup("")]
	[Export]
	public bool Active { get; set; }


	public override void _Ready() {
		EmitSignal(SignalName.Died);
	}

}

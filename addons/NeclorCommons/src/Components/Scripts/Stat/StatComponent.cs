using Godot;
using NeclorCommons.Components.Interfaces;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class StatComponent : Node, IComponent {


	[Signal]
	public delegate void MaxValueChangedEventHandler(int newMaxValue);
	[Signal]
	public delegate void OnFullEventHandler(int value);
	[Signal]
	public delegate void OnZeroEventHandler();
	[Signal]
	public delegate void ValueChangedEventHandler(int value);
	//TODO:
	//[Signal]
	//public delegate void ValueDecreasedEventHandler(int amount);
	//[Signal]
	//public delegate void ValueIncreasedEventHandler(int amount);


	private const int DefaultValue = 100;


	[ExportGroup("")]
	[Export(PropertyHint.Range, "0, 100, 1, or_greater")]
	public int MaxValue {
		get;
		set {
			int oldMaxValue = field;
			field = Math.Max(0, value);
			if (oldMaxValue == field) return;
			EmitSignal(SignalName.MaxValueChanged, field);

			int oldValue = Value;
			Value = Value;
			if (oldValue == Value && Value == field) EmitSignal(SignalName.OnFull, field);
		}
	} = DefaultValue;

	[Export(PropertyHint.Range, "0, 100, 1, or_greater")]
	public virtual int Value {
		get;
		set {
			int oldValue = field;
			field = Math.Clamp(value, 0, MaxValue);
			int difference = field - oldValue;
			if (difference == 0) return;

			EmitSignal(SignalName.ValueChanged, field);
			//TODO:
			//if difference > 0: value_increased.emit(difference)
			//else: value_decreased.emit(-difference)

			if (IsFull) EmitSignal(SignalName.OnFull, field);
			if (IsZero) EmitSignal(SignalName.OnZero);
		}
	} = DefaultValue;


	public bool IsFull {
		get => Value == MaxValue;
	}
	public bool IsZero {
		get => Value == 0;
	}


	public StatIntComponent(int maxValue = DefaultValue, int value = DefaultValue) {
		MaxValue = maxValue;
		Value = value;
	}

	public int DecreaseMaxValue(int amount) {
		int oldMaxValue = MaxValue;
		MaxValue -= amount;
		return oldMaxValue - MaxValue;
	}

	public int IncreaseMaxValue(int amount) {
		int oldMaxValue = MaxValue;
		MaxValue += amount;
		return MaxValue - oldMaxValue;
	}

	public int DecreaseValue(int amount) {
		int oldValue = Value;
		Value -= amount;
		return oldValue - Value;
	}

	public int IncreaseValue(int amount) {
		int oldValue = Value;
		Value += amount;
		return Value - oldValue;
	}

	public void SetValueToMax() {
		Value = MaxValue;
	}

	public void SetValueToZero() {
		Value = 0;
	}

	#region Setters
	public void SetValue(int value) {
		Value = value;
	}
	#endregion
}

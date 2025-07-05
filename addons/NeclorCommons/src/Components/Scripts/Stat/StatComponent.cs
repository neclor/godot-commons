using Godot;
using NeclorCommons.Components.Interfaces;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class StatComponent(int maxValue = 100) : Node, IComponent {


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
	} = maxValue;

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
	} = maxValue;


	public bool IsFull => Value == MaxValue;
	public bool IsZero => Value == 0;


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

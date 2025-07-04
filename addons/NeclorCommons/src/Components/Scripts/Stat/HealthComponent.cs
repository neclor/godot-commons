using Godot;
using System;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class HealthComponent : StatComponent {


	[Signal]
	public delegate void ResurrectedEventHandler(int value);


	public override int Value {
		get => base.Value;
		set {
			if (IsDead) return;
			if (value <= 0 || MaxValue <= 0) IsDead = true;
			base.Value = value;
		}
	}

	public bool IsDead { get; private set; } = false;


	public void Kill() {
		SetValueToZero();
	}

	public void Resurrect(int value) {
		if (!IsDead) return;
		IsDead = false;
		Value = value;
		if (!IsDead) EmitSignal(SignalName.Resurrected, Value);
	}

}

using Godot;


namespace Neclor.Godot.Common.Components;


#pragma warning disable CA1000
public interface IScene<TSelf> where TSelf : Node, IScene<TSelf> {

	static abstract string ScenePath { get; }

	static TSelf New() {
		return GD.Load<PackedScene>(TSelf.ScenePath).Instantiate<TSelf>();
	}
}
#pragma warning restore CA1000

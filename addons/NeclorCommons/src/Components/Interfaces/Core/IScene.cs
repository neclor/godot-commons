using Godot;


namespace Neclor.Commons.Components.Interfaces.Core;


public interface IScene<TSelf> where TSelf : Node, IScene<TSelf> {


	static abstract string ScenePath { get; }


	static TSelf New() {
		return GD.Load<PackedScene>(TSelf.ScenePath).Instantiate<TSelf>();
	}
}

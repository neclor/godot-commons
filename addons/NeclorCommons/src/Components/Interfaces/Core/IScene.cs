using Godot;

namespace Neclor.Commons.Components.Interfaces;


public interface IScene {


	static abstract string ScenePath { get; }


	static T New<T>() where T : Node, IScene{
		return GD.Load<PackedScene>(T.ScenePath).Instantiate<T>();
	}
}

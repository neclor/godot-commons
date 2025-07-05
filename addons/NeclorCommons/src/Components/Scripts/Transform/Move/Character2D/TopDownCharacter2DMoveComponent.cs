using Godot;
using NeclorCommons.Utils;


namespace NeclorCommons.Components.Scripts;


[GlobalClass]
public partial class TopDownCharacter2DMoveComponent : Character2DMoveComponent {


	public override void _PhysicsProcess(double delta) {
		if (!IsActive || Character is null) return;

		Vector2 halfDeltaVelocity = Force / Mass * (float)delta / 2;

		Character.Velocity += halfDeltaVelocity;
		Character.Velocity = Character.Velocity.Lerp(InputDirection * Speed, MathfUtils.DecayWeight(Decay, (float)delta));

		Vector2 preCollisionVelocity = Character.Velocity;

		Character.MoveAndSlide();
		Character.Velocity += halfDeltaVelocity;

		PushRigidBodies(preCollisionVelocity);
	}


	protected void PushRigidBodies(Vector2 preCollisionVelocity) {
		if (Character is null) return;

		Action<RigidBody2D, Vector2> pushLogic;
		switch (PushMode) {
			case RigidBodyPushMode.Force:
				pushLogic = (RigidBody2D collider, Vector2 collisionVelocity) => {
					collider.ApplyCentralForce(collisionVelocity * ForceScale);
				};
				break;

			case RigidBodyPushMode.Instant:
				pushLogic = (RigidBody2D collider, Vector2 collisionVelocity) => {
					collider.SetAxisVelocity(collisionVelocity);
				};
				break;

			case RigidBodyPushMode.Disabled:
				return;

			default:
				return;
		}

		int count = Character.GetSlideCollisionCount();
		for (int i = 0; i < count; i++) {
			KinematicCollision2D collision = Character.GetSlideCollision(i);
			GodotObject collider = collision.GetCollider();

			if (collider is not RigidBody2D rigidBody) continue;

			Vector2 collisionVelocity = preCollisionVelocity.Project(-collision.GetNormal());
			pushLogic(rigidBody, collisionVelocity);
		}
	}
}

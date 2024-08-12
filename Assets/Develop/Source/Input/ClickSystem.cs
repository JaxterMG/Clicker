using Scellecs.Morpeh;
using UnityEngine.InputSystem;

namespace Develop.Source
{
	public class ClickSystem : ISystem 
	{
		public World World { get; set; }

		private InputAction fireAction;

		public void OnAwake() 
		{
			var playerInput = new PlayerInput();
			fireAction = playerInput.GameActionMap.Fire;
		}

		public void OnUpdate(float deltaTime) 
		{
			if (fireAction.WasPerformedThisFrame()) 
			{
				var entity = this.World.CreateEntity();
				ref var mouseClickEvent = ref entity.AddComponent<ClickEvent>();
			}
		}

		public void Dispose() 
		{
		}
	}
}
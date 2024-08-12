// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using UnityEngine.InputSystem;

namespace Develop.Source.Input
{
	public class ClickSystem : ISystem 
	{
		public World World { get; set; }
		
		private PlayerInput _playerInput;

		private InputAction _fireAction;

		public void OnAwake()
		{
			_playerInput = new PlayerInput();
			_fireAction = _playerInput.GameActionMap.Fire;
			_playerInput.Enable(); // Активирует управление
		}

		public void OnUpdate(float deltaTime) 
		{
			if (_fireAction.WasPerformedThisFrame()) 
			{
				var entity = World.CreateEntity();
				ref var mouseClickEvent = ref entity.AddComponent<ClickEvent>();
			}
		}

		public void Dispose() 
		{
		}
	}
}
// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Utils;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Develop.Source.Input
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(ClickSystem))]
	public class ClickSystem : UpdateSystem 
	{
		private PlayerInput _playerInput;

		private InputAction _fireAction;

		public override void OnAwake()
		{
			_playerInput = new PlayerInput();
			_fireAction = _playerInput.GameActionMap.Fire;
			_playerInput.Enable();
		}

		public override void OnUpdate(float deltaTime) 
		{
			if (_fireAction.WasPerformedThisFrame()) 
			{
				var entity = World.CreateEntity();
				ref var mouseClickEvent = ref entity.AddComponent<ClickEvent>();
				entity.AddComponent<OneFrame>();
			}
		}

		public void Dispose() 
		{
		}
		
		public static ClickSystem Create() 
		{
			return CreateInstance<ClickSystem>();
		}
	}
}
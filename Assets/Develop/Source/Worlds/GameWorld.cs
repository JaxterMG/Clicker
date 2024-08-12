// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Input;
using Develop.Source.Units;
using Develop.Source.Utils;

namespace Develop.Source.Worlds
{
	using Scellecs.Morpeh;
	using UnityEngine;

	public class GameWorld : MonoBehaviour
	{
		private World _world;
		private SystemsGroup _updateSystems;
		private SystemsGroup _eventSystems;

		private void Awake()
		{
			_world = World.Default;

			_updateSystems = _world.CreateSystemsGroup();

			_updateSystems.AddSystem(new UnitsSpawnSystem());
			_updateSystems.AddSystem(new OneFrame<ClickEvent>());
			_updateSystems.AddSystem(new ClickSystem());

			_updateSystems.Initialize();
		}

		private void Update()
		{
			_world.Update(Time.deltaTime);
			_updateSystems.Update(Time.deltaTime);
			
		}

		private void OnDestroy()
		{
			_updateSystems.Dispose();
			
		}
	}
}
// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Ticks
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(TickSystem))]
	public class TickSystem : UpdateSystem
	{
		private Filter _tickFilter;
		
		private Stash<TickComponent> _tickComponents;
		
		public override void OnAwake()
		{
			_tickFilter = World.Filter.With<TickComponent>().Build();
			_tickComponents = World.GetStash<TickComponent>();
		}

		public override void OnUpdate(float deltaTime)
		{
			foreach (var entity in this._tickFilter)
			{
				ref var tickComponent = ref _tickComponents.Get(entity);
				tickComponent.timePassed += deltaTime;

				if (tickComponent.timePassed >= tickComponent.TickInterval)
				{
					tickComponent.timePassed = 0f;
				}
			}
		}
		public static TickSystem Create() 
		{
			return CreateInstance<TickSystem>();
		}
	}
}
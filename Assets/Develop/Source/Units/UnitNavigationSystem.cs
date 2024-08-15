// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Base;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Units
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UnitNavigationSystem))]
	public class UnitNavigationSystem : UpdateSystem
	{
		private Filter _basesFilter;
		private Filter _navMeshAgentsFilter;

		public override void OnAwake()
		{
			_basesFilter = World.Filter.With<BasePointRef>().Build();
			_navMeshAgentsFilter = World.Filter.With<UnitAgentRef>().Build();
		}

		public override void OnUpdate(float deltaTime)
		{
			foreach (var entity in _navMeshAgentsFilter)
			{
				ref var unitAgent = ref entity.GetComponent<UnitAgentRef>();
				
				if(unitAgent.Value.hasPath) continue;
				
				foreach (var baseEntity in _basesFilter)
				{
					ref var chosenBase = ref baseEntity.GetComponent<BasePointRef>();
					if (!chosenBase.IsUsed)
					{
						chosenBase.IsUsed = true;
						unitAgent.Value.SetDestination(chosenBase.Value.position);
					}
					else
					{
						chosenBase.IsUsed = false;
					}
				}
				
			}
		}

		public void Dispose()
		{
		}
		
		public static UnitNavigationSystem Create() 
		{
			return CreateInstance<UnitNavigationSystem>();
		}
	}
}
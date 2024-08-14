// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Utils;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Units
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UnitsDespawnSystem))]
	public class UnitsDespawnSystem : UpdateSystem
	{
		//TODO: Redo UnitsPool
		public UnitsPool UnitsPool;

		private Filter _baseTriggers;

		public override void OnAwake()
		{
			if (UnitsPool == null) UnitsPool = GameObject.FindObjectOfType<UnitsPool>();
			_baseTriggers = World.Filter.With<TriggerEvent>().Build();
		}

		public override void OnUpdate(float deltaTime)
		{ 
			foreach (var entity in _baseTriggers)
			{
				ref var triggerEvent = ref entity.GetComponent<TriggerEvent>();
				if (triggerEvent.OtherCollider != null)
				{
					DespawnUnit(triggerEvent.OtherCollider.gameObject);
				}
			}
		}

		private void DespawnUnit(GameObject gameObject)
		{
			UnitsPool.Return(gameObject);
		}

		public static UnitsDespawnSystem Create() 
		{
			return CreateInstance<UnitsDespawnSystem>();
		}
	}
}
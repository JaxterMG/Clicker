// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace Develop.Source.Utils
{
	[RequireComponent(typeof(Collider))]
	public class TriggerEventMonoProvider : MonoProvider<TriggerEvent>
	{
		private Entity _associatedEntity;

		private void Awake()
		{
			_associatedEntity = this.Entity;
		}

		private void OnTriggerEnter(Collider other)
		{
			var world = World.Default;
			var triggerEventEntity = world.CreateEntity();

			ref var triggerEventComponent = ref triggerEventEntity.AddComponent<TriggerEvent>();
			triggerEventEntity.AddComponent<OneFrame>();
			//triggerEventComponent.TriggeringEntity = _associatedEntity;
			triggerEventComponent.OtherCollider = other;

			//ref var currentComponent = ref _associatedEntity.GetComponent<TriggerEvent>();
			//currentComponent = triggerEventComponent;
		}
	}
}
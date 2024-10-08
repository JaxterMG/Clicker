﻿// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Utils;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using UnityEngine;

namespace Develop.Source.Base
{
	public sealed class BasePointComponentProvider : MonoProvider<BasePointRef>
	{
		private void OnTriggerEnter(Collider other)
		{
			var world = World.Default;
			var triggerEventEntity = world.CreateEntity();

			ref var triggerEventComponent = ref triggerEventEntity.AddComponent<TriggerEvent>();
			triggerEventEntity.AddComponent<OneFrame>();
			triggerEventComponent.OtherCollider = other;
		}
	}
}
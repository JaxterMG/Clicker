// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Currency;
using Develop.Source.Utils;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Base
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(EntityEnterBaseSystem))]
	public class EntityEnterBaseSystem : UpdateSystem
	{
		private Filter _triggerFilter;
		private Filter _currencyFilter;
		private Stash<CurrencyComponent> _currencyComponents;
		
		public override void OnAwake()
		{
			_triggerFilter = World.Filter.With<TriggerEvent>().Build();
			_currencyFilter = World.Filter.With<CurrencyComponent>().Build();
			_currencyComponents = World.GetStash<CurrencyComponent>();
		}

		public override void OnUpdate(float deltaTime)
		{
			foreach (var entity in _triggerFilter)
			{
				//TODO: Переделать, а то приведет к багу, если будет несколько триггер ивентов
				foreach (var currencyEntity in _currencyFilter)
				{
					ref var currencyComponent = ref _currencyComponents.Get(currencyEntity);
					currencyComponent.EntitiesAmount++;
				}
			}
		}
		public static EntityEnterBaseSystem Create() 
		{
			return new EntityEnterBaseSystem();
		}
	}
}
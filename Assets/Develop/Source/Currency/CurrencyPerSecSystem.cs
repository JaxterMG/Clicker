// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Ticks;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Currency
{

	// Entities amount
	// Currency per entity
	// Currency value
	// Current currency
	// CurrentCurrency = CurrentCurrency + EntitiesAmount * CurrencyPerEntity * CurrencyValue
	// CurrencyPerSec = EntitiesAmount * CurrencyPerEntity * CurrencyValue * 1Sec
	
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CurrencyPerSecSystem))]
	public class CurrencyPerSecSystem : UpdateSystem 
	{
		private Filter _currencyFilter;
		private Filter _ticksFilter;
		private Stash<TickComponent> _tickComponents;
		private Stash<CurrencyComponent> _currencyComponents;

		public override void OnAwake() 
		{
			_currencyFilter = World.Filter.With<CurrencyComponent>().Build();
			_ticksFilter = World.Filter.With<TickComponent>().Build();
			
			_tickComponents = World.GetStash<TickComponent>();
			_currencyComponents = World.GetStash<CurrencyComponent>();
		}

		public override void OnUpdate(float deltaTime) 
		{
			float currencyPerSec = 0f;
			foreach (var tickEntity in _ticksFilter) 
			{
				ref var tickComponent = ref _tickComponents.Get(tickEntity);

				if (tickComponent.timePassed == 0f) 
				{
					foreach (var currencyEntity in _currencyFilter) 
					{
						ref var currencyComponent = ref _currencyComponents.Get(currencyEntity);
						currencyComponent.CurrentCurrency += currencyComponent.EntitiesAmount * currencyComponent.CurrencyPerEntity * currencyComponent.CurrencyValue;
						currencyComponent.CurrencyPerSecond = currencyComponent.EntitiesAmount * currencyComponent.CurrencyPerEntity * currencyComponent.CurrencyValue / tickComponent.TickInterval;
					}
				}
			}
		}
		
		public static CurrencyPerSecSystem Create() 
		{
			return CreateInstance<CurrencyPerSecSystem>();
		}
	}
}
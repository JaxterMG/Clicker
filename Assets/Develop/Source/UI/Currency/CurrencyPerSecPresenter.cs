// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Currency;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.UIElements;

namespace Develop.Source.UI.Currency
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CurrencyPerSecPresenter))]
	public class CurrencyPerSecPresenter : UpdateSystem 
	{
		private Filter _currencyFilter;
		private Filter _gameUIFilter;
		private Stash<CurrencyComponent> _currencyComponents;
		private Stash<GameUIRef> _gameUIRefs;
		public override void OnAwake() 
		{
			_currencyFilter = World.Filter.With<CurrencyComponent>().Build();
			_gameUIFilter = World.Filter.With<GameUIRef>().Build();
			_currencyComponents = World.GetStash<CurrencyComponent>();
			_gameUIRefs = World.GetStash<GameUIRef>();
		}

		public override void OnUpdate(float deltaTime) 
		{
			foreach (var currencyEntity in _currencyFilter)
			{
				foreach (var gameUIEntity in _gameUIFilter)
				{
					var root = _gameUIRefs.Get(gameUIEntity).Value.rootVisualElement;

					var currencyLabel = root.Q<Label>("CurrentCurrencyAmount");
					currencyLabel.text = _currencyComponents.Get(currencyEntity).CurrentCurrency.ToString();
					
					var entityAmountLabel = root.Q<Label>("EntityCounterAmount");
					entityAmountLabel.text = _currencyComponents.Get(currencyEntity).EntitiesAmount.ToString();
					
					var currencyPerSecLabel = root.Q<Label>("CurrencyPerSecAmount");
					currencyPerSecLabel.text = _currencyComponents.Get(currencyEntity).CurrencyPerSecond.ToString();
				}
			}

		}
		
		public static CurrencyPerSecPresenter Create() 
		{
			return CreateInstance<CurrencyPerSecPresenter>();
		}
	}
}
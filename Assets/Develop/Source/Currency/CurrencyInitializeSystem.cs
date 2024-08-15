// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Ticks;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Develop.Source.Currency
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CurrencyInitializeSystem))]
	public class CurrencyInitializeSystem : Initializer
	{
		private string _currencySettingsKey;
		private string _tickSettingsKey;
		
		public override void OnAwake()
		{
			_currencySettingsKey = "CurrencySettings";
			_tickSettingsKey = "TickSettings";
			LoadAndInitialize();
		}
		
		private void LoadAndInitialize() {
			Addressables.LoadAssetAsync<CurrencySettings>(_currencySettingsKey).Completed += OnCurrencySettingsLoaded;
			Addressables.LoadAssetAsync<TickSettings>(_tickSettingsKey).Completed += OnTickSettingsLoaded;
		}

		private void OnCurrencySettingsLoaded(AsyncOperationHandle<CurrencySettings> handle) {
			if (handle.Status == AsyncOperationStatus.Succeeded) {
				var currencySettings = handle.Result;
				InitializeCurrencySystem(currencySettings);
			} else {
				Debug.LogError($"Failed to load CurrencySettings with key: {_currencySettingsKey}");
			}
		}

		private void OnTickSettingsLoaded(AsyncOperationHandle<TickSettings> handle) {
			if (handle.Status == AsyncOperationStatus.Succeeded) {
				var tickSettings = handle.Result;
				InitializeTickSystem(tickSettings);
			} else {
				Debug.LogError($"Failed to load TickSettings with key: {_tickSettingsKey}");
			}
		}

		private void InitializeCurrencySystem(CurrencySettings settings) {
			var world = World.Default;
			var currencyEntity = world.CreateEntity();
			ref var currencyComponent = ref currencyEntity.AddComponent<CurrencyComponent>();

			currencyComponent.EntitiesAmount = settings.EntitiesAmount;
			currencyComponent.CurrencyPerEntity = settings.CurrencyPerEntity;
			currencyComponent.CurrencyValue = settings.CurrencyValue;
			currencyComponent.CurrentCurrency = settings.CurrentCurrency;
		}

		private void InitializeTickSystem(TickSettings settings) {
			var world = World.Default;
			var tickEntity = world.CreateEntity();
			ref var tickComponent = ref tickEntity.AddComponent<TickComponent>();

			tickComponent.TickInterval = settings.tickInterval;
		}
		
		public static CurrencyInitializeSystem Create() 
		{
			return CreateInstance<CurrencyInitializeSystem>();
		}
	}
}
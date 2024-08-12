// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Input;
using Scellecs.Morpeh;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Develop.Source.Units
{
	public class UnitsSpawnSystem : ISystem
	{
		public World World { get; set; }
		
		private Filter _clickEventFilter;
		
		public const string UNIT_PREFAB_ADDRESS = "Units/UnitPrefab";
		private UnitPrefabData _prefabData;

		public void OnAwake()
		{
			_clickEventFilter = World.Filter.With<ClickEvent>().Build();
			Addressables.LoadAssetAsync<UnitPrefabData>(UNIT_PREFAB_ADDRESS).Completed += OnPrefabDataLoaded;
		}

		private void OnPrefabDataLoaded(AsyncOperationHandle<UnitPrefabData> obj) 
		{
			if (obj.Status == AsyncOperationStatus.Succeeded) 
			{
				_prefabData = obj.Result;
			}
		}

		public void OnUpdate(float deltaTime)
		{
			foreach (var entity in _clickEventFilter)
			{
				ref var clickEvent = ref entity.GetComponent<ClickEvent>();
				SpawnUnit();
				entity.RemoveComponent<ClickEvent>();
				World.RemoveEntity(entity);
			}
		}
		private void SpawnUnit()
		{
			GameObject.Instantiate(_prefabData.prefab, Vector3.zero, Quaternion.identity);
		}

		public void Dispose()
		{
		}
	}
}
// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Develop.Source.Input;
using Develop.Source.Spawner;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Develop.Source.Units
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(UnitsSpawnSystem))]
	public class UnitsSpawnSystem : UpdateSystem
	{
		private Filter _clickEventFilter;
		private Filter _spawnsFilter;
		
		public const string UNIT_PREFAB_ADDRESS = "Units/UnitPrefab";
		private UnitPrefabData _prefabData;

		public override void OnAwake()
		{
			_clickEventFilter = World.Filter.With<ClickEvent>().Build();
			_spawnsFilter = World.Filter.With<UnitSpawnPointRef>().Build();
			Addressables.LoadAssetAsync<UnitPrefabData>(UNIT_PREFAB_ADDRESS).Completed += OnPrefabDataLoaded;
		}

		private void OnPrefabDataLoaded(AsyncOperationHandle<UnitPrefabData> obj) 
		{
			if (obj.Status == AsyncOperationStatus.Succeeded) 
			{
				_prefabData = obj.Result;
			}
		}

		public override void OnUpdate(float deltaTime)
		{
			foreach (var entity in _clickEventFilter)
			{
				ref var clickEvent = ref entity.GetComponent<ClickEvent>();
				
				foreach (var spawnerEntity in _spawnsFilter)
				{
					ref var spawnPointRef = ref spawnerEntity.GetComponent<UnitSpawnPointRef>();
					SpawnUnit(spawnPointRef.Value.position);
					break;
				}

				entity.RemoveComponent<ClickEvent>();
				World.RemoveEntity(entity);
			}
		}
		private void SpawnUnit(Vector3 position)
		{
			GameObject.Instantiate(_prefabData.prefab, position, Quaternion.identity);
		}

		public void Dispose()
		{
		}
		
		public static UnitsSpawnSystem Create() 
		{
			return CreateInstance<UnitsSpawnSystem>();
		}
	}
}
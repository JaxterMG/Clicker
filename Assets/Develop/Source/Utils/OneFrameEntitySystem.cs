// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Utils
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OneFrameEntitySystem))]
	public class OneFrameEntitySystem : UpdateSystem 
	{
		private Filter _oneFrameFilter;

		public override void OnAwake() 
		{
			_oneFrameFilter = World.Filter.With<OneFrameEntity>().Build();
		}

		public override void OnUpdate(float deltaTime) 
		{
			var oneFrameComponents = World.GetStash<OneFrameEntity>();
			foreach (var entity in _oneFrameFilter) 
			{
				World.RemoveEntity(entity);
			}
		}
		public static OneFrameEntitySystem Create() 
		{
			return CreateInstance<OneFrameEntitySystem>();
		}
	}
}
// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;

namespace Develop.Source.Utils
{
	[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(OneFrameSystem))]
	public class OneFrameSystem : UpdateSystem 
	{
		private Filter _oneFrameFilter;

		public override void OnAwake() 
		{
			_oneFrameFilter = World.Filter.With<OneFrame>().Build();
		}

		public override void OnUpdate(float deltaTime) 
		{
			var oneFrameComponents = World.GetStash<OneFrame>();
			foreach (var entity in _oneFrameFilter) 
			{
				oneFrameComponents.Remove(entity);
			}
		}

		public void Dispose() 
		{
		}
		
		public static OneFrameSystem Create() 
		{
			return CreateInstance<OneFrameSystem>();
		}
	}
}
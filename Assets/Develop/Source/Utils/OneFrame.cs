// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;

namespace Develop.Source
{

	public class OneFrame<T> : ISystem where T : struct, IComponent 
	{
		public World World { get; set; }

		private Filter filter;

		public void OnAwake() 
		{
			this.filter = this.World.Filter.With<T>().Build();
		}

		public void OnUpdate(float deltaTime) 
		{
			foreach (var entity in this.filter) 
			{
				entity.RemoveComponent<T>();
			}
		}

		public void Dispose() 
		{
		}
	}
}
// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;

namespace Develop.Source.Ticks
{
	[System.Serializable]
	public struct TickComponent : IComponent 
	{
		public float timePassed;
		public float TickInterval;
		
	}
}
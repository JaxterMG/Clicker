// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using UnityEngine.AI;

namespace Develop.Source.Units
{
	[System.Serializable]
	public struct UnitAgentRef : IComponent
	{
		public NavMeshAgent Value;
	}
}
// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;
using UnityEngine;

namespace Develop.Source.Utils
{
	[System.Serializable]
	public struct TriggerEvent : IComponent
	{
		public Collider OtherCollider;
	}
}
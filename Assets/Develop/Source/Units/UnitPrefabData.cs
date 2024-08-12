// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using UnityEngine;

namespace Develop.Source.Units
{
	[CreateAssetMenu(fileName = "UnitPrefabData", menuName = "Configs/UnitPrefabData", order = 1)]
	public class UnitPrefabData : ScriptableObject
	{
		public GameObject prefab;
	}
}
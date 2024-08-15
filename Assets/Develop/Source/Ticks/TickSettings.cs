// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using UnityEngine;

namespace Develop.Source.Ticks
{
	[CreateAssetMenu(fileName = "TickSettings", menuName = "Settings/Tick Settings")]
	public class TickSettings : ScriptableObject 
	{
		public float tickInterval;
	}
}
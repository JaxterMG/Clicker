// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

namespace Develop.Source.Currency
{
	using UnityEngine;

	[CreateAssetMenu(fileName = "CurrencySettings", menuName = "Settings/Currency Settings")]
	public class CurrencySettings : ScriptableObject 
	{
		public int EntitiesAmount;
		public float CurrencyPerEntity;
		public float CurrencyValue;
		public float CurrentCurrency;
	}
}
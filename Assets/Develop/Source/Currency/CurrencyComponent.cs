// SPDX-License-Identifier: Apache-2.0
// © 2024 JaxterMG <eugeny.craevsky@gmail.com>

using Scellecs.Morpeh;

namespace Develop.Source.Currency
{
	[System.Serializable]
	public struct CurrencyComponent : IComponent {
		public int EntitiesAmount;
		public float CurrencyPerEntity;
		public float CurrencyValue;
		public float CurrentCurrency;
		public float CurrencyPerSecond;
	}
}
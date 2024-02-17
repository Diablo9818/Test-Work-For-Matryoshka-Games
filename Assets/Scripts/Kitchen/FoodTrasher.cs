using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		[SerializeField] private float _doubleTapTimeThreshold = 0.3f;
		FoodPlace _place = null;
		float     _timer = 0f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if ( _place != null && !_place.IsFree && _place.CurFood != null && _place.CurFood.CurStatus == Food.FoodStatus.Overcooked ) {

				if ( Time.time - _timer < _doubleTapTimeThreshold ) {
					_place.FreePlace();
				}
				_timer = Time.time;
			}
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

using  CookingPrototype.Controllers;

using TMPro;

namespace CookingPrototype.UI {
	public sealed class MenuWindow : MonoBehaviour {
		public TMP_Text GoalText     = null;
		public Button   PlayButton = null;
		public Button   CloseButton  = null;

		bool _isInit = false;

		void Init() {
			var gc = GameplayController.Instance;
			PlayButton.onClick.AddListener(gc.Play);
			CloseButton .onClick.AddListener(gc.CloseGame);
		}

		public void Show() {
			if ( !_isInit ) {
				Init();
			}

			var gc = GameplayController.Instance;

			GoalText.text = $"{gc.OrdersTarget}";

			Time.timeScale = 0f;
			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}
}

using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Code.Ui.Menu{
    public class MenuUiView : UiWindow{
        [SerializeField]
        private Button _startButton;
        [SerializeField]
        private Button _inventoryButton;
        [SerializeField]
        private Button _topRatingButton;
        [SerializeField]
        private Button _getBonusButton;

        public void Init(UnityAction onStart, UnityAction onShowInventory, UnityAction onShowTopRating,
            UnityAction onGetBonus){
            base.Init();
            _startButton.OnClickAsObservable().Subscribe(_ => onStart.Invoke()).AddTo(_subscriptions);
            _inventoryButton.OnClickAsObservable().Subscribe(_ => onShowInventory.Invoke()).AddTo(_subscriptions);
            _topRatingButton.OnClickAsObservable().Subscribe(_ => onShowTopRating.Invoke()).AddTo(_subscriptions);
            _getBonusButton.OnClickAsObservable().Subscribe(_ => onGetBonus.Invoke()).AddTo(_subscriptions);
        }
    }
}
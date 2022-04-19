using Code.Ui;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace Code.Fight{
    public class GameoverUiView : UiWindow{
        [SerializeField]
        private Button _againButton;
        [SerializeField]
        private Button _closeButton;

        public void Init(UnityAction onAgainGame, UnityAction goToMenu){
            base.Init();
            _againButton.OnClickAsObservable().Subscribe(_ => onAgainGame.Invoke()).AddTo(_subscriptions);
            _closeButton.OnClickAsObservable().Subscribe(_ => goToMenu.Invoke()).AddTo(_subscriptions);
        }
    }
}
using UniRx;
using UnityEngine;
using UnityEngine.UI;


namespace Code.Ui.Fight{
    public class FightUiView: UiWindow{
        [SerializeField]
        private Button _onThrow;
        public void Init(ReactiveCommand onThrowKnife){
            base.Init();
            _onThrow.OnClickAsObservable().Subscribe(_ => onThrowKnife.Execute()).AddTo(_subscriptions);
        }
    }
}
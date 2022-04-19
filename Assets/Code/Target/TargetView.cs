using DG.Tweening;
using UniRx;
using UnityEngine;


namespace Code.Target{
    public class TargetView : MonoBehaviour{
        public ReactiveCommand<GameObject> OnCollisionEnter2d = new ReactiveCommand<GameObject>();
        private SpriteRenderer _renderer;

        private void Awake(){
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D other){
            OnCollisionEnter2d.Execute(other.gameObject);
            transform.DOPunchScale(new Vector3(0.05f, 0.05f, 0.05f), 0.2f, 32, 1);
        }

        public void EndingFight(){
            _renderer.DOFade(0, 0.5f);
        }
    }
}
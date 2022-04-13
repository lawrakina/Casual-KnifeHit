using System;
using System.Collections.Generic;
using System.Linq;
using Code.BaseControllers.Interfaces;
using UniRx;
using UnityEngine;


namespace Code.Ui{
    public abstract class UiWindow : MonoBehaviour, IInitialization
    {
        #region Fields

        protected CompositeDisposable _subscriptions;
        
        public Action OnShow;

        public Action OnHide;

        #endregion


        #region Properties

        public GameObject GameObject => gameObject;
        public Transform Transform => transform;

        #endregion


        #region ClassLiveCycles

        public virtual void Init()
        {
            _subscriptions = new CompositeDisposable();
        }

        public virtual void OnDestroy()
        {
            _subscriptions?.Dispose();
        }

        #endregion


        #region Methods

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public virtual void Show()
        {
            OnShow?.Invoke();
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            OnHide?.Invoke();
            gameObject.SetActive(false);
        }

        #endregion
    }
}
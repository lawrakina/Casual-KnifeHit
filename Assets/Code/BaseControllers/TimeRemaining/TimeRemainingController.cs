using System;
using System.Collections.Generic;
using Code.BaseControllers.Interfaces;


namespace Code.BaseControllers.TimeRemaining{
    public sealed class TimeRemainingController : IExecute{
        #region Fields

        private readonly List<ITimeRemaining> _timeRemainings;

        #endregion


        public Guid Id{ get; }

        public bool IsOn => true;


        #region ClassLifeCycles

        public TimeRemainingController(){
            _timeRemainings = TimeRemainingExtensions.TimeRemainings;
        }

        #endregion


        public void Execute(float deltaTime){
            for (var i = 0; i < _timeRemainings.Count; i++){
                var obj = _timeRemainings[i];
                obj.CurrentTime -= deltaTime;
                if (obj.CurrentTime <= 0.0f){
                    obj?.Method?.Invoke();
                    if (!obj.IsRepeating){
                        obj.RemoveTimeRemaining();
                    } else{
                        obj.CurrentTime = obj.Time;
                    }
                }
            }
        }
    }
}
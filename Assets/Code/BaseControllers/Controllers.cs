using System;
using System.Collections.Generic;
using Code.BaseControllers.Interfaces;
using Code.BaseControllers.TimeRemaining;


namespace Code.BaseControllers{
    public sealed class Controllers :  IExecute, IFixedExecute, ILateExecute, IInitialization, IDisposable
    {
        public Controllers()
        {
            _initializeControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _executeControllers.Add(new TimeRemainingController());
            _lateControllers = new List<ILateExecute>();
            _fixedControllers = new List<IFixedExecute>();
            _disposablesControllers = new List<IDisposable>();
        }
        

        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<IFixedExecute> _fixedControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<IDisposable> _disposablesControllers;

        public Guid Id => Guid.Empty;
        public bool IsOn => true;

        public void Add(IController controller)
        {
            if (controller is IInitialization initializeController) _initializeControllers.Add(initializeController);

            if (controller is IExecute executeController) _executeControllers.Add(executeController);

            if (controller is IFixedExecute fixedExecuteController) _fixedControllers.Add(fixedExecuteController);

            if (controller is ILateExecute lateExecuteController) _lateControllers.Add(lateExecuteController);

            if (controller is IDisposable disposableController) _disposablesControllers.Add(disposableController);
        }

        public void Init()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
                _initializeControllers[index].Init();
        }

        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                if(_executeControllers[index].IsOn)
                    _executeControllers[index].Execute(deltaTime);
            }
        }

        public void FixedExecute(float deltaTime)
        {
            for (var index = 0; index < _fixedControllers.Count; ++index)
                _fixedControllers[index].FixedExecute(deltaTime);
        }

        public void LateExecute(float deltaTime)
        {
            for (var index = 0; index < _lateControllers.Count; ++index) 
                _lateControllers[index].LateExecute(deltaTime);
        }

        public void Dispose(){
            for (var index = 0; index < _disposablesControllers.Count; ++index) 
                _disposablesControllers[index].Dispose();
        }

        public void Remove(IController controller)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                if(_executeControllers[index].Id == controller.Id)
                    _executeControllers.RemoveAt(index);
            }
            for (var index = 0; index < _fixedControllers.Count; ++index)
            {
                if(_fixedControllers[index].Id == controller.Id)
                    _fixedControllers.RemoveAt(index);
            }
            for (var index = 0; index < _lateControllers.Count; ++index)
            {
                if(_lateControllers[index].Id == controller.Id)
                    _lateControllers.RemoveAt(index);
            }
        }
    }
}
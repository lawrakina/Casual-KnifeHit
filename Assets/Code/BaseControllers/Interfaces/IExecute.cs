﻿namespace Code.BaseControllers.Interfaces{
    public interface IExecute: IController
    {
        void Execute(float deltaTime);
    }
}
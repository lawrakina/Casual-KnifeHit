﻿namespace Code.BaseControllers.Interfaces{
    public interface IFixedExecute: IController
    {
        void FixedExecute(float deltaTime);
    }
}
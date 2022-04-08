using System;


namespace Code.BaseControllers.Interfaces{
    public interface IController{
        Guid Id { get; }
        bool IsOn { get; }
    }
}
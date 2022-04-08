namespace Code.BaseControllers.Interfaces{
    public interface ILateExecute: IController
    {
        void LateExecute(float deltaTime);
    }
}
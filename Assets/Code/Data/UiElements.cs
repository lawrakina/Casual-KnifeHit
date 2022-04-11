using Code.Fight;
using Code.Ui.Fight;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(UiElements), menuName = "Ui - List/"+nameof(UiElements))]
    internal class UiElements: ScriptableObject{
        public FightUiView fightUiView;
    }
}
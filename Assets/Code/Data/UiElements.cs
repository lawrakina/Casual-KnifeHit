using Code.Fight;
using Code.Ui.Fight;
using Code.Ui.Menu;
using UnityEngine;


namespace Code.Data{
    [CreateAssetMenu(fileName = nameof(UiElements), menuName = "Ui - List/" + nameof(UiElements))]
    internal class UiElements : ScriptableObject{
        public FightUiView fightUiView;
        public MenuUiView menuUiView;
    }
}
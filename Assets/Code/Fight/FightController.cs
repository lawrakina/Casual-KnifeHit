using System.Collections.Generic;
using Code.BaseControllers;
using Code.Data;
using Code.Knife;


namespace Code.Fight{
    internal class FightController : BaseController{
        private readonly GameData _gameData;

        public FightController(GameData gameData):base(true){
            _gameData = gameData;
            var queue = new Queue<IKnife>();
        }
    }
}
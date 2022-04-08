using System.Collections.Generic;
using Code.BaseControllers;
using Code.Knife;


namespace Code.Fight{
    internal class FightController : BaseController{
        public FightController(GameData gameData):base(true){
            var queue = new Queue<IKnife>();
        }
    }
}
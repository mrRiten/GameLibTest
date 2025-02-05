using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class CavalryBarracks : Build
    {
        public CavalryBarracks(MapPosition mapPosition)
        {
            Health = 60;
            ActionPoint = 0;
            PointToAction = 3;
            MapPosition = mapPosition;
        }
    }
}

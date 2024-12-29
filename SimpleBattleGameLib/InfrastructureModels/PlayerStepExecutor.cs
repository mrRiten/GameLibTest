using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class PlayerStepExecutor(PlayerStep playerStep, MapManager mapManager)
    {
        private readonly PlayerStep _playerStep = playerStep;
        private readonly MapManager _mapManager = mapManager;

        public void Execute()
        {
            ExecuteBuild();
            ExecuteSolder();
        }

        private void ExecuteBuild()
        {
            var buildActionItem = _playerStep.BuildStep.BuildActionItem;

            if (buildActionItem == null) return;

            foreach (var item in buildActionItem)
            {
                var action = (BuildAction)item.Action;

                if (action == BuildAction.Build)
                {
                    _mapManager.PlaceBuild(item, _playerStep.Player);
                }
                else if (action == BuildAction.Destroy)
                {
                    _mapManager.DeleteBuild(item, _playerStep.Player);
                }
            }
        }

        private void ExecuteSolder()
        {
            // Todo: Code
            return;
        }
    }
}

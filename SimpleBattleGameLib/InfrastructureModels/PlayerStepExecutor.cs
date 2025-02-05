using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class PlayerStepExecutor(PlayerStep playerStep, MapManager mapManager)
    {
        private readonly PlayerStep _playerStep = playerStep;
        private readonly MapManager _mapManager = mapManager;

        public void Execute()
        {
            // Todo: refactor ExecuteBuild & ExecuteSolder, mb recode to generic
            ExecuteBuild();
            ExecuteSolder();

            ExecuteIncome();
        }

        private void ExecuteIncome()
        {
            var player = _playerStep.Player;

            foreach (var build in player.Builds)
            {
                if (build.ActionPoint >= build.PointToAction)
                {
                    // Todo: action by build (baraks)

                    if (build.GetType() == typeof(Mine))
                    {
                        player.Money += 10;
                    }

                    build.ActionPoint = 0;
                }

                build.ActionPoint += 1;
            }
        }

        private void ExecuteBuild()
        {
            var buildActionItem = _playerStep.BuildStep?.BuildActionItem;

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
            var solderActionItem = _playerStep.SolderStep?.SolderActionItems;

            if (solderActionItem == null) return;

            foreach (var item in solderActionItem)
            {
                var action = (SolderAction)item.Action;

                if (action == SolderAction.Attack)
                {
                    _mapManager.AttackSolder(item, _playerStep.Player);
                }
                else if (action == SolderAction.Move)
                {
                    _mapManager.MoveSolder(item, _playerStep.Player);
                }
            }
        }

    }
}

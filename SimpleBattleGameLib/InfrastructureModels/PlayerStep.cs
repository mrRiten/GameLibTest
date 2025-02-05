using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class PlayerStep(Player player, BuildStep buildStep, SolderStep solderStep)
    {
        public Player Player { get; set; } = player;
        public BuildStep? BuildStep { get; set; } = buildStep;
        public SolderStep? SolderStep { get; set; } = solderStep;
    }
}

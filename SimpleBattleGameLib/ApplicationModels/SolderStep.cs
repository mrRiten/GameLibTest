namespace SimpleBattleGameLib.ApplicationModels
{
    public class SolderStep(ICollection<SolderActionItem> solderActionItems)
    {
        public ICollection<SolderActionItem> SolderActionItems { get; set; } = solderActionItems;
    }

    public enum SolderAction
    {
        Move = 1,
        Attack = 2,
    }

    public class SolderActionItem(MapPosition currentPosition, MapPosition targetPosition, SolderAction solderAction)
    {
        public MapPosition CurrentPosition { get; set; } = currentPosition;
        public MapPosition TargetPosition { get; set; } = targetPosition;
        public int Action { get; set; } = (int)solderAction;
    }
}

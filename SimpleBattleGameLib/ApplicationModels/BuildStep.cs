namespace SimpleBattleGameLib.ApplicationModels
{
    public class BuildStep(ICollection<BuildActionItem> buildActionItems)
    {
        public ICollection<BuildActionItem>? BuildActionItem { get; set; } = buildActionItems;
    }

    public enum BuildAction
    {
        Build = 1,
        Destroy = 2,
    }

    public class BuildActionItem
    {
        public int BuildId { get; set; }
        public MapPosition Position { get; set; }
        public int Action { get; set; }

        public BuildActionItem(MapPosition mapPosition, BuildAction buildAction)
        {
            Position = mapPosition;
            Action = (int)buildAction;
        }

        public BuildActionItem(BuildType buildType, MapPosition mapPosition, BuildAction buildAction) : this(mapPosition, buildAction)
        {
            BuildId = (int)buildType;
        }
    }
}

using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class MapManager
    {
        public Map Map { get; set; }

        public void PlaceBuild(BuildActionItem buildActionItem, Player player)
        {
            if (!Map.IsValidPosition(buildActionItem.Position)) return;

            Build? newBuild = null;

            // Todo: Code *Barracks create logic
            switch ((BuildType)buildActionItem.BuildId)
            {
                case BuildType.Mine: newBuild = new Mine(buildActionItem.Position); break;
                case BuildType.InfantryBarracks: break;
                case BuildType.CavalryBarracks: break;
                case BuildType.ArcheryBarracks: break;
            }

            if (newBuild == null) return;

            Map.Builds.Add(newBuild);
            player.Builds.Add(newBuild);
            DeleteMapPlace(newBuild.MapPosition);
        }

        public void DeleteBuild(BuildActionItem buildActionItem, Player player)
        {
            if (!Map.IsValidPosition(buildActionItem.Position)) return;

            var buildToRemove = Map.Builds.FirstOrDefault(mp => mp.MapPosition.Equals(buildActionItem.Position));

            if (buildToRemove == null) return;

            player.Builds.Remove(buildToRemove);
            Map.Builds.Remove(buildToRemove);
            Map.MapPlaces.Add(new Field(buildToRemove.MapPosition));
        }

        private void DeleteMapPlace(MapPosition mapPosition)
        {
            var placeToRemove = Map.MapPlaces.FirstOrDefault(mp => mp.MapPosition.Equals(mapPosition));

            if (placeToRemove == null) return;

            Map.MapPlaces.Remove(placeToRemove);
        }

    }
}

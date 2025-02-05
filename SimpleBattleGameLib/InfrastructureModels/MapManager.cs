using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class MapManager
    {
        // Todo: if (!Map.IsValidPosition(buildActionItem.Position)) return; - Recode to Attribute
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

        public void MoveSolder(SolderActionItem solderActionItem, Player player)
        {
            if (!Map.IsValidPosition([solderActionItem.CurrentPosition, solderActionItem.TargetPosition])) return;

            if (Map.MapPlaces.FirstOrDefault(mp => mp.MapPosition == solderActionItem.TargetPosition) == null) return;

            DeleteMapPlace(solderActionItem.TargetPosition);
            Map.MapPlaces.Add(new Field(solderActionItem.CurrentPosition));

            player.Entities.FirstOrDefault(s => s.MapPosition == solderActionItem.TargetPosition)
                .MapPosition = solderActionItem.TargetPosition;
        }

        public void AttackSolder(SolderActionItem solderActionItem, Player player)
        {
            if (!Map.IsValidPosition([solderActionItem.CurrentPosition, solderActionItem.TargetPosition])) return;

            var curentEntity = Map.Entities.FirstOrDefault(mp => mp.MapPosition == solderActionItem.CurrentPosition);
            var targetEntity = Map.Entities.FirstOrDefault(mp => mp.MapPosition == solderActionItem.TargetPosition);

            if (targetEntity == null) return;

            targetEntity.Health -= curentEntity.Damage;
        }

        private void DeleteMapPlace(MapPosition mapPosition)
        {
            var placeToRemove = Map.MapPlaces.FirstOrDefault(mp => mp.MapPosition.Equals(mapPosition));

            if (placeToRemove == null) return;

            Map.MapPlaces.Remove(placeToRemove);
        }

    }
}

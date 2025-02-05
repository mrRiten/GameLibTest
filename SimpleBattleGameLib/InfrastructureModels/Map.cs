using SimpleBattleGameLib.ApplicationModels;

namespace SimpleBattleGameLib.InfrastructureModels
{
    public class Map
    {
        public int Weidth { get; set; }
        public int Higth { get; set; }

        public required ICollection<MapPlace> MapPlaces { get; set; }
        public ICollection<Entity>? Entities { get; set; }
        public required ICollection<Build> Builds { get; set; }

        public bool IsValidPosition(MapPosition mapPosition)
        {
            if (IsValidCords(mapPosition) && IsValidPlace(mapPosition))
            {
                return true;
            }

            return false;
        }

        public bool IsValidPosition(IEnumerable<MapPosition> mapPositions)
        {
            foreach (var mapPosition in mapPositions)
            {
                if (!(IsValidCords(mapPosition) && IsValidPlace(mapPosition)))
                {
                    return false;
                }
            }
            
            return true;
        }

        private bool IsValidPlace(MapPosition targetMapPosition)
        {
            var mapPlaceOccupied = MapPlaces
                .Any(mapPlace => mapPlace.MapPosition == targetMapPosition && mapPlace.IsPassable == false);

            var entityOccupied = Entities?.Any(entity => entity?.MapPosition == targetMapPosition) ?? false;

            var buildOccupied = Builds.Any(build => build.MapPosition == targetMapPosition);

            return !(mapPlaceOccupied || entityOccupied || buildOccupied);
        }

        private bool IsValidCords(MapPosition mapPosition)
        {
            if (mapPosition.X < 0 || mapPosition.Y < 0)
            {
                return false;
            }

            if (mapPosition.X > Weidth || mapPosition.Y > Higth)
            {
                return false;
            }

            return true;
        }
    }
}

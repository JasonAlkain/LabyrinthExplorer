namespace LabyrinthExplorer
{
    public interface IGameStateStore
    {
        PlayerData? LoadPlayer();

        void SavePlayer(PlayerData playerData);
    }
}

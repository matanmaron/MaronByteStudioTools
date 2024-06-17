namespace MaronByteStudio.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        void Start()
        {
            Settings.LoadSettings();
            AudioManager.Instance.PlayMusic(MusicType.Menu);
        }
    }
}
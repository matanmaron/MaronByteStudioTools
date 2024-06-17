using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MaronByteStudio.Menu
{
    public class MenuOptionsPanel : MonoBehaviour
    {
        [SerializeField] Button InvertMouseButton;
        [SerializeField] TextMeshProUGUI InvertMouseText;
        [SerializeField] Button SoundButton;
        [SerializeField] Button MusicButton;
        [SerializeField] Button BackButton;
        [SerializeField] MenuScene menu;
        TextMeshProUGUI SoundText;
        TextMeshProUGUI MusicText;

        void Start()
        {
            SoundText = SoundButton.GetComponentInChildren<TextMeshProUGUI>();
            MusicText = MusicButton.GetComponentInChildren<TextMeshProUGUI>();

            SoundButton.onClick.AddListener(OnSoundButton);
            MusicButton.onClick.AddListener(OnMusicButton);
            BackButton.onClick.AddListener(() => menu.OnBackButton());
            InitButtons();
        }
        
        private void InitButtons()
        {
            string sound = Settings.MuteSfx ? "Off" : "On";
            SoundText.text = $"Sound {sound}";
            string music = Settings.MuteMusic ? "Off" : "On";
            MusicText.text = $"Music {music}";
        }

        private void OnMusicButton()
        {
            Settings.MuteMusic = !Settings.MuteMusic;
            string music = Settings.MuteMusic ? "Off" : "On";
            MusicText.text = $"Music is {music}";
        }

        private void OnSoundButton()
        {
            Settings.MuteSfx = !Settings.MuteSfx;
            string sound = Settings.MuteSfx ? "Off" : "On";
            SoundText.text = $"Sound is {sound}";
        }

        private void OnDestroy()
        {
            SoundButton.onClick.RemoveAllListeners();
            MusicButton.onClick.RemoveAllListeners();
            BackButton.onClick.RemoveAllListeners();
        }
    }
}

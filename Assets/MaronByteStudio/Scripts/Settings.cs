using MaronByteStudio.Managers;
using UnityEngine;

namespace MaronByteStudio
{
    public static class Settings
    {
        private static bool _muteMusic = false;
        private static bool _muteSfx = false;

        internal static bool MuteMusic
        {
            get
            {
                return _muteMusic;
            }
            set
            {
                _muteMusic = value;
                SaveSettings();
                AudioManager.Instance.Refresh();
            }
        }


        internal static bool MuteSfx
        {
            get
            {
                return _muteSfx;
            }
            set
            {
                _muteSfx = value;
                SaveSettings();
                AudioManager.Instance.Refresh();
            }
        }

        internal static void LoadSettings()
        {
            MuteMusic = GetBool("MuteMusic", false);
            MuteSfx = GetBool("MuteSfx", false);
            Debug.Log($"[Settings] > LoadSettings [MuteMusic:{MuteMusic}, MuteSfx:{MuteSfx}]");
        }

        internal static void SaveSettings()
        {
            SetBool("MuteMusic", MuteMusic);
            SetBool("MuteSfx", MuteSfx);
            Debug.Log($"[Settings] > SaveSettings [MuteMusic:{MuteMusic}, MuteSfx:{MuteSfx}]");
        }

        private static bool GetBool(string key, bool defValue)
        {
            return PlayerPrefs.GetInt(key, defValue ? 1 : 0) != 0;
        }

        private static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            PlayerPrefs.Save();
        }

    }
}

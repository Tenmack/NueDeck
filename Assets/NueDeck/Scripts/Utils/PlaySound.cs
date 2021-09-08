using NueDeck.Scripts.Managers;
using UnityEngine;

namespace NueDeck.Scripts.Utils
{
    public class PlaySound : MonoBehaviour
    {
        public SoundProfileData myProfileData;

        public void PlaySfx()
        {
            AudioManager.instance.PlayOneShot(myProfileData.GetRandomClip());
        }

        public void PlayButton()
        {
            AudioManager.instance.PlayOneShotButton(myProfileData.GetRandomClip());
        }
    }
}

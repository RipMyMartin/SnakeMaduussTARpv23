using System;

namespace SnakeMaduussTARpv23
{
    public static class EatSound
    {
        private const string EatSoundFilePath = "../../../ALLAH.mp3";

        public static void PlayEatSound()
        {
            var soundPlayer = new SoundPlayer(EatSoundFilePath);
            soundPlayer.PlayAsync(); // Play sound asynchronously
        }
    }
}

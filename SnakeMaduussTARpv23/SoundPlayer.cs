using NAudio.Wave;
using System;
using System.Threading.Tasks;

namespace SnakeMaduussTARpv23
{
    public class SoundPlayer : IDisposable
    {
        private readonly IWavePlayer _waveOutEvent;
        private readonly AudioFileReader _audioFileReader;

        public SoundPlayer(string filePath)
        {
            _waveOutEvent = new WaveOutEvent();
            _audioFileReader = new AudioFileReader(filePath);
            _waveOutEvent.Init(_audioFileReader);
        }

        public void Play()
        {
            _waveOutEvent.Play();
        }

        public void PlayAsync()
        {
            Task.Run(() =>
            {
                Play();
                // Do not wait for playback to finish
                _waveOutEvent.PlaybackStopped += (sender, args) => Dispose();
            });
        }

        public void Dispose()
        {
            _waveOutEvent.Dispose();
            _audioFileReader.Dispose();
        }
    }
}

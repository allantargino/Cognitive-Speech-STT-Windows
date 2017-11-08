using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextWPFSample.Model
{
    public class Recorder
    {
        private WaveIn _waveSource = null;
        private WaveFileWriter _waveFile = null;

        private Action<string> _fileCallback = null;
        private string _filePath = string.Empty;

        public bool IsRecording { get; private set; }

        public Recorder(Action<string> fileCallback, string filePath = "recording.wav")
        {
            _fileCallback = fileCallback;
            _filePath = filePath;
        }

        private WaveIn InitWaveSource()
        {
            var waveSource = new WaveIn
            {
                WaveFormat = new WaveFormat(44100, 1)
            };

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(WaveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(WaveSource_RecordingStopped);

            return waveSource;
        }

        private void DisposeObjects()
        {
            if (_waveSource != null)
            {
                _waveSource.Dispose();
                _waveSource = null;
            }

            if (_waveFile != null)
            {
                _waveFile.Dispose();
                _waveFile = null;
            }
        }

        public void StartRecording()
        {
            if(File.Exists(_filePath))
                File.Delete(_filePath);

            _waveSource = InitWaveSource();

            _waveFile = new WaveFileWriter(_filePath, _waveSource.WaveFormat);
            _waveSource.StartRecording();
            IsRecording = true;
        }

        public void StopRecording()
        {
            _waveSource.StopRecording();
            IsRecording = false;
        }
        
        void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (_waveFile != null)
            {
                _waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                _waveFile.Flush();
            }
        }

        void WaveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            DisposeObjects();

            IsRecording = false;

            _fileCallback(_filePath);
        }

    }
}

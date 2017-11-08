using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechToTextWPFSample.Model
{
    public class Recorder
    {
        public WaveIn waveSource = null;
        public WaveFileWriter waveFile = null;

        private bool recording = false;

        public Recorder()
        {
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(WaveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(WaveSource_RecordingStopped);
        }
        
        public void StartRecording()
        {
            waveFile = new WaveFileWriter(@"C:\Temp\Test0001.wav", waveSource.WaveFormat);
            waveSource.StartRecording();
            recording = true;
        }

        public void StopRecording()
        {
            waveSource.StopRecording();
            recording = false;
        }
        
        void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        void WaveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }

            recording = false;
        }
    }
}

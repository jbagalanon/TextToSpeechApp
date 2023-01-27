using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TextToSpeechApp
{
    public partial class Form1 : Form
    {
        private SpeechSynthesizer synthesizer;

        public Form1()
        {
            InitializeComponent();
            synthesizer = new SpeechSynthesizer();

        }


        private void txtDialog_TextChanged(object sender, EventArgs e)
        {


        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
           
            synthesizer.SpeakAsync(txtDialog.Text);

        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {          

            saveFileDialog.Filter = "WAV file|*.wav";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                synthesizer.SetOutputToWaveFile(saveFileDialog.FileName);
                synthesizer.Speak(txtDialog.Text);
                synthesizer.SetOutputToDefaultAudioDevice();
            }
        }



        private void btnStop_Click(object sender, EventArgs e)
        {


            synthesizer.SpeakAsyncCancelAll();
            //if (synthesizer.State == SynthesizerState.Speaking || synthesizer.State == SynthesizerState.Speaking)
            //{
            //    synthesizer.SpeakAsyncCancel(Prompt prompt);
            //}
        }
    }
}

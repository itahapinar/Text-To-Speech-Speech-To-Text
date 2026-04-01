using NAudio.Wave;
using System.Net.Http.Headers;
using System.Speech.Synthesis;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Text_To_Speech___Speech_To_Text
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer reader = new SpeechSynthesizer();
        WaveInEvent waveIn;
        WaveFileWriter waveWriter;
        string tempWavPath = Path.Combine(Path.GetTempPath(), "whisper_input.wav");
        bool isRecording = false;
        readonly string openAiKey = Environment.GetEnvironmentVariable("API_KEY");

        public Form1()
        {
            InitializeComponent();
        }

        private void read_btn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mainText.Text))
            {
                reader.SpeakAsync(mainText.Text);
            }
            else
            {
                MessageBox.Show("Please enter a text!!");
            }
        }

        private void talk_btn_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                isRecording = true;
                talk_btn.Text = "⏹";

                waveIn = new WaveInEvent();
                waveIn.WaveFormat = new WaveFormat(16000, 1);
                waveWriter = new WaveFileWriter(tempWavPath, waveIn.WaveFormat);

                waveIn.DataAvailable += (s, a) =>
                {
                    waveWriter.Write(a.Buffer, 0, a.BytesRecorded);
                };

                waveIn.StartRecording();
            }
            else
            {
                isRecording = false;
                talk_btn.Text = "🎤";

                waveIn.StopRecording();
                waveWriter.Dispose();
                waveIn.Dispose();

                talk_btn.Enabled = false;
                _ = TranscribeWithWhisperAsync();
            }
        }

        private async Task TranscribeWithWhisperAsync()
        {
            try
            {
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", openAiKey);

                using var form = new MultipartFormDataContent();

                var fileBytes = File.ReadAllBytes(tempWavPath);
                var fileContent = new ByteArrayContent(fileBytes);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue("audio/wav");

                form.Add(fileContent, "file", "audio.wav");
                form.Add(new StringContent("whisper-1"), "model");

                var response = await client.PostAsync(
                    "https://api.openai.com/v1/audio/transcriptions", form);

                var json = await response.Content.ReadAsStringAsync();

                var start = json.IndexOf("\"text\":\"") + 8;
                var end = json.IndexOf("\"", start);
                var text = json.Substring(start, end - start);

                mainText.Invoke(() =>
                {
                    mainText.Text += text + Environment.NewLine;
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                talk_btn.Invoke(() => talk_btn.Enabled = true);
            }
        }
    }
}
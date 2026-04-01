# 🎙️ Text To Speech & Speech To Text

A Windows desktop application built with **C# / .NET 8 / WinForms** that lets you convert text to speech using the Windows TTS engine and transcribe your voice to text via **OpenAI Whisper API**.

---

## ✨ Features

| Feature | Description |
|---|---|
| 📢 Text to Speech | Types or pastes any text into the text box and reads it aloud instantly |
| 🎤 Speech to Text | Records microphone input and transcribes it using OpenAI Whisper (`whisper-1`) |
| ⏹ Toggle Recording | A single button starts and stops recording; transcribed text is appended to the text box |

---

## 🖥️ Requirements

- **OS:** Windows (Windows 10 or later recommended)
- **Runtime:** [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- **IDE:** Visual Studio 2022 (v17+) or later
- **OpenAI API Key** with access to the Whisper API

---

## 📦 Dependencies

| Package | Version |
|---|---|
| [NAudio](https://github.com/naudio/NAudio) | 2.3.0 |
| [System.Speech](https://www.nuget.org/packages/System.Speech) | 10.0.5 |

> All packages are managed via NuGet and will be restored automatically on build.

---

## 🔑 Setup & Configuration

The app reads your OpenAI API key from an **environment variable**.

### Setting the Environment Variable

**PowerShell (current session):**
```powershell
$env:API_KEY = "sk-..."
```

**Permanently (Windows System):**
```
Control Panel → System → Advanced System Settings → Environment Variables
```
Add a new variable:
- **Name:** `API_KEY`
- **Value:** `sk-your-openai-api-key-here`

> ⚠️ Never hard-code your API key directly in the source code.

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/text-to-speech-speech-to-text.git
cd "text-to-speech-speech-to-text"
```

### 2. Restore NuGet packages

```bash
dotnet restore
```

### 3. Build the project

```bash
dotnet build
```

### 4. Run the application

```bash
dotnet run --project "Text To Speech & Speech To Text"
```

Or open `Text To Speech & Speech To Text.sln` in **Visual Studio** and press `F5`.

---

## 🗂️ Project Structure

```
Text To Speech & Speech To Text/
├── Text To Speech & Speech To Text.sln       # Solution file
└── Text To Speech & Speech To Text/
    ├── Program.cs                             # Application entry point
    ├── Form1.cs                               # Main form — core logic
    ├── Form1.Designer.cs                      # Auto-generated UI layout
    ├── Form1.resx                             # Form resources
    ├── Text To Speech & Speech To Text.csproj # Project file
    └── Properties/
        ├── Resources.cs
        └── Resources.resx
```

---

## 🧠 How It Works

### Text → Speech
Uses `System.Speech.Synthesis.SpeechSynthesizer` (Windows built-in TTS engine) to read aloud whatever text is in the text box.

```csharp
reader.SpeakAsync(mainText.Text);
```

### Speech → Text
1. Captures microphone audio at **16 kHz, mono** using `NAudio.WaveInEvent`
2. Saves the recording to a temporary `.wav` file
3. Sends the file to the **OpenAI Whisper API** (`/v1/audio/transcriptions`)
4. Appends the transcribed text to the text box

```csharp
// Recording format
waveIn.WaveFormat = new WaveFormat(16000, 1);

// API call
var response = await client.PostAsync(
    "https://api.openai.com/v1/audio/transcriptions", form);
```

---

## 🎮 Usage

1. **Text to Speech:** Type or paste text into the text area → click **Read** (📢)
2. **Speech to Text:**
   - Click **Talk / 🎤** to start recording
   - Speak into your microphone
   - Click **⏹** to stop — transcription appears in the text box automatically

---

## ⚙️ Configuration Details

| Setting | Value |
|---|---|
| Target Framework | `net8.0-windows` |
| Output Type | `WinExe` |
| Nullable | Enabled |
| Windows Forms | Enabled |
| Implicit Usings | Enabled |
| Audio Format | 16000 Hz, Mono, WAV |
| Whisper Model | `whisper-1` |

---

## 🔒 Security Notes

- The OpenAI API key is loaded from the `API_KEY` environment variable at runtime — **never** commit your key to source control.
- The temporary `.wav` file is written to the system temp directory (`%TEMP%\whisper_input.wav`) and reused across sessions; it is not deleted automatically.

---

## 🛠️ Troubleshooting

| Problem | Solution |
|---|---|
| "Please enter a text!!" | The text box is empty — type something before clicking Read |
| Transcription fails | Make sure `API_KEY` environment variable is set correctly |
| Microphone not detected | Check Windows sound settings and microphone permissions |
| Build fails | Ensure .NET 8.0 SDK is installed and NuGet packages are restored |

---

## 📄 License

This project is open source. Feel free to use, modify, and distribute.

---

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/amazing-feature`
3. Commit your changes: `git commit -m 'Add amazing feature'`
4. Push to the branch: `git push origin feature/amazing-feature`
5. Open a Pull Request

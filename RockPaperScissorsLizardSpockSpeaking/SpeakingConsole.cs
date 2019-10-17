using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Newtonsoft.Json.Extensions;
using Newtonsoft.Json;
using System.IO;
using System.Threading;

namespace RockPaperScissorsLizardSpockSpeaking
{
	public static class SpeakingConsole
	{
		private const string MP3_LINK_START_MARKER = "<param name='flashvars' value='file=";
		private const string MP3_LINK_END_MARKER = "'>";
		private static string MP3_PATH = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/temp.mp3";

		private static bool blnMediaEnded = false;
		class TextToSpeechPostModel
		{
			[JsonProperty("language")]
			public string Language { get; set; }
			[JsonProperty("voice")]
			public string Voice { get; set; }
			[JsonProperty("speed")]
			public int Speed { get; set; }
			[JsonProperty("input_text")]
			public string InputText { get; set; }
			[JsonProperty("action")]
			public string Action { get; set; } = "process_text";
		}

		public static bool EnableSpeaking { get; set; } = true;
		public static Language ChosenLanguage { get; set; } = Language.British_English;
		public static Voice ChosenVoice { get; set; } = Voice.Alice;
		public static Speed ChosenSpeed { get; set; } = Speed.Medium;

		public enum Language
		{
			[Description("US English")]
			US_English,
			[Description("British English")]
			British_English,
			French,
			Spanish,
			German,
			Italian,
			Portuguese,
			Russian
		}

		public enum Voice
		{
			[Description("IVONA Kimberly22")]
			Alice,
			[Description("IVONA Salli22")]
			Daisy,
			[Description("IVONA Joey22")]
			George,
			[Description("IVONA Jennifer22")]
			Jenna,
			[Description("IVONA Eric22")]
			John,
		}

		public enum Speed
		{
			Slow = -1,
			Medium,
			Fast,
			VeryFast
		}
		private static RestClient client = new RestClient() { ReadWriteTimeout = 60000, Timeout = 60000 };
		private static WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();

		static SpeakingConsole()
		{
			client.UseNewtonsoftJsonDeserializer();
			wplayer.PlayStateChange += new WMPLib._WMPOCXEvents_PlayStateChangeEventHandler(player_PlayStateChange);
		}

		public static void Speak(string s)
		{
			RestRequest request = new RestRequest("http://www.fromtexttospeech.com/");
			//request.AddParameter(new JsonParameter("", new TextToSpeechPostModel() { InputText = s, Language = ChosenLanguage.GetDescription(), Voice = ChosenVoice.GetDescription(), Speed = (int)ChosenSpeed }) { Type = ParameterType.GetOrPost });
			request.AddParameter("language", ChosenLanguage.GetDescription(), ParameterType.GetOrPost);
			request.AddParameter("voice", ChosenVoice.GetDescription(), ParameterType.GetOrPost);
			request.AddParameter("speed", ((int)ChosenSpeed).ToString(), ParameterType.GetOrPost);
			request.AddParameter("input_text", s, ParameterType.GetOrPost);
			request.AddParameter("action", "process_text", ParameterType.GetOrPost);
			IRestResponse response = client.Post(request);
			int intLinkStart = response.Content.IndexOf(MP3_LINK_START_MARKER) + MP3_LINK_START_MARKER.Length;
			string strTempContent = response.Content.Substring(intLinkStart);
			string strLink = strTempContent.Substring(0, strTempContent.IndexOf(MP3_LINK_END_MARKER));
			request = new RestRequest("http://www.fromtexttospeech.com" + strLink);
			byte[] bytes = client.DownloadData(request);
			bool blnFileInUse = false;
			do
			{
				try
				{
					using (Stream stream = new FileStream(MP3_PATH, FileMode.Create))
					{
						stream.Write(bytes, 0, bytes.Length);
						wplayer.URL = MP3_PATH;
						wplayer.controls.play();
						while (!blnMediaEnded)
						{
							Thread.Sleep(100);
						}
						blnMediaEnded = false;
					}
				}
				catch
				{
					blnFileInUse = true;
					Thread.Sleep(100);
				}
			} while (blnFileInUse);
		}

		private static void player_PlayStateChange(int newState)
		{
			// Test the current state of the player and display a message for each state.
			switch (newState)
			{
				case 8:    // MediaEnded
					blnMediaEnded = true;
					break;
			}
		}
		public static string SpeakAndReturn(string s)
		{
			Speak(s);
			return s;
		}
		public static int Read()
		{
			int i = Console.Read();
			Speak(i.ToString());
			return i;
		}
		public static ConsoleKeyInfo ReadKey(bool intercept)
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey(intercept);
			Speak(keyInfo.KeyChar.ToString());
			return keyInfo;
		}
		public static ConsoleKeyInfo ReadKey()
		{
			ConsoleKeyInfo keyInfo = Console.ReadKey();
			Speak(keyInfo.KeyChar.ToString());
			return keyInfo;
		}
		public static string ReadLine()
		{
			return SpeakAndReturn(Console.ReadLine());
		}
		public static void Write(string value)
		{
			Console.Write(value);
			Speak(value);
		}
		public static void Write(object value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(ulong value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(long value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(string format, object arg0, object arg1)
		{
			Console.Write(format, arg0, arg1);
			Speak(String.Format(format, arg0, arg1));
		}
		public static void Write(string format, object arg0)
		{
			Console.Write(format, arg0);
			Speak(String.Format(format, arg0));
		}
		public static void Write(uint value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(string format, object arg0, object arg1, object arg2, object arg3)
		{
			Console.Write(format, arg0, arg1, arg2, arg3);
			Speak(String.Format(format, arg0, arg1, arg2, arg3));
		}
		public static void Write(string format, params object[] arg)
		{
			Console.Write(format, arg);
			Speak(String.Format(format, arg));
		}
		public static void Write(bool value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(char value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(char[] buffer)
		{
			Console.Write(buffer);
			Speak(new string(buffer));
		}
		public static void Write(char[] buffer, int index, int count)
		{
			Console.Write(buffer);
			Speak(new string(buffer).Substring(index, count));
		}
		public static void Write(string format, object arg0, object arg1, object arg2)
		{
			Console.Write(format, arg0, arg1, arg2);
			Speak(String.Format(format, arg0, arg1, arg2));
		}
		public static void Write(decimal value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(float value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void Write(double value)
		{
			Console.Write(value);
			Speak(value.ToString());
		}
		public static void WriteLine()
		{
			Console.WriteLine();
		}
		public static void WriteLine(float value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(int value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(uint value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(long value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(ulong value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(object value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(string value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(string format, object arg0)
		{
			Console.WriteLine(format, arg0);
			Speak(String.Format(format, arg0));
		}
		public static void WriteLine(string format, object arg0, object arg1, object arg2)
		{
			Console.WriteLine(format, arg0, arg1, arg2);
			Speak(String.Format(format, arg0, arg1, arg2));
		}
		public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
		{
			Console.WriteLine(format, arg0, arg1, arg2, arg3);
			Speak(String.Format(format, arg0, arg1, arg2, arg3));
		}
		public static void WriteLine(string format, params object[] arg)
		{
			Console.WriteLine(format, arg);
			Speak(String.Format(format, arg));
		}
		public static void WriteLine(char[] buffer, int index, int count)
		{
			Console.WriteLine(buffer);
			Speak(new string(buffer).Substring(index, count));
		}
		public static void WriteLine(char[] buffer)
		{
			Console.WriteLine(buffer);
			Speak(new string(buffer));
		}
		public static void WriteLine(bool value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
		public static void WriteLine(string format, object arg0, object arg1)
		{
			Console.WriteLine(format, arg0, arg1);
			Speak(String.Format(format, arg0, arg1));
		}
		public static void WriteLine(double value)
		{
			Console.WriteLine(value);
			Speak(value.ToString());
		}
	}
}

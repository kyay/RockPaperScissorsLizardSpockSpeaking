using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsLizardSpockSpeaking
{
    public static class SpeakingConsole
    {
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
        private static RestSharp.RestClient client = new RestSharp.RestClient();
        private static 
        public static int Read();
        public static ConsoleKeyInfo ReadKey(bool intercept);
        public static ConsoleKeyInfo ReadKey();
        public static string ReadLine();
        public static void Write(string value);
        public static void Write(object value);
        public static void Write(ulong value);
        public static void Write(long value);
        public static void Write(string format, object arg0, object arg1);
        public static void Write(string format, object arg0);
        public static void Write(uint value);
        public static void Write(string format, object arg0, object arg1, object arg2, object arg3);
        public static void Write(string format, params object[] arg);
        public static void Write(bool value);
        public static void Write(char value);
        public static void Write(char[] buffer);
        public static void Write(char[] buffer, int index, int count);
        public static void Write(string format, object arg0, object arg1, object arg2);
        public static void Write(decimal value);
        public static void Write(float value);
        public static void Write(double value);
        public static void WriteLine();
        public static void WriteLine(float value);
        public static void WriteLine(int value);
        public static void WriteLine(uint value);
        public static void WriteLine(long value);
        public static void WriteLine(ulong value);
        public static void WriteLine(object value);
        public static void WriteLine(string value);
        public static void WriteLine(string format, object arg0);
        public static void WriteLine(string format, object arg0, object arg1, object arg2);
        public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3);
        public static void WriteLine(string format, params object[] arg);
        public static void WriteLine(char[] buffer, int index, int count);
        public static void WriteLine(char[] buffer);
        public static void WriteLine(bool value);
        public static void WriteLine(string format, object arg0, object arg1);
        public static void WriteLine(double value);
    }
}

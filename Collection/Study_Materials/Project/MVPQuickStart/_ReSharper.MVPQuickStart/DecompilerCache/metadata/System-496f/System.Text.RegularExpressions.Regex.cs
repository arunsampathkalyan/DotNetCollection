// Type: System.Text.RegularExpressions.Regex
// Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.dll

using System;
using System.Collections;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime;
using System.Runtime.Serialization;

namespace System.Text.RegularExpressions
{
    [Serializable]
    public class Regex : ISerializable
    {
        protected internal Hashtable capnames;
        protected internal Hashtable caps;
        protected internal int capsize;
        protected internal string[] capslist;
        protected internal RegexRunnerFactory factory;
        protected internal string pattern;
        protected internal RegexOptions roptions;

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected Regex();

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public Regex(string pattern);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public Regex(string pattern, RegexOptions options);

        protected Regex(SerializationInfo info, StreamingContext context);

        public static int CacheSize { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        public RegexOptions Options { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        public bool RightToLeft { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; }

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo si, StreamingContext context);

        #endregion

        public static string Escape(string str);
        public static string Unescape(string str);
        public override string ToString();
        public string[] GetGroupNames();
        public int[] GetGroupNumbers();
        public string GroupNameFromNumber(int i);
        public int GroupNumberFromName(string name);
        public static bool IsMatch(string input, string pattern);
        public static bool IsMatch(string input, string pattern, RegexOptions options);
        public bool IsMatch(string input);
        public bool IsMatch(string input, int startat);
        public static Match Match(string input, string pattern);
        public static Match Match(string input, string pattern, RegexOptions options);
        public Match Match(string input);
        public Match Match(string input, int startat);
        public Match Match(string input, int beginning, int length);
        public static MatchCollection Matches(string input, string pattern);
        public static MatchCollection Matches(string input, string pattern, RegexOptions options);
        public MatchCollection Matches(string input);
        public MatchCollection Matches(string input, int startat);
        public static string Replace(string input, string pattern, string replacement);
        public static string Replace(string input, string pattern, string replacement, RegexOptions options);
        public string Replace(string input, string replacement);
        public string Replace(string input, string replacement, int count);
        public string Replace(string input, string replacement, int count, int startat);
        public static string Replace(string input, string pattern, MatchEvaluator evaluator);
        public static string Replace(string input, string pattern, MatchEvaluator evaluator, RegexOptions options);
        public string Replace(string input, MatchEvaluator evaluator);
        public string Replace(string input, MatchEvaluator evaluator, int count);
        public string Replace(string input, MatchEvaluator evaluator, int count, int startat);
        public static string[] Split(string input, string pattern);
        public static string[] Split(string input, string pattern, RegexOptions options);
        public string[] Split(string input);
        public string[] Split(string input, int count);
        public string[] Split(string input, int count, int startat);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void CompileToAssembly(RegexCompilationInfo[] regexinfos, AssemblyName assemblyname);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void CompileToAssembly(RegexCompilationInfo[] regexinfos, AssemblyName assemblyname,
                                             CustomAttributeBuilder[] attributes);

        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public static void CompileToAssembly(RegexCompilationInfo[] regexinfos, AssemblyName assemblyname,
                                             CustomAttributeBuilder[] attributes, string resourceFile);

        protected void InitializeReferences();
        protected bool UseOptionC();
        protected bool UseOptionR();
    }
}

// logger for compilation finished hook.
// where we need a callback and Debug.Log.
//#if !UNITY_2020_1_OR_NEWER <- still need it for tests in 2020+
using Mono.CecilX;
using UnityEngine;

namespace Mirror.Weaver
{
    public class CompilationFinishedLogger : Logger
    {
        public void Warning(string message) => Warning(message, null);
        public void Warning(string message, MemberReference mr)
        {
            if (mr != null) message = $"{message} (at {mr})";

            if (CompilationFinishedHook.UnityLogEnabled) Debug.LogWarning(message);
            CompilationFinishedHook.OnWeaverWarning?.Invoke(message);
        }

        public void Error(string message) => Error(message, null);
        public void Error(string message, MemberReference mr)
        {
            if (mr != null) message = $"{message} (at {mr})";

            if (CompilationFinishedHook.UnityLogEnabled) Debug.LogError(message);
            CompilationFinishedHook.OnWeaverError?.Invoke(message);
        }
    }
}
//#endif

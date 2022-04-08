using System;
using UnityEngine;


namespace Code.Extensions{
    public static class Dbg{
        public static void Log(string message){
            if (Debug.isDebugBuild)
                Debug.Log($"{message}");
        }

        public static void Log(Enum @enum){
            if (Debug.isDebugBuild)
                Debug.Log($"Console.{@enum.GetType()}:{@enum}");
        }

        public static void Warning(string message){
            if (Debug.isDebugBuild)
                Debug.LogWarning($"{message}");
        }

        public static void Error(string message){
            if (Debug.isDebugBuild)
                Debug.LogError($"{message}");
        }
    }
}
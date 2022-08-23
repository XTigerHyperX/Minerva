using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Minerva.Core
{
    internal static class Logger
    {
        private static readonly object ObjetLock = new();
        private static readonly Queue<Action> Logs = new();
        private static readonly DateTime InitialDT;
        private static bool loggerThreadRunning = true;
        private static DateTime currentDT;
        
        static Logger()
        {
            InitialDT = currentDT = DateTime.Now;
            InitializeThread();
        }
        
        private enum LogLevel
        {
            Process,
            Path,
            GarbageCollector,
            Info,
            Error,
            Success
        }
        public static void LogInfo(string content, [CallerMemberName] string callingMethodName = default) => QueueAction(() => Log(LogLevel.Info, content, DateTime.Now, callingMethodName));

        public static void LogSuccess(string content, [CallerMemberName] string callingMethodName = default) => QueueAction(() => Log(LogLevel.Success, content, DateTime.Now, callingMethodName));

        public static void LogError(string content, [CallerMemberName] string callingMethodName = default) => QueueAction(() => Log(LogLevel.Error, content, DateTime.Now, callingMethodName));
        
        public static void LogPath(string content, [CallerMemberName] string callingMethodName = default) => QueueAction(() => Log(LogLevel.Path, content, DateTime.Now, callingMethodName));

        public static void LogProcess(string content, [CallerMemberName] string callingMethodName = default) => QueueAction(() => Log(LogLevel.Process, content, DateTime.Now, "CurrentProcess"));
        
        public static void LogTotalTime() => QueueAction(() =>
        {
            Console.WriteLine($"All tasks were done in {Convert.ToInt32((DateTime.Now - InitialDT).TotalSeconds)}s");
            Thread.Sleep(100);
            loggerThreadRunning = false;
        });

        private static void QueueAction(Action action)
        {
            lock (ObjetLock)
            {
                Logs.Enqueue(action);
            }
        }

        private static void InitializeThread()
        {
            Thread loggerThread = new(() =>
            {
                while (loggerThreadRunning)
                {
                    lock (ObjetLock)
                    {
                        if (Logs.TryDequeue(out Action logInvoke))
                        {
                            logInvoke?.Invoke();
                        }
                    }
                }
            });

            loggerThread.Start();
        }

        private static void Log(LogLevel state, string content, DateTime dateTime, string methodName)
        {
            string toWrite = state == LogLevel.Info ? $"[{dateTime:G}]" : $"[{dateTime:G} ({Convert.ToInt32((dateTime - currentDT).TotalMilliseconds)}ms)]";
            currentDT = dateTime;
            Console.ForegroundColor = state switch
            {
                LogLevel.Process => ConsoleColor.DarkCyan,
                LogLevel.Info => ConsoleColor.Cyan,
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Path => ConsoleColor.Yellow,
                LogLevel.GarbageCollector => ConsoleColor.Cyan,
                LogLevel.Success => ConsoleColor.Green,
                _ => throw new ArgumentException("Unsupported LogLevel")
            };
                Console.WriteLine($"{toWrite} [{state}] ({methodName}) {content}");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
    
}
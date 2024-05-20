using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Reflection;

namespace Globals
{
    static class Timing{
        static Stopwatch sw = new Stopwatch();
        public static void TimeStopwatch<T>(MethodInfo method, T classInstance, object[] obj, string algorithm){
            sw.Start();
            var returned = method.Invoke(classInstance, obj);
            // Console.WriteLine(returned);
            sw.Stop();
            Console.WriteLine("{0} Elapsed Time={1}\n", algorithm ,sw.Elapsed);
            sw.Reset();
        }

        public static void RunMethodAndStopWatch<T>(T instance, object[] items, string method_name){
            var types = new List<Type>();
            items.ToList().ForEach(item => types.Add(item.GetType()));
            MethodInfo method = typeof(T).GetMethod(method_name.Replace(" ", ""), types.ToArray());
            TimeStopwatch<T>(method, instance, items, method_name);
        }
    }
}
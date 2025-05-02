using System;
using System.Threading.Tasks;
using UnityEngine;

namespace General
{
    public static class Utils
    {
        public static async Task HandleExceptions(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(StackTraceUtility.ExtractStringFromException(e));
                throw;
            }
        } 
        
        public static async Task<T> HandleExceptions<T>(this Task<T> task)
        {
            try
            {
                return await task;
            }
            catch (Exception e)
            {
                Console.WriteLine(StackTraceUtility.ExtractStringFromException(e));
                throw;
            }
        } 
    }
}
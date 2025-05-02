using System;
using System.Threading.Tasks;
using DataProviding;
using Firebase.Database;
using UnityEngine;
using Newtonsoft.Json;

namespace General
{
    public static class DataLoadService
    {
        public async static Task<T> Load<T>(string path)
        {
            Debug.Log($"Trying to load {path} of type {typeof(T).Name}");
            var task = FirebaseDatabase.DefaultInstance.GetReference(path).GetValueAsync();
            await task.HandleExceptions();

            if (task.IsFaulted)
            {
                throw new Exception($"Load data of type {typeof(T).Name} from path {path} failed!");
            }

            var jsonValue = task.Result.GetRawJsonValue();
            Debug.Log($"Load data of type {typeof(T).Name} from path {path} succeeded!" +
                      $"\nRaw: {jsonValue}");
            return JsonConvert.DeserializeObject<T>(jsonValue);
        }
    }
}
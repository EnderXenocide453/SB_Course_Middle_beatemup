using AI;
using DataProviding;
using Firebase;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;
using Task = System.Threading.Tasks.Task;

namespace General
{
    public class MainApplication : MonoBehaviour
    {
        private async void Awake()
        {
            await CheckSystemCompatibility();
            Init();
        }

        private Task CheckSystemCompatibility()
        {
            return FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
            {
                var dependencyStatus = task.Result;
                if (dependencyStatus != DependencyStatus.Available)
                {
                    Debug.LogError($"Could not resolve all Firebase dependencies: {dependencyStatus}");
                    return;
                }
                
                FirebaseDatabase.DefaultInstance.SetPersistenceEnabled(false);
            });
        }

        private async void Init()
        {
            await LoadData();
            SceneManager.LoadSceneAsync(1);
        }

        private async Task LoadData()
        {
            await LoadStaticData();
        }

        private async Task LoadStaticData()
        {
            var staticData = await DataLoadService.Load<StaticData>("StaticData").HandleExceptions();
            DataProvider.RegisterData(staticData);
            
            var aiData = new AIGlobalData();
            aiData.Init();
            DataProvider.RegisterData(aiData);
        }
    }
}
using UnityEngine;
using UnityEngine.Events;

namespace Minigame2
{
    public class GameManager : Singleton<GameManager>
    {
        public bool isStarted = false;
        public float time;

        public UnityEvent OnStartGame;
        public UnityEvent OnEndGame;
        
        
        private void Update()
        {
            if (!isStarted) return;

            time -= Time.deltaTime;
            if (time <= 0f)
            {
                EndGame();
            }
        }

        public void StartGame()
        {
            isStarted = true;
            
            // Player
            GameObject.FindWithTag("Player")?.GetComponent<PlayerMovement>()?.StartMovement();
            
            // Spawner
            var spawners = FindObjectsByType<PrefabSpawner>(FindObjectsSortMode.None);
            foreach (var spawner in spawners)
            {
                spawner.StartSpawn();
            }
            
            OnStartGame.Invoke();
        }

        public void EndGame()
        {
            isStarted = false;
            
            // Player
            GameObject.FindWithTag("Player")?.GetComponent<PlayerMovement>()?.StopMovement();
            
            MingameData.Instance.SetMoney();

            OnEndGame.Invoke();
        }
    }
}
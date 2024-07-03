using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Minigame2
{
    [RequireComponent(typeof(Camera))]
    public class CameraManager : Singleton<CameraManager>
    {
        private Camera cam;
    
        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        public async void Shake(float ShakeAmount, float ShakeTime)
        {
            Vector3 origin = cam.transform.position;
        
            float timer = 0f;
            while (timer <= ShakeTime)
            {
                cam.transform.position = origin + (Vector3)Random.insideUnitCircle * ShakeAmount;
                timer += Time.deltaTime;
                await UniTask.DelayFrame(1);
            }

            cam.transform.position = origin;
        }   
    }
}
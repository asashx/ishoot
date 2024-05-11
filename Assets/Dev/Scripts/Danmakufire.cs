using System.Collections;
using System.Collections.Generic;
using DanmakU.Fireables;
using UnityEngine;

namespace DanmakU
{

    [AddComponentMenu("DanmakU/Danmaku Emitter")]
    public class DanmakuEmitter : DanmakuBehaviour
    {

        public DanmakuPrefab DanmakuType;

        public Range Speed = 5f;
        public Range AngularSpeed;
        public Color Color = Color.white;
        public Range FireRate = 5;
        public float FrameRate;
        public Arc Arc;
        public Line Line;
        public Transform direction; // 添加一个变量来表示发射的方向

        public int bulletsPerSound = 10; // Add this field to specify how many bullets should be fired before playing the sound

        private int bulletCount; // Add this field to track the number of bullets fired
        public AudioClip shotSound; // Add this field to hold the audio clip to be played

        private AudioSource audioSource; // Add this field to hold the AudioSource component
        float timer;
        DanmakuConfig config;
        IFireable fireable;

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            if (DanmakuType == null)
            {
                Debug.LogWarning($"Emitter doesn't have a valid DanmakuPrefab", this);
                return;
            }
            var set = CreateSet(DanmakuType);
            set.AddModifiers(GetComponents<IDanmakuModifier>());
            fireable = Arc.Of(Line).Of(set);
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        /// <summary>
        /// Update is called every frame, if the MonoBehaviour is enabled.
        /// </summary>
        void Update()
        {
            if (fireable == null) return;
            var deltaTime = Time.deltaTime;
            if (FrameRate > 0)
            {
                deltaTime = 1f / FrameRate;
            }
            timer -= deltaTime;
            if (timer < 0)
            {
                config = new DanmakuConfig
                {
                    Position = transform.position,
                    Rotation = direction != null ? direction.rotation.eulerAngles.y * Mathf.Deg2Rad : transform.rotation.eulerAngles.y * Mathf.Deg2Rad, // 使用direction的方向，如果direction为空，则使用transform的方向
                    Speed = Speed,
                    AngularSpeed = AngularSpeed,
                    Color = Color
                };
                fireable.Fire(config);
                bulletCount++;

                if (shotSound != null && bulletCount == bulletsPerSound)
                {
                    audioSource.PlayOneShot(shotSound);
                }
                bulletCount = 0;
                timer = 1f / FireRate.GetValue();
            }
        }


    }

}

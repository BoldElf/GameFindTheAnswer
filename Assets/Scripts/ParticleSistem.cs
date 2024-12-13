using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Game
{
    public class ParticleSistem : MonoBehaviour
    {
        [SerializeField] private float activeTime = 1;
        [SerializeField] private ParticleSystem _particleSystem;
        [Inject] private SetFindSystem setFindSystem;

        private ParticleSystem particle;

        private void Start()
        {
            setFindSystem.spawnParticle += StartParticle;
        }

        private bool isPlay = false;
        private float timer;

        private void Update()
        {
            if (isPlay == true)
            {
                timer += Time.deltaTime;

                if (timer > activeTime)
                {
                    setFindSystem.NextLevel();
                    isPlay = false;
                    timer = 0;
                }
            }

        }

        private void StartParticle(ButtonController button)
        {
            particle = Instantiate(_particleSystem,button.gameObject.transform);
            DOTween.Sequence().Append(DOTween.To(PlayParticle, 0, 1f, _particleSystem.main.duration)).SetLink(button.gameObject);
            isPlay = true;
        }

        private void PlayParticle(float f)
        {
        
        }
    }
}


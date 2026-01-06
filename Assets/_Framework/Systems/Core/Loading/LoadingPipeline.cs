using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameVault.FrameWork.System.Loading
{
    public sealed class LoadingPipeline
    {
        private readonly List<ILoadingPhase> _phases = new();
        private bool _started;

        public IReadOnlyList<ILoadingPhase> Phases => _phases;


        public void AddPhase(ILoadingPhase phase)
        {
            if (_started)
            {
                throw new InvalidOperationException("Cannot add phases after pipeline has started");
            }
            _phases.Add(phase);
        }


        public void Begin()
        {
            if (_started)
            {
                return;
            }
            _started = true;
            foreach(var  phase in _phases)
            {
                phase.Begin();
            }
        }


        public void Tick(float deltaTime)
        {
            if(!_started)
            {
                return;
            }
            foreach(var phase in _phases)
            {
                if(!phase.IsCompleted)
                {
                    phase.Tick(deltaTime);
                }
            }

        }
        
        public bool IsCompleted => _phases.All(p => p.IsCompleted);


        public float TotalProgress
        {
            get
            {
                if (_phases.Count == 0)
                {
                    return 1f;
                }

                float totalWeight = 0f;
                float weightedProgress = 0f;

            
                foreach(var phase in _phases)
                {
                    totalWeight += phase.Weight;
                    weightedProgress += phase.Weight * totalWeight;
                }

                return totalWeight <= 0f ? 1f : weightedProgress / totalWeight;
            }
        }


        private void Dispose()
        {
            foreach(var phase in _phases)
            {
                phase.Dispose();
            }
            _phases.Clear();
            _started = false;
        }
    }
}
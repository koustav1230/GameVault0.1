using GameVault.FrameWork.System.Loading.Pipeline;
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

        public LoadingPipelineState State { get; private set; } = LoadingPipelineState.Idle;

        public float Progress { get; private set; }
        public bool IsRunning => State == LoadingPipelineState.Running;
        public bool IsCompleted => State == LoadingPipelineState.Completed;

        /// <summary>
        /// Phase Registration
        /// </summary>
        /// <param name="phase"></param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddPhase(ILoadingPhase phase)
        {
            _phases.Add(phase);
        }


        /// <summary>
        /// Lifecycle
        /// </summary>

        public void Start()
        {
     
            if(_phases.Count == 0)
            {
                Debug.Log("[LoadingPipeine] Started with no phases");
                State = LoadingPipelineState.Completed;
                return;
            }

            Debug.Log("[LoadingPipeline] Started");

            State = LoadingPipelineState.Running;

            foreach (var phase in _phases)
            {
                phase.Begin();
            }
        }



        public void Tick(float deltaTime)
        {
            if (State != LoadingPipelineState.Running)
            {
                return;
            }

            float weightedProgress = 0f;
            float totalWeight = 0f;
            bool allBlockingCompleted = true;


            foreach (var phase in _phases)
            {
            
                if (!phase.IsCompleted)
                {
                    phase.Tick(deltaTime);

                    if (phase.Type == LoadingPhaseType.Blocking)
                    {
                        allBlockingCompleted = false;
                    }
                }

                weightedProgress += phase.Progress * phase.Weight;
                totalWeight += phase.Weight;
            }

            Progress = totalWeight > 0f ? Mathf.Clamp01(weightedProgress / totalWeight) : 1f;

            if (allBlockingCompleted)
            {
               State = LoadingPipelineState.AwaitingCompletion;
               Debug.Log("[LoadingPipeline] Blocking phases completed");
            }

        }

        public void Complete()
        {
        
            if(State == LoadingPipelineState.Completed)
            {
                return;
            }

            Debug.Log("[LoadingPipeline] Completed");

            foreach(var phase in _phases)
            {
                phase.Dispose();
            }
            _phases.Clear();
            State = LoadingPipelineState.Completed;
        }
    }
}
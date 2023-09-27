using Race_game_project.AIPathFinderManager;
using Racing_game_project.AIInputManager;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Race_game_project.AICarMovement
{
    public class AICarMovement : MonoBehaviour, IAICarMovement
    {
        [SerializeField]
        GameObject firstHalfGrid;
        [SerializeField]
        GameObject secondHalfGrid;
        public bool isSecondHalf = false;
        IAIShortestPathFinder _aiPathFinder;
        IAIInputManager _aiInputManager;
        void Awake()
        {
            _aiPathFinder = this.gameObject.GetComponent<AIShortestPathFinder>();
            _aiInputManager = this.gameObject.GetComponent<AIInputManager>();
            _aiPathFinder.SetId(Guid.NewGuid());
            SetNewPath();
        }
        void Update()
        {
            _aiInputManager.ManageAIInputData();

        }
        public void SetIsSecondHalfOfGrid(bool isSecondHalf)
        {
            this.isSecondHalf = isSecondHalf;
        }
        public void SetNewPath()
        {
            if (isSecondHalf)
                _aiPathFinder.FindShortestPath(secondHalfGrid, 0f, true);
            else
                _aiPathFinder.FindShortestPath(firstHalfGrid, 0f, true);
        }
    }
}
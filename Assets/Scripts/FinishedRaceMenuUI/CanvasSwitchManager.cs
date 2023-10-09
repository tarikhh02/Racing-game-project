using UnityEngine;

namespace Race_game_project.CanvasSwithcingManager
{
    public class CanvasSwitchManager : MonoBehaviour, ICanvasSwitchManager
    {
        [SerializeField]
        GameObject _trackDataCanvas;
        [SerializeField]
        GameObject _finishedRaceCanvas;

        public void SwitchCanvas()
        {
            _trackDataCanvas.SetActive(false);
            _finishedRaceCanvas.SetActive(true);
        }
    }
}
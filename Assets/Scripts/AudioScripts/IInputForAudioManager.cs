using UnityEngine;

namespace Race_game_project.AudioInputManagement
{
    public interface IInputForAudioManager
    {
        public void GetInputForAudio(ref Race_game_project.AudioScripts.State _nextState, AudioSource braking, AudioSource spinningWheels);
    }
}
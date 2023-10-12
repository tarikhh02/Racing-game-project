using Race_game_project.AudioInputManagement;
using UnityEngine;

public class AudioManagement : MonoBehaviour
{
    [SerializeField]
    AudioClip _idle;
    [SerializeField]
    AudioClip _throttle;
    [SerializeField]
    AudioClip _maxSpeed;
    [SerializeField]
    AudioSource _braking;
    [SerializeField]
    AudioSource _spinningWheels;
    [SerializeField]
    AudioSource _audioSource;
    Race_game_project.AudioScripts.State _currentState = Race_game_project.AudioScripts.State.Start;
    Race_game_project.AudioScripts.State _nextState = Race_game_project.AudioScripts.State.Idle;
    IInputForAudioManager _audioInputManager;
    
    private void Awake()
    {
        _audioInputManager = this.GetComponent<InputForAudioManager>();
    }
    private void Update()
    {
        _audioInputManager.GetInputForAudio(ref _nextState, _braking, _spinningWheels);
        ChooseSoundBasedOnState();
    }
    private void ChooseSoundBasedOnState()
    {
        if (_nextState != _currentState)
        {
            if (_nextState == Race_game_project.AudioScripts.State.Idle)
                PlaySound(_idle, true);
            else if (_nextState == Race_game_project.AudioScripts.State.Throttle)
                PlaySound(_throttle, true);
            else if (_nextState == Race_game_project.AudioScripts.State.MaxSpeed)
                 PlaySound(_maxSpeed, true);
            _currentState = _nextState;
        }
    }
    private void PlaySound(AudioClip clip, bool isLooping)
    {
        _audioSource.Stop();
        _audioSource.clip = clip;
        _audioSource.loop = isLooping;
        _audioSource.volume = 0.3f;
        _audioSource.Play();
    }
}

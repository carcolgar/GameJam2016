using UnityEngine;
using System.Collections.Generic;

public class FMODManager : MonoBehaviour 
{
    #region CONSTANTS
    
    public sealed class Sounds
    {
        public static string Cat = "Cat";
        public static string Chicken = "Chicken";
        public static string Dog = "Dog";
        public static string DoorWindowOpen = "DoorWindowOpen";
        public static string DoorWindowClose = "DoorWindowClose";
        public static string Environment = "Environment";
        public static string GameOver = "GameOver";
        public static string Grandma = "Grandma";
        public static string HandsOn = "HandsOn";
        public static string LeaveObject = "LeaveObject";
        public static string MainMenu = "MainMenu";
        public static string Monks = "Monks";
        public static string OffCandle = "OffCandle";
        public static string OnCandle = "OnCandle";
        public static string PickObject = "PickObject";
        public static string PlayerStep = "PlayerStep";
        public static string Radio = "Radio";
        public static string Request = "Request";        
        public static string RequestFail = "RequestFail";
        public static string RequestSuccess = "RequestSuccess";
        public static string Teletubies = "Teletubies";
        public static string WashingMachine = "WashingMachine";
    }
    
    public sealed class Parameter
    {
        public static string Time = "Time";
        public static string Monks = "Monks";
    }
    
    
    #endregion
    

    #region FIELDS
    
    private static string _eventsPath = "event:/";
    
    private Dictionary<string, FMOD.Studio.EventInstance> _runningSounds = null;
    
    #endregion


    #region SINGLETON
    
    private static FMODManager _instance = null;
    
    public static FMODManager SINGLETON { get { return _instance; } }
    
    #endregion


    #region UNITY_METHODS
    
    /// <summary>
    /// Awake del componente
    /// </summary>
    private void Awake()
    {
        _instance = this;
        
        _runningSounds = new Dictionary<string, FMOD.Studio.EventInstance>();
    }
    
    #endregion
    
    
    #region CUSTOM_METHODS
    
    public void PlayOneShot(string soundEventName)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_eventsPath + soundEventName);
    }
    
    public void PlaySound(string soundEventName, string parameterName = "", float parameterValue = 0.0f)
    {
        if(_runningSounds.ContainsKey(soundEventName))
        {
            Debug.LogWarning("[FMODManager::PlaySound] El sonido '"+soundEventName+"' ya se esta reproduciendo");
            return;
        }
        
        FMOD.Studio.EventInstance fmodEvent = FMODUnity.RuntimeManager.CreateInstance(_eventsPath+soundEventName);
        fmodEvent.start();
        
        _runningSounds.Add(soundEventName, fmodEvent);
        
        if(parameterName!="")
        {
            FMOD.Studio.ParameterInstance parameter;
            fmodEvent.getParameter(parameterName, out parameter);
            parameter.setValue(parameterValue);
        }
    }
    
    public void ChangeParameterValue(string soundEventName, string parameterName, float parameterValue)
    {
        if(!_runningSounds.ContainsKey(soundEventName))
        {
            Debug.LogWarning("[FMODManager::ChangeParameterValue] El sonido '"+soundEventName+"' no se esta reproduciendo reproduciendo");
            return;
        }
        
        FMOD.Studio.EventInstance fmodEvent = _runningSounds[soundEventName];
        FMOD.Studio.ParameterInstance parameter;
        fmodEvent.getParameter(parameterName, out parameter);
        parameter.setValue(parameterValue);
    }
    
    public void StopSound(string soundEventName)
    {
        if(!_runningSounds.ContainsKey(soundEventName))
        {
            Debug.LogWarning("[FMODManager::StopSound] El sonido '"+soundEventName+"' no se esta reproduciendo reproduciendo");
            return;
        }
        
        FMOD.Studio.EventInstance fmodEvent = _runningSounds[soundEventName];
        fmodEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        
        _runningSounds.Remove(soundEventName);
    }
    
    public void StopAllSounds()
    {
        foreach(var pair in _runningSounds)
        {
            pair.Value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);            
        }
        
        _runningSounds.Clear();
    }
    
    #endregion

}

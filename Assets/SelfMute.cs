using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

#endif
using Normal.Realtime;


namespace Narf
{

public class SelfMute : MonoBehaviour
{

    public RealtimeAvatarVoice _RealtimeAvatarVoice;

    void Awake(){
        // _RealtimeAvatarVoice = GetComponent<RealtimeAvatarVoice>(); 
    }


    public void ToggleMute(bool val){
        // print($"val {val}");
        _RealtimeAvatarVoice.mute = val;


    }


    void Start(){}

    void Update(){

        if (Input.GetKey("q"))
        {
            print("up arrow key is held down");
            ToggleMute(true);
        }

        if (Input.GetKey("w"))
        {
            print("down arrow key is held down");
            ToggleMute(false);
        }


    }

    public void Rebuild(){}

}



// android errors and does not compile if this is not wrapping the editor
#if UNITY_EDITOR

[CustomEditor(typeof(SelfMute))]
public class SelfMuteEditor : Editor
{
	public override void OnInspectorGUI()
	{
        DrawDefaultInspector();
        
		SelfMute pick = (SelfMute)target;
	
		if (GUILayout.Button("ToggleMute true", GUILayout.Height(40))) {
            pick.ToggleMute(true);
        }
						
		if (GUILayout.Button("ToggleMute false", GUILayout.Height(40))) {
            pick.ToggleMute(false);
        }
		
	}

}


#endif

}
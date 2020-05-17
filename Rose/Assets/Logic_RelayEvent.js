#pragma strict
import UnityEngine.Events;

var OnStartTrigger : boolean;
var RandomPick : boolean;
//var StartDelay : float;
var Output : OutputDatas[];

class OutputDatas{
	var StartDelay : float;
	var Triggered : UnityEvent;
	//var AffectedGameObject : GameObject;
	//var ScriptToTrigger : String; 
	//var isGotValue : boolean;
	//var scriptValue : float;
	//var DestroyAffectedObject : boolean;
	//var EnableAffectedObject : boolean;
	//var DisableAffectedObject : boolean;
}

function Start () {
 		
 	if(OnStartTrigger){
 		if(RandomPick){
	 		TriggerRandom();
	 		}else{
	 		Trigger();
	 		}
 		}	
}

function TriggerRandom(){
	var Nene = Output[Random.Range(0, Output.length)];
	
		yield WaitForSeconds(Nene.StartDelay);
		
		Nene.Triggered.Invoke();
}

function Trigger(){
//yield WaitForSeconds(StartDelay);

	for (var M : OutputDatas in Output){
		yield WaitForSeconds(M.StartDelay);

			M.Triggered.Invoke();	
	}
}
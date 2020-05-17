#pragma strict

var HeadModel : Renderer;
var EyeLevel : Transform;
var Target : Transform;
var EyeSetting : Eyes;

private var uvAnimationRateR : Vector2 = Vector2( 0.0f, 0.0f );
private var uvAnimationRateL : Vector2 = Vector2( 0.0f, 0.0f );
private var textureName : String = "_MainTex"; 
private var MM : GameObject;
var InvertHorizontal : boolean;
var InvertVertical : boolean;
var SpeedOfLooking : float = 1.00;

class Eyes{
var IrisLeftIndex : int;
var IrisRightIndex : int;
var MaxIrisPanHoriOutward : float = 0.1;
var MaxIrisPanHoriInward : float = -0.07;
var MaxIrisPanVertUp : float = 0.15;
var MaxIrisPanVertDown : float = -0.15;
}
 
function Start(){
MM = new GameObject("DummyTarget");
MM.transform.parent = EyeLevel;
MM.transform.localRotation = EyeLevel.localRotation;
}
 
function Update(){
	//Eyes start to focus on target if found	
	if(Target != null){
		MM.transform.position = Target.position;
		
		if(!InvertHorizontal){
		uvAnimationRateR.x = Mathf.Lerp(uvAnimationRateR.x, MM.transform.localPosition.x - EyeLevel.localPosition.x, Time.deltaTime * SpeedOfLooking);
		}else{
		uvAnimationRateR.x = Mathf.Lerp(uvAnimationRateR.x, EyeLevel.localPosition.x - MM.transform.localPosition.x, Time.deltaTime * SpeedOfLooking);
		}
		
		if(!InvertVertical){
		uvAnimationRateR.y = Mathf.Lerp(uvAnimationRateR.y, EyeLevel.localPosition.y - MM.transform.localPosition.y, Time.deltaTime * SpeedOfLooking);
		}else{
		uvAnimationRateR.y = Mathf.Lerp(uvAnimationRateR.y, MM.transform.localPosition.y - EyeLevel.localPosition.y, Time.deltaTime * SpeedOfLooking);
		}
		
		uvAnimationRateR = Vector2( Mathf.Clamp(uvAnimationRateR.x, EyeSetting.MaxIrisPanHoriInward, EyeSetting.MaxIrisPanHoriOutward), 
									Mathf.Clamp(uvAnimationRateR.y, EyeSetting.MaxIrisPanVertDown, EyeSetting.MaxIrisPanVertUp) );
	   	
	   	var PanOutL : float;
		var PanInL : float;
	   	PanOutL = EyeSetting.MaxIrisPanHoriOutward  * -1.0;
	   	PanInL = EyeSetting.MaxIrisPanHoriInward  * -1.0;
	   	
	   if(!InvertHorizontal){
		uvAnimationRateL.x = Mathf.Lerp(uvAnimationRateL.x, MM.transform.localPosition.x - EyeLevel.localPosition.x, Time.deltaTime * SpeedOfLooking);
		}else{
		uvAnimationRateL.x = Mathf.Lerp(uvAnimationRateL.x, EyeLevel.localPosition.x - MM.transform.localPosition.x, Time.deltaTime * SpeedOfLooking);
		}
		
		if(!InvertVertical){
		uvAnimationRateL.y = Mathf.Lerp(uvAnimationRateL.y, EyeLevel.localPosition.y - MM.transform.localPosition.y, Time.deltaTime * SpeedOfLooking);
		}else{
		uvAnimationRateL.y = Mathf.Lerp(uvAnimationRateL.y, MM.transform.localPosition.y - EyeLevel.localPosition.y, Time.deltaTime * SpeedOfLooking);
		}
		
	   	uvAnimationRateL = Vector2( Mathf.Clamp(uvAnimationRateL.x, PanOutL, PanInL), 
									Mathf.Clamp(uvAnimationRateL.y, EyeSetting.MaxIrisPanVertDown, EyeSetting.MaxIrisPanVertUp) );
	   
	    HeadModel.materials[EyeSetting.IrisLeftIndex].SetTextureOffset( textureName, uvAnimationRateL);
	    HeadModel.materials[EyeSetting.IrisRightIndex].SetTextureOffset( textureName, uvAnimationRateR);
    }else{
    	//Eyes Return to Original Position if target not found
	    uvAnimationRateR = Vector2.Lerp( uvAnimationRateR, Vector2.zero, Time.deltaTime);
		uvAnimationRateL = Vector2.Lerp( uvAnimationRateL, Vector2.zero, Time.deltaTime);
		HeadModel.materials[EyeSetting.IrisLeftIndex].SetTextureOffset( textureName, uvAnimationRateL);
	    HeadModel.materials[EyeSetting.IrisRightIndex].SetTextureOffset( textureName, uvAnimationRateR);
    }
}
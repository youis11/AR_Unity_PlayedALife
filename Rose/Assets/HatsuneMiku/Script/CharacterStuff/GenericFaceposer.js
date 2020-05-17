#pragma strict

var MorpherModel : SkinnedMeshRenderer;
private var skinnedMeshRenderer : SkinnedMeshRenderer;
var OnStartPlay : boolean = true;
var RandomBlinking : boolean;
var RandomFace : boolean;
var EyeMorphNum : int;
var MorphSpeed : float;
@HideInInspector var MorphNumber : int;
@HideInInspector var MorphAmount : float;
@HideInInspector var Ontalking : boolean = false;

var MorphToScript : ScriptMorph[];

class ScriptMorph{
var MorphNum : int;
}

var MouthForTalkingMorph : TalkingMorph;

class TalkingMorph{
var MouthMorphNum : int[];
}

var RandomFaceMorph : FaceRandom[];

class FaceRandom{
var FirstMorphNumber : int;
var NeedSecondMorph : boolean = true;
var SecondMorphNumber : int;
}

private var faceSpeed = 1f;
private var MaximumBlend = 50f;
private var MinimumBlend = 0f;
private var blendtwo = 0f;
private var blendthree = 0f;
private var plusyes : boolean;
private var minusyes : boolean;
private var Operator : float;

private var BlinkingSpeed = 10f;
private var blendOne = 0f;
private var startblink = false;
private var startblinkB = false;
private var Activated : boolean;
private var blendShapeCount:int=0;
private var delaymouthsync : boolean = true;

function neni (M : boolean){
Ontalking = M;
}

function Start(){
	if(OnStartPlay){
	InvokeRepeating("EyeBlinking", 1, 3);
	InvokeRepeating("Ranme", 1, 5);
	}
}

function Awake(){
skinnedMeshRenderer = MorpherModel.GetComponent(SkinnedMeshRenderer);
  blendShapeCount = MorpherModel.GetComponent(SkinnedMeshRenderer).sharedMesh.blendShapeCount;
}

function EyeBlinking () {
startblink = true;
}

function Update(){
	if(Activated){
	MorphAmount = Mathf.Lerp(MorphAmount, 100, Time.deltaTime * MorphSpeed);
	skinnedMeshRenderer.SetBlendShapeWeight (MorphNumber, MorphAmount);		
	}
		
if (RandomBlinking == true){
	BlinkNow();
	}	
	
if (RandomFace == true){
	FaceRandomNow();
	}				
}

function BlinkNow(){
 //Blink morph is 0
	if (startblink == true){
		skinnedMeshRenderer.SetBlendShapeWeight (EyeMorphNum, blendOne);
		blendOne += BlinkingSpeed;
		}
		
	if (blendOne >= 100){
		startblinkB = true;
		startblink = false;
		}

	if (startblinkB == true){
		skinnedMeshRenderer.SetBlendShapeWeight (EyeMorphNum, blendOne);
		blendOne -= BlinkingSpeed;
		}
		
	if (blendOne <= 0){
		startblinkB = false;
		startblink = false;
		}
}

function Ranme(){
faceSpeed = Random.Range(1.0, 2.0);
MaximumBlend = Random.Range(30, 40);
MinimumBlend = Random.Range(0, 20);

Operator = Random.Range(1.00, 2.00);
	if (Operator > 1.50){
	plusyes = true;
	minusyes = false;
	}
	
	if (Operator < 1.50){
	plusyes = false;
	minusyes = true;
	}
}

function FaceRandomNow(){
	if(Ontalking == false){
	    for(var M : FaceRandom in RandomFaceMorph){
			skinnedMeshRenderer.SetBlendShapeWeight (M.FirstMorphNumber, blendtwo);
			
			if(M.NeedSecondMorph)
			skinnedMeshRenderer.SetBlendShapeWeight (M.SecondMorphNumber, blendtwo);
		}
		
		if (plusyes == true){
		blendtwo += faceSpeed;
		blendthree += faceSpeed;
		}
		
		if (minusyes == true){
		blendtwo -= faceSpeed;
		blendthree -= faceSpeed;
		}
		
		if (blendtwo >= MaximumBlend)
		blendtwo = MaximumBlend;
			
		if (blendtwo <= MinimumBlend)
		blendtwo = MinimumBlend;
		
		if (blendthree >= 100)
		blendthree = 99;
		
		if (blendthree <= 0)
		blendthree = 1;
	}
}

function FaceTalking(TalkingNow: float){
    //Mouth 
    if(delaymouthsync){
  	delaymouthsync = false;
    var NRandom : int = Random.Range(0,MouthForTalkingMorph.MouthMorphNum.Length);
   		yield WaitForSeconds(1.0);
    delaymouthsync = true;
    }
    
    for(var i : int = 0; i<MouthForTalkingMorph.MouthMorphNum.Length; i++){
    	if(i == NRandom){
    	skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.MouthMorphNum[i], TalkingNow);
    	}else{
    	skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.MouthMorphNum[i], 0);
    	}
    }
    
//    if(NRandom == 0){
//	skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.FirstMouthMorphNum, TalkingNow);
//	if(MouthForTalkingMorph.SecondMouthMorphNum)
//	skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.SecondMouthMorphNum, 0);
//	}else
//	if(NRandom == 1){
//		if(MouthForTalkingMorph.SecondMouthMorphNum){
//			skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.SecondMouthMorphNum, TalkingNow);
//			skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.FirstMouthMorphNum, 0);
//			}else
//		skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.FirstMouthMorphNum, TalkingNow);
//	}else
//	if(NRandom == 2){
//		if(MouthForTalkingMorph.ThirdMouthMorphNum){
//			skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.SecondMouthMorphNum, TalkingNow);
//			skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.FirstMouthMorphNum, 0);
//			}else
//			skinnedMeshRenderer.SetBlendShapeWeight (MouthForTalkingMorph.FirstMouthMorphNum, TalkingNow);
//			}
}

function ResetFace(){

		RandomBlinking = false;
		RandomFace = false;
	
		//Random Morph
		for(var M : FaceRandom in RandomFaceMorph){
			skinnedMeshRenderer.SetBlendShapeWeight (M.FirstMorphNumber, 0);
			
			if(M.NeedSecondMorph)
			skinnedMeshRenderer.SetBlendShapeWeight (M.SecondMorphNumber, 0);
		}
		
		//eyes
		skinnedMeshRenderer.SetBlendShapeWeight (EyeMorphNum, 0);
		
		//OthersMimic
		for(var M : ScriptMorph in MorphToScript)
		skinnedMeshRenderer.SetBlendShapeWeight (M.MorphNum, 0);
		
		for(var i : int = 0; i < blendShapeCount; i++)
		skinnedMeshRenderer.SetBlendShapeWeight (i, 0);

}

function DoMimic(Mimic : float){

	RandomBlinking = false;
	RandomFace = false;

	for(var M : ScriptMorph in MorphToScript)
	skinnedMeshRenderer.SetBlendShapeWeight (M.MorphNum, Mimic);
	
}

function EnableRandomize(){

	RandomBlinking = true;
	RandomFace = true;
}

function DisableBlink(){

	RandomBlinking = false;
}

function DisableRandomFace(){

	RandomFace = false;
}

function StatusBlink( M : boolean){

	RandomBlinking = M;
}

function StatusRandomFace( M : boolean){

	RandomFace = M;
}

function ChooseMorphNumber(MorphNumberA : int){
	MorphNumber = MorphNumberA;
	skinnedMeshRenderer.SetBlendShapeWeight (MorphNumber, MorphAmount);
}

function ChooseMorphAmount(MorphAmountA : float){
	MorphAmount = MorphAmountA;
	skinnedMeshRenderer.SetBlendShapeWeight (MorphNumber, MorphAmount);
}



 #pragma strict

var DialogueScript : GameObject;
private var freqData: float[];
private var nSamples: int = 1024;
private var fMax = 24000;
private var talkingnow = false;
var volume = 40;
var frqLow = 200;
var frqHigh = 800;

var SpectrumVoice : float;
var DATAREAD : float;
//var TypeOfFaceposer : hahahah;

enum hahahah{
UseRokiahiFaceposer,
UseGenericFaceposer
}
     
function BandVol(fLow:float, fHigh:float): float {
    
    fLow = Mathf.Clamp(fLow, 20, fMax); // limit low...
    fHigh = Mathf.Clamp(fHigh, fLow, fMax); // and high frequencies
    GetComponent.<AudioSource>().GetSpectrumData(freqData, 0, FFTWindow.BlackmanHarris); 
    var n1: int = Mathf.Floor(fLow * nSamples / fMax);
    var n2: int = Mathf.Floor(fHigh * nSamples / fMax);
    var sum: float = 0;
    // average the volumes of frequencies fLow to fHigh
    for (var i=n1; i<=n2; i++){
    sum += freqData[i];
    }
    
    SpectrumVoice = sum * (n2 - n1 + 1);
    return sum * (n2 - n1 + 1);
}

function Start(){

freqData = new float[nSamples];

} 
       
function Update() { 

	if(DialogueScript){

		var DATAREADA = Mathf.Clamp ((BandVol(frqLow,frqHigh) * volume), 0, 100);
		DATAREAD = Mathf.Lerp(0, SpectrumVoice, Time.time * 0.1);

		DialogueScript.SendMessage("FaceTalking", DATAREAD, SendMessageOptions.DontRequireReceiver);
		
		/*
		if(TypeOfFaceposer == hahahah.UseRokiahiFaceposer){
			DialogueScript.GetComponent(RokiahiFaceposer).FaceTalking(DATAREAD);
		}

		if(TypeOfFaceposer == hahahah.UseGenericFaceposer){
			DialogueScript.GetComponent(GenericFaceposer).FaceTalking(DATAREAD);
		}
		*/
	}
}

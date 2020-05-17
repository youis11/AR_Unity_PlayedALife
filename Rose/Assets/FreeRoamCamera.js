#pragma strict

public var sensitivityX : float = 8F;
public var sensitivityY : float = 8F;

var mHdg : float = 0F;
var mPitch : float = 0F;

function Awake()
{
mPitch = transform.eulerAngles.x;
mHdg = transform.eulerAngles.y;
}

function Update()
{

 var deltaX : float = Input.GetAxis("Mouse X") * sensitivityX;
 var deltaY : float = Input.GetAxis("Mouse Y") * sensitivityY;
 var deltaHor : float = Input.GetAxis("HorizontalKeyboard") * 0.2;
 var deltaVer : float = Input.GetAxis("VerticalKeyboard") * 0.2;


 if (Input.GetMouseButton(1))
 {
     ChangeHeading(deltaX);
     ChangePitch(-deltaY);
 }

  Strafe(deltaHor);
  MoveForwards(deltaVer);
}

function MoveForwards(aVal : float)
{
 var fwd : Vector3 = transform.forward;
 //fwd.y = 0;
 fwd.Normalize();
 transform.position += aVal * fwd;
}

function Strafe(aVal : float)
{
 transform.position += aVal * transform.right;
}

function ChangeHeading(aVal : float)
{
 mHdg += aVal;
 WrapAngle(mHdg);
 transform.localEulerAngles = Vector3(mPitch, mHdg, 0);
}

function ChangePitch(aVal : float)
{
 mPitch += aVal;
 WrapAngle(mPitch);
 transform.localEulerAngles = Vector3(mPitch, mHdg, 0);
}

function WrapAngle(angle : float)
{
 if (angle < -360F)
     angle += 360F;
 if (angle > 360F)
     angle -= 360F;
}
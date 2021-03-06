// uScript Action Node
// (C) 2012 hyenApp LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Vectors")]

[NodeCopyright("Copyright 2012 by hyenApp LLC")]
[NodeToolTip( "Multiplies two Vector2 variables together and returns the result.")]
[NodeAuthor("hyenApp LLC", "http://www.hyenapp.com")]
[NodeHelp("")]

[FriendlyName("Multiply Vector2", "Multiplies Vector2 variables together and returns the result. \n\n[ A + B ] \n\nIf more than one variable is connected to A, they will be multiplied together before being multiplied to B. \n\nIf more than one variable is connected to B, they will be multiplied together before being multiplied to A.")]
public class hyenApp_MultiplyVector2 : uScriptLogic {
	
	public bool Out { get { return true; } }

	public void In(
		[FriendlyName("A", "The first variable or variable list.")] Vector2[] A,
		[FriendlyName("B", "The second variable or variable list.")] Vector2[] B,
		[FriendlyName("Result", "The Vector3 result of the operation.")] out Vector2 Result
	) {
		Vector2 a = A[0];
		Vector2 b = B[0];

		for ( int i = 1; i < A.Length; i++ ) {
			a.x = a.x * A[i].x;
			a.y = a.y * A[i].y;
		}

		for ( int i = 1; i < B.Length; i++ ) {
			b.x = b.x * B[i].x;
			b.y = b.y * B[i].y;
		}

		Result.x = a.x * b.x;
		Result.y = a.y * b.y;

   }
	
}

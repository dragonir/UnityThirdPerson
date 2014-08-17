// uScript Action Node
// (C) 2012 hyenApp LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Math/Curves")]

[NodeCopyright("Copyright 2012 by hyenApp LLC")]
[NodeToolTip("Calculates a Vector2 point along Bezier curve.")]
[NodeAuthor("hyenApp LLC", "http://www.hyenapp.com")]
[NodeHelp("")]

[FriendlyName("Bezier Point Vector2", "Calculates a Vector2 point along Bezier curve.")]
public class hyenApp_BezierPointVector2 : uScriptLogic {

	public bool Out { get { return true; } }

	public void In(
		[FriendlyName("Start Point", "first term")] Vector2 p1,
		[FriendlyName("Start Curve", "second term")] Vector2 p2,
		[FriendlyName("End Curve", "third term")] Vector2 p3,
		[FriendlyName("End Point", "fourth term")] Vector2 p4,
		[FriendlyName("Time", "Time is clamped between [0...1]. When Time = 0 returns Start Point. When Time = 1 returns End Point. When Time = 0.5 returns the average along the Bezier curve.")] float t,
		[FriendlyName("Point", "")] out Vector2 p
	) {
		t = Mathf.Clamp(t, 0, 1);
		float u = 1 - t;
		float tt = t * t;
		float uu = u * u;
		float uuu = uu * u;
		float ttt = tt * t;
		
		p = uuu * p1;
		p += 3 * uu * t * p2;
		p += 3 * u * tt * p3;
		p += ttt * p4;
		
	}
	
}

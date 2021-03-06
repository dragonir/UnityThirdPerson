// uScript Action Node
// (C) 2011 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Gets the current gravity as a Vector3.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide#Get_Gravity")]

[FriendlyName("Get Gravity", "Gets the current gravity as a Vector3.")]
public class uScriptAct_GetGravity : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Gravity", "Returns the current gravity value.")]
      out Vector3 Gravity
      )
   {
		 Gravity = Physics.gravity;
      
   }
}
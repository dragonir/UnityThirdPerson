// uScript Action Node
// (C) 2014 Detox Studios LLC

using UnityEngine;
using System.Collections;

[NodePath("Actions/Physics")]

[NodeCopyright("Copyright 2014 by Detox Studios LLC")]
[NodeToolTip("Applies an Add Force at the specified location for the Target GameObject.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Add Force At Position", "Applies an Add Force at the specified location for the Target GameObject. Target must have a rigidbody component in order to recieve a force.")]
public class uScriptAct_AddForceAtPosition : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Target", "GameObject to apply the force to.")]
      GameObject Target,
      
      [FriendlyName("Force", "The force to apply to the Target. The force is a Vector3, so it defines both the direction and magnitude of the force.")]
      Vector3 Force,

      [FriendlyName("Position", "The location of the Force as a Vector3.")]
      Vector3 ForcePosition,
      
      [FriendlyName("Scale", "A scale to multiply to the force (force x scale).")]
      [DefaultValue(0f), SocketState(false, false)]
      float Scale,
      
      [FriendlyName("Use ForceMode", "The force being applied will use the object's mass.")]
      [SocketState(false, false)]
      bool UseForceMode,
      
      [FriendlyName("ForceMode Type", "Specifies the ForceMode to use if Use ForceMode is set to true.")]
      [SocketState(false, false)]
      ForceMode ForceModeType
      )
   {
		if  ( null != Target.rigidbody )
		{
         if (Scale != 0) { Force = Force * Scale; }

			if ( UseForceMode )
			{
				Target.rigidbody.AddForceAtPosition(Force, ForcePosition, ForceModeType);
			}
			else
			{
            Target.rigidbody.AddForceAtPosition(Force, ForcePosition);
			}
		}
		else
		{
         uScriptDebug.Log("(Node - Add Force At Position) The specified Target GameObject does not have a rigidbody component, so no force could be added.", uScriptDebug.Type.Warning);
		}
		
      
   }
}
// uScript Action Node
// (C) 2011 Detox Studios LLC

#if (UNITY_FLASH)

   // This node is not supported on Flash at this time. This compiler directive is needed for the project to compile for these devices without error.

#else

using UnityEngine;
using System.Collections;
using System.Text;
using System.Security.Cryptography;

[NodePath("Actions/Security")]

[NodeCopyright("Copyright 2011 by Detox Studios LLC")]
[NodeToolTip("Generates an MD5 hash string from a key.")]
[NodeAuthor("Detox Studios LLC", "http://www.detoxstudios.com")]
[NodeHelp("http://www.uscript.net/docs/index.php?title=Node_Reference_Guide")]

[FriendlyName("Generate MD5 Hash", "Generates an MD5 hash string from a key.")]
public class uScriptAct_GenerateMD5Hash : uScriptLogic
{
   public bool Out { get { return true; } }

   public void In(
      [FriendlyName("Key", "The string to be used to generate the hash from.")]
      string Key,

      [FriendlyName("MD5 Hash", "The MD5 Hash generated by the Key.")]
      out string Hash
      )
   {
      if (Key != "")
      {
         UTF8Encoding ue = new UTF8Encoding();
         byte[] bytes = ue.GetBytes(Key);

         // encrypt bytes
         MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
         byte[] hashBytes = md5.ComputeHash(bytes);

         // Convert the encrypted bytes back to a string (base 16)
         string tmpHash = "";

         for (int i = 0; i < hashBytes.Length; i++)
         {
            tmpHash += System.Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
         }

         Hash = tmpHash.PadLeft(32, '0');
      }
      else
      {
         uScriptDebug.Log("[Generate MD5 Hash] The Key provided was empty, returning an empty string for the MD5 Hash.", uScriptDebug.Type.Warning);
         Hash = "";
      }

   }
}

#endif
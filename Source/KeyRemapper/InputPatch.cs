
using HarmonyLib;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace KeyRemapper
{
    [HarmonyPatch]
    public static class InputPatches
    {
        [HarmonyPatch(typeof(Input), nameof(Input.GetAxisRaw))]
        [HarmonyPrefix]
        public static bool GetAxisRaw_Prefix(string axisName, ref float __result)
        {
            if (axisName == "Horizontal")
            {
                float value = 0f;
                if (Input.GetKey(Plugin.KeyMoveRight_Primary.Value) || Input.GetKey(Plugin.KeyMoveRight_Secondary.Value))
                    value += 1f;
                if (Input.GetKey(Plugin.KeyMoveLeft_Primary.Value) || Input.GetKey(Plugin.KeyMoveLeft_Secondary.Value))
                    value -= 1f;
                __result = value;
                return false;
            }
            if (axisName == "Vertical")
            {
                float value = 0f;
                if (Input.GetKey(Plugin.KeyCrouch_Primary.Value) || Input.GetKey(Plugin.KeyCrouch_Secondary.Value))
                    value -= 1f;
                __result = value;
                return false;
            }
            return true;
        }

        [HarmonyPatch(typeof(Input), nameof(Input.GetButtonDown))]
        [HarmonyPrefix]
        public static bool GetButtonDown_Prefix(string buttonName, ref bool __result)
        {
            if (buttonName == "Jump")
            {
                __result = Input.GetKeyDown(Plugin.KeyJump_Primary.Value) || Input.GetKeyDown(Plugin.KeyJump_Secondary.Value);
                return false;
            }
            if (buttonName == "Fire1")
            {
                __result = Input.GetKeyDown(Plugin.KeyAttack_Primary.Value) || Input.GetKeyDown(Plugin.KeyAttack_Secondary.Value);
                return false;
            }
            return true;
        }
    }
}

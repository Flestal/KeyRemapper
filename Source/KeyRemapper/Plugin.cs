using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;
using DGENT.DestinyStone;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System;
using System.Diagnostics;
using System.Linq;

namespace KeyRemapper
{
    [BepInPlugin("Flestal.KeyRemapper", "KeyRemapper", "1.0.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigEntry<KeyCode> KeyMoveLeft_Primary;
        public static ConfigEntry<KeyCode> KeyMoveLeft_Secondary;
        public static ConfigEntry<KeyCode> KeyMoveRight_Primary;
        public static ConfigEntry<KeyCode> KeyMoveRight_Secondary;
        public static ConfigEntry<KeyCode> KeyCrouch_Primary;
        public static ConfigEntry<KeyCode> KeyCrouch_Secondary;
        public static ConfigEntry<KeyCode> KeyJump_Primary;
        public static ConfigEntry<KeyCode> KeyJump_Secondary;
        public static ConfigEntry<KeyCode> KeyAttack_Primary;
        public static ConfigEntry<KeyCode> KeyAttack_Secondary;

        private void Awake()
        {
            KeyMoveLeft_Primary = Config.Bind("Movement", "MoveLeft_Primary", KeyCode.A, "왼쪽 이동 (기본)");
            KeyMoveLeft_Secondary = Config.Bind("Movement", "MoveLeft_Secondary", KeyCode.LeftArrow, "왼쪽 이동 (보조)");

            KeyMoveRight_Primary = Config.Bind("Movement", "MoveRight_Primary", KeyCode.D, "오른쪽 이동 (기본)");
            KeyMoveRight_Secondary = Config.Bind("Movement", "MoveRight_Secondary", KeyCode.RightArrow, "오른쪽 이동 (보조)");

            KeyCrouch_Primary = Config.Bind("Movement", "Crouch_Primary", KeyCode.S, "앉기 (기본)");
            KeyCrouch_Secondary = Config.Bind("Movement", "Crouch_Secondary", KeyCode.DownArrow, "앉기 (보조)");

            KeyJump_Primary = Config.Bind("Actions", "Jump_Primary", KeyCode.W, "점프 (기본)");
            KeyJump_Secondary = Config.Bind("Actions", "Jump_Secondary", KeyCode.UpArrow, "점프 (보조)");

            KeyAttack_Primary = Config.Bind("Actions", "Attack_Primary", KeyCode.Mouse0, "기본 공격 (기본)");
            KeyAttack_Secondary = Config.Bind("Actions", "Attack_Secondary", KeyCode.LeftControl, "기본 공격 (보조)");

            Harmony.CreateAndPatchAll(typeof(InputPatches));
            Logger.LogInfo("Key Remapper (Final) has been loaded!");
        }
    }

}

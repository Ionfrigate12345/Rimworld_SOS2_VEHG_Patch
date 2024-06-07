﻿using HarmonyLib;
using Verse;

namespace SOS2VEHelixienPatch
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatches
    {
        private static Harmony _harmonyInstance;
        public static Harmony HarmonyInstance { get { return _harmonyInstance; } }

        static HarmonyPatches()
        {
            _harmonyInstance = new Harmony("com.ionfrigate12345.sos2vehelixienpatch");
            _harmonyInstance.PatchAll();
        }
    }
}
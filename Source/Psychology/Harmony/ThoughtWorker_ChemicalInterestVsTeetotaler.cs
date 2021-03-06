﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;
using Harmony;

namespace Psychology.Harmony
{
    [HarmonyPatch(typeof(ThoughtWorker_ChemicalInterestVsTeetotaler), "CurrentSocialStateInternal")]
    public static class ThoughtWorker_ChemicalInterestVsTeetotalerPatch
    {
        [LogPerformance]
        [HarmonyPostfix]
        public static void Disable(ref ThoughtState __result, Pawn p, Pawn other)
        {
            if (__result.StageIndex != ThoughtState.Inactive.StageIndex)
            {
                if (PsycheHelper.PsychologyEnabled(p) && PsycheHelper.PsychologyEnabled(other))
                {
                    __result = false;
                }
            }
        }
    }
}

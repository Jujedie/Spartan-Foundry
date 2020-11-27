using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using HarmonyLib;
using Verse;
using RimWorld;
using RimWorld.Planet;

namespace AchievementsExpanded
{
    public class SpartanFoundry_QuestManager_Notify_ThingsProduced_Patch
    {

        public static void CheckItemCraftedMultiple(Pawn worker, List<Thing> things)
        {
            if (things != null && worker != null)
            {
                foreach (var card in AchievementPointManager.GetCards<ItemCraftTrackerMultipleSpartanFoundry>())
                {

                    foreach (Thing thing in things)
                    {
                        if (thing != null && card != null)
                        {
                            if ((card.tracker as ItemCraftTrackerMultipleSpartanFoundry).Trigger(thing))
                            {
                                card.UnlockCard();
                            }
                        }
                    }
                }
            }

        }
    }
}

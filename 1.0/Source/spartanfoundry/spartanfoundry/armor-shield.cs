using RimWorld;
using System.Collections;
using System.Collections.Generic;
using Verse;

namespace PowerArmorShield
{
    public class AdvShieldAlert : Alert_ShieldUserHasRangedWeapon
    {
        public virtual AlertReport GetReport()
        {
            using (IEnumerator<Pawn> enumerator = PawnsFinder.get_AllMaps_FreeColonistsSpawned().GetEnumerator())
            {
                while (((IEnumerator)enumerator).MoveNext())
                {
                    Pawn current = enumerator.Current;
                    if (((Pawn_EquipmentTracker)current.equipment).get_Primary() != null && ((ThingDef)((Thing)((Pawn_EquipmentTracker)current.equipment).get_Primary()).def).get_IsRangedWeapon())
                    {
                        List<Apparel> wornApparel = ((Pawn_ApparelTracker)current.apparel).get_WornApparel();
                        for (int index = 0; index < wornApparel.Count; ++index)
                        {
                            if (wornApparel[index] is ShieldBelt && !(wornApparel[index] is ShieldMkII))
                                return AlertReport.op_Implicit((Thing)current);
                        }
                    }
                }
            }
            return AlertReport.op_Implicit(false);
        }



using RimWorld;
using Verse;

public class ShieldMkII : ShieldBelt
{
    public override bool AllowVerbCast(IntVec3 root, Map map, LocalTargetInfo targ, Verb v)
    {
        return true;
    }


}

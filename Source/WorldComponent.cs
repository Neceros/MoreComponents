using RimWorld.Planet;
using System;
using Verse;

namespace MoreComps
{
  internal class MoreCompsWorldComp : WorldComponent
  {
    public MoreCompsWorldComp(World world)
      : base(world)
    {}

    public override void FinalizeInit()
    {
      base.FinalizeInit();

      MoreCompsModSettings.OriginalCompsAmount = DefDatabase<ThingDef>.GetNamed("MineableComponentsIndustrial").building.mineableYield;
      ApplyAllChanges();
    }

    public void ApplyAllChanges()
    {
      DefDatabase<ThingDef>.GetNamed("MineableComponentsIndustrial").building.mineableYield = (int)Math.Floor(MoreCompsModSettings.OriginalCompsAmount * MoreCompsModSettings.multiplyMC);
    }
  }
}

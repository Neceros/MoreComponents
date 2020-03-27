using System;
using UnityEngine;
using Verse;

namespace MoreComps
{
  public class MoreCompsModSettings : ModSettings
  {
    public static float MultiplyMineableComps => multiplyMC;
    public static int OriginalCompsAmount;

    // Internal reference only. DO NOT call outside of this class.
    public static float multiplyMC = 2.5f;
    // End warning

    public override void ExposeData()
    {
      base.ExposeData();
      Scribe_Values.Look(ref multiplyMC, "MCAmountToMultiplyComps");
    }
  }

  public class MoreCompsMod : Mod
  {
    MoreCompsModSettings settings;
    public MoreCompsMod(ModContentPack con) : base(con)
    {
      this.settings = GetSettings<MoreCompsModSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
      Listing_Standard listing = new Listing_Standard();
      listing.Begin(inRect);
      listing.Label("MCRestartWarning".Translate());
      listing.Gap(24);
      listing.Label("MCMultiplyAmountLabel".Translate() + ": [" + MoreCompsModSettings.OriginalCompsAmount.ToString() + " x " + (MoreCompsModSettings.multiplyMC * 100).ToString() + "%] = " + (MoreCompsModSettings.OriginalCompsAmount * MoreCompsModSettings.multiplyMC).ToString() + " " + "MCMultiplyAmountEndLabel".Translate());
      MoreCompsModSettings.multiplyMC = RoundToNearestHalf(listing.Slider(MoreCompsModSettings.multiplyMC, 0f, 20f));
      if(MoreCompsModSettings.OriginalCompsAmount * MoreCompsModSettings.multiplyMC >= 75)
        listing.Label("MCStackWarning".Translate());
      
      listing.End();
      base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
      return "MCTitle".Translate();
    }

    private float RoundToNearestHalf(float val)
    { 
      return (float)Math.Round(val * 2, MidpointRounding.AwayFromZero) / 2;
    }
  }
}

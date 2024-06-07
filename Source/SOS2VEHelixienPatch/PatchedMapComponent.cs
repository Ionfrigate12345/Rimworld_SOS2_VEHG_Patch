using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace SOS2VEHelixienPatch
{
    internal class PatchedMapComponent : MapComponent
    {
        public PatchedMapComponent(Map map) : base(map)
        {
        }
        
        public override void MapGenerated()
        {
            base.MapGenerated();

            var allMaps = Find.Maps.ToList();

            foreach (var map in allMaps)
            {
                if (HarmonyUtils.IsSOS2SpaceMap(map))
                {
                    var thingsGasGeyserList = map.listerThings.AllThings
                        .Where(t => t.ThingID.Contains("VHGE_GasGeyser"))
                        .ToList();
                    Log.Warning("SOS2 space map detected. Deleting Vanilla Helixien Gas Expanded Geysers. Totally to be removed:" + thingsGasGeyserList.Count);
                    foreach (var thingGasGeyser in thingsGasGeyserList)
                    {
                        Log.Warning("Removing Geyser " + thingGasGeyser.ThingID);
                        thingGasGeyser.DeSpawn();
                    }
                }
            }
        }
    }
}

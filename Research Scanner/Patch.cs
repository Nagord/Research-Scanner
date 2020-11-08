using CodeStage.AntiCheat.ObscuredTypes;
using HarmonyLib;
using PulsarPluginLoader.Utilities;
using System.Collections.Generic;

namespace Research_Scanner
{
    [HarmonyPatch(typeof(PLShipInfoBase), "NetworkedStartEnhancedEMScan")]
    class Patch
    {
        static void Postfix(PLShipInfoBase __instance)
        {
            if (__instance.GetIsPlayerShip() && PhotonNetwork.isMasterClient)
            {
                int foundresearchcount = 0;
                foreach (KeyValuePair<ObscuredInt, ObscuredBool> MyResearch in PLEncounterManager.Instance.GetCurrentPersistantEncounterInstance().MyPersistantData.ProbePickupPersistantData)
                {
                    if (!MyResearch.Value)
                    {
                        //Logger.Info("found research");
                        foundresearchcount++;
                    }
                }
                if (foundresearchcount > 1)
                {
                    Messaging.Notification("High anomalous signature detected.", PhotonTargets.All);
                }
                else if (foundresearchcount > 0)
                {
                    Messaging.Notification("Low anomalous signature detected.", PhotonTargets.All);
                }
            }
        }
    }
}
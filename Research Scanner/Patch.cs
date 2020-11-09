using CodeStage.AntiCheat.ObscuredTypes;
using HarmonyLib;
using PulsarPluginLoader.Utilities;
using System.Collections.Generic;

namespace Enhanced_EM_Scanner
{
    [HarmonyPatch(typeof(PLShipInfoBase), "NetworkedStartEnhancedEMScan")]
    class Patch
    {
        static void Postfix(PLShipInfoBase __instance)
        {
            if (__instance.GetIsPlayerShip() && PhotonNetwork.isMasterClient)
            {
                int foundscrapcount = 0;
                foreach (PLSpaceScrap scrapObject in UnityEngine.Object.FindObjectsOfType(typeof(PLSpaceScrap)))
                {
                    if(scrapObject != null && !scrapObject.Collected)
                    {
                        //__instance.MySensorObjectShip.GetDetectionSignal
                        //float sqrMagnitude = (__instance.ExteriorTransformCached.position - scrapObject.transform.position).sqrMagnitude;
                        foundscrapcount++;
                    }
                }
                int foundresearchcount = 0;
                foreach (KeyValuePair<ObscuredInt, ObscuredBool> MyResearch in PLEncounterManager.Instance.GetCurrentPersistantEncounterInstance().MyPersistantData.ProbePickupPersistantData)
                {
                    if (!MyResearch.Value)
                    {
                        foundresearchcount++;
                    }
                }
                if (foundresearchcount > 1)
                {
                    Messaging.Notification("Anomaly detected: High Signature", PhotonTargets.All);
                }
                else if (foundresearchcount > 0)
                {
                    Messaging.Notification("Anomaly detected: Low Signature", PhotonTargets.All);
                }
                if(foundscrapcount > 2)
                {
                    Messaging.Notification($"Debris detected: High Signature", PhotonTargets.All);
                }
                else if(foundscrapcount > 0)
                {
                    Messaging.Notification($"Debris detected: Low Signature", PhotonTargets.All);
                }
            }
        }
    }
}
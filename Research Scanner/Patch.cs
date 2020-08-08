using CodeStage.AntiCheat.ObscuredTypes;
using HarmonyLib;
using PulsarPluginLoader.Utilities;
using System.Collections.Generic;

namespace Research_Scanner
{
    [HarmonyPatch(typeof(PLServer), "NetworkedStartEnhancedEMScan")]
    class Patch
    {
        static void Postfix(ref int shipID)
        {
            if (shipID == PLEncounterManager.Instance.PlayerShip.ShipID && PhotonNetwork.isMasterClient)
            {
                bool hasfoundresearch = false;
                foreach (KeyValuePair<ObscuredInt, ObscuredBool> MyResearch in PLEncounterManager.Instance.GetCurrentPersistantEncounterInstance().MyPersistantData.ProbePickupPersistantData)
                {
                    if (MyResearch.Value)
                    {
                        hasfoundresearch = true;
                        break;
                    }
                }
                if (hasfoundresearch)
                {
                    Messaging.Notification("Scanner has found research!", PhotonTargets.All);
                }
            }
        }
    }
}
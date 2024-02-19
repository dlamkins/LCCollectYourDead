using GameNetcodeStuff;
using HarmonyLib;

namespace LCCollectYourDead.Patches {
    [HarmonyPatch(typeof(ShipTeleporter))]
    internal class ShipTeleporterPatch {

        [HarmonyPatch("beamUpPlayer")]
        [HarmonyPostfix]
        static void CashEmIn(ShipTeleporter __instance) {
            PlayerControllerB beamedUpPlayer = StartOfRound.Instance.mapScreen.targetedPlayer;

            if (beamedUpPlayer?.deadBody != null) {
                var scrapBody = beamedUpPlayer.deadBody.grabBodyObject;

                if (scrapBody != null) {
                    RoundManager.Instance.CollectNewScrapForThisRound(scrapBody);
                }
            }
        }

    }
}

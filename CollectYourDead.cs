using BepInEx.Logging;
using BepInEx;
using HarmonyLib;

namespace LCCollectYourDead {
    [BepInPlugin(MOD_NAMESPACE, MOD_NAME, MOD_VERSION)]
    public class CollectYourDead : BaseUnityPlugin {

        private const string MOD_NAMESPACE = "freesnow.collectyourdead";
        private const string MOD_NAME = "Collect Your Dead";
        private const string MOD_VERSION = "1.0.0";

        private readonly Harmony _harmony = new Harmony(MOD_NAMESPACE);

        public ManualLogSource Logger { get; private set; }

        public static CollectYourDead Instance { get; private set; }

        void Awake() {
            if (Instance == null) {
                Instance = this;
            }

            this.Logger = BepInEx.Logging.Logger.CreateLogSource(MOD_NAMESPACE);

            this.Logger.LogInfo($"{MOD_NAME} v{MOD_VERSION} is now running.");

            _harmony.PatchAll();
        }

    }
}

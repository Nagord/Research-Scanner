using PulsarModLoader;

namespace Enhanced_EM_Scanner
{
    public class Mod : PulsarMod
    {
        public override string Version => "1.0.1";

        public override string Author => "Dragon";

        public override string Name => "Enhanced EM Scanner";

        public override int MPFunctionality => (int)MPFunction.HostOnly;

        public override string ShortDescription => "Enhances EM Scanner capabilities to include research and space scrap detection";

        public override string LongDescription => "Provides a notification for space research and space scrap after the completion of an EM scan. Anomaly Detected: {Low/High} signature. Debris Detected: {Low/High} signature";

        public override string HarmonyIdentifier()
        {
            return "Dragon.EnhancedEMScanner";
        }
    }
}

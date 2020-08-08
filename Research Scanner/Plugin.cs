using PulsarPluginLoader;

namespace Research_Scanner
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "0.0.1";

        public override string Author => "Dragon";

        public override string Name => "ResearchScanner";

        public override int MPFunctionality => (int)MPFunction.HostOnly;

        public override string HarmonyIdentifier()
        {
            return "Dragon.ResearchScanner";
        }
    }
}

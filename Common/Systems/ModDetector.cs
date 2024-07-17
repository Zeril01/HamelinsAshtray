namespace HamelinsAshtray.Common.Systems
{
    internal class ModDetector : ModSystem
    {
        public static bool calamityIsEnabled;

        public override void PostSetupContent() => calamityIsEnabled = ModLoader.TryGetMod("CalamityMod", out _);
    }
}

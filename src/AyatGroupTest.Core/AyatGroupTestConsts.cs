using AyatGroupTest.Debugging;

namespace AyatGroupTest
{
    public class AyatGroupTestConsts
    {
        public const string LocalizationSourceName = "AyatGroupTest";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "14c6c39c4ddf48ed927d7942cbf20f58";
    }
}

using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AyatGroupTest.Localization
{
    public static class AyatGroupTestLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(AyatGroupTestConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(AyatGroupTestLocalizationConfigurer).GetAssembly(),
                        "AyatGroupTest.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

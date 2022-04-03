using System.Xml.Linq;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Packaging;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Infrastructure.Migrations;
using Umbraco.Cms.Infrastructure.Packaging;

namespace Qualia.Umb.PackageMigration
{
    public partial class ImportPackageXmlMigration : PackageMigrationBase
    {
        public ImportPackageXmlMigration(
            IPackagingService packagingService,
            IMediaService mediaService,
            MediaFileManager mediaFileManager,
            MediaUrlGeneratorCollection mediaUrlGenerators,
            IShortStringHelper shortStringHelper,
            IContentTypeBaseServiceProvider contentTypeBaseServiceProvider,
            IMigrationContext context)
            : base(packagingService,
                mediaService,
                mediaFileManager,
                mediaUrlGenerators,
                shortStringHelper,
                contentTypeBaseServiceProvider,
                context,
                new DefaultMigrationSettings()
                )
        { }


        protected override void Migrate()
        {
            var planType = Context.Plan.GetType();
            var resources = planType.Assembly.GetManifestResourceNames();
            var stream = planType.Assembly.GetManifestResourceStream(planType, resources[0]);
            var xmlPack = XDocument.Load(stream);
            var packageBuilder = ImportPackage.FromXmlDataManifest(xmlPack);
            packageBuilder.Do();
        }
}
}
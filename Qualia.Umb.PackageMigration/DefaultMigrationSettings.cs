namespace Qualia.Umb.PackageMigration
{
    public partial class ImportPackageXmlMigration
    {
        internal class DefaultMigrationSettings :
            Umbraco.Cms.Core.Configuration.Models.PackageMigrationSettings, 
            Microsoft.Extensions.Options.IOptions<Umbraco.Cms.Core.Configuration.Models.PackageMigrationSettings>
        {
            public Umbraco.Cms.Core.Configuration.Models.PackageMigrationSettings Value => 
                new Umbraco.Cms.Core.Configuration.Models.PackageMigrationSettings 
                { 
                    AllowComponentOverrideOfRunSchemaAndContentMigrations = true, 
                    RunSchemaAndContentMigrations = true 
                };
        }
}
}
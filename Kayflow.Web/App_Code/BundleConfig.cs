using System.Web.Optimization;
using System.Web.UI;

/// <summary>
/// Summary description for BundleConfig
/// </summary>
public class BundleConfig
{
    const string jquery_version = "2.1.4";

    public static void RegisterBundles(BundleCollection bundles)
	{
        #region -= Bundles =-
        bundles.Add(new ScriptBundle("~/bundles/DialogJs").Include(
            "~/Scripts/DialogFormSize.js",
            "~/Scripts/ModalDialogForm.js"
            ));
        bundles.Add(new ScriptBundle("~/bundles/CommonJs").Include(
            "~/Scripts/GlobalFunctions.js",
            "~/Scripts/messagesJS.js"
            ));
        bundles.Add(new ScriptBundle("~/bundles/ExtLibs").Include(
            "~/Scripts/flexmenu.min.js",
            "~/Scripts/modernizr.custom.js",
            "~/Scripts/jquery.dropdown.min.js"
            )); 
        #endregion

        ScriptManager.ScriptResourceMapping.AddDefinition("DialogJs", new ScriptResourceDefinition
        {
            Path = "~/bundles/DialogJs"
        });
        ScriptManager.ScriptResourceMapping.AddDefinition("CommonJs", new ScriptResourceDefinition
        {
            Path = "~/bundles/CommonJs"
        });
        ScriptManager.ScriptResourceMapping.AddDefinition("ExtLibs", new ScriptResourceDefinition
        {
            Path = "~/bundles/ExtLibs"
        });
        ScriptManager.ScriptResourceMapping.AddDefinition(
            "jquery",
            new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + jquery_version + ".min.js",
                DebugPath = "~/Scripts/jquery-" + jquery_version + ".js",
                CdnPath = "http://code.jquery.com/jquery-" + jquery_version + ".min.js",
                CdnDebugPath = "http://code.jquery.com/jquery-" + jquery_version + ".js",
                CdnSupportsSecureConnection = true
            });
        ScriptManager.ScriptResourceMapping.AddDefinition(
            "noty",
            new ScriptResourceDefinition
            {
                Path = "~/Scripts/noty/jquery.noty.packaged.min.js",
                DebugPath = "~/Scripts/noty/jquery.noty.packaged.js",
            });
        ScriptManager.ScriptResourceMapping.AddDefinition(
                    "tocker",
                    new ScriptResourceDefinition
                    {
                        Path = "~/Scripts/ticker/jquery.easy-ticker.js",
                        DebugPath = "~/Scripts/ticker/jquery.easy-ticker.min.js",
                    });
	}
}
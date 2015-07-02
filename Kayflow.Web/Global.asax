<%@ Application Language="C#" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="DevExpress.Utils.Localization.Internal" %>
<%@ Import Namespace="DevExpress.Web" %>
<%@ Import Namespace="DevExpress.Web.ASPxClasses.Localization" %>
<%@ Import Namespace="Framework.SqlDataAccess.Manager" %>
<%@ Import Namespace="Kayflow.Controller" %>
<%@ Import Namespace="log4net" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        Factory.AddConnection("Kayflow", System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DBConnectionString"].ToString());
        log4net.Config.XmlConfigurator.Configure();
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        ASPxWebControl.CallbackError += Application_Error;
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        var httpContext = HttpContext.Current;
        var exception = httpContext.Server.GetLastError();
        var logger = LogManager.GetLogger(GetType());
        if (exception == null)
            return;
        if (httpContext.Session != null)
        {
            httpContext.Session["LastError"] = exception;
            httpContext.Session["ErrorRequest"] = httpContext.Request;
        }
        if (exception is CustomException)
            logger.Info("Handled InfoException", exception);
        else
        {
            var errorTitle = string.Format("Unhandled Exception with request ({0});",
                                           httpContext.Request.Unvalidated.QueryString);
            logger.Error(errorTitle, exception);
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started
        ASPxUploadControlLocalizer.Activate();
    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    public class ASPxUploadControlLocalizer : ASPxperienceLocalizer
    {
        public static void Activate()
        {
            var localizer = new ASPxUploadControlLocalizer();
            var provider = new DefaultActiveLocalizerProvider<ASPxperienceStringId>(localizer);
            SetActiveLocalizerProvider(provider);
        }
        public override string GetLocalizedString(ASPxperienceStringId id)
        {
            return id == ASPxperienceStringId.UploadControl_UnspecifiedError
                       ? "The total request length may exceed the maximum allowed length."
                       : base.GetLocalizedString(id);
        }
    }
</script>

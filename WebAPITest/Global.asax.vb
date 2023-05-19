Imports System.Net.Http.Formatting
Imports System.Web.Http

Public Class WebApiApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)

        ' JSON�V���A���C�U��L���ɂ���
        GlobalConfiguration.Configuration.Formatters.Clear()
        GlobalConfiguration.Configuration.Formatters.Add(New JsonMediaTypeFormatter())

    End Sub
End Class

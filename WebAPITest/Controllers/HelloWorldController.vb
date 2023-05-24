Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Namespace Controllers
    Public Class HelloWorldController
        Inherits ApiController

        <HttpGet>
        Public Function GetMessage() As String
            Return "Hello World"
        End Function
        '/api/helloworld
        '/api/helloworld/getmessage
        'curl https://localhost:44325/api/helloworld

        <HttpGet>
        <Route("api/helloworld/Add")>
        Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
            Return a + b
        End Function
        '/api/helloworld/add?a=5&b=3

        <HttpGet>
        <Route("api/helloworld/GetMessage2")>
        Public Function GetMessage2(ByVal text As String) As String
            Return "Hello Word " & text
        End Function
        '/api/helloworld/GetMessage2?text=aaa

        <HttpGet>
        <Route("api/helloworld/Tuple")>
        Public Function Tuple(ByVal text As String) As (Integer, String)
            Dim number As Integer = 1
            Dim message As String = "bbb " & text
            Return (number, message)
        End Function
        '/api/helloworld/Tuple?text=aaa

        Public Class MultipleResultsModel
            Public Property Result1 As String
            Public Property Result2 As String
            Public Property Result3 As String
        End Class

        <HttpGet>
        <Route("api/helloworld/CustomModel")>
        Public Function GetCustomModel() As IHttpActionResult
            Dim result1 As String = "Result 1"
            Dim result2 As String = "Result 2"
            Dim result3 As String = "Result 3"

            Dim multipleResults = New MultipleResultsModel With {
                .Result1 = result1,
                .Result2 = result2,
                .Result3 = result3
            }
            Return Ok(multipleResults)
        End Function
        '/api/helloworld/CUstomModel

        <HttpGet>
        <Route("api/helloworld/json")>
        Public Function GetJson() As IHttpActionResult
            Dim data = New With {
                .Name = "John Doe",
                .Age = 30
            }
            Return Json(data)
        End Function
        '/api/helloworld/json

        <HttpPost>
        <Route("api/helloworld/savetext")>
        Public Sub SaveText(<FromBody> ByVal text As String)

            '接続先情報を取得
            Dim devDataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
            Dim devInitialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
            Dim devUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
            Dim devPassword As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")
            Dim devTimeout As String = System.Environment.GetEnvironmentVariable("DEV_TIMEOUT")

            Dim connectionString As String = ""

            '接続先情報を構築
            connectionString &= String.Format("Data Source = {0};", devDataSource)
            connectionString &= String.Format("Initial Catalog = {0};", devInitialCatalog)
            connectionString &= String.Format("User ID = {0};", devUserID)
            connectionString &= String.Format("Password = {0};", devPassword)
            connectionString &= String.Format("Connect Timeout = {0};", devTimeout)

            Dim connection As SqlConnection = New SqlConnection(connectionString)

            ' データベースに接続
            connection.Open()

            ' SQLクエリの作成
            Dim query As String = "INSERT INTO dt_text (text) VALUES (@Text)"
            Dim command As SqlCommand = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Text", text)

            ' クエリを実行
            command.ExecuteNonQuery()

            ' データベース接続を閉じる
            connection.Close()
        End Sub
        'curl -X POST -H "Content-Type: application/json" -d "\"your_text_here\"" https://localhost:44325/api/helloworld/savetext


        <HttpDelete>
        <Route("api/helloworld/deletetext/{text}")>
        Public Function DeleteText(ByVal text As String) As IHttpActionResult
            ' テキストの削除処理を実装する
            '接続先情報を取得
            Dim devDataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
            Dim devInitialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
            Dim devUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
            Dim devPassword As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")
            Dim devTimeout As String = System.Environment.GetEnvironmentVariable("DEV_TIMEOUT")

            Dim connectionString As String = ""

            '接続先情報を構築
            connectionString &= String.Format("Data Source = {0};", devDataSource)
            connectionString &= String.Format("Initial Catalog = {0};", devInitialCatalog)
            connectionString &= String.Format("User ID = {0};", devUserID)
            connectionString &= String.Format("Password = {0};", devPassword)
            connectionString &= String.Format("Connect Timeout = {0};", devTimeout)

            Dim connection As SqlConnection = New SqlConnection(connectionString)

            ' データベースに接続
            connection.Open()

            ' SQLクエリの作成
            Dim query As String = "DELETE FROM dt_text WHERE text = @Text"
            Dim command As SqlCommand = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Text", text)

            ' クエリを実行
            command.ExecuteNonQuery()

            ' データベース接続を閉じる
            connection.Close()

            Dim response As New HttpResponseMessage(HttpStatusCode.NoContent)
            Return Json(response.StatusCode)

        End Function
        'curl -X DELETE https://localhost:44325/api/helloworld/deletetext/text

    End Class
End Namespace
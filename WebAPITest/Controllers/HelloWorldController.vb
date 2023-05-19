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


        '<HttpPost>
        'Public Sub SaveText(<FromBody> ByVal text As String)

        '    '接続先情報を取得
        '    Dim devDataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
        '    Dim devInitialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
        '    Dim devUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
        '    Dim devPassword As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")
        '    Dim devTimeout As String = System.Environment.GetEnvironmentVariable("DEV_TIMEOUT")

        '    Dim connectionString As String = ""

        '    '接続先情報を構築
        '    connectionString &= String.Format("Data Source = {0};", devDataSource)
        '    connectionString &= String.Format("Initial Catalog = {0};", devInitialCatalog)
        '    connectionString &= String.Format("User ID = {0};", devUserID)
        '    connectionString &= String.Format("Password = {0};", devPassword)
        '    connectionString &= String.Format("Connect Timeout = {0};", devTimeout)

        '    Dim connection As SqlConnection = New SqlConnection(connectionString)

        '    ' データベースに接続
        '    connection.Open()

        '    ' SQLクエリの作成
        '    Dim query As String = "INSERT INTO dt_test (text) VALUES (@Text)"
        '    Dim command As SqlCommand = New SqlCommand(query, connection)
        '    command.Parameters.AddWithValue("@Text", text)

        '    ' クエリを実行
        '    command.ExecuteNonQuery()

        '    ' データベース接続を閉じる
        '    connection.Close()
        'End Sub


        '<HttpPost>
        'Public Sub DeleteText(ByVal text As String)
        '    ' テキストの削除処理を実装する
        '    '接続先情報を取得
        '    Dim devDataSource As String = System.Environment.GetEnvironmentVariable("DEV_DATA_SOURCE")
        '    Dim devInitialCatalog As String = System.Environment.GetEnvironmentVariable("DEV_INITIAL_CATALOG")
        '    Dim devUserID As String = System.Environment.GetEnvironmentVariable("DEV_USER")
        '    Dim devPassword As String = System.Environment.GetEnvironmentVariable("DEV_PASSWORD")
        '    Dim devTimeout As String = System.Environment.GetEnvironmentVariable("DEV_TIMEOUT")

        '    Dim connectionString As String = ""

        '    '接続先情報を構築
        '    connectionString &= String.Format("Data Source = {0};", devDataSource)
        '    connectionString &= String.Format("Initial Catalog = {0};", devInitialCatalog)
        '    connectionString &= String.Format("User ID = {0};", devUserID)
        '    connectionString &= String.Format("Password = {0};", devPassword)
        '    connectionString &= String.Format("Connect Timeout = {0};", devTimeout)

        '    Dim connection As SqlConnection = New SqlConnection(connectionString)

        '    ' データベースに接続
        '    connection.Open()

        '    ' SQLクエリの作成
        '    Dim query As String = "DELETE FROM dt_test WHERE text = @Text)"
        '    Dim command As SqlCommand = New SqlCommand(query, connection)
        '    command.Parameters.AddWithValue("@Text", text)

        '    ' クエリを実行
        '    command.ExecuteNonQuery()

        '    ' データベース接続を閉じる
        '    connection.Close()

        '    ' ...
        '    ' 削除が成功した場合はNoContentステータスコード(204)を返す
        '    ' 削除が失敗した場合はInternalServerErrorステータスコード(500)を返す
        '    ' ...

        '    '' 例として、NoContentステータスコードを返す
        '    'Dim response As New HttpResponseMessage(HttpStatusCode.NoContent)
        '    'Return response
        'End Sub

    End Class
End Namespace
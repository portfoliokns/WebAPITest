Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Net
Imports System.Net.Http
Imports System.Web.Http

Namespace Controllers
    Public Class HelloWorldController
        Inherits ApiController

        Public Function GetMessage() As String
            Return "Hello World"
        End Function

        <HttpGet>
        Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
            Return a + b
        End Function

        <HttpPost>
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
            Dim query As String = "INSERT INTO dt_test (text) VALUES (@Text)"
            Dim command As SqlCommand = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Text", text)

            ' クエリを実行
            command.ExecuteNonQuery()

            ' データベース接続を閉じる
            connection.Close()
        End Sub


        <HttpPost>
        Public Sub DeleteText(ByVal text As String)
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
            Dim query As String = "DELETE FROM dt_test WHERE text = @Text)"
            Dim command As SqlCommand = New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@Text", text)

            ' クエリを実行
            command.ExecuteNonQuery()

            ' データベース接続を閉じる
            connection.Close()

            ' ...
            ' 削除が成功した場合はNoContentステータスコード(204)を返す
            ' 削除が失敗した場合はInternalServerErrorステータスコード(500)を返す
            ' ...

            '' 例として、NoContentステータスコードを返す
            'Dim response As New HttpResponseMessage(HttpStatusCode.NoContent)
            'Return response
        End Sub

    End Class
End Namespace
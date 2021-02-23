Imports Discord
Imports Discord.Commands
Imports Discord.WebSocket
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.ComponentModel
Public Class Form1
    Dim Discord As New DiscordSocketClient
    Dim songs As String()
    Dim uss As String
    Dim idu As String
    Dim link As String
    Dim title As String
    ' The Bot Done By ALM7SHSH
    'INSTAGRAM : 2LC / اخلى ذمتى لمن بيستعمله بالحرام 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Discord.LoginAsync(TokenType.Bot, "TOKEN HERE")
            Discord.StartAsync()
            AddHandler Discord.MessageReceived, AddressOf onMessage
            AddHandler Discord.MessageReceived, AddressOf OnMessage2
        Catch ex As Exception
            MsgBox("Error : " + ex.Message)
        End Try
    End Sub
    Private Async Function OnMessage2(message As SocketUserMessage) As Task
        If message.Author.IsBot = True Then
            'ignore
        Else
            Dim msg As String = message.Content
            Dim sndr As String = message.Author.Username.ToLower
            addline(sndr + " :" + msg)
            ListBox1.Items.Add(message.Author.Username)
        End If
    End Function
    Private Delegate Sub addlog(linea As String)
    Private Sub addline(line As String)
        If ListBox1.InvokeRequired Then
            ListBox1.Invoke(New addlog(AddressOf addline), line)
            Exit Sub
        End If
        ListBox1.Items.Add(line)
    End Sub
    Private Async Function onMessage(rawmsg As SocketUserMessage) As Task
        If rawmsg.Author.IsBot = True Then
            ' ignore the comands
        Else
            Dim context As New SocketCommandContext(Discord, rawmsg)
            Dim user = TryCast(rawmsg.Author, SocketGuildUser)
            Dim channel As SocketTextChannel = Discord.GetChannel(rawmsg.Channel.Id)
            If rawmsg.Content.Contains("-help") Then
                Await rawmsg.Channel.SendMessageAsync("To Download Any Song " + vbCrLf + "Example : -d [songlink]")
            End If
            songs = rawmsg.Content.Split(" ")
            If rawmsg.Content.Contains(songs(1)) Then
                Try
                    System.Net.ServicePointManager.CheckCertificateRevocationList = False : System.Net.ServicePointManager.DefaultConnectionLimit = 300 : System.Net.ServicePointManager.UseNagleAlgorithm = False : System.Net.ServicePointManager.Expect100Continue = False : System.Net.ServicePointManager.SecurityProtocol = 3072
                    Dim Encoding As New Text.UTF8Encoding
                    Dim Bytes As Byte() = Encoding.GetBytes("q=" + songs(1) + "&vt=home")
                    Dim AJ As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("https://yt1s.com/api/ajaxSearch/index"), System.Net.HttpWebRequest)
                    With AJ
                        .Method = "POST"
                        .Proxy = Nothing
                        .Host = "yt1s.com"
                        .KeepAlive = True
                        .ContentLength = Bytes.Length
                        .Accept = "*/*"
                        .Headers.Add("X-Requested-With: XMLHttpRequest")
                        .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Edg/88.0.705.50"
                        .ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
                        .Headers.Add("Origin: https://yt1s.com")
                        .Headers.Add("Sec-Fetch-Site: same-origin")
                        .Headers.Add("Sec-Fetch-Mode: cors")
                        .Headers.Add("Sec-Fetch-Dest: empty")
                        .AutomaticDecompression = System.Net.DecompressionMethods.Deflate Or System.Net.DecompressionMethods.GZip
                        .Referer = "https://yt1s.com/"
                        .Headers.Add("Accept-Language: en-US,en;q=0.9,ar;q=0.8")
                        .Headers.Add("Cookie: __cfduid=d870e96cb15f6deada08c8312469347b51611516775; _ga=GA1.2.139570040.1611516777; _gid=GA1.2.16273936.1611516777; __atuvc=1%7C4; __atuvs=600e043ccc6c7a2e000; __atssc=google%3B1; _gat_gtag_UA_173445049_1=1")
                    End With
                    Dim Stream As IO.Stream = AJ.GetRequestStream() : Stream.Write(Bytes, 0, Bytes.Length) : Stream.Dispose() : Stream.Close()
                    Dim Reader As New IO.StreamReader(DirectCast(AJ.GetResponse(), System.Net.HttpWebResponse).GetResponseStream())
                    Dim nmi As String = Reader.ReadToEnd
                    Reader.Dispose()
                    Reader.Close()
                    uss = Regex.Match(nmi, "{""size"":""(.*?)"",""f"":""mp3"",""q"":""(.*?)"",""k"":""(.*?)""}}").Groups(3).Value
                    idu = Regex.Match(nmi, """vid"":""(.*?)"",").Groups(1).Value
                Catch ex As WebException : Dim AJJ As String = New IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd() : MsgBox("Error : " & AJJ) : End Try
                Try
                    System.Net.ServicePointManager.CheckCertificateRevocationList = False : System.Net.ServicePointManager.DefaultConnectionLimit = 300 : System.Net.ServicePointManager.UseNagleAlgorithm = False : System.Net.ServicePointManager.Expect100Continue = False : System.Net.ServicePointManager.SecurityProtocol = 3072
                    Dim Encoding As New Text.UTF8Encoding
                    Dim Bytes As Byte() = Encoding.GetBytes("vid=" + idu + "&k=" + uss)
                    Dim AJ As System.Net.HttpWebRequest = DirectCast(System.Net.WebRequest.Create("https://yt1s.com/api/ajaxConvert/convert"), System.Net.HttpWebRequest)
                    With AJ
                        .Method = "POST"
                        .Proxy = Nothing
                        .Host = "yt1s.com"
                        .KeepAlive = True
                        .ContentLength = Bytes.Length
                        .Accept = "*/*"
                        .Headers.Add("X-Requested-With: XMLHttpRequest")
                        .UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.96 Safari/537.36 Edg/88.0.705.50"
                        .ContentType = "application/x-www-form-urlencoded; charset=UTF-8"
                        .Headers.Add("Origin: https://yt1s.com")
                        .Headers.Add("Sec-Fetch-Site: same-origin")
                        .Headers.Add("Sec-Fetch-Mode: cors")
                        .Headers.Add("Sec-Fetch-Dest: empty")
                        .Referer = "https://yt1s.com/"
                        .AutomaticDecompression = System.Net.DecompressionMethods.Deflate Or System.Net.DecompressionMethods.GZip
                        .Headers.Add("Accept-Language: en-US,en;q=0.9,ar;q=0.8")
                        .Headers.Add("Cookie: __cfduid=d870e96cb15f6deada08c8312469347b51611516775; _ga=GA1.2.139570040.1611516777; _gid=GA1.2.16273936.1611516777; __atssc=google%3B1; __atuvc=2%7C4; __atuvs=600e043ccc6c7a2e001")
                    End With
                    Dim Stream As IO.Stream = AJ.GetRequestStream() : Stream.Write(Bytes, 0, Bytes.Length) : Stream.Dispose() : Stream.Close()
                    Dim Reader As New IO.StreamReader(DirectCast(AJ.GetResponse(), System.Net.HttpWebResponse).GetResponseStream())
                    Dim no1 As String = Reader.ReadToEnd : Reader.Dispose() : Reader.Close()
                    link = Regex.Match(no1, """dlink"":""(.*?)""}").Groups(1).Value
                    title = Regex.Match(no1, """title"":""(.*?)"",").Groups(1).Value
                    If no1.Contains("CONVERTED") Then
                        Dim link2 As String = link
                        If link2.Contains("\") Then
                            Dim new1 As String
                            new1 = link2.Replace("\", "")
                            link2 = new1
                            Await rawmsg.Author.SendMessageAsync(link2)
                        End If
                    Else
                        Await rawmsg.Author.SendMessageAsync("Error Downloading Check Your Link !")
                    End If
                Catch ex As WebException : Dim AJJ As String = New IO.StreamReader(ex.Response.GetResponseStream()).ReadToEnd()
                    MsgBox("Error : " & AJJ) : End Try
            End If
        End If
    End Function

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Discord.StopAsync()
    End Sub
End Class

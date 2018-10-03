Imports Microsoft.VisualBasic
Imports Newtonsoft.Json
Imports RestSharp

Public Class sms
    Private Shared url As String = "http://37.130.202.188/services.jspd"
    Private Shared uname As String = ""
    Private Shared pass As String = ""
    Private Shared vared As Boolean = False
    Private Shared MobeModir As String = ""
    Private Shared Ferestandeh As String = ""
    Private Shared ShomareHa() As String

    Public Shared Function Vorud(U As String, P As String) As Boolean
        Try
            Dim client = New RestClient(url)
            Dim request = New RestRequest(Method.POST)
            request.AddParameter("uname", U)
            request.AddParameter("pass", P)

            request.AddParameter("op", "lines")

            Dim response = client.Execute(request)
            Dim content = JsonConvert.DeserializeObject(response.Content)
            If content(0) = 0 Then
                uname = U
                pass = P
                vared = True
            Else
                vared = False
                Return False
            End If

            Dim lins As New List(Of String)
            For Each row In JsonConvert.DeserializeObject(Of String())(content(1))
                Dim inrow = JsonConvert.DeserializeObject(Of cSMSCoreLine)(row)
                If inrow.send = "1" Then
                    lins.Add(inrow.number)
                End If
            Next
            ShomareHa = lins.ToArray
            Return True
        Catch ex As Exception
            Return False
        End Try

        'myLogs.Add(response.Content, "smsErsal", girandegan)
    End Function

    Public Shared Sub Khoruj()
        uname = ""
        pass = ""
    End Sub

    Public Shared Function Mandeh() As Integer
        Try
            Dim client = New RestClient(url)
            Dim request = New RestRequest(Method.POST)
            request.AddParameter("uname", uname)
            request.AddParameter("pass", pass)

            request.AddParameter("op", "credit")

            Dim response = client.Execute(request)
            Dim content = JsonConvert.DeserializeObject(response.Content)
            Dim intMandeh As Integer
            If content(0) = 0 Then
                intMandeh = Math.Abs(Double.Parse(content(1).ToString))
            End If
            Return intMandeh
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function ayaVaredShodeh() As Boolean
        If uname.Trim = "" Then Return False
        If pass.Trim = "" Then Return False
        Return vared
    End Function

    Public Shared Function ListShomareh() As String()
        Return ShomareHa
    End Function


    Public Shared Function ErrorPM(errorCode As Integer) As String
        Select Case errorCode
            Case 1 : Return "متن پیام خالی می‌باشد"
            Case 2 : Return "کاربر محدود گردیده است"
            Case 3 : Return "شماره ارسالی به شما تعلق ندارد"
            Case 4 : Return "دریافت کننده وارد نگردیده است"
            Case 5 : Return "اعتبار شما ناکافی است"
            Case 6 : Return "تعداد رشته پیام نامناسب می‌باشد"
            Case 7 : Return "خط مورد نظر برای ارسال انبوه مناسب نمی‌باشد"

            Case 98 : Return "حد بالای دریافت کننده رعایت نگردیده است"
            Case 99 : Return "اپراتور شماره ارسال کننده قطع می‌باشد"

            Case 962 : Return "نام کاربری یا رمز عبور اشتباه می‌باشد"
            Case 963 : Return "کاربری شما محدود گردیده است"

            Case 301 : Return "از کارکتر ویژه در نام کاربری استفاده گردیده است"
            Case 302 : Return "قیمت گذاری انجام نشده است"
            Case 303 : Return "نام کاربری وارد نگردیده است"
            Case 304 : Return "نام کاربری قبلا انتخاب گردیده است"
            Case 305 : Return "نام کاربری وارد نگردیده است"
            Case 306 : Return "کد ملی وارد نگردیده است"
            Case 307 : Return "کد ملی به خطا وارد شده است"
            Case 308 : Return "شماره شناسنامه نا‌معتبر است"
            Case 309 : Return "شماره شناسنامه وارد نگردیده است"
            Case 310 : Return "ایمیل کاربر وارد نگردیده است"
            Case 311 : Return "شماره تلفن وارد نگردیده است"
            Case 312 : Return "تلفن به درستی وارد نگردیده است"
            Case 313 : Return "آدرس شما وارد نگردیده است"
            Case 314 : Return "شماره موبایل را وارد نکرده اید"
            Case 315 : Return "شماره موبایل به درستی وارد نگردیده است"
            Case 316 : Return "سطح دسترسی به درستی وارد نگردیده است"

        End Select
        Return -1
    End Function

    Public Shared Function Ersal(Ferestandeh As String, Payam As String, ParamArray Girandeh() As String) As Integer
        Try
            Dim client = New RestClient(url)
            Dim request = New RestRequest(Method.POST)
            request.AddParameter("uname", uname)
            request.AddParameter("pass", pass)

            request.AddParameter("op", "send")

            request.AddParameter("from", Ferestandeh)
            request.AddParameter("message", Payam)
            Dim girandegan = Newtonsoft.Json.JsonConvert.SerializeObject(Girandeh)
            request.AddParameter("to", girandegan)

            Dim response = client.Execute(request)
            Dim content = JsonConvert.DeserializeObject(response.Content)
            Return content(0)
        Catch ex As Exception
            Return -1
        End Try
        'myLogs.Add(response.Content, "smsErsal", girandegan)
    End Function

    Public Shared Sub ErsalBeModir(Payam As String)
        Ersal(Payam, MobeModir)
    End Sub
End Class

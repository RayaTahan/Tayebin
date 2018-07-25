Imports System.Drawing.Text

Public NotInheritable Class fun
    Public Shared Function strShamsi2PersianDate(strShamsi As String) As FreeControls.PersianDate
        Dim t() As String = strShamsi.Split("/")
        Dim persiancal = New System.Globalization.PersianCalendar
        Dim dt = persiancal.ToDateTime(t(0), t(1), t(2), 0, 0, 0, 0, 0)

        Return FreeControls.PersianDate.Parse(dt)
    End Function

    Public Enum appFont As Integer
        AdobeArabic = 1
        DroidNaskh = 2
        DroidKufi = 3
        Nazanin = 4
        Roya = 5
        SegeoUI = 6
        IranSans = 7
    End Enum

    Public Structure FontStruct
        Dim Font As appFont
        Dim FontFamily As FontFamily
        Dim AyaDorosht As Boolean
        Dim AdSize As Integer

        Sub New(Font As appFont)
            Me.Font = Font
            Dim pfc As New PrivateFontCollection
            Dim adSize As Integer
            Dim AyaFontDorosht As Boolean
            Select Case Font
                Case appFont.AdobeArabic
                    pfc.AddFontFile("data\app\font\ADOBEARABIC-BOLD.OTF")
                    pfc.AddFontFile("data\app\font\ADOBEARABIC-BOLDITALIC.OTF")
                    pfc.AddFontFile("data\app\font\ADOBEARABIC-ITALIC.OTF")
                    pfc.AddFontFile("data\app\font\ADOBEARABIC-REGULAR.OTF")
                    AdSize = 0
                    AyaFontDorosht = False
                Case appFont.DroidNaskh
                    pfc.AddFontFile("data\app\font\DROIDNASKH-BOLD.TTF")
                    pfc.AddFontFile("data\app\font\DROIDNASKH-REGULAR.TTF")
                    AdSize = -2
                    AyaFontDorosht = True
                Case appFont.DroidKufi
                    pfc.AddFontFile("data\app\font\DROID ARABIC KUFI BOLD.TTF")
                    pfc.AddFontFile("data\app\font\DROID ARABIC KUFI.TTF")
                    AdSize = -2
                    AyaFontDorosht = True
                Case appFont.Nazanin
                    pfc.AddFontFile("data\app\font\BNAZANIN.TTF")
                    pfc.AddFontFile("data\app\font\BNAZNNBD.TTF")
                    AdSize = 0
                    AyaFontDorosht = True
                Case appFont.Roya
                    pfc.AddFontFile("data\app\font\BROYA.TTF")
                    pfc.AddFontFile("data\app\font\BROYABD.TTF")
                    AdSize = 0
                    AyaFontDorosht = True
                Case appFont.SegeoUI
                    pfc.AddFontFile("data\app\font\SEGOEUI.TTF")
                    pfc.AddFontFile("data\app\font\SEGOEUIB.TTF")
                    pfc.AddFontFile("data\app\font\SEGOEUII.TTF")
                    pfc.AddFontFile("data\app\font\SEGOEUIL.TTF")
                    pfc.AddFontFile("data\app\font\SEGOEUISL.TTF")
                    pfc.AddFontFile("data\app\font\SEGOEUIZ.TTF")
                    pfc.AddFontFile("data\app\font\SEGUIBL.TTF")
                    pfc.AddFontFile("data\app\font\SEGUIBLI.TTF")
                    pfc.AddFontFile("data\app\font\SEGUILI.TTF")
                    pfc.AddFontFile("data\app\font\SEGUISB.TTF")
                    pfc.AddFontFile("data\app\font\SEGUISBI.TTF")
                    pfc.AddFontFile("data\app\font\SEGUISLI.TTF")
                    AdSize = 0
                    AyaFontDorosht = False
                Case appFont.IranSans
                    pfc.AddFontFile("data\app\font\IRANSans.TTF")
                    pfc.AddFontFile("data\app\font\IRANSans_Bold.TTF")
                    pfc.AddFontFile("data\app\font\IRANSans_Light.TTF")
                    pfc.AddFontFile("data\app\font\IRANSans_Medium.TTF")
                    pfc.AddFontFile("data\app\font\IRANSans_UltraLight.TTF")
                    adSize = 3
                    AyaFontDorosht = False
            End Select
            FontFamily = pfc.Families(0)
            AyaDorosht = AyaFontDorosht
            adSize = adSize
        End Sub
    End Structure

    Public Shared Sub ChangeFont(Control As Object, font As appFont)
        ChangeObjectFont(Control, New FontStruct(font))
    End Sub

    Private Shared Sub ChangeObjectFont(Control As Object, sFont As FontStruct)
        Dim type As Type = Control.GetType
        Dim LastWidth As Integer = -1
        Dim LastHeight As Integer = -1


        If type.GetProperty("AutoScaleMode") IsNot Nothing Then
            Control.AutoScaleMode = AutoScaleMode.None
        End If
        
        If type.GetProperty("Font") IsNot Nothing Then
            Try
                Control.Font = New Font(sFont.FontFamily, Control.Font.Size + sFont.AdSize)
            Catch ex As Exception
                Control.Font = New Font(sFont.FontFamily, Control.Font.Size)
            End Try
        End If
        
        If TypeOf Control Is Panel Then
            If Control.Dock = DockStyle.Right Then
                If sFont.AyaDorosht Then
                    Control.Size = New Size(270, Control.Size.Height)
                Else
                    Control.Size = New Size(220, Control.Size.Height)
                End If
            End If
        End If

        Dim ctl As Control = TryCast(Control, Control)
        If ctl IsNot Nothing Then
            For Each child As Control In ctl.Controls
                Try
                    ChangeObjectFont(child, sFont)
                Catch ex As Exception

                End Try
            Next
        End If
    End Sub


    Public Shared Function TedadRuydadEmruz() As Integer
        Dim tarikh As New cTarikh
        Dim tedad As Integer = 0

        Dim Sal As Integer = tarikh.Sal
        Dim Mah As Integer = tarikh.Mah
        Dim Ruz As Integer = tarikh.Ruz


        For Each item As DataRow In SQLiter.Fill(String.Format("select * from tOzv where Tavalod like '%/{0}/{1}'", Strings.Right("00" & Mah, 2), Strings.Right("00" & Ruz, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Tavalod").ToString.Substring(0, item("Tavalod").ToString.IndexOf("/")))
                If _Sal > Sal Then
                    'sal haye bad
                ElseIf _Sal = Sal Then
                    tedad += 1
                Else
                    tedad += 1
                End If
            Catch ex As Exception

            End Try
        Next

        For Each item As DataRow In SQLiter.Fill(String.Format("select * from tOzv where Vafat like '%/{0}/{1}'", Strings.Right("00" & Mah, 2), Strings.Right("00" & Ruz, 2))).Rows
            Try
                Dim _Sal As Integer = Val(item("Vafat").ToString.Substring(0, item("Vafat").ToString.IndexOf("/")))
                Dim VafatShahadat As String = ""
                If item("Zende") = "z" Then
                Else
                    If _Sal > Sal Then
                        'sal haye bad
                    ElseIf _Sal = Sal Then
                        tedad += 1
                    Else
                        tedad += 1
                    End If
                End If
            Catch ex As Exception

            End Try
        Next

        Return tedad
    End Function
End Class

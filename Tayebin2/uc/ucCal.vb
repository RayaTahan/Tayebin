Public Class ucCal
    Dim isInited As Boolean = False
    Dim cel((42) + 1) As ucCalCel
    Dim Shanbe(7) As Label
    Dim SalBad, SalQabl, MahBad, MahQabl As Button
    Dim lblNamayesh, lblEmruz As Label

    Dim inSal, inMah, inRuz As Integer

    Private Sub ucCal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.RightToLeft = RightToLeft.No
        Me.BackColor = Color.GhostWhite
        init()
        Dim Emruz As New cTarikh

        lblEmruz.Text = String.Format("امروز {0} {1} {2} ماه {3}", Emruz.EsmeRuz, Emruz.Ruz, Emruz.EsmeMah, Emruz.Sal)
        Namayesh(Emruz.Sal, Emruz.Mah, Emruz.Ruz)
        For i As Integer = 1 To 42
            If cel(i).Visible AndAlso cel(i).Text = Emruz.Ruz Then
                Cel_Click(cel(i).lbl, Nothing)
            End If
        Next

    End Sub

    Private Sub init()
        If isInited = False Then
            For i As Integer = 1 To 42
                cel(i) = New ucCalCel
                With cel(i)
                    .Text = i
                    .Visible = True
                    .Margin = New Padding(1)
                End With
                Me.Controls.Add(cel(i))
                AddHandler cel(i).Click, AddressOf Cel_Click
            Next

            For i As Integer = 0 To 6
                Shanbe(i) = New Label
                With Shanbe(i)
                    .AutoSize = False
                    .TextAlign = ContentAlignment.MiddleCenter
                    .BackColor = Color.Transparent

                    .Margin = New Padding(1)
                End With
                Me.Controls.Add(Shanbe(i))
            Next
            Shanbe(0).Text = "شنبه"
            Shanbe(1).Text = "یک شنبه"
            Shanbe(2).Text = "دو شنبه"
            Shanbe(3).Text = "سه شنبه"
            Shanbe(4).Text = "چهار شنبه"
            Shanbe(5).Text = "پنج شنبه"
            Shanbe(6).Text = "جمعه"
            Shanbe(6).ForeColor = Color.Red

            SalBad = New Button
            With SalBad
                .Name = "SalBad"
                .Text = "+"
                .Margin = New Padding(2)
                Me.Controls.Add(SalBad)
                .BringToFront()
            End With
            AddHandler SalBad.Click, AddressOf Button_Click

            SalQabl = New Button
            With SalQabl
                .Name = "SalQabl"
                .Text = "-"
                .Margin = New Padding(2)
                Me.Controls.Add(SalQabl)
                .BringToFront()
            End With
            AddHandler SalQabl.Click, AddressOf Button_Click

            MahBad = New Button
            With MahBad
                .Name = "MahBad"
                .Text = "+"
                .Margin = New Padding(2)
                Me.Controls.Add(MahBad)
                .BringToFront()
            End With
            AddHandler MahBad.Click, AddressOf Button_Click

            MahQabl = New Button
            With MahQabl
                .Name = "MahQabl"
                .Text = "-"
                .Margin = New Padding(2)
                Me.Controls.Add(MahQabl)
                .BringToFront()
            End With
            AddHandler MahQabl.Click, AddressOf Button_Click

            lblNamayesh = New Label
            With lblNamayesh
                .AutoSize = False
                .TextAlign = ContentAlignment.MiddleCenter
                .Text = "نمایش"
                .ForeColor = Color.DarkGreen
                Me.Controls.Add(lblNamayesh)
            End With

            lblEmruz = New Label
            With lblEmruz
                .AutoSize = False
                .TextAlign = ContentAlignment.MiddleCenter
                .Text = "امروز"
                .ForeColor = Color.DarkBlue
                Me.Controls.Add(lblEmruz)
            End With
            AddHandler lblEmruz.Click, AddressOf Emruz_Click

            isInited = True
            Me.ucCal_Resize(Nothing, Nothing)
        End If
    End Sub

    Private Sub ucCal_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        If isInited Then
            'Me.Update()
            Dim _w As Integer = 400
            Dim _h As Integer = 350
            Dim w As Integer = Me.Width
            Dim h As Integer = Me.Height
            Dim bala As Integer = 75 / _h * h
            Dim chap As Integer = 25 / _w * w
            Dim wCel As Integer = 50 / _w * w
            Dim hCel As Integer = 40 / _h * h

            For i As Integer = 1 To 42
                cel(i).Size = New Point(wCel, hCel)
                Dim cTop As Integer = i \ 7
                If i Mod 7 = 0 Then
                    cTop -= 1
                End If
                cTop *= hCel
                Dim tmp As Integer = i
                While tmp >= 7
                    tmp -= 7
                End While
                If tmp > 0 Then
                    tmp = 7 - tmp
                End If
                Dim cLeft As Integer = tmp * wCel
                cTop += bala
                cLeft += chap
                cel(i).Location = New Point(cLeft, cTop)
            Next

            For i As Integer = 0 To 6
                With Shanbe(i)
                    .Size = New Point(wCel, hCel)
                    .Location = New Point((6 - i) * wCel + chap, 35 / _h * h)
                End With
            Next

            With SalBad
                .Size = New Point(chap / 3 * 2, bala)
                .Location = New Point(w - chap / 3 * 2, 0)
            End With

            With SalQabl
                .Size = New Point(chap / 3 * 2, bala)
                .Location = New Point(0, 0)
            End With

            With MahBad
                .Size = New Point(chap / 3 * 2, h - SalBad.Height)
                .Location = New Point(w - chap / 3 * 2, bala)
            End With

            With MahQabl
                .Size = New Point(chap / 3 * 2, h - SalBad.Height)
                .Location = New Point(0, bala)
            End With

            With lblNamayesh
                .Size = New Point(wCel * 7, 25 / _h * h)
                .Location = New Point(chap, 0)
            End With

            With lblEmruz
                .Size = New Point(wCel * 7, 25 / _h * h)
                .Location = New Point(chap, cel(42).Top + hCel)
            End With

        End If
    End Sub

    Private Sub ucCal_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.ucCal_Resize(Nothing, Nothing)
    End Sub

    Public Event Entekhab(Sal As Integer, Mah As Integer, Ruz As Integer)

    Public Sub Cel_Click(Sender As Object, e As EventArgs)
        Dim incel As ucCalCel = CType(CType(Sender, Label).Parent, ucCalCel)
        For i As Integer = 1 To 42
            cel(i).selected = False
        Next
        incel.Selected = True

        RaiseEvent Entekhab(inSal, inMah, incel.Text)
    End Sub

    Public Sub Emruz_Click(Sender As Object, e As EventArgs)
        Dim Emruz As New cTarikh
        lblEmruz.Text = String.Format("امروز {0} {1} {2} ماه {3}", Emruz.EsmeRuz, Emruz.Ruz, Emruz.EsmeMah, Emruz.Sal)
        Namayesh(Emruz.Sal, Emruz.Mah, Emruz.Ruz)
        For i As Integer = 1 To 42
            If cel(i).Visible AndAlso cel(i).Text = Emruz.Ruz Then
                Cel_Click(cel(i).lbl, Nothing)
            End If
        Next
        RaiseEvent Entekhab(Emruz.Sal, Emruz.Mah, Emruz.Ruz)
    End Sub

    Public Event QablNamayeshMah(Sal As Integer, Mah As Integer)
    Public Event BadNamayeshMah(Sal As Integer, Mah As Integer)

    Dim _bold As String = ""
    Public Property inNamayeshBold As String '''' [1][2]....
        Get
            Return _bold
        End Get
        Set(value As String)
            _bold = value
        End Set
    End Property

    Public Sub Namayesh(Sal As Integer, Mah As Integer, Optional Ruz As Integer = 0)
        If Sal > 0 AndAlso Mah > 0 And Mah < 13 Then
            RaiseEvent QablNamayeshMah(Sal, Mah)

            inSal = Sal
            inMah = Mah
            inRuz = Ruz
            Dim pc As New Globalization.PersianCalendar
            Dim dt As New DateTime(Sal, Mah, 1, pc)
            Dim tarikh As New cTarikh(dt)
            Dim start As Integer = 0
            Select Case dt.DayOfWeek
                Case DayOfWeek.Saturday
                    start = 1
                Case DayOfWeek.Sunday
                    start = 2
                Case DayOfWeek.Monday
                    start = 3
                Case DayOfWeek.Tuesday
                    start = 4
                Case DayOfWeek.Wednesday
                    start = 5
                Case DayOfWeek.Thursday
                    start = 6
                Case DayOfWeek.Friday
                    start = 7
            End Select

            Dim last As Integer
            If tarikh.Mah <= 6 Then
                last = 31 + start - 1
            ElseIf tarikh.Mah <= 11 Then
                last = 30 + start - 1
            Else
                If tarikh.isDorost(String.Format("{0}/{1}/{2}", Sal, Mah, 30)) Then
                    last = 30 + start - 1
                Else
                    last = 29 + start - 1
                End If
            End If

            If start > 1 Then
                For i As Integer = 1 To start - 1
                    With cel(i)
                        .Visible = False
                        .Boldeded = False
                        .Selected = False
                    End With
                Next
            End If

            Dim n As Integer = 1
            For i As Integer = start To last
                With cel(i)
                    .Boldeded = False
                    .Selected = False
                    If _bold.Contains(String.Format("[{0}]", n)) Then
                        .Boldeded = True
                    Else
                        .Boldeded = False
                    End If
                    .Text = n
                    .Visible = True
                End With
                n += 1
            Next

            For i As Integer = last + 1 To 42
                With cel(i)
                    .Visible = False
                    .Boldeded = False
                    .Selected = False
                End With
            Next

            lblNamayesh.Text = String.Format("نمایش {0} ماه {1}", tarikh.EsmeMahha(Mah), Sal)

            RaiseEvent BadNamayeshMah(Sal, Mah)
        End If
    End Sub

    Private Sub Button_Click(Sender As Object, e As EventArgs)
        Select Case Sender.Name
            Case "SalBad"
                Namayesh(inSal + 1, inMah)
            Case "SalQabl"
                Namayesh(inSal - 1, inMah)
            Case "MahBad"
                Dim tM As Integer = inMah + 1
                Dim tS As Integer = inSal
                If tM = 13 Then
                    tM = 1
                    tS += 1
                End If
                Namayesh(tS, tM)
            Case "MahQabl"
                Dim tM As Integer = inMah - 1
                Dim tS As Integer = inSal
                If tM = 0 Then
                    tM = 12
                    tS -= 1
                End If
                Namayesh(tS, tM)
        End Select
    End Sub
End Class

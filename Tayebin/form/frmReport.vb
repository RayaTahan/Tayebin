Imports CrystalDecisions.CrystalReports.Engine

Public Class frmReport


    Public Enum KodumGozaresh As Integer
        Kolli = 1
        SalDore = 2
        HozurQiabAlef = 3
        HozurQiabBe = 4
        QablieSherkatNakarde = 5
        HozurQiabJim = 6
    End Enum

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(Kodum As KodumGozaresh, Optional dID As Integer = -1, Optional d1 As Object = Nothing, Optional d2 As Object = Nothing)
        InitializeComponent()

        Dim Zaman As String = String.Format("{0} - {1} : {2}", (New cTarikh).ToString, (New cSaat).ToString, "زمان ایجاد ")

        Dim Report = Nothing


        Select Case Kodum
            Case KodumGozaresh.Kolli
                Report = New rprtAzaKolli

                Report.SetDataSource(SQL.Fill("Select * from tOzv order by Famil , Nam "))
                Report.SummaryInfo.ReportTitle = "گزارش کلی اعضا"
            Case KodumGozaresh.SalDore
                Report = New rprtAzaKolli

                Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID)))

                Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                Report.SummaryInfo.ReportTitle = String.Format("گزارش دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)
            Case KodumGozaresh.HozurQiabAlef
                Report = New rprtHozurQiabAlef

                Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID)))

                Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                Report.SummaryInfo.ReportTitle = String.Format("فرم الف حضور و غیاب دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)
            Case KodumGozaresh.HozurQiabBe
                Report = New rprtHozurQiabBe

                Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID)))

                Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                Report.SummaryInfo.ReportTitle = String.Format("فرم ب حضور و غیاب دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)

            Case KodumGozaresh.HozurQiabJim
                Report = New rprtHozurQiabJim

                Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID)))

                Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                Report.SummaryInfo.ReportTitle = String.Format("فرم جیم حضور و غیاب دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)

            Case KodumGozaresh.QablieSherkatNakarde
                Report = New rprtAzaKolli

                Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in(select IDOzv from vOzvSalDore where SalID={0}) and ID not in(select IDOzv from vOzvSalDore where SalID={1}) order by Famil , Nam", d1, d2)))
                Report.SummaryInfo.ReportTitle = String.Format("گزارش اعضایی که در سال '{0}' حضور داشتند و در سال '{1}' حضور ندارند", SQL.RunCommandScaler(String.Format("select Onvan from tSal where ID={0}", d1)), SQL.RunCommandScaler(String.Format("select Onvan from tSal where ID={0}", d2)))
            Case Else


        End Select

        Report.SummaryInfo.ReportAuthor = AppMan.TanzimGet("KanunNam")
        Report.SummaryInfo.ReportComments = Zaman

        Viewer.ReportSource = Report

    End Sub

    Private Sub frmReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.P AndAlso e.Modifiers = Keys.Control Then
            Viewer.PrintReport()
        End If
    End Sub

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Viewer.RefreshReport()
    End Sub
End Class

Imports Microsoft.Reporting.WinForms

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
        Me.Show()

        Dim tbl As New DataTable
        Dim param As New List(Of ReportParameter)

        param.Add(New ReportParameter("Kanun", AppMan.TanzimGet("KanunNam").ToString))
        param.Add(New ReportParameter("Zaman", String.Format("{0} - {1} :{2}", (New cTarikh).ToString, (New cSaat).ToString, "زمان ایجاد")))
        param.Add(New ReportParameter("Emza", String.Format("{0} | نرم افزار {1} نسخه {2}", AppMan.AppURL, AppMan.AppName, AppMan.AppVer)))



        Select Case Kodum
            Case KodumGozaresh.Kolli
                viewer.LocalReport.ReportPath = "data\reports\R101.rdlc"
                param.Add(New ReportParameter("rprtCode", "" & "R101"))
                tbl = SQL.Fill("Select * from tOzv order by Famil , Nam ")
                param.Add(New ReportParameter("Onvan", "گزارش کلی اعضا"))

            Case KodumGozaresh.SalDore
                viewer.LocalReport.ReportPath = "data\reports\R101.rdlc"
                param.Add(New ReportParameter("rprtCode", "" & "R101"))
                tbl = SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID))
                Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                param.Add(New ReportParameter("Onvan", String.Format("گزارش دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)))

            Case KodumGozaresh.QablieSherkatNakarde
                viewer.LocalReport.ReportPath = "data\reports\R101.rdlc"
                param.Add(New ReportParameter("rprtCode", "" & "R101"))
                tbl = SQL.Fill(String.Format("Select * from tOzv where ID in(select IDOzv from vOzvSalDore where SalID={0}) and ID not in(select IDOzv from vOzvSalDore where SalID={1}) order by Famil , Nam", d1, d2))
                param.Add(New ReportParameter("Onvan", String.Format("گزارش اعضایی که در سال '{0}' حضور داشتند و در سال '{1}' حضور ندارند", SQL.RunCommandScaler(String.Format("select Onvan from tSal where ID={0}", d1)), SQL.RunCommandScaler(String.Format("select Onvan from tSal where ID={0}", d2)))))

            Case KodumGozaresh.HozurQiabAlef
                viewer.LocalReport.ReportPath = "data\reports\R102.rdlc"
                param.Add(New ReportParameter("rprtCode", "" & "R102"))
                tbl = SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID))
                Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                param.Add(New ReportParameter("Onvan", String.Format("فرم حضور و غیاب دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)))

                'Case KodumGozaresh.HozurQiabBe
                '    Report = New rprtHozurQiabBe

                '    Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID)))

                '    Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                '    Report.SummaryInfo.ReportTitle = String.Format("فرم حضور و غیاب دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)

                'Case KodumGozaresh.HozurQiabJim
                '    Report = New rprtHozurQiabJim

                '    Report.SetDataSource(SQL.Fill(String.Format("Select * from tOzv where ID in (select IDOzv from tOzvSalDore where IDSalDore={0}) order by Famil , Nam ", dID)))

                '    Dim data = SQL.Fill("select * from vSalDore where SalDoreID=" & dID)
                '    Report.SummaryInfo.ReportTitle = String.Format("فرم حضور و غیاب دوره [{3}] {0} سال {1} ، مربی : {2}", data(0).Item("DoreOnvan"), data(0).Item("SalOnvan"), data(0).Item("MorabbiOnvan"), dID)



            Case Else


        End Select

        Dim ds = New ReportDataSource("ds", tbl)

        With viewer
            .SetDisplayMode(DisplayMode.PrintLayout)
            .LocalReport.DataSources.Add(ds)
            .LocalReport.SetParameters(param)
            .RefreshReport()
        End With


    End Sub

    Private Sub frmReport_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.P Then
            viewer.PrintDialog()
        End If
    End Sub

    Private Sub frmReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        viewer.RefreshReport()
    End Sub
End Class
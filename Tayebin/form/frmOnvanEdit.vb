Imports System.Data.SQLite

Public Class frmOnvanEdit

    Public Enum KodumOnvan As Integer
        Dore = 0
        Morabbi = 1
        Madrak = 2
        Karname = 3
    End Enum

    Dim dID As Integer
    Dim dKodum As KodumOnvan
    Dim data As DataTable

    Dim tblName As String = ""

    Sub New(Kodum As KodumOnvan, Optional ID As Integer = -1)
        InitializeComponent()

        dKodum = Kodum
        dID = ID
    End Sub

    Private Sub frmSalEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        Select Case dKodum
            Case KodumOnvan.Dore
                TextBox2.MaxLength = 50
                Me.Text = "فرم دوره"
                tblName = "tDore"
            Case KodumOnvan.Morabbi
                TextBox2.MaxLength = 100
                Me.Text = "فرم مربی"
                tblName = "tMorabbi"
            Case KodumOnvan.Madrak
                TextBox2.MaxLength = 50
                Me.Text = "فرم نوع مدرک"
                tblName = "tNoMadrak"
            Case KodumOnvan.Karname
                TextBox2.MaxLength = 50
                Me.Text = "فرم ریز کارنامه"
                tblName = "tRizKarname"
        End Select

        If dID = -1 Then
            TextBox1.Text = "[جدید]"
            TextBox2.Text = ""
        Else

            data = SQLiter.Fill(String.Format("select * from {0} where ID={1}", tblName, dID))
            TextBox1.Text = dID
            TextBox2.Text = data(0).Item("Onvan")
        End If

        Me.Show()
        TextBox2.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If dID = -1 Then
                SQLiter.RunCommand(String.Format("insert into {0}(Onvan) values(@0)", tblName), {New SQLiteParameter("@0", TextBox2.Text)})
            Else
                SQLiter.RunCommand(String.Format("update {0} set Onvan=@0 where ID=@1", tblName), {New SQLiteParameter("@0", TextBox2.Text), New SQLiteParameter("@1", dID)})
            End If

            Select Case dKodum
                Case KodumOnvan.Morabbi
                    Dim own As frmDoreha = Me.Owner
                    own.ReloadData()
                Case KodumOnvan.Dore
                    Dim own As frmDoreha = Me.Owner
                    own.ReloadData()
                Case KodumOnvan.Karname
                    Dim own As frmOnvanList = Me.Owner
                    own.ReloadData()
                Case KodumOnvan.Madrak
                    Dim own As frmOnvanList = Me.Owner
                    own.ReloadData()
            End Select

            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

End Class
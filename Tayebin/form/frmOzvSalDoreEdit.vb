Imports System.Data.SQLite

Public Class frmOzvSalDoreEdit


    Dim dID As Integer
    Dim OzvID As Integer
    Dim data As DataRow

    Sub New(Ozv As Integer, Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
        OzvID = Ozv
    End Sub

    Private Sub frmOzvSalDoreEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        Try
            ListView1.Items.Clear()
            For Each row In SQLiter.Fill("select SalDoreID,SalOnvan,DoreOnvan,MorabbiOnvan from vSalDore").Rows()
                Dim item As New ListViewItem()
                item.Tag = row("SalDoreID")
                item.Text = row("DoreOnvan")
                item.SubItems.Add(row("MorabbiOnvan"))
                ListView1.Groups.Add(New ListViewGroup(row("SalOnvan").ToString, row("SalOnvan").ToString))
                item.Group = ListView1.Groups(row("SalOnvan"))
                ListView1.Items.Add(item)
            Next

            If Not (Val(SQLiter.RunCommandScaler("select count(*) from tSalDore") > 0)) Then
                MessageBox.Show("اطلاعات اولیه مورد نیاز شامل سال-دوره باید وجود داشته باشد!")
                Me.Close()
            End If

            Dim OData = SQLiter.Fill("select * from tOzv where ID=" & OzvID)
            UcTextBox1.Text = String.Format("({0}) : {1} {2}", OzvID, OData(0).Item("Nam"), OData(0).Item("Famil"))

            If dID = -1 Then
                TextBox1.Text = "[جدید]"
                UcTextBox2.Text = "[اکنون]"
            Else

                data = SQLiter.Fill("select * from tOzvSalDore where ID=" & dID).Rows(0)
                TextBox1.Text = dID

                For Each item As ListViewItem In ListView1.Items
                    If item.Tag = data("IDSalDore") Then
                        item.BackColor = Color.Orange
                    Else

                    End If
                Next

                UcTextBox2.Text = String.Format("{0} - {1}", data("ZamanSabt"), data("TarikhSabt"))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Me.Close()
        End Try

        Dim w As Integer = ListView1.Width - 40
        ListView1.Columns(0).Width = w * 40 / 100
        ListView1.Columns(1).Width = w * 60 / 100
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ListView1.SelectedItems.Count = 1 Then
            Try
                If dID = -1 Then
                    SQLiter.RunCommand("insert into tOzvSalDore(IDOzv,IDSalDore,TarikhSabt,ZamanSabt) values(@0,@1,@2,@3)", {New SQLiteParameter("@0", OzvID), New SQLiteParameter("@1", ListView1.SelectedItems(0).Tag), New SQLiteParameter("@2", (New cTarikh).ToString), New SQLiteParameter("@3", (New cSaat).ToString)})
                Else
                    SQLiter.RunCommand("update tOzvSalDore set IDSalDore=@0 where ID=@1", {New SQLiteParameter("@0", ListView1.SelectedItems(0).Tag), New SQLiteParameter("@1", dID)})
                End If

                Dim own As frmOzvView = Me.Owner
                own.ReloadData()
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("حتما باید یکی از سال دوره ها انتخاب شده باشد.")
        End If

    End Sub

    Private Sub ListView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListView1.MouseDoubleClick
        Button1.PerformClick()
    End Sub
End Class
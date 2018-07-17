Public Class frmGozareshHa

    Private Sub frmGozareshHa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TreeView1.Nodes.Clear()
        For Each tSal As DataRow In SQL.Fill("select ID,Onvan from tSal").Rows
            Dim nSal As New TreeNode(tSal.Item("Onvan"))
            nSal.Tag = tSal.Item("ID")
            For Each tSalDore As DataRow In SQL.Fill("select SalDoreID,DoreOnvan,MorabbiOnvan from vSalDore where SalID=" & nSal.Tag).Rows
                Dim nSalDore As New TreeNode(String.Format("{0} [{1}]", tSalDore.Item("DoreOnvan"), tSalDore.Item("MorabbiOnvan")))
                nSalDore.Tag = tSalDore.Item("SalDoreID")

                nSal.Nodes.Add(nSalDore)
            Next
            TreeView1.Nodes.Add(nSal)
        Next
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button6.Enabled = False

        Dim salHa As DataTable = SQL.Fill("select ID,Onvan from tSal")
        With comboHozur
            .ValueMember = "ID"
            .DisplayMember = "Onvan"
            .DataSource = salHa.Copy
        End With
        With comboAdamHozur
            .ValueMember = "ID"
            .DisplayMember = "Onvan"
            .DataSource = salHa.Copy
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New frmReport(frmReport.KodumGozaresh.Kolli)
        frm.Show()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

        If TreeView1.SelectedNode IsNot Nothing AndAlso TreeView1.SelectedNode.Parent IsNot Nothing Then
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
        Else
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button6.Enabled = False
        End If
        
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim frm As New frmReport(frmReport.KodumGozaresh.SalDore, TreeView1.SelectedNode.Tag)
            frm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            Dim frm As New frmReport(frmReport.KodumGozaresh.HozurQiabAlef, TreeView1.SelectedNode.Tag)
            frm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim frm As New frmReport(frmReport.KodumGozaresh.HozurQiabBe, TreeView1.SelectedNode.Tag)
            frm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New frmReport(frmReport.KodumGozaresh.QablieSherkatNakarde, d1:=comboHozur.SelectedValue, d2:=comboAdamHozur.SelectedValue)
        frm.Show()
    End Sub

    Private Sub comboHozur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboHozur.SelectedIndexChanged

    End Sub

    Private Sub comboAdamHozur_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboAdamHozur.SelectedIndexChanged

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Try
            Dim frm As New frmReport(frmReport.KodumGozaresh.HozurQiabJim, TreeView1.SelectedNode.Tag)
            frm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
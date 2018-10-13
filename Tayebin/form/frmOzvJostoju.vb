Public Class frmOzvJostoju
    Dim SelectedDores As String = ""
    Dim TreeBusy As Integer = 0
    Dim HameDoreha As Boolean = False

    Private Sub frmOzvJostoju_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add(New TreeNode("همه اعضا") With {.Tag = -1})

        For Each tSal As DataRow In SQLiter.Fill("select ID,Onvan from tSal order by TarikhShoru desc").Rows
            Dim nSal As New TreeNode(tSal.Item("Onvan"))
            nSal.Tag = tSal.Item("ID")
            For Each tSalDore As DataRow In SQLiter.Fill("select SalDoreID,DoreOnvan,MorabbiOnvan from vSalDore where SalID=" & nSal.Tag).Rows
                Dim nSalDore As New TreeNode(String.Format("{0} [{1}]", tSalDore.Item("DoreOnvan"), tSalDore.Item("MorabbiOnvan")))
                nSalDore.Tag = tSalDore.Item("SalDoreID")

                nSalDore.Checked = True

                nSal.Nodes.Add(nSalDore)
            Next
            nSal.Checked = True
            TreeView1.Nodes.Add(nSal)
        Next

        comboVaz.DisplayMember = "key"
        comboVaz.ValueMember = "value"
        comboVaz.Items.Add(New DictionaryEntry("زنده", "z"))
        comboVaz.Items.Add(New DictionaryEntry("وفات", "v"))
        comboVaz.Items.Add(New DictionaryEntry("شهادت", "s"))
        comboVaz.SelectedIndex = 0

        UcTextBox1.Focus()
        UcTextBox1.Select()
        UcTextBox1.Focus()
    End Sub


    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        TreeBusy += 1
        If TreeBusy = 1 Then

            If e.Node.Parent IsNot Nothing Then
                Dim allChecked As Boolean = True
                For Each chn As TreeNode In e.Node.Parent.Nodes
                    If chn.Checked = False Then
                        allChecked = False
                        Exit For
                    End If
                Next
                e.Node.Parent.Checked = allChecked
            End If
            For Each nd As TreeNode In e.Node.Nodes
                nd.Checked = nd.Parent.Checked
            Next

            If e.Node.Tag = -1 AndAlso e.Node.Checked Then
                For Each chn As TreeNode In TreeView1.Nodes
                    If chn.Tag <> -1 Then
                        chn.Checked = False
                        For Each nd As TreeNode In chn.Nodes
                            nd.Checked = False
                        Next
                    End If
                Next
                HameDoreha = True
            ElseIf e.Node.Tag = -1 AndAlso e.Node.Checked = False Then
                HameDoreha = False
            End If

        End If
        TreeBusy -= 1
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TreeView1.SelectedNode = Nothing
    End Sub

    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        e.Node.Checked = Not e.Node.Checked
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Public Function dSalDore() As String
        If HameDoreha Then
            Return ""
        Else
            SelectedDores = ""
            For Each nd As TreeNode In TreeView1.Nodes
                For Each nod As TreeNode In nd.Nodes
                    Dim DoreKey As String = String.Format("[{0}]", nod.Tag)
                    If nod.Checked Then
                        SelectedDores += DoreKey
                    Else
                        SelectedDores = SelectedDores.Replace(DoreKey, "")
                    End If
                Next
            Next

            Dim tmpSalDoreHa As String = SelectedDores.Replace("][", ",").Replace("[", "").Replace("]", "")

            Dim SalDore As String = ""
            If tmpSalDoreHa = "" Then
                SalDore = ""
            Else
                SalDore = " ID in(select IDOzv from tOzvSalDore where IDSalDore in(" & tmpSalDoreHa & ")) "
            End If

            Return SalDore
        End If
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim ShartList As New List(Of String)
        Dim sShart As String = UcTextBox1.Text.Trim
        If Val(UcTextBox1.Text.Trim) Then
            ShartList.Add("ID=" & sShart)
        End If

        Dim ptrn As String = "{0} like '%{1}%'"
        ShartList.Add(String.Format(ptrn, "Nam", sShart))
        ShartList.Add(String.Format(ptrn, "Famil", sShart))
        ShartList.Add(String.Format(ptrn, "Pedar", sShart))
        ShartList.Add(String.Format(ptrn, "Tavalod", sShart))
        ShartList.Add(String.Format(ptrn, "Vafat", sShart))
        ShartList.Add(String.Format(ptrn, "CodeMelli", sShart))
        ShartList.Add(String.Format(ptrn, "SalVorud", sShart))
        ShartList.Add(String.Format(ptrn, "Tel", sShart))
        ShartList.Add(String.Format(ptrn, "Mob", sShart))
        ShartList.Add(String.Format(ptrn, "MobPedar", sShart))
        ShartList.Add(String.Format(ptrn, "MobMadar", sShart))
        ShartList.Add(String.Format(ptrn, "Tahsil", sShart))
        ShartList.Add(String.Format(ptrn, "MahalTahsil", sShart))
        ShartList.Add(String.Format(ptrn, "Shoql", sShart))
        ShartList.Add(String.Format(ptrn, "MahalKar", sShart))
        ShartList.Add(String.Format(ptrn, "ShoqlPedar", sShart))
        ShartList.Add(String.Format(ptrn, "ShoqlMadar", sShart))
        ShartList.Add(String.Format(ptrn, "Adres", sShart))
        ShartList.Add(String.Format(ptrn, "Tozih", sShart))

        Dim frm As frmOzvha = Me.Owner
        frm.ReloadData(ShartList.ToArray, dSalDore)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ptrn As String = "{0} like '%{1}%'"

        Dim ShartList As New List(Of String)
        If txtNam.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Nam", txtNam.Text.Trim))
        If txtFamil.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Famil", txtFamil.Text.Trim))
        If txtPedar.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Pedar", txtPedar.Text.Trim))
        If chTavalod.Checked Then ShartList.Add(String.Format(ptrn, "Tavalod", TarikhTavalod.Value))
        If chVafat.Checked Then ShartList.Add(String.Format(ptrn, "Vafat", TarikhVafat.Value))
        If chHayat.Checked Then ShartList.Add(String.Format(ptrn, "Vafat", comboVaz.SelectedValue))
        If txtCodeMelli.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "CodeMelli", txtCodeMelli.Text.Trim))
        If txtSalVorud.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "SalVorud", txtSalVorud.Text.Trim))
        If txtTel.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Tel", txtTel.Text.Trim))
        If txtMob.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Mob", txtMob.Text.Trim))
        If txtMobPedar.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "MobPedar", txtMobPedar.Text.Trim))
        If txtMobMadar.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "MobMadar", txtMobMadar.Text.Trim))
        If txtTahsil.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Tahsil", txtTahsil.Text.Trim))
        If txtMahalTahsil.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "MahalTahsil", txtMahalTahsil.Text))
        If txtShoql.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Shoql", txtShoql.Text.Trim))
        If txtMahalKar.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "MahalKar", txtMahalKar.Text.Trim))
        If txtShoqlPedar.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "ShoqlPedar", txtShoqlPedar.Text.Trim))
        If txtShoqlMadar.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "ShoqlMadar", txtShoqlMadar.Text.Trim))
        If txtAdres.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Adres", txtAdres.Text.Trim))
        If txtTozih.Text.Trim <> "" Then ShartList.Add(String.Format(ptrn, "Tozih", txtTozih.Text.Trim))

        Dim frm As frmOzvha = Me.Owner
        frm.ReloadData(ShartList.ToArray, dSalDore, True)
        Me.Close()
    End Sub

    Private Sub UcTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles UcTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button4.PerformClick()
        End If
    End Sub

    Private Sub Pishrafte_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNam.KeyDown, txtFamil.KeyDown, txtPedar.KeyDown, txtCodeMelli.KeyDown, txtSalVorud.KeyDown, txtTel.KeyDown, txtMob.KeyDown, txtMobPedar.KeyDown, txtMobMadar.KeyDown, txtAdres.KeyDown, txtTahsil.KeyDown, txtMahalTahsil.KeyDown, txtShoql.KeyDown, txtMahalKar.KeyDown, txtShoqlPedar.KeyDown, txtShoqlMadar.KeyDown, txtTozih.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.PerformClick()
        End If
    End Sub

End Class
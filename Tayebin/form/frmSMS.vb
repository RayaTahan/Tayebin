Imports System.Data.SQLite

Public Class frmSMS
    Dim SelectedDores As String = ""
    Dim TreeBusy As Integer = 0
    Dim HameDoreha As Boolean = False

    Dim Girandegan As New List(Of String)
    Dim GirandeganBiTekrar() As String

    Private Sub frmSMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        TreeView1.Nodes.Clear()
        TreeView1.Nodes.Add(New TreeNode("همه اعضا") With {.Tag = -1})

        For Each tSal As DataRow In SQLiter.Fill("select ID,Onvan from tSal").Rows
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

        If sms.ayaVaredShodeh Then
            ListBox1.Items.Clear()
            ListBox1.Items.AddRange(sms.ListShomareh)
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(sms.ListShomareh)
            Try
                ComboBox1.SelectedIndex = 0
            Catch ex As Exception

            End Try
        Else
            If sms.Vorud(AppMan.Tanzimat("smsUser"), AppMan.Tanzimat("smsPass")) Then
                ListBox1.Items.Clear()
                ListBox1.Items.AddRange(sms.ListShomareh)
                ComboBox1.Items.Clear()
                ComboBox1.Items.AddRange(sms.ListShomareh)
                Try
                    ComboBox1.SelectedIndex = 0
                Catch ex As Exception

                End Try
            End If
        End If
        UcTextBox1.Text = AppMan.Tanzimat("smsUser")

        UcTextBox1.Focus()
        UcTextBox1.Select()
        UcTextBox1.Focus()
        BeRuz()

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
        taqir()
    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        TreeView1.SelectedNode = Nothing
    End Sub

    Private Sub TreeView1_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeSelect
        e.Node.Checked = Not e.Node.Checked
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
                SalDore = " 1=0 "
            Else
                SalDore = " ID in(select IDOzv from tOzvSalDore where IDSalDore in(" & tmpSalDoreHa & ")) "
            End If

            Return SalDore
        End If
    End Function

    Private Sub UcTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles UcTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            'Button4.PerformClick()
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Shell("explorer http://irsms.net")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AppMan.Tanzimat("smsUser") = UcTextBox1.Text
        AppMan.Tanzimat("smsPass") = UcTextBox2.Text
        sms.Khoruj()
        If sms.Vorud(AppMan.Tanzimat("smsUser"), AppMan.Tanzimat("smsPass")) Then
            ListBox1.Items.Clear()
            ListBox1.Items.AddRange(sms.ListShomareh)
            ComboBox1.Items.Clear()
            ComboBox1.Items.AddRange(sms.ListShomareh)
            Try
                ComboBox1.SelectedIndex = 0
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AppMan.Tanzimat("smsUser") = ""
        AppMan.Tanzimat("smsPass") = ""
        UcTextBox1.Text = ""
        UcTextBox2.Text = ""
        sms.Khoruj()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Label3.Text = "..."
        If sms.ayaVaredShodeh Then
            Dim etebar = sms.Mandeh \ 10
            Label3.Text = AdadHa.HezarTaHezarTa(etebar) & " تومان"
        Else
            Label3.Text = "لطفا وارد شوید"
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Shell("explorer http://irsms.net")
    End Sub

    Private Sub UcTextBox3_TextChanged(sender As Object, e As EventArgs) Handles UcTextBox3.TextChanged
        taqir()
    End Sub

    Private Sub taqir()
        Dim le = UcTextBox3.TextLength
        Dim sf As Integer = 0
        If le <= 70 Then
            sf = 1
        Else
            sf = Math.Ceiling(le / 66)
        End If
        Label6.Text = sf

        Dim nafar = 0
        Dim sl = ""
        Dim sls = 0
        If CheckBox1.Checked Then
            sl += ",Mob "
            sls += 1
        End If
        If CheckBox2.Checked Then
            sl += ",MobPedar "
            sls += 1
        End If
        If CheckBox3.Checked Then
            sl += ",MobMadar "
            sls += 1
        End If
        If sls = 0 Then
            Label7.Text = 0
        Else
            sl = sl.Substring(1)
            Dim saldore = dSalDore()
            Dim tbl = SQLiter.Fill($"select {sl} from tOzv {IIf(saldore = "", "", "where " & saldore)}")
            Girandegan.Clear()
            For Each row In tbl.Rows
                For i = 0 To sls - 1
                    If row(i).ToString.Length >= 10 Then
                        Girandegan.Add(row(i).ToString.Replace(" ", ""))
                    End If
                Next
            Next
            GirandeganBiTekrar = Girandegan.Distinct.ToArray
            Label7.Text = GirandeganBiTekrar.Length

        End If

        If Label6.Text = "0" Or Label7.Text = "0" Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        taqir()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        taqir()
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        taqir()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim natijeh = sms.Ersal(ComboBox1.Items(ComboBox1.SelectedIndex).ToString, UcTextBox3.Text, GirandeganBiTekrar)
        If natijeh = 0 Then
            SQLiter.RunCommand("insert into tSentSMS(User, TT, SS, Matn, Girandegan) values(@0,@1,@2,@3,@4)", {
        New SQLiteParameter("@0", 1),
        New SQLiteParameter("@1", (New cTarikh).ToString),
        New SQLiteParameter("@2", (New cSaat).ToString),
        New SQLiteParameter("@3", UcTextBox3.Text),
        New SQLiteParameter("@4", GirandeganBiTekrar.Length)
                                   })
            UcTextBox3.Text = ""
            CheckBox1.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            MessageBox.Show("پیام با موفقیت ارسال شد.")
            BeRuz()
        Else
            MessageBox.Show(sms.ErrorPM(natijeh))
        End If
    End Sub

    Private Sub BeRuz()
        DataGridView1.DataSource = SQLiter.Fill("select ID,TT,SS,Matn,Girandegan from tSentSMS order by ID desc LIMIT 20")
    End Sub
End Class
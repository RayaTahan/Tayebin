Imports System.Data.SQLite

Public Class frmOzvEdit
    Dim lastCodeMelli As String = ""

    Dim dID As Integer
    Dim data As DataTable

    Sub New(Optional ID As Integer = -1)
        InitializeComponent()

        dID = ID
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub comboVaz_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboVaz.SelectedIndexChanged
        If comboVaz.SelectedItem.Value = "z" Then
            TarikhVafat.Visible = False
        Else
            TarikhVafat.Visible = True
        End If
    End Sub

    Private Sub frmOzvEdit_Load(sender As Object, e As EventArgs) Handles Me.Load
        'fun.ChangeFont(Me, My.MySettings.Default.Context.Item("Font"))

        Me.Show()

        comboVaz.DisplayMember = "key"
        comboVaz.ValueMember = "value"
        comboVaz.Items.Add(New DictionaryEntry("زنده", "z"))
        comboVaz.Items.Add(New DictionaryEntry("وفات", "v"))
        comboVaz.Items.Add(New DictionaryEntry("شهادت", "s"))
        comboVaz.SelectedIndex = 0
        Dim emsal As Integer = (New cTarikh).Sal
        txtSalVorud.Maximum = emsal


        If dID = -1 Then
            txtID.Text = "[جدید]"
            txtSalVorud.Value = emsal
        Else

            data = SQLiter.Fill(String.Format("select * from tOzv where ID={0}", dID))
            txtID.Text = dID
            txtNam.Text = data(0).Item("Nam")
            txtFamil.Text = data(0).Item("Famil")
            txtPedar.Text = data(0).Item("Pedar")
            TarikhTavalod.Value = fun.strShamsi2PersianDate(data(0).Item("Tavalod"))
            Select Case data(0).Item("Zende")
                Case "z"
                    comboVaz.SelectedIndex = 0
                Case "v"
                    comboVaz.SelectedIndex = 1
                Case "s"
                    comboVaz.SelectedIndex = 2
            End Select
            If comboVaz.SelectedItem.Value = "z" Then
                'TarikhVafat.Value = fun.strShamsi2PersianDate("0000/00/00")
            Else
                TarikhVafat.Value = fun.strShamsi2PersianDate(data(0).Item("Vafat"))
            End If
            txtCodeMelli.Text = data(0).Item("CodeMelli")
            lastCodeMelli = data(0).Item("CodeMelli")
            Dim tsal As Integer = 0
            Integer.TryParse(data(0).Item("SalVorud").ToString, tsal)
            txtSalVorud.Value = tsal
            txtTel.Text = data(0).Item("Tel")
            txtMob.Text = data(0).Item("Mob")
            txtMobPedar.Text = data(0).Item("MobPedar")
            txtMobMadar.Text = data(0).Item("MobMadar")
            txtAdres.Text = data(0).Item("Adres")
            txtTahsil.Text = data(0).Item("Tahsil")
            txtMahalTahsil.Text = data(0).Item("MahalTahsil")
            txtShoql.Text = data(0).Item("Shoql")
            txtMahalKar.Text = data(0).Item("MahalKar")
            txtShoqlPedar.Text = data(0).Item("ShoqlPedar")
            txtShoqlMadar.Text = data(0).Item("ShoqlMadar")
            txtTozih.Text = data(0).Item("Tozih")
            txtZamanSabt.Text = String.Format("{0} - {1}", data(0).Item("ZamanSabt"), data(0).Item("TarikhSabt"))
            txtZamanVirayesh.Text = String.Format("{0} - {1}", data(0).Item("ZamanVirayesh"), data(0).Item("TarikhVirayesh"))
            txtTedadVirayesh.Text = data(0).Item("TedadVirayesh")
        End If

        txtNam.Focus()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Khata As Boolean = False
        Try
            Dim TaVafat As String = ""
            If comboVaz.SelectedItem.Value = "z" Then
                TaVafat = ""
            Else
                TaVafat = TarikhVafat.Value.ToString("yyyy/MM/dd")
            End If

            Dim AlanTarikh As String = (New cTarikh).ToString
            Dim AlanSaat As String = (New cSaat).ToString

            If txtCodeMelli.Text = lastCodeMelli OrElse SQLiter.RunCommandScaler(String.Format("select Count(*) from tOzv where CodeMelli like '{0}'", txtCodeMelli.Text)) = "0" Then
                If dID = -1 Then


                    dID = SQLiter.RunCommandScaler("insert into tOzv(Nam,Famil,Pedar,Tavalod,Vafat,Zende,CodeMelli,Tel,Mob,MobPedar,MobMadar,Tahsil,MahalTahsil,Shoql,MahalKar,ShoqlPedar,ShoqlMadar,Adres,Tozih,TarikhSabt,ZamanSabt,TarikhVirayesh,ZamanVirayesh,TedadVirayesh,AxID,SalVorud) values(@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12,@13,@14,@15,@16,@17,@18,@19,@20,@21,@22,@23,-1,@24) ; select scope_identity()",
                                   {
        New SQLiteParameter("@0", txtNam.Text),
        New SQLiteParameter("@1", txtFamil.Text),
        New SQLiteParameter("@2", txtPedar.Text),
        New SQLiteParameter("@3", TarikhTavalod.Value.ToString("yyyy/MM/dd")),
        New SQLiteParameter("@4", TaVafat),
        New SQLiteParameter("@5", comboVaz.SelectedItem.Value),
        New SQLiteParameter("@6", txtCodeMelli.Text),
        New SQLiteParameter("@7", txtTel.Text),
        New SQLiteParameter("@8", txtMob.Text),
        New SQLiteParameter("@9", txtMobPedar.Text),
        New SQLiteParameter("@10", txtMobMadar.Text),
        New SQLiteParameter("@11", txtTahsil.Text),
        New SQLiteParameter("@12", txtMahalTahsil.Text),
        New SQLiteParameter("@13", txtShoql.Text),
        New SQLiteParameter("@14", txtMahalKar.Text),
        New SQLiteParameter("@15", txtShoqlPedar.Text),
        New SQLiteParameter("@16", txtShoqlMadar.Text),
        New SQLiteParameter("@17", txtAdres.Text),
        New SQLiteParameter("@18", txtTozih.Text),
        New SQLiteParameter("@19", AlanTarikh),
        New SQLiteParameter("@20", AlanSaat),
        New SQLiteParameter("@21", ""),
        New SQLiteParameter("@22", ""),
        New SQLiteParameter("@23", 0),
        New SQLiteParameter("@24", txtSalVorud.Value)
                                   })


                Else
                    SQLiter.RunCommand("update tOzv set Nam=@0,Famil=@1,Pedar=@2,Tavalod=@3,Vafat=@4,Zende=@5,CodeMelli=@6 ,Tel=@7,Mob=@8,MobPedar=@9,MobMadar=@10,Tahsil=@11,MahalTahsil=@12 ,Shoql=@13,MahalKar=@14,ShoqlPedar=@15,ShoqlMadar=@16,Adres=@17,Tozih=@18,TarikhVirayesh=@19,ZamanVirayesh=@20,TedadVirayesh=@21, SalVorud=@23 where ID=@22",
                                  {
       New SQLiteParameter("@0", txtNam.Text),
       New SQLiteParameter("@1", txtFamil.Text),
       New SQLiteParameter("@2", txtPedar.Text),
       New SQLiteParameter("@3", TarikhTavalod.Value.ToString("yyyy/MM/dd")),
       New SQLiteParameter("@4", TaVafat),
       New SQLiteParameter("@5", comboVaz.SelectedItem.Value),
       New SQLiteParameter("@6", txtCodeMelli.Text),
       New SQLiteParameter("@7", txtTel.Text),
       New SQLiteParameter("@8", txtMob.Text),
       New SQLiteParameter("@9", txtMobPedar.Text),
       New SQLiteParameter("@10", txtMobMadar.Text),
       New SQLiteParameter("@11", txtTahsil.Text),
       New SQLiteParameter("@12", txtMahalTahsil.Text),
       New SQLiteParameter("@13", txtShoql.Text),
       New SQLiteParameter("@14", txtMahalKar.Text),
       New SQLiteParameter("@15", txtShoqlPedar.Text),
       New SQLiteParameter("@16", txtShoqlMadar.Text),
       New SQLiteParameter("@17", txtAdres.Text),
       New SQLiteParameter("@18", txtTozih.Text),
       New SQLiteParameter("@19", AlanTarikh),
       New SQLiteParameter("@20", AlanSaat),
       New SQLiteParameter("@21", Val(txtTedadVirayesh.Text) + 1),
       New SQLiteParameter("@23", txtSalVorud.Value),
       New SQLiteParameter("@22", dID)
                                  })
                End If
            Else
                MessageBox.Show("کد ملی وارد شده در سیستم وجود دارد. ظاهرا اطلاعات این فرد قبلا در نرم افزار وارد شده است.", "خطا")
                Khata = True
            End If

            If Not Khata Then
                Dim own As frmOzvha = Me.Owner
                own.ReloadData()
                Dim frm As New frmOzvView(dID)
                frm.Show(Me.Owner)
                Me.Close()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class
Imports System.IO
Public Class Accueil
    Private cheminFichier As String = System.IO.Path.Combine(Application.StartupPath, "Score", "score.txt")
    Dim tmp_add As Integer

    Private Sub Accueil_END(sender As Object, e As EventArgs) Handles MyBase.Closing
        End
    End Sub

    Private Sub Accueil_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ListeJoueurs.Clear()
        If File.Exists(cheminFichier) Then
            Dim lignes() As String = File.ReadAllLines(cheminFichier)

            For Each ligne As String In lignes
                Dim parties() As String = ligne.Split(";"c)
                If parties.Length > 0 Then
                    ComboBox1.Items.Add(parties(0))
                    CreerJoueur(parties(0), parties(1), parties(2), parties(3), parties(4))
                End If
            Next

        Else
            MessageBox.Show("Fichier non trouvé.")
        End If
        RadioButton1.Checked = True
        Panel1.Visible = False

        Dim front As String = IO.Path.Combine(Application.StartupPath, "Images", "front.jpg")

        Me.BackgroundImage = Image.FromFile(front)
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub

    Private Sub NouvellePartie_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If ComboBox1.Text.Trim.Length >= 3 And Not ComboBox1.Text.Contains(";") Then
            Dim form2 As New Jeu()
            form2.tmpAdd(tmp_add)
            Me.Hide()
            form2.initChemin(cheminFichier)
            form2.NomJoueurF2(ComboBox1.Text.Trim)
            form2.Show()
        ElseIf ComboBox1.Text.Contains(";") Then
            MessageBox.Show("Le nom contient le caractere interdit  ';' ")
            ComboBox1.Focus()
        Else
            MessageBox.Show("Le nom doit contenir au minimum 3 caractères.")
            ComboBox1.Focus()
        End If

    End Sub

    Private Sub Score_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim form3 As New Score()
        Me.Hide()
        form3.Show()
    End Sub

    Private Sub Quitter_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim choix As MsgBoxResult = MsgBox("êtes vous sûr de quitter?", MsgBoxStyle.YesNo, "confirmation")
        If choix = vbYes Then
            End
        End If
    End Sub

    Private Sub Option_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Panel1.Visible = True Then
            Panel1.Visible = False
        ElseIf Panel1.Visible = False Then
            Panel1.Visible = True
        End If
    End Sub

    Private Sub PanelOption_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim pen As New Pen(Color.Black, 3)
        e.Graphics.DrawRectangle(pen, 0, 0, Panel1.Width - 1, Panel1.Height - 1)
    End Sub

    Private Sub RadioButton1Min_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked Then
            tmp_add = 0
        End If
    End Sub

    Private Sub RadioButton2Min_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked Then
            tmp_add = 60
        End If
    End Sub

    Private Sub RadioButton3Min_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked Then
            tmp_add = 120
        End If
    End Sub
End Class

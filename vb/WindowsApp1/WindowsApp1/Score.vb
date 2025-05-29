Imports System.Security

Public Class Score
    Private Sub Form3_END(sender As Object, e As EventArgs) Handles MyBase.Closing
        End
    End Sub

    Private Sub Score_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        trieNom()
        For Each joueur In ListeJoueurs
            ComboBox1.Items.Add(joueur.getNom())
        Next
        trieDecroissant()
        initListBox()
        Button3.Text = "Croissant"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListeJoueurs.Clear()
        Dim form1 As New Accueil()
        Me.Hide()
        form1.Show()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedItem IsNot Nothing Then
            ComboBox1.Text = ListBox1.SelectedItem.ToString()
        End If
    End Sub

    Private Sub initListBox()
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is ListBox Then
                CType(ctrl, ListBox).Items.Clear()
            End If
        Next
        For Each joueur In ListeJoueurs
            ListBox1.Items.Add(joueur.getNom())
            ListBox2.Items.Add(joueur.getScore())
            ListBox3.Items.Add(joueur.getTempsMin())
            ListBox4.Items.Add(joueur.getNbrParties())
            ListBox5.Items.Add(joueur.getTempsJouer())
        Next
    End Sub
    Private Sub trieCroissant()
        ListeJoueurs = ListeJoueurs _
        .OrderBy(Function(j) j.getScore()) _
        .ThenBy(Function(j) j.getTempsMin()) _
        .ThenBy(Function(j) j.getNom()) _
        .ToList()
    End Sub
    Private Sub trieDecroissant()
        ListeJoueurs = ListeJoueurs _
        .OrderByDescending(Function(j) j.getScore()) _
        .ThenByDescending(Function(j) j.getTempsMin()) _
        .ThenBy(Function(j) j.getNom()) _
        .ToList()
    End Sub

    Private Sub trieNom()
        ListeJoueurs = ListeJoueurs.OrderBy(Function(j) j.getNom()).ToList()
    End Sub

    Private Sub GetStringStatJoueur(nom As String)
        Dim joueur = ListeJoueurs.FirstOrDefault(Function(j) j.getNom() = nom.Trim)
        If joueur Is Nothing Then
            MessageBox.Show("Le joueur na pas ete trouve")
            ComboBox1.Focus()
        Else
            MessageBox.Show("Joueur : " & joueur.getNom & vbCrLf &
                "Score : " & joueur.getScore & vbCrLf &
                "Records : " & joueur.getTempsMin & "sec" & vbCrLf &
                "Nombre de parties : " & joueur.getNbrParties & vbCrLf &
                "Temps jouer : " & joueur.getTempsJouer & "sec")

        End If


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Button3.Text = "Croissant" Then
            Button3.Text = "Decroissant"
            trieCroissant()
            initListBox()
            trieNom()
        ElseIf Button3.Text = "Decroissant" Then
            Button3.Text = "Croissant"
            trieDecroissant()
            initListBox()
            trieNom()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetStringStatJoueur(ComboBox1.Text)
    End Sub
End Class
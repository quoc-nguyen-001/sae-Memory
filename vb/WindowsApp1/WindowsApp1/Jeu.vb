
Public Class Jeu
    Private NomJoueur As String
    Private cheminFichier As String
    Private tmp_add As Integer = 0


    Public Sub NomJoueurF2(nomjoueur As String)
        Me.NomJoueur = nomjoueur
    End Sub

    Public Sub initChemin(cheminfichier As String)
        Me.cheminFichier = cheminfichier
    End Sub

    Public Sub tmpAdd(tmp_add As Integer)
        Me.tmp_add = tmp_add
    End Sub

    Private Sub Form2_END(sender As Object, e As EventArgs) Handles MyBase.Closing
        finJeu()
        End
    End Sub
    Dim basePath As String = System.IO.Path.Combine(Application.StartupPath, "Images")

    Dim head As Image = Image.FromFile(System.IO.Path.Combine(basePath, "head.png"))
    Dim right_arm As Image = Image.FromFile(System.IO.Path.Combine(basePath, "right_arm.png"))
    Dim left_arm As Image = Image.FromFile(System.IO.Path.Combine(basePath, "left_arm.png"))
    Dim right_leg As Image = Image.FromFile(System.IO.Path.Combine(basePath, "right_leg.png"))
    Dim left_leg As Image = Image.FromFile(System.IO.Path.Combine(basePath, "left_leg.png"))
    Dim back_card As Image = Image.FromFile(System.IO.Path.Combine(basePath, "back_card.png"))


    Dim cards As New List(Of Card)
    Private Class Card
        Private Image As Image
        Private Devoiler As Boolean 'Si une carte est devoile son label ne pourra plus etre clicker et etre back_card
        Private Id As String
        Public Sub New(img As Image, devo As Boolean, indice As String)
            Image = img
            Devoiler = devo
            Id = indice
        End Sub

        Public Function getImage()
            Return Image
        End Function
        Public Function getDevo()
            Return Devoiler
        End Function
        Public Function getId()
            Return Id
        End Function

        Public Sub swapImage(img As Image)
            Me.Image = img
        End Sub
        Public Sub swapDevo(devo As Boolean)
            Me.Devoiler = devo
        End Sub

        Public Sub swapId(id As String)
            Me.Id = id
        End Sub

    End Class

    Dim cpt_carre As Integer = 0
    Dim tmp_carre As Integer
    Dim cpt_devo As Integer = 0
    Dim liste_devo As New List(Of Label)
    Dim EstCarre As Boolean = True
    Dim secondesRestantes As Integer = 60

    Private Sub Jeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        initInfo()
        initCard()
        Dim front As String = IO.Path.Combine(Application.StartupPath, "Images", "front.jpg")

        Me.BackgroundImage = Image.FromFile(front)
        Me.BackgroundImageLayout = ImageLayout.Stretch
    End Sub
    Private Sub initInfo()
        secondesRestantes += tmp_add
        Label22.Text = NomJoueur
        If tmp_add = 0 Then
            Label24.Text = "1 min"
        ElseIf tmp_add = 60 Then
            Label24.Text = "2 min"
        ElseIf tmp_add = 120 Then
            Label24.Text = "3 min"
        End If
    End Sub
    Private Sub initCard()
        'apparaitre le dos de carte à tous les cartes
        For i As Integer = 1 To 20
            Dim label1_20 As Label = Me.Controls("Label" & i.ToString())
            label1_20.Text = ""
            label1_20.BackgroundImage = back_card
            label1_20.BackgroundImageLayout = ImageLayout.Stretch
            AddHandler label1_20.Click, AddressOf Card_Click ' que les labels de 1 à 20 ont la fonctionnalité click
        Next

        ' Ajouter les cartes dans la liste
        cards.Clear() 'si ya plusieurs parties alors initialise les cartes
        For i As Integer = 1 To 4
            cards.Add(New Card(left_arm, False, "left_arm"))
            cards.Add(New Card(right_arm, False, "right_arm"))
            cards.Add(New Card(left_leg, False, "left_leg"))
            cards.Add(New Card(right_leg, False, "right_leg"))
            cards.Add(New Card(head, False, "head"))
        Next

        ' Mélanger la liste aléatoirement
        Dim rnd As New Random()
        cards = cards.OrderBy(Function(x) rnd.Next()).ToList()

        Timer1.Interval = 1000

    End Sub

    Private Async Sub Card_Click(sender As Object, e As EventArgs)
        Timer1.Start()
        Dim lbl As Label = CType(sender, Label)
        Dim index As Integer
        Integer.TryParse(New String(lbl.Name.Where(AddressOf Char.IsDigit).ToArray()), index)

        If index >= 1 And index - 1 < cards.Count And cpt_devo < 4 And cards(index - 1).getDevo() = False Then
            Dim img As Image = cards(index - 1).getImage()
            lbl.BackgroundImage = img

            liste_devo.Add(lbl)
            cards(index - 1).swapDevo(True)
            cpt_devo += 1

        End If
        'si les cartes sont les memes
        If liste_devo.Count > 1 Then
            Dim index_label As Integer
            Integer.TryParse(New String(liste_devo(0).Name.Where(AddressOf Char.IsDigit).ToArray()), index_label)
            If cards(index - 1).getId() <> cards(index_label - 1).getId() Then
                EstCarre = False
            End If
        End If


        ' Reset si pas trouve de carre
        If cpt_devo = 4 AndAlso EstCarre = False Then
            Await Task.Delay(500)

            For Each carte As Label In liste_devo
                carte.BackgroundImage = back_card
                Dim index_label As Integer
                Integer.TryParse(New String(carte.Name.Where(AddressOf Char.IsDigit).ToArray()), index_label)
                cards(index_label - 1).swapDevo(False)
            Next
            liste_devo.Clear()
            cpt_devo = 0
            EstCarre = True
            'si trouve carre ajout le nbr de carre trouve de 1
        ElseIf cpt_devo = 4 AndAlso EstCarre = True Then
            tmp_carre = (60 + tmp_add) - secondesRestantes
            liste_devo.Clear()
            cpt_devo = 0
            cpt_carre += 1
        End If

        'fin jeu si trouve 5 carre
        If cpt_carre = 5 Then
            Await Task.Delay(500)
            finJeu()
            Dim form4 As New FinJeu()
            form4.initImages(head, right_arm, left_arm, right_leg, left_leg, tmp_carre, NomJoueur)
            Me.Hide()
            form4.Show()
        End If



    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        secondesRestantes -= 1
        Label24.Text = secondesRestantes & "sec"

        If secondesRestantes <= 0 Then
            Label24.Text = "rip"
            Await Task.Delay(500)
            finJeu()
            Dim form1 As New Accueil()
            Me.Hide()
            form1.Show()
        End If

    End Sub

    Private Sub Abandon_Click(sender As Object, e As EventArgs) Handles Button1.Click
        finJeu()
        Dim form1 As New Accueil()
        Me.Hide()
        form1.Show()
    End Sub

    Private Sub finJeu()
        Timer1.Stop()
        MAJ_Jouer(NomJoueur, cpt_carre, tmp_carre, secondesRestantes, tmp_add)
        EnregistrerFichier(cheminFichier)
        ListeJoueurs.Clear()
    End Sub

End Class
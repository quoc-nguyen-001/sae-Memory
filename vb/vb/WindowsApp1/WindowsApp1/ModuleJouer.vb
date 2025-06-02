Imports System.IO
Imports System.Net.Mime.MediaTypeNames

Module ModuleJouer
    Public Class Joueur
        Private Nom As String
        Private score As Integer
        Private tempsMin As Integer
        Private nbrParties As Integer
        Private tempsJouer As Integer

        Public Function getString()
            Dim s As String = Nom & ";" & score & ";" & tempsMin & ";" & nbrParties & ";" & tempsJouer
            Return s
        End Function

        Public Function getNom()
            Return Nom
        End Function
        Public Function getScore()
            Return score
        End Function
        Public Function getTempsMin()
            Return tempsMin
        End Function
        Public Function getNbrParties()
            Return nbrParties
        End Function
        Public Function getTempsJouer()
            Return tempsJouer
        End Function

        Public Sub New(nom As String)
            Me.Nom = nom
            Me.score = 0
            Me.tempsMin = 0
            Me.nbrParties = 0
            Me.tempsJouer = 0
        End Sub
        Public Sub New(nom As String, score As Integer, tempsMin As Integer, nbrParties As Integer, tempsJouer As Integer)
            Me.Nom = nom
            Me.score = score
            Me.tempsMin = tempsMin
            Me.nbrParties = nbrParties
            Me.tempsJouer = tempsJouer
        End Sub

        Public Sub MettreAJourStats(score As Integer, tempsCarre As Integer, tempsJouer As Integer, tmp_add As Integer)
            nbrParties += 1
            Me.tempsJouer += (60 + tmp_add) - tempsJouer

            If Me.score < score Then
                Me.score = score
                tempsMin = tempsCarre
            ElseIf Me.score = score AndAlso Me.tempsMin < tempsCarre Then
                Me.tempsMin = tempsCarre
            End If
        End Sub
    End Class

    Public ListeJoueurs As New List(Of Joueur)

    Public Function TrouverOuCreerJoueur(nom As String) As Joueur
        Dim joueur = ListeJoueurs.FirstOrDefault(Function(j) j.getNom() = nom)
        If joueur Is Nothing Then
            joueur = New Joueur(nom)
            ListeJoueurs.Add(joueur)
        End If
        Return joueur
    End Function

    Public Sub CreerJoueur(nom As String, score As Integer, tempsMin As Integer, nbrParties As Integer, tempsJouer As Integer)
        Dim joueur = New Joueur(nom, score, tempsMin, nbrParties, tempsJouer)
        ListeJoueurs.Add(joueur)

    End Sub

    Public Sub MAJ_Jouer(nom As String, score As Integer, tempsCarre As Integer, tempsJouer As Integer, tmp_add As Integer)
        Dim joueur = TrouverOuCreerJoueur(nom)
        joueur.MettreAJourStats(score, tempsCarre, tempsJouer, tmp_add)


    End Sub

    Public Sub EnregistrerFichier(cheminFichier As String)
        File.WriteAllText(cheminFichier, "") 'vider le fichier txt

        For Each joueur In ListeJoueurs
            File.AppendAllText(cheminFichier, joueur.getString() & Environment.NewLine) ' ecrire tous les informations des joueurs dans le fichier
        Next
    End Sub

End Module



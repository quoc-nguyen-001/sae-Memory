Public Class FinJeu
    Private head As Image
    Private right_arm As Image
    Private left_arm As Image
    Private right_leg As Image
    Private left_leg As Image
    Private temps As Integer
    Private nom As String


    Public Sub initImages(head As Image, right_arm As Image, left_arm As Image, right_leg As Image, left_leg As Image, temps As Integer, nom As String)
        Me.head = head
        Me.right_arm = right_arm
        Me.left_arm = left_arm
        Me.right_leg = right_leg
        Me.left_leg = left_leg
        Me.temps = temps
        Me.nom = nom
    End Sub
    Private Async Sub FinJeu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label5.Text = nom
        Label7.Text = temps
        Label3.Text = ""
        Label11.Text = ""
        Label8.Text = ""
        Label10.Text = ""
        Label9.Text = ""

        Panel1.BringToFront()
        Panel1.Visible = True
        Await Task.Delay(3000)
        Panel1.Visible = False


        Await Task.Delay(1000)
        Label3.BackgroundImage = head
        Label3.BackgroundImageLayout = ImageLayout.Stretch
        Await Task.Delay(1000)
        Label10.BackgroundImage = right_arm
        Label10.BackgroundImageLayout = ImageLayout.Stretch
        Await Task.Delay(1000)
        Label8.BackgroundImage = left_arm
        Label8.BackgroundImageLayout = ImageLayout.Stretch
        Await Task.Delay(1000)
        Label11.BackgroundImage = right_leg
        Label11.BackgroundImageLayout = ImageLayout.Stretch
        Await Task.Delay(1000)
        Label9.BackgroundImage = left_leg
        Label9.BackgroundImageLayout = ImageLayout.Stretch

        Await Task.Delay(3000)
        Dim form1 As New Accueil()
        Me.Hide()
        form1.Show()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint
        Dim pen As New Pen(Color.Black, 3)
        e.Graphics.DrawRectangle(pen, 0, 0, Panel1.Width - 1, Panel1.Height - 1)
    End Sub
End Class
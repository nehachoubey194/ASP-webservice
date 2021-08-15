

Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Me.BindGrid()
        End If
    End Sub

   Private Sub BindGrid()
        Dim service As New CRUD_ServiceVB.ServiceVB()
        GridView1.DataSource = service.[Get]()
        GridView1.DataBind()
    End Sub
End Class

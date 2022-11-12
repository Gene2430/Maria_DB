Public Class Form1
    Dim lv As ListViewItem
    Dim selected As String

    Private Sub PopListView()
        ListView1.Clear()
        With ListView1
            .View = View.Details
            .GridLines = True
            .Columns.Add("ID", 50)
            .Columns.Add("Last Name", 100)
            .Columns.Add("First Name", 100)
            .Columns.Add("Middle", 50)
            .Columns.Add("Address", 180)
            .Columns.Add("Gender", 50)
            .Columns.Add("Contact", 80)
            .Columns.Add("Position", 80)
        End With

        openCon()
        sql = "Select * from tblempinfo"
        rs = New ADODB.Recordset
        rs.CursorLocation = 3
        rs.Open(sql, cn, 3, 3)


        If rs.RecordCount > 0 Then
            rs.MoveFirst()
            Do Until rs.EOF
                lv = New ListViewItem(rs.Fields("emp_id").Value.ToString)
                lv.SubItems.Add(rs.Fields("emp_last").Value)
                lv.SubItems.Add(rs.Fields("emp_first").Value)
                lv.SubItems.Add(rs.Fields("emp_middle").Value)
                lv.SubItems.Add(rs.Fields("emp_address").Value)
                lv.SubItems.Add(rs.Fields("emp_gender").Value)
                lv.SubItems.Add(rs.Fields("emp_contact").Value)
                lv.SubItems.Add(rs.Fields("emp_position").Value)
                ListView1.Items.Add(lv)
                rs.MoveNext()
            Loop
        End If
        rs.Close()
        cn.Close()

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PopListView()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If MsgBox("Are you sure to Add this record?", vbExclamation + vbYesNo) = vbYes Then
            openCon()
            sql = "Select * from tblempinfo"
            rs = New ADODB.Recordset
            rs.Open(sql, cn, 3, 3)
            rs.AddNew()
            rs.Fields("emp_id").Value = Me.txtId.Text
            rs.Fields("emp_last").Value = Me.txtlastname.Text
            rs.Fields("emp_first").Value = Me.txtfirstname.Text
            rs.Fields("emp_middle").Value = Me.txtmiddle.Text
            rs.Fields("emp_address").Value = Me.txtaddress.Text
            rs.Fields("emp_gender").Value = Me.cmbgender.Text
            rs.Fields("emp_contact").Value = Me.txtcontact.Text
            rs.Fields("emp_position").Value = Me.cmbcourse.Text
            rs.Update()
            rs.Close()
            cn.Close()
        End If
        PopListView()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub
End Class


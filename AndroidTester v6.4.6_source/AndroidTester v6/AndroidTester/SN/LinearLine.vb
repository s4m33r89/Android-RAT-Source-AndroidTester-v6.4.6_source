﻿Imports System.ComponentModel

Namespace SN
    Public Class LinearLine
        Inherits Control
        Private _Color0 As Color

        Private _Color1 As Color

        <Category("Colours")>
        Public Property Colour0 As Color
            Get
                Return Me._Color0
            End Get
            Set(ByVal value As Color)
                Me._Color0 = value
            End Set
        End Property

        <Category("Colours")>
        Public Property Colour1 As Color
            Get
                Return Me._Color1
            End Get
            Set(ByVal value As Color)
                Me._Color1 = value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
            Me._Color0 = Color.FromArgb(0, 0, 0)
            Me._Color1 = Color.FromArgb(0, 0, 0)
            MyBase.SetStyle(ControlStyles.ResizeRedraw, True)
            MyBase.Size = CType((New Point(10, 20)), System.Drawing.Size)
        End Sub

        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            MyBase.OnPaint(e)
            e.Graphics.DrawLine(New Pen(Me.Colour0), 0, 0, 0, 90)
            e.Graphics.DrawLine(New Pen(Me.Colour1), 1, 0, 0, 90)
        End Sub
    End Class
End Namespace

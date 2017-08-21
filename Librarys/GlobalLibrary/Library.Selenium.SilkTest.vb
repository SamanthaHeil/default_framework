'Imports System
'Imports System.Text
'Imports System.Text.RegularExpressions
'Imports System.Threading
'Imports NUnit.Framework
'Imports System.Collections.Generic
'Imports Microsoft.VisualStudio.TestTools.UnitTesting
'Imports SilkTest.Ntf
'Imports SilkTest.Ntf.XBrowser
'Imports Lean.Test.Automation.Framework.LibraryGlobal.libGlobal


'Namespace Library.Selenium.SilkTest
'    <TestFixture()> _
'    Public Class SilkHelper
'        Private verificationErrors As StringBuilder
'        <SetUp()> _
'        Public Sub SetupTest()
'            Try
'                Dim baseState = New BrowserBaseState()
'                baseState.Url = p_pathUrlApp
'                baseState.Execute()
'            Catch ex As Exception
'                HandlerError("Library.Selenium.SilkTest.SetupTest: " & ex.StackTrace & " - " & ex.Message)
'            End Try
'        End Sub

'        <TearDown()> _
'        Public Sub TeardownTest()
'            Try
'                objSeleniumRC.[Stop]()
'            Catch ex As Exception
'                HandlerError("Library.Selenium.SilkTest.TeardownTest: " & ex.StackTrace & " - " & ex.Message)
'            End Try
'        End Sub
'    End Class
'    'class contains all methods to interactin with windows and elements
'    Public Class Interaction

'        Private desk As Desktop = Agent.Desktop
'        Function Open(url As String) As Boolean
'            Try
'                desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).Navigate(url)
'                Return True
'            Catch ex As Exception
'                HandlerError("Library.Selenium.SilkTest.Open: " & ex.StackTrace & " - " & ex.Message)
'                Return False
'            End Try
'        End Function
'        Function OpenWindow(url As String, WindowID As String) As Boolean
'            Try

'                Return True
'            Catch ex As Exception
'                HandlerError("Library.Selenium.SilkTest.OpenWindow: " & ex.StackTrace & " - " & ex.Message)
'                Return False
'            End Try
'        End Function

'        Function SelectWindow(windowID As String) As Boolean
'            Try
'                If Integer.Parse(windowID) = 0 Then
'                    desk.BrowserApplication("WebBrowser").SetActive()
'                Else
'                    desk.BrowserApplication("WebBrowser" + windowID).SetActive()
'                End If
'                Return True
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.SelectWindow: " & ex.StackTrace & " - " & ex.Message)
'                Return False
'            End Try
'        End Function
'        Function exist(element As String, waitMilliseconds As Integer) As Boolean
'            Try
'                Thread.Sleep(waitMilliseconds)
'                If desk.BrowserApplication(strValueWindowApp).BrowserWindow().Exists(element) Then Return True Else Return False
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.exist:" & ex.StackTrace & " - " & ex.Message)
'                Return False
'            End Try
'        End Function
'        Function waitExist(element As String) As Boolean
'            Try
'                For i = 0 To p_timeout
'                    If desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).Exists(element) Then
'                        desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).BrowserObject(element).HighlightObject(1000, Color.BLUE)
'                        Return True
'                    End If
'                    System.Threading.Thread.Sleep(1000)
'                Next
'                Return False
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.exist:" & ex.StackTrace & " - " & ex.Message)
'                Return False
'            End Try
'        End Function
'        'Sub WaitLoadPage()
'        '    Try
'        '        Dim lastTimeout As Integer = p_timeout
'        '        p_timeout = 600
'        '        objSeleniumRC.WaitForPageToLoad(p_timeout)
'        '        p_timeout = lastTimeout
'        '    Catch ex As Exception

'        '    End Try
'        'End Sub
'        Function click(element As String) As Boolean
'            Try
'                If String.IsNullOrEmpty(element) Then Return False
'                If waitExist(element) Then
'                    Try
'                        desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).BrowserObject(element).Click(MouseButton.Left, New Point(2, 2))
'                        Return True
'                    Catch ex As Exception
'                        HandlerError("Library.Silk.Silk4NET.Interaction.Click: " + ex.Message)
'                        Return False
'                    End Try
'                End If
'                Return False
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.Click: " + ex.Message)
'                Return False
'            End Try
'        End Function
'        Function DoubleClick(element As String) As Boolean
'            Try
'                If String.IsNullOrEmpty(element) Then Return False
'                If waitExist(element) Then
'                    Try
'                        desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).BrowserObject(element).Click(MouseButton.Left, New Point(2, 2))
'                        Return True
'                    Catch ex As Exception
'                        HandlerError("Library.Silk.Silk4NET.Interaction.DoubbleClick: " + ex.Message)
'                        Return False
'                    End Try
'                End If
'                Return False
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.Click: " + ex.Message)
'                Return False
'            End Try
'        End Function
'        Function focus(element As String) As Boolean
'            Try
'                If String.IsNullOrEmpty(element) Then Return False
'                If waitExist(element) Then
'                    Try
'                        desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).BrowserObject(element).BrowserObject("gbqfq").SetFocus()
'                        Return True
'                    Catch ex As Exception
'                        HandlerError("LibrarySeleniumRC.Interaction.focus")
'                        Return False
'                    End Try
'                End If
'                Return False
'            Catch ex As Exception
'                HandlerError("LibrarySeleniumRC.Interaction.focus")
'                Return False
'            End Try
'        End Function
'        Public Function setValue(element As String, value As String) As Boolean
'            Try
'                If String.IsNullOrEmpty(element) Then Return False
'                If String.IsNullOrEmpty(value) Then Return False
'                If waitExist(element) Then
'                    Try
'                        Do While Not desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).Text = value
'                            desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).SetText(value)
'                        Loop
'                        Return True
'                    Catch ex As Exception
'                        HandlerError("Library.Silk.Silk4NET.Interaction.setValue")
'                        Return False
'                    End Try
'                End If
'                Return True
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.setValue")
'                Return False
'            End Try
'        End Function
'        'Function selectValue(element As String, value As String) As Boolean
'        '    If String.IsNullOrEmpty(element) Then Return False
'        '    If String.IsNullOrEmpty(value) Then Return True
'        '    If waitExist(element) Then
'        '        Try
'        '            Do While objSeleniumRC.GetSelectedLabel(element) <> value
'        '                Try
'        '                    objSeleniumRC.Select(element, value)
'        '                Catch ex As Exception
'        '                End Try
'        '            Loop
'        '            Return True
'        '        Catch ex As Exception
'        '            HandlerError("LibraryInteractionRC.Interaction.selectValue")
'        '            Return False
'        '        End Try
'        '    End If
'        '    Return False
'        'End Function
'        'Function selectValueByIndex(element As String, value As String) As Boolean
'        '    If String.IsNullOrEmpty(element) Then Return False
'        '    If String.IsNullOrEmpty(value.Replace("index=", "")) Then Return True
'        '    If waitExist(element) Then
'        '        Try
'        '            objSeleniumRC.Select(element, value)
'        '            Return True
'        '        Catch ex As Exception
'        '            HandlerError("LibraryInteractionRC.Interaction.selectValueByIndex")
'        '            Return False
'        '        End Try
'        '    End If
'        '    Return False
'        'End Function
'        'Function selectValueByValue(element As String, value As String) As Boolean
'        '    If String.IsNullOrEmpty(element) Then Return False
'        '    If String.IsNullOrEmpty(value.Replace("value=", "")) Then Return True
'        '    If waitExist(element) Then
'        '        Try
'        '            objSeleniumRC.Select(element, value)
'        '            Return True
'        '        Catch ex As Exception
'        '            HandlerError("LibraryInteractionRC.Interaction.selectValueByValue")
'        '            Return False
'        '        End Try
'        '    End If
'        '    Return False
'        'End Function
'        Function GetText(element As String) As String
'            If String.IsNullOrEmpty(element) Then Return Nothing
'            If Not waitExist(element) Then Return Nothing
'            Try
'                Dim text = desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).BrowserObject(element).GetProperty("Text")
'                Return text
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.GetText")
'                Return Nothing
'            End Try
'        End Function
'        'Function GetAttribute(element As String, attribute As String) As String
'        '    If String.IsNullOrEmpty(element) Then Return Nothing
'        '    If Not waitExist(element) Then Return Nothing
'        '    Try
'        '        Dim text = objSeleniumRC.GetAttribute(element + attribute)
'        '        Return text
'        '    Catch ex As Exception
'        '        HandlerError("LibraryInteractionRC.Interaction.GetAttribute")
'        '        Return Nothing
'        '    End Try
'        'End Function
'        Function GetValue(element As String) As String
'            If String.IsNullOrEmpty(element) Then Return Nothing
'            If Not waitExist(element) Then Return Nothing
'            Try
'                Dim text = desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).BrowserObject(element).GetProperty("Value")
'                Return text
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.GetValue")
'                Return Nothing
'            End Try
'        End Function
'        'Function getSelectedValue(element As String) As String
'        '    If String.IsNullOrEmpty(element) Then Return Nothing
'        '    If waitExist(element) Then
'        '        Try
'        '            Return objSeleniumRC.GetSelectedLabel(element)
'        '        Catch ex As Exception
'        '            HandlerError("LibraryInteractionRC.Interaction.selectValue")
'        '            Return Nothing
'        '        End Try
'        '    End If
'        '    Return False
'        'End Function
'        Function isEditable(element As String) As Boolean
'            Dim text As String = Nothing
'            Dim Editable As Boolean = False
'            Try
'                text = desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).Text
'                desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).SetText("")
'                If text <> desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).Text Then Editable = True
'                desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).SetText(text + "a")
'                If text <> desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).Text Then Editable = True
'                desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTextField(element).SetText(text)
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.IsEditable")
'                Return Nothing
'            End Try
'            Return Editable
'        End Function
'        Function GetTextGridView(element As String, Optional col As Integer = 0, Optional row As Integer = 0, Optional value As String = Nothing) As String
'            Dim text As String = Nothing
'            Try
'                If Not waitExist(element) Then Return Nothing

'                For r = row To 100
'                    For c = col To 100
'                        Try
'                            text = desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTable(element).GetRow(r).GetCell(c).Text
'                        Catch ex As Exception
'                            Exit For
'                        End Try
'                        If text = value Then Return text
'                    Next
'                Next
'                Return Nothing
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.GetCellData")
'                Return Nothing
'            End Try
'        End Function
'        Function GetIndexCol(element As String, Optional col As Integer = 0, Optional row As Integer = 0, Optional value As String = Nothing) As String
'            Dim text As String = Nothing
'            Try
'                If Not waitExist(element) Then Return Nothing
'                For r = row To 100
'                    For c = col To 100
'                        Try
'                            text = desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTable(element).GetRow(r).GetCell(c).Text
'                        Catch ex As Exception
'                            Exit For
'                        End Try
'                        If text = value Then Return c
'                    Next
'                Next
'                Return Nothing
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.GetCellData")
'                Return Nothing
'            End Try
'        End Function
'        Function GetIndexRow(element As String, Optional col As Integer = 0, Optional row As Integer = 0, Optional value As String = Nothing) As String
'            Dim text As String = Nothing
'            Try
'                If Not waitExist(element) Then Return Nothing
'                For r = row To 100
'                    For c = col To 100
'                        Try
'                            text = desk.BrowserApplication(strValueWindowApp).BrowserWindow(strValueWindow).DomTable(element).GetRow(r).GetCell(c).Text
'                        Catch ex As Exception
'                            Exit For
'                        End Try
'                        If text = value Then Return r
'                    Next
'                Next
'                Return Nothing
'            Catch ex As Exception
'                HandlerError("Library.Silk.Silk4NET.Interaction.GetCellData")
'                Return Nothing
'            End Try
'        End Function
'        'Function GetTextGridViewByRow(table As String, value As String, attribute As String, col As Integer, Optional element As String = "", Optional row As Integer = 1) As String
'        '    Dim text As String = Nothing
'        '    Try
'        '        If Not waitExist(table) Then Return Nothing
'        '        For r = row To 100
'        '            Try
'        '                text = GetAttribute(table + "/tr[" + r.ToString() + "]/td[" + col.ToString() + "]" + element, attribute)
'        '                If InStr(text, value) > 0 Then
'        '                    Return r
'        '                End If
'        '            Catch ex As Exception
'        '            End Try
'        '        Next
'        '        Return Nothing
'        '    Catch ex As Exception
'        '        HandlerError("LibraryInteractionRC.Interaction.GetCellData")
'        '        Return Nothing
'        '    End Try
'        'End Function
'        'Function GetCellDataByReference(element As String, reference As String, colRefer As Integer, colTarget As Integer, Optional rowRefer As Integer = 0) As String
'        '    Dim text As String = Nothing
'        '    Try
'        '        If Not waitExist(element) Then Return Nothing
'        '        For r = rowRefer To 100
'        '            Try
'        '                text = objSeleniumRC.GetTable(element & "." & r & "." & colRefer)
'        '                If text = reference Then
'        '                    Return objSeleniumRC.GetTable(element & "." & r & "." & colTarget)
'        '                End If
'        '                Return text
'        '            Catch ex As Exception
'        '                Exit For
'        '            End Try
'        '        Next
'        '        Return Nothing
'        '    Catch ex As Exception
'        '        HandlerError("LibraryInteractionRC.Interaction.GetCellDataByReference")
'        '        Return Nothing
'        '    End Try
'        'End Function
'    End Class
'End Namespace


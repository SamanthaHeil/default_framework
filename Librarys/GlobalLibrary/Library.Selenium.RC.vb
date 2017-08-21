Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports NUnit.Framework
Imports Selenium
Imports Lean.Test.Automation.Framework.LibraryGlobal.libGlobal
Imports Lean.Test.Automation.API
Namespace LibrarySeleniumRC
    <TestFixture()>
    Public Class SeleniumRCHelper
        Private verificationErrors As StringBuilder
        <SetUp()>
        Public Sub SetupTest()
            Try
                objSeleniumRC = New DefaultSelenium(p_ServerRC, p_portRC, SelectBrowser(p_browserType), p_pathUrlApp)
                objSeleniumRC.Start()
                verificationErrors = New StringBuilder()
            Catch ex As Exception
                objSeleniumRC = New DefaultSelenium(p_ServerRC, p_portRC, SelectBrowser(p_browserType), p_pathUrlApp)
                objSeleniumRC.Start()
                verificationErrors = New StringBuilder()
                MsgBox("LibrarySeleniumRC.SetupTest: " & ex.Message)
                HandlerError("LibrarySeleniumRC.SetupTest: " & ex.Message)
            End Try
        End Sub

    End Class
    'class contains all methods to interactin with windows and elements
    Public Class InteractionRC
        Private IDenType As String = "xpath="
        Function Open(url As String) As Boolean
            Try
                objSeleniumRC.Open(url)
                Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Interaction.Open: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function OpenWindow(url As String, WindowID As String) As Boolean
            Try
                objSeleniumRC.OpenWindow(url, WindowID)
                Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Interaction.OpenWindow: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function WaitForPageToLoad(Optional TimeOut As Integer = 30000, Optional element As String = Nothing, Optional isEditable As Boolean = True) As Boolean
            Try
                objSeleniumRC.WaitForPageToLoad(TimeOut)
                Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Interaction.WaitForPageToLoad: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function SelectWindow(windowID As String) As Boolean
            Try
                objSeleniumRC.SelectWindow(windowID)
                Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Interaction.SelectWindow: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function Exist(element As String, waitMilliseconds As Integer) As Boolean
            Try
                Thread.Sleep(waitMilliseconds)
                If objSeleniumRC.IsElementPresent(IDenType & element) Then Return True Else Return False
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Interaction.exist:" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function WaitExist(element As String) As Boolean
            Try
                For i = 0 To p_timeout Step 100
                    If objSeleniumRC.IsElementPresent(IDenType & element) Then
                        If p_Highlight Then objSeleniumRC.Highlight(IDenType & element)
                        Return True
                    End If
                    Console.Write("Element: " & element & "time: " & i)
                    Thread.Sleep(100)
                Next
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message)
                Return False
            End Try
        End Function
        Function GetHtmlSource()
            Try
                Return objSeleniumRC.GetHtmlSource()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Sub Clear(element As String)
            Try
                objSeleniumRC.Type(IDenType & element, "")
            Catch ex As Exception

            End Try
        End Sub
        Sub TypeKeys(element As String, value As String)
            Try
                objSeleniumRC.TypeKeys(IDenType & element, value)
            Catch ex As Exception

            End Try
        End Sub
        Sub WindowMaximize()
            Try
                objSeleniumRC.WindowMaximize()
            Catch ex As Exception

            End Try
        End Sub
        Sub WindowFocus()
            Try
                objSeleniumRC.WindowFocus()
            Catch ex As Exception

            End Try
        End Sub
        Sub Refresh()
            Try
                objSeleniumRC.Refresh()
            Catch ex As Exception

            End Try
        End Sub

        Function click(element As String) As Boolean
            Try

                If String.IsNullOrEmpty(element) Then Return False
                If WaitExist(IDenType & element) Then
                    Try
                        objSeleniumRC.Click(IDenType & element)
                        Return True
                    Catch ex As Exception
                        'Throw New Exception("Click element error: " & ex.Message)
                        Return False
                    End Try
                End If
                Return False
            Catch ex As Exception
                HandlerError("LibrarySeleniumRC.Interaction.click")
                Return False
            End Try
        End Function
        Function DoubleClick(element As String) As Boolean
            Try
                If String.IsNullOrEmpty(element) Then Return False
                If WaitExist(IDenType & element) Then
                    Try
                        objSeleniumRC.DoubleClick(IDenType & element)
                        Return True
                    Catch ex As Exception
                        HandlerError("LibrarySeleniumRC.Interaction.click")
                        Return False
                    End Try
                End If
                Return False
            Catch ex As Exception
                HandlerError("LibrarySeleniumRC.Interaction.click")
                Return False
            End Try
        End Function

        Public Function Type(element As String, value As String) As Boolean
            Dim counTry As Integer = 0
            Try
                If String.IsNullOrEmpty(element) Then Return True
                If WaitExist(IDenType & element) Then
                    Try
                        Do While Not objSeleniumRC.GetValue(IDenType & element) = Trim(value)
                            objSeleniumRC.Type(IDenType & element, "")
                            objSeleniumRC.Type(IDenType & element, value)
                            Test.Wait(200)
                            counTry += 1
                            If counTry > 3 Then Throw New Exception("O valor digitado nao corresponde ao valor apresentado pela tela")
                        Loop
                        Return True
                    Catch ex As Exception
                        HandlerError("LibraryInteractionRC.Interaction.Type")
                        Return False
                    End Try
                End If
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.Type")
                Return False
            End Try
            Return Nothing
        End Function

        Function SelectValue(element As String, value As String) As String
            If String.IsNullOrEmpty(element) Then Throw New Exception("element name can not be empty")
            If String.IsNullOrEmpty(value) Then Return True
            If WaitExist(IDenType & element) Then
                Try
                    For i = 0 To p_timeout Step 100
                        Try
                            objSeleniumRC.Select(IDenType & element, value)
                            Test.Wait(100)
                        Catch ex As Exception
                            p_errorDescription = ex.Message
                        End Try
                        If objSeleniumRC.GetSelectedLabel(IDenType & element) = value Then Return True
                    Next
                    Throw New Exception("value: (" & value & ") not found!")
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                    HandlerError("LibraryInteractionRC.Interaction.selectValue: " & ex.Message)
                    Return False
                End Try
            End If
            Return False
        End Function
        Function GetText(element As String) As String
            If String.IsNullOrEmpty(element) Then Return Nothing
            If Not WaitExist(IDenType & element) Then Return Nothing
            Try
                Dim text = objSeleniumRC.GetText(IDenType & element)
                Return text
            Catch ex As Exception
                'Throw New Exception(ex.Message)
                HandlerError("LibraryInteractionRC.Interaction.selectValue")
                Return "Warning: Element not found! - Element: " & element
            End Try
        End Function
        Function GetValue(element As String) As String
            If String.IsNullOrEmpty(element) Then Return Nothing
            If Not WaitExist(IDenType & element) Then Return Nothing
            Try
                Dim text = objSeleniumRC.GetValue(IDenType & element)
                Return text
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.selectValue")
                Return "Warning: Element not found! - Element: " & element
            End Try
        End Function
        Function GetTextPopup(Optional click As Boolean = True) As String
            Stop
            Dim msg As String = Nothing
            Try
                Dim alert = objSeleniumWD.SwitchTo().Alert()
                msg = alert.Text
                If click Then alert.Accept()
                Return msg
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.selectValue")
                Return Nothing
            End Try
        End Function
        Function GetSelectedValue(element As String) As String
            If String.IsNullOrEmpty(element) Then Return Nothing
            If WaitExist(IDenType & element) Then
                Try
                    Return objSeleniumRC.GetSelectedLabel(IDenType & element)
                Catch ex As Exception
                    HandlerError("LibraryInteractionRC.Interaction.selectValue")
                    Return Nothing
                End Try
            End If
            Return False
        End Function
        Function isEditable(element As String) As Boolean
            If String.IsNullOrEmpty(element) Then Return False
            If WaitExist(IDenType & element) Then
                Try
                    If objSeleniumRC.IsEditable(IDenType & element) Then
                        Return True
                    Else
                        Return False
                    End If
                Catch ex As Exception
                    HandlerError("LibraryInteractionRC.Interaction.waitLoadElement")
                    Return False
                End Try
            End If
            Return False
        End Function
        Function GetCellData(element As String, Optional col As Integer = 0, Optional row As Integer = 0, Optional value As String = Nothing) As String
            Dim text As String = Nothing
            Try
                If Not WaitExist(IDenType & element) Then Return Nothing
                For r = row To 100
                    For c = col To 100
                        Try
                            text = objSeleniumRC.GetTable(IDenType & element & "." & r & "." & c)
                        Catch ex As Exception
                            Exit For
                        End Try
                        If text = value Then Return text
                    Next
                Next
                Return Nothing
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.GetCellData")
                Return Nothing
            End Try
        End Function

        Function GetCellDataByReference(element As String, reference As String, colRefer As Integer, colTarget As Integer, Optional rowRefer As Integer = 0) As String
            Dim text As String = Nothing
            Try
                If Not WaitExist(IDenType & element) Then Return Nothing
                For r = rowRefer To 100
                    Try
                        text = objSeleniumRC.GetTable(IDenType & element & "." & r & "." & colRefer)
                        If text = reference Then
                            Return objSeleniumRC.GetTable(IDenType & element & "." & r & "." & colTarget)
                        End If
                        Return text
                    Catch ex As Exception
                        Exit For
                    End Try
                Next
                Return Nothing
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.GetCellDataByReference")
                Return Nothing
            End Try
        End Function
        Public Sub TeardownTest()
            Try
                objSeleniumRC.[Stop]()
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Helper.TeardownTest: " & ex.StackTrace & " - " & ex.Message)
            End Try
            ' Assert.AreEqual("", verificationErrors.ToString())
        End Sub
    End Class
End Namespace

Imports System
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports NUnit.Framework
Imports Selenium
Imports Lean.Test.Automation.Framework.LibraryGlobal.libGlobal
Imports Lean.Test.Automation.API
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Remote
Imports OpenQA
Imports OpenQA.Selenium.IE
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Firefox
Imports OpenQA.Selenium.Safari
Imports System.Drawing.Imaging
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports OpenQA.Selenium.Interactions

Namespace LibrarySeleniumWDBrowserStack
    Public Class ScreenShotRemoteWebDriver
        Inherits RemoteWebDriver
        Implements ITakesScreenshot
        Public Sub New(uri As Uri, dc As DesiredCapabilities)
            MyBase.New(uri, dc)
        End Sub

        Public Function GetScreenshots() As OpenQA.Selenium.Screenshot
            Dim screenshotResponse As Response = Me.Execute(DriverCommand.Screenshot, Nothing)
            Dim base64 As String = screenshotResponse.Value.ToString()
            Return New OpenQA.Selenium.Screenshot(base64)
        End Function
    End Class
    <TestClass()> _
    Public Class WDBrowserStackHelper
        'Public driver As ScreenShotRemoteWebDriver
        Private capability As New DesiredCapabilities

        <TestInitialize()>
        Public Sub SetupTest()
            Try
                Select Case p_ToolName
                    Case ActiveTool.SeleniumWDBrowserStack
                        capability.SetCapability("browser", "IE")
                        capability.SetCapability("browser_version", "9.0")
                        capability.SetCapability("os", "Windows")
                        capability.SetCapability("os_version", "7")
                        capability.SetCapability("resolution", "1024x768")

                        capability.SetCapability("build", "screenshot test")
                        capability.SetCapability("browserstack.debug", "true")
                        capability.SetCapability("browserstack.user", "sergiosuba3")
                        capability.SetCapability("browserstack.key", "eWJyQvHFwNcoNMzxP4ob")
                        capability.SetCapability("browserstack.local", "true")
                        capability.SetCapability("browserstack.localIdentifier", "Test123")
                        capability.SetCapability("acceptSslCerts", "true") 'certificados

                        'driver.Navigate().GoToUrl("http://<username>:<password>@yourdomain")
                        objSeleniumWDBS = New ScreenShotRemoteWebDriver(New Uri("http://hub.browserstack.com/wd/hub/"), capability)
                End Select

            Catch ex As Exception
                'handler error
            End Try
        End Sub
        <TestCleanup()>
        Public Sub Termination()
            objSeleniumWDBS.Quit()
        End Sub

    End Class
    'class contains all methods to interactin with windows and elements
    Public Class InteractionWDBrowseerStack
        'Private driver As New WDBrowserStackHelper
        Function Open(url As String) As Boolean
            Try
                objSeleniumWDBS.Navigate.GoToUrl(url)
                Console.WriteLine(objSeleniumWDBS.Title)
                Console.WriteLine(vbCrLf)
                Return True
            Catch ex As Exception
                HandlerError("LibraryobjSeleniumWD.InteractionWDBrowseerStack.Open: " & url & " Error:" & ex.Message & " - " & ex.InnerException.ToString)
                Return False
            End Try
        End Function
        Function WaitForPageToLoad(Optional timeOut As Integer = 0) As Boolean
            timeOut = IIf(timeOut <> 0, timeOut, p_timeout)
            Try
                Console.WriteLine("WaitForPageToLoad: Timeout = " & p_timeout)
                objSeleniumWDBS.Manage.Timeouts().SetPageLoadTimeout(System.TimeSpan.FromSeconds(p_timeout))
            Catch ex As Exception
                HandlerError("LibraryobjSeleniumWD.InteractionWDBrowseerStack.WaitForPageToLoad: Error: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        'VERIFICAR*******************************************************
        Function OpenWindow(url As String, WindowID As String) As Boolean
            Try
                'objSeleniumWDBS.OpenWindow(url, WindowID)
                Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Interaction.OpenWindow: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        'VERIFICAR*******************************************************
        Function SelectWindow(windowID As String) As Boolean
            Try
                'objSeleniumRC.SelectWindow(windowID)
                Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Selenium.Interaction.SelectWindow: " & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function Exist(element As String, waitMilliseconds As Integer) As Boolean

            Try
                Thread.Sleep(waitMilliseconds)
                If waitLoadElement(element, False) Then Return True Else Return False
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Interaction.exist:" & ex.StackTrace & " - " & ex.Message)
                Return False
            End Try
        End Function
        Function WaitExist(element As String) As Boolean

            Try
                If waitLoadElement(element, True) Then Return True
            Catch ex As Exception
                HandlerError("Library.Selenium.RC.Interaction.exist:" & ex.StackTrace & " - " & ex.Message)
                Throw New Exception(ex.Message)
                Return False
            End Try
        End Function
        'VERIFICAR*******************************************************
        Function GetHtmlSource()
            Try
                'Return objSeleniumWDBS
            Catch ex As Exception
                Return Nothing
            End Try
            Return Nothing
        End Function
        Sub Clear(element As String)

            Try
                Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                webElement.Clear()
            Catch ex As Exception

            End Try
        End Sub
        Sub TypeKeys(element As String, value As String)
            Try

                Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                webElement.SendKeys(value)
            Catch ex As Exception

            End Try
        End Sub
        Sub WindowMaximize()
            Try
                objSeleniumWDBS.Manage.Window.Maximize()
            Catch ex As Exception

            End Try
        End Sub
        'VERIFICAR*******************************************************
        Sub WindowFocus()
            Try
                ' objSeleniumRC.WindowFocus()
            Catch ex As Exception

            End Try
        End Sub
        Sub Refresh()
            Try
                objSeleniumWDBS.Navigate.Refresh()
            Catch ex As Exception

            End Try
        End Sub
        Function mouseOver(element As String) As Boolean

            Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
            Dim action As Actions = Nothing
            Try
                action.MoveToElement(webElement).Build.Perform()
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        Function click(element As String) As Boolean
            Try

                If String.IsNullOrEmpty(element) Then Return False
                If WaitExist(element) Then
                    Try
                        Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                        webElement.Click()
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
        Function DoubleClick(element As String) As Boolean

            Try
                If String.IsNullOrEmpty(element) Then Return False
                If WaitExist(element) Then
                    Try
                        Dim act As Actions = Nothing
                        act.DoubleClick(objSeleniumWDBS.FindElement(By.XPath(element))).Build().Perform()
                        Return True
                    Catch ex As Exception
                        HandlerError("LibrarySeleniumRC.Interaction.click")
                        Return False
                    End Try
                End If
                Return False
            Catch ex As Exception

            End Try
            HandlerError("LibrarySeleniumRC.Interaction.click")
            Return False
        End Function

        Public Function Type(element As String, value As String) As Boolean
            Dim counTry As Integer = 0
            Try

                If String.IsNullOrEmpty(element) Then Return True
                'If String.IsNullOrEmpty(value) Then Return True
                If WaitExist(element) Then
                    Try
                        Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                        Do While Not webElement.GetAttribute("value") = Trim(value)
                            webElement.Clear()
                            webElement.SendKeys(value)
                            Test.Wait(200)
                            counTry += 1
                            If counTry > 3 Then Throw New Exception("O valor digitado nao corresponde ao valor apresentado pela tela")
                        Loop
                        Return True
                    Catch ex As Exception
                        HandlerError("LibraryInteractionRC.Interaction.Type")
                        Return False
                    End Try
                Else
                    Return False
                End If
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.Type")
                Return False
            End Try
            Return Nothing
        End Function

        Function SelectValue(element As String, value As String) As Boolean

            If String.IsNullOrEmpty(element) Then Return True
            If String.IsNullOrEmpty(value) Then Return True

            If WaitExist(element) Then
                Try
                    Do
                        Try

                            Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                            webElement.SendKeys(value)
                            Test.Wait(100)
                        Catch ex As Exception
                        End Try
                    Loop While objSeleniumRC.GetSelectedLabel(element) <> value
                    Return True
                Catch ex As Exception
                    HandlerError("LibraryInteractionRC.Interaction.selectValue")
                    Return False
                End Try
            End If
            Return False
        End Function
        Function GetText(element As String) As String

            If String.IsNullOrEmpty(element) Then Return Nothing
            If Not WaitExist(element) Then Return Nothing
            Try
                Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                Return webElement.Text
            Catch ex As Exception
                Throw New Exception(ex.Message)
                Return Nothing
            End Try
        End Function
        Function GetValue(element As String) As String

            If String.IsNullOrEmpty(element) Then Return Nothing
            If Not WaitExist(element) Then Return Nothing
            Try
                Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                Return webElement.GetAttribute("value")
            Catch ex As Exception
                HandlerError("LibraryInteractionRC.Interaction.selectValue")
                Return Nothing
            End Try
        End Function
        Function GetSelectedValue(element As String) As String

            If String.IsNullOrEmpty(element) Then Return Nothing
            If WaitExist(element) Then
                Try
                    Dim webElement As IWebElement = objSeleniumWDBS.FindElement(By.XPath(element))
                    Return webElement.GetAttribute("Value")
                Catch ex As Exception
                    HandlerError("LibraryInteractionRC.Interaction.selectValue")
                    Return Nothing
                End Try
            End If
            Return False
        End Function
        Function isEditable(element As String) As Boolean

            If String.IsNullOrEmpty(element) Then Return False
            If WaitExist(element) Then
                Try
                    If objSeleniumWDBS.FindElement(By.Id(element)).Enabled Then
                        Console.WriteLine("waitLoadElement: " & element)
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
        'VERIFICAR******************************************************
        Function GetCellData(element As String, Optional col As Integer = 0, Optional row As Integer = 0, Optional value As String = Nothing) As String
            Dim text As String = Nothing
            Try
                If Not WaitExist(element) Then Return Nothing
                For r = row To 100
                    For c = col To 100
                        Try
                            ' text = objSeleniumWDBS.GetTable(element & "." & r & "." & c)
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
        'VERIFICAR******************************************************
        Function GetCellDataByReference(element As String, reference As String, colRefer As Integer, colTarget As Integer, Optional rowRefer As Integer = 0) As String

            Dim text As String = Nothing
            Try
                If Not WaitExist(element) Then Return Nothing
                For r = rowRefer To 100
                    Try
                        text = objSeleniumRC.GetTable(element & "." & r & "." & colRefer)
                        If text = reference Then
                            Return objSeleniumRC.GetTable(element & "." & r & "." & colTarget)
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
        ' different functions
        Function waitLoadElement(element As String, isEditable As Boolean) As Boolean

            Try
                For i = 0 To p_timeout
                    Try

                        If objSeleniumWDBS.FindElement(By.XPath(element)).Displayed Then
                            Return True
                        End If
                    Catch ex As Exception
                        Thread.Sleep(1000)
                    End Try
                Next
                Throw New Exception("waitLoadElement: Element=" & element & " not found")
                Return False
            Catch ex As Exception
                Throw New Exception(ex.Message)
                HandlerError("LibraryobjSeleniumWD.InteractionWDBrowseerStack.waitLoadElement: " & element)
                Return False
            End Try
        End Function
        Public Sub TeardownTest()
            Try
                objSeleniumWDBS.Quit()
            Catch generatedExceptionName As Exception
                ' Ignore errors if unable to close the browser
            End Try
            ' Assert.AreEqual("", verificationErrors.ToString())
        End Sub
    End Class
End Namespace

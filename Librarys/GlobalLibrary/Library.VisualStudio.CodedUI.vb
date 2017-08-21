'Imports Lean.Test.Automation.Framework.LibraryGlobal.libGlobal
'Imports System.Threading

'Namespace LibraryVisualStudioCodedUI
'    Public Class InteractionVS
'        Inherits WinWindow
'        Private mWinName As winName

'        'open url
'        Function Open(url As String, Optional element As String = Nothing) As Boolean
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function WaitForPageToLoad(Optional timeOut As Integer = 0) As Boolean
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function OpenWindow(url As String, WindowID As String) As Boolean
'            Try
'            Catch ex As Exception

'            End Try
'        End Function
'        Function Exist(element As String, waitMilliseconds As Integer, Optional typeIdentification As typeIdentification = typeIdentification.xpath) As Boolean
'            Try
'                Thread.Sleep(waitMilliseconds)

'            Catch ex As Exception

'            End Try
'        End Function
'        Function WaitExist(element As String, Optional typeIdentification As typeIdentification = typeIdentification.xpath) As Boolean
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function GetHtmlSource()
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Sub Clear(element As String)
'            Try

'            Catch ex As Exception

'            End Try
'        End Sub
'        Sub TypeKeys(element As String)
'            Try

'            Catch ex As Exception

'            End Try
'        End Sub
'        Sub WindowMaximize()
'            Try

'            Catch ex As Exception

'            End Try
'        End Sub
'        Sub Refresh()
'            Try

'            Catch ex As Exception

'            End Try
'        End Sub
'        Function MouseOver(element As String) As Boolean
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function click(element As String, Optional typeIdentification As typeIdentification = typeIdentification.xpath, Optional waitElement As Boolean = True) As Boolean
'            Try
'                If String.IsNullOrEmpty(element) Then Return False
'                If waitElement Then
'                    If WaitExist(element, typeIdentification) Then
'                        Try

'                        Catch ex As Exception

'                        End Try
'                    End If
'                End If
'            Catch ex As Exception

'            End Try
'        End Function
'        Function DoubleClick(element As String) As Boolean

'            Try
'                If String.IsNullOrEmpty(element) Then Return False
'                If WaitExist(element) Then
'                    Try

'                    Catch ex As Exception

'                    End Try
'                End If
'                    Catch ex As Exception
'            End Try
'        End Function
'        Function GetText(element As String, Optional typeIdentification As typeIdentification = typeIdentification.xpath) As String
'            If String.IsNullOrEmpty(element) Then Return Nothing
'            If Not WaitExist(element, typeIdentification) Then Return Nothing
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function GetValue(element As String, Optional typeIdentification As typeIdentification = typeIdentification.xpath) As String
'            If String.IsNullOrEmpty(element) Then Return Nothing
'            'If Not WaitExist(element, typeIdentification) Then Return Nothing
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function GetTextPopup(Optional click As Boolean = True) As String
'            Dim msg As String = Nothing
'            Try

'            Catch ex As Exception

'            End Try
'        End Function
'        Function GetSelectedValue(element As String) As String
'            If String.IsNullOrEmpty(element) Then Return Nothing
'            If WaitExist(element) Then
'                Try

'                Catch ex As Exception

'                End Try
'            End If
'        End Function
'        Function isEditable(element As String) As Boolean
'            If String.IsNullOrEmpty(element) Then Return False
'            If WaitExist(element) Then
'                Try



'                Catch ex As Exception

'                End Try
'            End If
'        End Function
'        Sub TearDownTest()
'            Try

'            Catch ex As Exception

'            End Try
'        End Sub

'        Function Type(element As String, value As String)
'            Try
'                p_ObjName = element
'                Dim textBox As WinEdit = winName.winSearch.editBox

'                textBox.Text = value
'            Catch ex As Exception
'                Return False
'            End Try
'            Return True
'        End Function
'        Public Function SelectValue(element As String, value As String)
'            Try
'                p_ObjName = element
'                Dim combobox As WinComboBox = winName.winSearch.comboBox
'                combobox.SelectedItem = value
'            Catch ex As Exception

'            End Try
'        End Function
'        '###############################################################################################################################
'        'COMMON windows objetcs
'        'common
'        Public ReadOnly Property winName() As winName
'            Get
'                If (Me.mWinName Is Nothing) Then
'                    Me.mWinName = New winName()
'                End If
'                Return Me.mWinName
'            End Get
'        End Property
'    End Class

'    'window
'    Public Class winName
'        Inherits WinWindow
'        Private mWinSearch As winSearch

'        Public Sub New()
'            MyBase.New()
'            Me.SearchProperties(WinWindow.PropertyNames.Name) = p_WinName
'            Me.SearchProperties.Add(New PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains))
'            ' Me.WindowTitles.Add("Validar Deploy QA")
'        End Sub

'        Public ReadOnly Property winSearch() As winSearch
'            Get
'                If (Me.mWinSearch Is Nothing) Then
'                    Me.mWinSearch = New winSearch(Me)
'                End If
'                Return Me.mWinSearch
'            End Get
'        End Property
'    End Class

'    Public Class winSearch
'        Inherits WinWindow
'        Private mEditBox As WinEdit
'        Private mCombobox As WinComboBox

'        Public Sub New(ByVal searchLimitContainer As UITestControl)
'            MyBase.New(searchLimitContainer)

'            Me.SearchProperties(WinWindow.PropertyNames.Name) = p_WinName
'            Me.SearchProperties.Add(New PropertyExpression(WinWindow.PropertyNames.ClassName, "WindowsForms10.Window", PropertyExpressionOperator.Contains))
'            'Me.WindowTitles.Add("Validar Deploy QA")
'            Me.SearchProperties(WinWindow.PropertyNames.ControlName) = p_ObjName

'        End Sub

'        Public ReadOnly Property editBox() As WinEdit
'            Get
'                If (Me.mEditBox Is Nothing) Then
'                    Me.mEditBox = New WinEdit(Me)
'                    'Me.mUITxtIDScenarioEdit.SearchProperties(WinEdit.PropertyNames.Name) = "Field Target"
'                    'Me.mUITxtIDScenarioEdit.WindowTitles.Add("Validar Deploy QA")
'                End If
'                Return Me.mEditBox
'            End Get
'        End Property
'        Public ReadOnly Property comboBox() As WinComboBox
'            Get
'                If (Me.mCombobox Is Nothing) Then
'                    Me.mCombobox = New WinComboBox(Me)
'                End If
'                Return Me.mCombobox
'            End Get
'        End Property
'    End Class
'End Namespace
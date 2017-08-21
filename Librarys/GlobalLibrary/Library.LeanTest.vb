Imports Lean.Test.Automation.API
Imports Lean.Test.Automation.Framework.LibraryGlobal
Imports Lean.Test.Automation.Framework.LibraryGlobal.LibGlobal

Namespace LibraryLeanTest
    Public Class InteractionLeanTest

        Sub Clear(element As String)
            Try

            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
                Throw New Exception("Clear element error: " & p_errorDescription)
            End Try
        End Sub

        Sub WindowMaximize()
            Try

            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
                Throw New Exception("Windows maximize error: " & p_errorDescription)
            End Try
        End Sub
        'VERIFICAR*******************************************************
        Sub WindowFocus()
            Try

            Catch ex As Exception

            End Try
        End Sub
        Sub Wait(milliSecondWait)
            Try
                System.Threading.Thread.Sleep(milliSecondWait)
            Catch ex As Exception

            End Try
        End Sub

        Function Click(coordinates As String) As Boolean
            Try
                Dim cood As String() = coordinates.Split(",")
                Wait(p_speedyExecution)
                Dim dv = New Devices
                Dim p = New MousePositions
                dv.MouseClick(cood(0), cood(1))
            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
                HandlerError("LibraryLeanTest.Interaction.click")
                Throw New Exception(ex.Message)
                Return False
            End Try
        End Function

        Function DobleClick(coordinates As String) As Boolean
            Try
                Dim cood As String() = coordinates.Split(",")
                Wait(p_speedyExecution)
                Dim dv = New Devices
                Dim p = New MousePositions
                dv.MouseClick(cood(0), cood(1))
                dv.MouseClick(cood(0), cood(1))
            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
                HandlerError("LibraryLeanTest.Interaction.click")
                Throw New Exception(ex.Message)
                Return False
            End Try
        End Function

        Public Function Type(coordinates As String, value As String) As Boolean
            Try
                Dim dv = New Devices
                If String.IsNullOrEmpty(value) Then Return True
                Click(coordinates)
                dv.SendKeyWait("{SELECT}")
                dv.SendKeyWait(value)
            Catch ex As Exception
                p_errorDescription = "Menssage error: " & ex.Message.ToString
                HandlerError("LibraryInteractionRC.Interaction.Type")
                Throw New Exception(ex.Message)
                Return False
            End Try
            Return Nothing
        End Function

        Function SelectValue(element As String, value As String, Optional typeIdentification As typeIdentification = typeIdentification.xpath) As Boolean

        End Function
    End Class
End Namespace
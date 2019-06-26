Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class TitularizeTestes
    Inherits InsufladorTesteBase

    <TestMethod>
    Public Sub Titularize()
        For Each pair In MyBase.TesteData
            Assert.AreEqual(pair.Key.Titularize(), pair.Value)
            Debug.WriteLine(pair.Key & " - " & pair.Key.Titularize())
        Next
    End Sub

    Public Sub New()
        MyBase.TesteData.Add("some title", "Some Title")
        MyBase.TesteData.Add("some-title", "Some Title")
        MyBase.TesteData.Add("sometitle", "Sometitle")
        MyBase.TesteData.Add("some-title: The begining", "Some Title: The Begining")
        MyBase.TesteData.Add("some_title:_the_begining", "Some Title: The Begining")
        MyBase.TesteData.Add("some title: The_begining", "Some Title: The Begining")
    End Sub
End Class

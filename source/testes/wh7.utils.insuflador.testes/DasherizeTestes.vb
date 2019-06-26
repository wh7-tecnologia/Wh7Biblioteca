Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class DasherizeTestes
    Inherits InsufladorTesteBase

    <TestMethod()>
    Public Sub Dasherize()
        For Each pair In MyBase.TesteData
            Assert.AreEqual(pair.Key.Dasherize(), pair.Value)
            Debug.WriteLine(pair.Key & " - " & pair.Key.Dasherize())
        Next
    End Sub

    Public Sub New()
        MyBase.TesteData.Add("some_title", "some-title")
        MyBase.TesteData.Add("some-title", "some-title")
        MyBase.TesteData.Add("some_title_goes_here", "some-title-goes-here")
        MyBase.TesteData.Add("some_title and_another", "some-title and-another")
    End Sub

End Class
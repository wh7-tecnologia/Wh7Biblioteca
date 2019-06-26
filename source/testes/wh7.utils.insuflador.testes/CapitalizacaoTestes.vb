Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
'Imports NUnit.Framework




<TestClass()>
Public Class CapitalizacaoTestes
    Inherits InsufladorTesteBase

    '    Private testContextInstance As TestContext

    '    '''<summary>
    '    '''Obtém ou define o contexto do teste que provê
    '    '''informação e funcionalidade da execução de teste atual.
    '    '''</summary>
    '    Public Property TestContext() As TestContext
    '        Get
    '            Return testContextInstance
    '        End Get
    '        Set(ByVal value As TestContext)
    '            testContextInstance = Value
    '        End Set
    '    End Property


    <TestMethod()>
    Public Sub Capitalizacao()
        For Each pair In TesteData
            Assert.AreEqual(pair.Key.Capitalizacao(), pair.Value)
            Debug.WriteLine(pair.Key.Capitalizacao())
        Next
    End Sub

    '#Region "Atributos de teste adicionais"
    '    '
    '    ' É possível usar os seguintes atributos adicionais enquanto escreve os testes:
    '    '
    '    ' Use ClassInitialize para executar código antes de executar o primeiro teste na classe
    '    ' <ClassInitialize()> Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    '    ' End Sub
    '    '
    '    ' Use ClassCleanup para executar código após a execução de todos os testes em uma classe
    '    ' <ClassCleanup()> Public Shared Sub MyClassCleanup()
    '    ' End Sub
    '    '
    '    ' Use TestInitialize para executar código antes de executar cada teste
    '    ' <TestInitialize()> Public Sub MyTestInitialize()
    '    ' End Sub
    '    '
    '    ' Use TestCleanup para executar código após execução de cada teste
    '    ' <TestCleanup()> Public Sub MyTestCleanup()
    '    ' End Sub
    '    '
    '#End Region

    Public Sub New()
        TesteData.Add("some title", "Some title")
        TesteData.Add("some Title", "Some title")
        TesteData.Add("SOMETITLE", "Sometitle")
        TesteData.Add("someTitle", "Sometitle")
        TesteData.Add("some title goes here", "Some title goes here")
        TesteData.Add("some TITLE", "Some title")
    End Sub

End Class







'    <TestMethod()>
'    Public Sub TestMethod1()
'        ' TODO: Adicionar lógica de teste aqui
'    End Sub

'End Class

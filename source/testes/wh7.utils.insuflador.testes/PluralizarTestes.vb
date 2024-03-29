﻿Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class PluralizarTestes
    Inherits InsufladorTesteBase

    <TestMethod>
    Public Sub Pluralizar()
        For Each pair In MyBase.TesteData
            Assert.AreEqual(pair.Key.Pluralizar(), pair.Value)
            Debug.WriteLine(pair.Key & " - " & pair.Key.Pluralizar())
        Next
    End Sub

    <TestMethod>
    Public Sub Singularize()
        For Each pair In MyBase.TesteData
            Assert.AreEqual(pair.Value.Singularize(), pair.Key)
            Debug.WriteLine(pair.Key & " - " & pair.Key.Singularize())
        Next
    End Sub

    Public Sub New()
        MyBase.TesteData.Add("search", "searchs") 'MyBase.TesteData.Add("search", "searches")
        MyBase.TesteData.Add("switch", "switchs") 'MyBase.TesteData.Add("switch", "switches")
        'MyBase.TesteData.Add("fix", "fixes")
        'MyBase.TesteData.Add("box", "boxes")
        'MyBase.TesteData.Add("process", "processes")
        'MyBase.TesteData.Add("address", "addresses")
        'MyBase.TesteData.Add("case", "cases")
        'MyBase.TesteData.Add("stack", "stacks")
        'MyBase.TesteData.Add("wish", "wishes")
        'MyBase.TesteData.Add("fish", "fish")
        'MyBase.TesteData.Add("category", "categories")
        'MyBase.TesteData.Add("query", "queries")
        'MyBase.TesteData.Add("ability", "abilities")
        'MyBase.TesteData.Add("agency", "agencies")
        'MyBase.TesteData.Add("movie", "movies")
        'MyBase.TesteData.Add("archive", "archives")
        'MyBase.TesteData.Add("index", "indices")
        'MyBase.TesteData.Add("wife", "wives")
        'MyBase.TesteData.Add("safe", "saves")
        'MyBase.TesteData.Add("half", "halves")
        'MyBase.TesteData.Add("move", "moves")
        'MyBase.TesteData.Add("salesperson", "salespeople")
        'MyBase.TesteData.Add("person", "people")
        'MyBase.TesteData.Add("spokesman", "spokesmen")
        'MyBase.TesteData.Add("man", "men")
        'MyBase.TesteData.Add("woman", "women")
        'MyBase.TesteData.Add("basis", "bases")
        'MyBase.TesteData.Add("diagnosis", "diagnoses")
        'MyBase.TesteData.Add("datum", "data")
        'MyBase.TesteData.Add("medium", "media")
        'MyBase.TesteData.Add("analysis", "analyses")
        'MyBase.TesteData.Add("node_child", "node_children")
        'MyBase.TesteData.Add("child", "children")
        'MyBase.TesteData.Add("experience", "experiences")
        'MyBase.TesteData.Add("day", "days")
        'MyBase.TesteData.Add("comment", "comments")
        'MyBase.TesteData.Add("foobar", "foobars")
        'MyBase.TesteData.Add("newsletter", "newsletters")
        'MyBase.TesteData.Add("old_news", "old_news")
        'MyBase.TesteData.Add("news", "news")
        'MyBase.TesteData.Add("series", "series")
        'MyBase.TesteData.Add("species", "species")
        'MyBase.TesteData.Add("quiz", "quizzes")
        'MyBase.TesteData.Add("perspective", "perspectives")
        'MyBase.TesteData.Add("ox", "oxen")
        'MyBase.TesteData.Add("photo", "photos")
        'MyBase.TesteData.Add("buffalo", "buffaloes")
        'MyBase.TesteData.Add("tomato", "tomatoes")
        'MyBase.TesteData.Add("dwarf", "dwarves")
        'MyBase.TesteData.Add("elf", "elves")
        'MyBase.TesteData.Add("information", "information")
        'MyBase.TesteData.Add("equipment", "equipment")
        'MyBase.TesteData.Add("bus", "buses")
        'MyBase.TesteData.Add("status", "statuses")
        'MyBase.TesteData.Add("status_code", "status_codes")
        'MyBase.TesteData.Add("mouse", "mice")
        'MyBase.TesteData.Add("louse", "lice")
        'MyBase.TesteData.Add("house", "houses")
        'MyBase.TesteData.Add("octopus", "octopi")
        'MyBase.TesteData.Add("virus", "viri")
        'MyBase.TesteData.Add("alias", "aliases")
        'MyBase.TesteData.Add("portfolio", "portfolios")
        'MyBase.TesteData.Add("vertex", "vertices")
        'MyBase.TesteData.Add("matrix", "matrices")
        'MyBase.TesteData.Add("axis", "axes")
        'MyBase.TesteData.Add("testis", "testes")
        'MyBase.TesteData.Add("crisis", "crises")
        'MyBase.TesteData.Add("rice", "rice")
        'MyBase.TesteData.Add("shoe", "shoes")
        'MyBase.TesteData.Add("horse", "horses")
        'MyBase.TesteData.Add("prize", "prizes")
        'MyBase.TesteData.Add("edge", "edges")
        'MyBase.TesteData.Add("goose", "geese")
        'MyBase.TesteData.Add("deer", "deer")
        'MyBase.TesteData.Add("sheep", "sheep")
        'MyBase.TesteData.Add("wolf", "wolves")
        'MyBase.TesteData.Add("volcano", "volcanoes")
        'MyBase.TesteData.Add("aircraft", "aircraft")
        'MyBase.TesteData.Add("alumna", "alumnae")
        'MyBase.TesteData.Add("alumnus", "alumni")
        'MyBase.TesteData.Add("fungus", "fungi")
    End Sub

End Class

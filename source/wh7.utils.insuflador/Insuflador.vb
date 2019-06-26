Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports System.Runtime.CompilerServices


Public Module Insuflador



    Sub New()
        AddPlural("$", "s")
        AddPlural("s$", "s")
        AddPlural("(ax|test)is$", "$1es")
        AddPlural("(octop|vir|alumn|fung)us$", "$1i")
        AddPlural("(alias|status)$", "$1es")
        AddPlural("(bu)s$", "$1ses")
        AddPlural("(buffal|tomat|volcan)o$", "$1oes")
        AddPlural("([ti])um$", "$1a")
        AddPlural("sis$", "ses")
        AddPlural("(?:([^f])fe|([lr])f)$", "$1$2ves")
        AddPlural("(hive)$", "$1s")
        AddPlural("([^aeiouy]|qu)y$", "$1ies")
        AddPlural("(x|ch|ss|sh)$", "$1es")
        AddPlural("(matr|vert|ind)ix|ex$", "$1ices")
        AddPlural("([m|l])ouse$", "$1ice")
        AddPlural("^(ox)$", "$1en")
        AddPlural("(quiz)$", "$1zes")
        AddSingular("s$", "")
        AddSingular("(n)ews$", "$1ews")
        AddSingular("([ti])a$", "$1um")
        AddSingular("((a)naly|(b)a|(d)iagno|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis")
        AddSingular("(^analy)ses$", "$1sis")
        AddSingular("([^f])ves$", "$1fe")
        AddSingular("(hive)s$", "$1")
        AddSingular("(tive)s$", "$1")
        AddSingular("([lr])ves$", "$1f")
        AddSingular("([^aeiouy]|qu)ies$", "$1y")
        AddSingular("(s)eries$", "$1eries")
        AddSingular("(m)ovies$", "$1ovie")
        AddSingular("(x|ch|ss|sh)es$", "$1")
        AddSingular("([m|l])ice$", "$1ouse")
        AddSingular("(bus)es$", "$1")
        AddSingular("(o)es$", "$1")
        AddSingular("(shoe)s$", "$1")
        AddSingular("(cris|ax|test)es$", "$1is")
        AddSingular("(octop|vir|alumn|fung)i$", "$1us")
        AddSingular("(alias|status)es$", "$1")
        AddSingular("^(ox)en", "$1")
        AddSingular("(vert|ind)ices$", "$1ex")
        AddSingular("(matr)ices$", "$1ix")
        AddSingular("(quiz)zes$", "$1")
        AddIrregular("person", "people")
        AddIrregular("man", "men")
        AddIrregular("child", "children")
        AddIrregular("sex", "sexes")
        AddIrregular("move", "moves")
        AddIrregular("goose", "geese")
        AddIrregular("alumna", "alumnae")
        AddUncountable("equipment")
        AddUncountable("information")
        AddUncountable("rice")
        AddUncountable("money")
        AddUncountable("species")
        AddUncountable("series")
        AddUncountable("fish")
        AddUncountable("sheep")
        AddUncountable("deer")
        AddUncountable("aircraft")
    End Sub

    Private Class Rule
        Private ReadOnly _regex As Regex
        Private ReadOnly _replacement As String

        Public Sub New(ByVal pattern As String, ByVal replacement As String)
            _regex = New Regex(pattern, RegexOptions.IgnoreCase)
            _replacement = replacement
        End Sub

        Public Function Apply(ByVal word As String) As String
            If Not _regex.IsMatch(word) Then
                Return Nothing
            End If

            Return _regex.Replace(word, _replacement)
        End Function
    End Class

    Private Sub AddIrregular(ByVal singular As String, ByVal plural As String)
        AddPlural("(" & singular(0) & ")" & singular.Substring(1) & "$", "$1" & plural.Substring(1))
        AddSingular("(" & plural(0) & ")" & plural.Substring(1) & "$", "$1" & singular.Substring(1))
    End Sub

    Private Sub AddUncountable(ByVal word As String)
        _uncountables.Add(word.ToLower())
    End Sub

    Private Sub AddPlural(ByVal rule As String, ByVal replacement As String)
        _plurals.Add(New Rule(rule, replacement))
    End Sub

    Private Sub AddSingular(ByVal rule As String, ByVal replacement As String)
        _singulars.Add(New Rule(rule, replacement))
    End Sub

    Private ReadOnly _plurals As List(Of Rule) = New List(Of Rule)()
    Private ReadOnly _singulars As List(Of Rule) = New List(Of Rule)()
    Private ReadOnly _uncountables As List(Of String) = New List(Of String)()

    <Extension()>
    Function Pluralizar(ByVal word As String) As String
        Return ApplyRules(_plurals, word)
    End Function

    <Extension()>
    Function Singularize(ByVal word As String) As String
        Return ApplyRules(_singulars, word)
    End Function

    Private Function ApplyRules(ByVal rules As List(Of Rule), ByVal word As String) As String
        Dim result As String = word

        If Not _uncountables.Contains(word.ToLower()) Then

            For Each oItem In rules

                If (CSharpImpl.__Assign(result, oItem.Apply(word))) IsNot Nothing Then
                    Exit For
                End If
            Next

            'For i As Integer = rules.Count - 1 To 0

            '    If (CSharpImpl.__Assign(result, rules(i).Apply(word))) IsNot Nothing Then
            '        Exit For
            '    End If
            'Next

        End If

        Return result
    End Function

    <Extension()>
    Function Titularize(ByVal word As String) As String
        Return Regex.Replace(Humanize(Underscore(word)), "\b([a-z])", Function(ByVal match As Match) match.Captures(0).Value.ToUpper())
    End Function

    <Extension()>
    Function Humanize(ByVal lowercaseAndUnderscoredWord As String) As String
        Return Capitalizacao(Regex.Replace(lowercaseAndUnderscoredWord, "_", " "))
    End Function

    <Extension()>
    Function Pascalize(ByVal lowercaseAndUnderscoredWord As String) As String
        Return Regex.Replace(lowercaseAndUnderscoredWord, "(?:^|_)(.)", Function(ByVal match As Match) match.Groups(1).Value.ToUpper())
    End Function

    <Extension()>
    Function Camelize(ByVal lowercaseAndUnderscoredWord As String) As String
        Return Uncapitalize(Pascalize(lowercaseAndUnderscoredWord))
    End Function

    <Extension()>
    Function Underscore(ByVal pascalCasedWord As String) As String
        Return Regex.Replace(Regex.Replace(Regex.Replace(pascalCasedWord, "([A-Z]+)([A-Z][a-z])", "$1_$2"), "([a-z\d])([A-Z])", "$1_$2"), "[-\s]", "_").ToLower()
    End Function

    <Extension()>
    Function Capitalizacao(ByVal word As String) As String
        Return word.Substring(0, 1).ToUpper() & word.Substring(1).ToLower()
    End Function

    <Extension()>
    Function Uncapitalize(ByVal word As String) As String
        Return word.Substring(0, 1).ToLower() & word.Substring(1)
    End Function

    <Extension()>
    Function Ordinalize(ByVal numberString As String) As String
        Return Ordanize(Integer.Parse(numberString), numberString)
    End Function

    <Extension()>
    Function Ordinalize(ByVal number As Integer) As String
        Return Ordanize(number, number.ToString())
    End Function

    Private Function Ordanize(ByVal number As Integer, ByVal numberString As String) As String
        Dim nMod100 As Integer = number Mod 100

        If nMod100 >= 11 AndAlso nMod100 <= 13 Then
            Return numberString & "th"
        End If

        Select Case number Mod 10
            Case 1
                Return numberString & "st"
            Case 2
                Return numberString & "nd"
            Case 3
                Return numberString & "rd"
            Case Else
                Return numberString & "th"
        End Select
    End Function

    <Extension()>
    Function Dasherize(ByVal underscoredWord As String) As String
        Return underscoredWord.Replace("_"c, "-"c)
    End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Module

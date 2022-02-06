# Rop.String

Features
--------

Rop.String includes Helper extension classes to manipulate strings.

`Char` Helper
------

Helper class char relative

```csharp
/// Is Equal with case option
public static bool IsEqualCase(this char a, char b, bool ignoreCase = true);
/// Check if a char is included in a char range with case option
public static bool InRange(this char a, IEnumerable<char> range, bool ignoreCase = false);
/// Check if a char is NOT included in a char range with case option
public static bool NotInRange(this char a, IEnumerable<char> range, bool ignoreCase = false);
/// Create a char range from a char to another
public static IEnumerable<char> RangeChar(char from, char to);
/// Create a char range from a char and count elements
public static IEnumerable<char> RangeChar(char from, int count);
/// Trim blank characters (includes carriage returns)
public static string TrimBlanks(this string s);
/// Trim control characters
public static string TrimControl(this string s);
```

`HexString` Helper
------

Helper class hexadecimal strings relative

```csharp
/// Unicode string to Hex (WideChar)
public static string ToHexStringW(this string str)
/// Hex to Unicode String (Wide)
public static string FromHexStringW(this string hexString)
/// Ascii String to Hex (Byte char)
public static string ToHexString(this string str)
/// Hex String to Ascii String
public static string FromHexString(this string hexString)
 ```


`StringBuilder` helper
-------

Helper class relative to StringBuilder

```csharp
/// Append Line with linux end of line
public static StringBuilder AppendUnixLine(this StringBuilder std, string value)
/// Append linux end of line
public static StringBuilder AppendUnixLine(this StringBuilder std)
```

`StringCase` helper
-------

Helper class relative to Uppercase and Lowercase and Diacritics

```csharp
/// Remove Diacritics from text
public static string RemoveDiacritics(this string text);
/// Remove diacritics and Lower string
public static string RemoveDiacriticsAndLower(this string text);
/// String starts with (no case)
public static bool StartsWithNoCase(this string a, string b);
/// String ends with (no case)
public static bool EnsWithNoCase(this string a, string b);
/// Equals no case
public static bool EqualsNoCase(this string a, string b);
```

`StringExtracts` helper
-------

Helper class relative to Extract substrings

```csharp
/// Try extract substring from string
public static bool TryExtract(this string a, string prefix, string suffix,bool trim, StringComparison comparer,out string result);
public static bool TryExtract(this string a, string prefix, string suffix, out string result);
public static bool TryExtract(this string a, string prefix, string suffix, bool trim, out string result);
public static bool TryExtract(this string a, string prefix, string suffix, StringComparison comparer,out string result);
/// Try extract substring from string (no case);
public static bool TryExtractNoCase(this string a, string prefix, string suffix, bool trim, out string result);
public static bool TryExtractNoCase(this string a, string prefix, string suffix, out string result);
/// Try extract substring from strins between two strings
public static string Between(this string cad, string left, string right,bool ignorecase = false);
/// Get left part of a string
public static string LeftTo(this string cad, string sep, bool ignorecase = false);
/// Get right part of a string
public static string RightTo(this string cad, string sep, bool ignorecase = false);
/// Breaks a string in two parts
public static (string, string) Break(this string cad, string separator, bool ignorecase = false);
/// Break a string representing a domain account
public static (string Domain, string User) StripDomain(string cad);
/// Get user part of a string representing a domain account ensuring domain name
public static string StripDomain(string cad,string ensuredomain);
```

`String` helper
-------

General string helper

```csharp
/// StartsWith including end index
public static bool StartsWith(this string a,string b, StringComparison comparer, out int endindex);
/// EndsWith including begin index
public static bool EndsWith(this string a, string b, StringComparison comparer, out int beginindex);
/// Check if string starts and ends with a prefix and a suffix and returns index of both
public static bool StartsAndEndsWith(this string a, string b,string c, StringComparison comparer, out int from,out int to);
/// Return a substring or empty if parameters out of index
public static string SafeSubstring(this string cad, int from);
/// Return a substring or empty if parameters out of index
public static string SafeSubstring(this string cad, int from, int length, bool spaces = false);
/// Append all strings in a array
public static string ConcatLines(params string[] cads);
/// Return another string if string is null or empty
public static string IfNullOrEmpty(this string cad, string value);
/// Return another string if string is null or empty or whitespace
public static string IfNullOrWhiteSpace(this string cad, string value);
/// Create a dummy string with maximun value
public static string StringMax { get; } = new string(char.MaxValue, 8);
/// Check if string is digit only
public static bool IsDigitOnly(this string cad);
/// Check if cad represents a integer
public static bool IsInteger(this string cad);
/// Get substring beetween two positions.
public static string Between(this string cad, int left, int right, bool spaces = false);
/// Conver bool value into StringComparison value
public static StringComparison ToIgnoreCase(this bool c);
```

`Token` helper
-------

String helper to parsing strings

```csharp
/// Check if a symbol is present in a position
public static string SymbolInPos(this string cad, int pos, IEnumerable<string> symbols, bool ignorecase = false);
public static string SymbolInPos(this string cad, int pos, params string[] symbols);
/// Extract token from string
public static string GetToken(string[] separator, ref string cad, bool ignorecase = false);
/// Check if a string contains a substring
public static bool ContainsCase(this string cad, string search, bool ignorecase = false);   
```


 ------
 (C)2022 Ramón Ordiales Plaza

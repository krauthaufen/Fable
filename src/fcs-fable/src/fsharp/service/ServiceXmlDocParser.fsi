// Copyright (c) Microsoft Corporation.  All Rights Reserved.  See License.txt in the project root for license information.

namespace FSharp.Compiler.SourceCodeServices

open FSharp.Compiler
open FSharp.Compiler.Range
open FSharp.Compiler.Ast

/// Represent an Xml documentation block in source code
type public XmlDocable =
    | XmlDocable of line:int * indent:int * paramNames:string list

module public XmlDocComment =
    
    /// if it's a blank XML comment with trailing "<", returns Some (index of the "<"), otherwise returns None
    val isBlank : string -> int option

module public XmlDocParser =
    /// Get the list of Xml documentation from current source code
    val getXmlDocables : sourceCodeOfTheFile : string * input : Ast.ParsedInput option -> XmlDocable list
    
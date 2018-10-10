namespace Fable

type CompilerOptions =
    { typedArrays: bool
      clampByteArrays: bool
      verbose: bool
      // This option is meant for precompiled libraries (like the Repl Lib)
      // to make public inlined functions part of the JS
      outputPublicInlinedFunctions: bool
  }

[<RequireQualifiedAccess>]
type Severity =
    | Warning
    | Error
    | Info

open Microsoft.FSharp.Compiler.SourceCodeServices

type InlineExpr =
    { Args: FSharpMemberOrFunctionOrValue list
      Body: FSharpExpr
      FileName: string }

type ICompiler =
    abstract FableCore: string
    abstract CurrentFile: string
    abstract Options: CompilerOptions
    abstract GetUniqueVar: ?name: string -> string
    abstract GetRootModule: string -> string
    abstract GetOrAddInlineExpr: string * (unit->InlineExpr) -> InlineExpr
    abstract AddLog: msg:string * severity: Severity * ?range:SourceLocation
                        * ?fileName:string * ?tag: string -> unit

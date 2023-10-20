﻿module Hw6.Parser

open System
open System.Threading.Tasks
open Hw6.Calculator
open Hw6.MaybeBuilder

[<System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage>]
let inline isOperationSupported (arg1, operation, arg2): Result<('a * CalculatorOperation * 'b), string> =
    match operation with
    | "Plus" -> Ok (arg1, CalculatorOperation.Plus, arg2)
    | "Minus" -> Ok (arg1, CalculatorOperation.Minus, arg2)
    | "Multiply" -> Ok (arg1, CalculatorOperation.Multiply, arg2)
    | "Divide" -> Ok (arg1, CalculatorOperation.Divide, arg2)
    | _ -> Error $"Could not parse value \'{operation}\'"

let tryParseToDouble (arg: string) = 
    match Double.TryParse(arg) with
    | (true, value) -> Ok value
    | _ -> Error $"Could not parse value \'{arg}\'"

let parseArgs (args: string[]): Result<('a * CalculatorOperation * 'b), string> =
    maybe {
        let! arg1 = tryParseToDouble args[0]
        let! arg2 = tryParseToDouble args[2]
        let! result = isOperationSupported (arg1, args[1] , arg2)
        return result
    }


let parseCalcArguments (args: string[]): Result<('a * CalculatorOperation * 'b), string> =
    maybe {
        let! argsParsed = args |> parseArgs
        return argsParsed
    }

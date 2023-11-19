﻿using System.Linq.Expressions;
using Hw10.ErrorMessages;

namespace Hw10.Services.MathCalculator;

public class ExpressionTreeVisitorImpl: ExpressionVisitor
{
    public static async Task<double> EvaluateAsync(Expression expression)
    {
        switch (expression)
        {
            case BinaryExpression binaryExpression:
                await Task.Delay(1000);
                
                var leftTask = EvaluateAsync(binaryExpression.Left);
                var rightTask = EvaluateAsync(binaryExpression.Right);
                
                var results = await Task.WhenAll(leftTask, rightTask);
                
                return EvaluateBinaryExpression(binaryExpression, results[0], results[1]);

            case ConstantExpression { Value: double value }:
                return value;

            default:
                throw new InvalidOperationException("Unsupported expression type.");
        }
    }

    private static double EvaluateBinaryExpression(BinaryExpression binaryExpr, double value1, double value2)
    {
        return binaryExpr.NodeType switch
        {
            ExpressionType.Add => value1 + value2,
            ExpressionType.Subtract => value1 - value2,
            ExpressionType.Multiply => value1 * value2,
            ExpressionType.Divide when value2 == 0 => throw new DivideByZeroException(MathErrorMessager.DivisionByZero),
            ExpressionType.Divide => value1 / value2,
            _ => throw new ArgumentException(MathErrorMessager.UnknownCharacter),
        };
    }

}
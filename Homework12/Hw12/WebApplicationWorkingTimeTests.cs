﻿using BenchmarkDotNet.Attributes;

namespace Hw12;

[MaxColumn]
[MinColumn]
public class WebApplicationWorkingTimeTests
{
	private HttpClient _cSharpClient = null!;
	private HttpClient _fSharpClient = null!;
		
	[GlobalSetup]
	public void SetUp()
	{
		_cSharpClient =  new TestApplicationFactoryCSharp().CreateClient();
		_fSharpClient =  new TestApplicationFactoryFSharp().CreateClient();
	}
	
	[Benchmark]
	public async Task PlusOperationTimeTestCSharp()
	{
		await SendRequestCSharp("1", "plus", "2");
	}
		
	[Benchmark]
	public async Task SubtractionOperationTimeTestCSharp()
	{
		await SendRequestCSharp("3", "minus", "2");
	}
		
	[Benchmark]
	public async Task MultiplicationOperationTimeTestCSharp()
	{
		await SendRequestCSharp("10", "multiply", "3");
	}

	[Benchmark]
	public async Task DivisionOperationTimeTestCSharp()
	{
		await SendRequestCSharp("20", "divide", "10");
	}
	
	[Benchmark]
	public async Task PlusOperationTimeTestFSharp()
	{
		await SendRequestFSharp("1", "Plus", "2");
	}
		
	[Benchmark]
	public async Task SubtractionOperationTimeTestFSharp()
	{
		await SendRequestFSharp("3", "Minus", "2");
	}

	[Benchmark]
	public async Task MultiplicationOperationTimeTestFSharp()
	{
		await SendRequestFSharp("10", "Multiply", "3");
	}

	[Benchmark]
	public async Task DivisionOperationTimeTestFSharp()
	{
		await SendRequestFSharp("20", "Divide", "10");
	}

	private async Task SendRequestCSharp(string v1, string operation, string v2)
	{
		await _cSharpClient.GetAsync($"/calculator/calculate?val1={v1}&operation={operation}&val2={v2}");
	}
		
	private async Task SendRequestFSharp(string v1, string operation, string v2)
	{
		await _fSharpClient.GetAsync($"/calculate?value1={v1}&operation={operation}&value2={v2}");
	}
}
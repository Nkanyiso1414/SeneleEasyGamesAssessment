﻿using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Senele.Solution.Pages;

public class Index_Tests : SolutionWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

#pragma checksum "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "58bce98d63c8082640df2f36dcd310753893d1f5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FantasyLeagueStandings_Details), @"mvc.1.0.view", @"/Views/FantasyLeagueStandings/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FantasyLeagueStandings/Details.cshtml", typeof(AspNetCore.Views_FantasyLeagueStandings_Details))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\_ViewImports.cshtml"
using NBAMvc1._1;

#line default
#line hidden
#line 2 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\_ViewImports.cshtml"
using NBAMvc1._1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"58bce98d63c8082640df2f36dcd310753893d1f5", @"/Views/FantasyLeagueStandings/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_FantasyLeagueStandings_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Models.FantasyLeagueStandings>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(94, 145, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>FantasyLeagueStandings</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(240, 40, false);
#line 14 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Wins));

#line default
#line hidden
            EndContext();
            BeginContext(280, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(344, 36, false);
#line 17 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Wins));

#line default
#line hidden
            EndContext();
            BeginContext(380, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(443, 42, false);
#line 20 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Losses));

#line default
#line hidden
            EndContext();
            BeginContext(485, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(549, 38, false);
#line 23 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Losses));

#line default
#line hidden
            EndContext();
            BeginContext(587, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(650, 41, false);
#line 26 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Draws));

#line default
#line hidden
            EndContext();
            BeginContext(691, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(755, 37, false);
#line 29 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Draws));

#line default
#line hidden
            EndContext();
            BeginContext(792, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(855, 49, false);
#line 32 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FantasyPoints));

#line default
#line hidden
            EndContext();
            BeginContext(904, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(968, 45, false);
#line 35 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.FantasyPoints));

#line default
#line hidden
            EndContext();
            BeginContext(1013, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1076, 56, false);
#line 38 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FantasyPointsAgainst));

#line default
#line hidden
            EndContext();
            BeginContext(1132, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1196, 52, false);
#line 41 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.FantasyPointsAgainst));

#line default
#line hidden
            EndContext();
            BeginContext(1248, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1311, 45, false);
#line 44 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GamesBack));

#line default
#line hidden
            EndContext();
            BeginContext(1356, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1420, 41, false);
#line 47 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.GamesBack));

#line default
#line hidden
            EndContext();
            BeginContext(1461, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1524, 45, false);
#line 50 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.MyTeamNav));

#line default
#line hidden
            EndContext();
            BeginContext(1569, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1633, 50, false);
#line 53 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.MyTeamNav.MyTeamID));

#line default
#line hidden
            EndContext();
            BeginContext(1683, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1746, 52, false);
#line 56 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.FantasyLeagueNav));

#line default
#line hidden
            EndContext();
            BeginContext(1798, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1862, 64, false);
#line 59 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
       Write(Html.DisplayFor(model => model.FantasyLeagueNav.FantasyLeagueID));

#line default
#line hidden
            EndContext();
            BeginContext(1926, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1973, 76, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58bce98d63c8082640df2f36dcd310753893d1f511558", async() => {
                BeginContext(2041, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 64 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyLeagueStandings\Details.cshtml"
                           WriteLiteral(Model.FantasyLeagueStandingsID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2049, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2057, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "58bce98d63c8082640df2f36dcd310753893d1f513923", async() => {
                BeginContext(2079, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2095, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.Models.FantasyLeagueStandings> Html { get; private set; }
    }
}
#pragma warning restore 1591

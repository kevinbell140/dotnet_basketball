#pragma checksum "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c87ce02aa8b478c2e1ca69ef5335daefbc19a65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_Details), @"mvc.1.0.view", @"/Views/Games/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Games/Details.cshtml", typeof(AspNetCore.Views_Games_Details))]
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
#line 1 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\_ViewImports.cshtml"
using NBAMvc1._1;

#line default
#line hidden
#line 2 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\_ViewImports.cshtml"
using NBAMvc1._1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c87ce02aa8b478c2e1ca69ef5335daefbc19a65", @"/Views/Games/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Models.Game>
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
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(76, 127, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Game</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(204, 42, false);
#line 14 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Season));

#line default
#line hidden
            EndContext();
            BeginContext(246, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(310, 38, false);
#line 17 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.Season));

#line default
#line hidden
            EndContext();
            BeginContext(348, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(411, 42, false);
#line 20 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(453, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(517, 38, false);
#line 23 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(555, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(618, 44, false);
#line 26 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DateTime));

#line default
#line hidden
            EndContext();
            BeginContext(662, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(726, 40, false);
#line 29 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.DateTime));

#line default
#line hidden
            EndContext();
            BeginContext(766, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(829, 49, false);
#line 32 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(878, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(942, 45, false);
#line 35 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomeTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(987, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1050, 49, false);
#line 38 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1163, 45, false);
#line 41 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.AwayTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(1208, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1271, 43, false);
#line 44 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(1314, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1378, 39, false);
#line 47 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(1417, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1480, 47, false);
#line 50 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PointSpread));

#line default
#line hidden
            EndContext();
            BeginContext(1527, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1591, 43, false);
#line 53 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.PointSpread));

#line default
#line hidden
            EndContext();
            BeginContext(1634, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1697, 45, false);
#line 56 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.OverUnder));

#line default
#line hidden
            EndContext();
            BeginContext(1742, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1806, 41, false);
#line 59 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.OverUnder));

#line default
#line hidden
            EndContext();
            BeginContext(1847, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1910, 53, false);
#line 62 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(1963, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2027, 49, false);
#line 65 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.AwayTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2076, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2139, 53, false);
#line 68 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2192, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2256, 49, false);
#line 71 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomeTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2305, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2368, 47, false);
#line 74 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeTeamNav));

#line default
#line hidden
            EndContext();
            BeginContext(2415, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2479, 47, false);
#line 77 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomeTeamNav.Key));

#line default
#line hidden
            EndContext();
            BeginContext(2526, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2589, 47, false);
#line 80 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayTeamNav));

#line default
#line hidden
            EndContext();
            BeginContext(2636, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2700, 47, false);
#line 83 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
       Write(Html.DisplayFor(model => model.AwayTeamNav.Key));

#line default
#line hidden
            EndContext();
            BeginContext(2747, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2794, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c87ce02aa8b478c2e1ca69ef5335daefbc19a6514330", async() => {
                BeginContext(2844, 4, true);
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
#line 88 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Details.cshtml"
                           WriteLiteral(Model.GameID);

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
            BeginContext(2852, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2860, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4c87ce02aa8b478c2e1ca69ef5335daefbc19a6516652", async() => {
                BeginContext(2882, 12, true);
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
            BeginContext(2898, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.Models.Game> Html { get; private set; }
    }
}
#pragma warning restore 1591

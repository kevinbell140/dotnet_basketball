#pragma checksum "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7178d8995b294b08cb53d2355f66d85190aa74f2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Standings_Details), @"mvc.1.0.view", @"/Views/Standings/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Standings/Details.cshtml", typeof(AspNetCore.Views_Standings_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7178d8995b294b08cb53d2355f66d85190aa74f2", @"/Views/Standings/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Standings_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Models.Standings>
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
            BeginContext(36, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(81, 132, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Standings</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(214, 40, false);
#line 14 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Wins));

#line default
#line hidden
            EndContext();
            BeginContext(254, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(318, 36, false);
#line 17 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Wins));

#line default
#line hidden
            EndContext();
            BeginContext(354, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(417, 42, false);
#line 20 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Losses));

#line default
#line hidden
            EndContext();
            BeginContext(459, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(523, 38, false);
#line 23 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Losses));

#line default
#line hidden
            EndContext();
            BeginContext(561, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(624, 46, false);
#line 26 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Percentage));

#line default
#line hidden
            EndContext();
            BeginContext(670, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(734, 42, false);
#line 29 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Percentage));

#line default
#line hidden
            EndContext();
            BeginContext(776, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(839, 50, false);
#line 32 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ConferenceWins));

#line default
#line hidden
            EndContext();
            BeginContext(889, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(953, 46, false);
#line 35 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.ConferenceWins));

#line default
#line hidden
            EndContext();
            BeginContext(999, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1062, 52, false);
#line 38 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ConferenceLosses));

#line default
#line hidden
            EndContext();
            BeginContext(1114, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1178, 48, false);
#line 41 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.ConferenceLosses));

#line default
#line hidden
            EndContext();
            BeginContext(1226, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1289, 48, false);
#line 44 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DivisionWins));

#line default
#line hidden
            EndContext();
            BeginContext(1337, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1401, 44, false);
#line 47 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.DivisionWins));

#line default
#line hidden
            EndContext();
            BeginContext(1445, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1508, 50, false);
#line 50 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DivisionLosses));

#line default
#line hidden
            EndContext();
            BeginContext(1558, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1622, 46, false);
#line 53 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.DivisionLosses));

#line default
#line hidden
            EndContext();
            BeginContext(1668, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1731, 44, false);
#line 56 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeWins));

#line default
#line hidden
            EndContext();
            BeginContext(1775, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1839, 40, false);
#line 59 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomeWins));

#line default
#line hidden
            EndContext();
            BeginContext(1879, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1942, 46, false);
#line 62 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeLosses));

#line default
#line hidden
            EndContext();
            BeginContext(1988, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2052, 42, false);
#line 65 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.HomeLosses));

#line default
#line hidden
            EndContext();
            BeginContext(2094, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2157, 44, false);
#line 68 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayWins));

#line default
#line hidden
            EndContext();
            BeginContext(2201, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2265, 40, false);
#line 71 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.AwayWins));

#line default
#line hidden
            EndContext();
            BeginContext(2305, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2368, 46, false);
#line 74 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayLosses));

#line default
#line hidden
            EndContext();
            BeginContext(2414, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2478, 42, false);
#line 77 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.AwayLosses));

#line default
#line hidden
            EndContext();
            BeginContext(2520, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2583, 47, false);
#line 80 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastTenWins));

#line default
#line hidden
            EndContext();
            BeginContext(2630, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2694, 43, false);
#line 83 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastTenWins));

#line default
#line hidden
            EndContext();
            BeginContext(2737, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2800, 49, false);
#line 86 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LastTenLosses));

#line default
#line hidden
            EndContext();
            BeginContext(2849, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2913, 45, false);
#line 89 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.LastTenLosses));

#line default
#line hidden
            EndContext();
            BeginContext(2958, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3021, 42, false);
#line 92 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Streak));

#line default
#line hidden
            EndContext();
            BeginContext(3063, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3127, 38, false);
#line 95 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.Streak));

#line default
#line hidden
            EndContext();
            BeginContext(3165, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3228, 45, false);
#line 98 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GamesBack));

#line default
#line hidden
            EndContext();
            BeginContext(3273, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3337, 41, false);
#line 101 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.GamesBack));

#line default
#line hidden
            EndContext();
            BeginContext(3378, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(3441, 43, false);
#line 104 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TeamNav));

#line default
#line hidden
            EndContext();
            BeginContext(3484, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(3548, 43, false);
#line 107 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
       Write(Html.DisplayFor(model => model.TeamNav.Key));

#line default
#line hidden
            EndContext();
            BeginContext(3591, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(3638, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7178d8995b294b08cb53d2355f66d85190aa74f218145", async() => {
                BeginContext(3688, 4, true);
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
#line 112 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Standings\Details.cshtml"
                           WriteLiteral(Model.TeamID);

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
            BeginContext(3696, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(3704, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7178d8995b294b08cb53d2355f66d85190aa74f220480", async() => {
                BeginContext(3726, 12, true);
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
            BeginContext(3742, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.Models.Standings> Html { get; private set; }
    }
}
#pragma warning restore 1591

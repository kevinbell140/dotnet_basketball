#pragma checksum "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6a7e9cb074a5509e27c809d3cbd7fdd6712bd259"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games__IndexBefore), @"mvc.1.0.view", @"/Views/Games/_IndexBefore.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Games/_IndexBefore.cshtml", typeof(AspNetCore.Views_Games__IndexBefore))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6a7e9cb074a5509e27c809d3cbd7fdd6712bd259", @"/Views/Games/_IndexBefore.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Games__IndexBefore : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Models.Game>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Games", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(31, 75, true);
            WriteLiteral("\r\n\r\n<div class=\"card\">\r\n    <div class=\"card-header text-center\">\r\n        ");
            EndContext();
            BeginContext(106, 95, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a7e9cb074a5509e27c809d3cbd7fdd6712bd2593937", async() => {
                BeginContext(183, 14, false);
#line 6 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                                                                               Write(Model.DateTime);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 6 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
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
            BeginContext(201, 22, true);
            WriteLiteral("\r\n        <h6>Spread: ");
            EndContext();
            BeginContext(224, 17, false);
#line 7 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
               Write(Model.PointSpread);

#line default
#line hidden
            EndContext();
            BeginContext(241, 387, true);
            WriteLiteral(@"</h6>
    </div>
    <div class=""card-body"">
        <table class=""table table-hover"">
            <thead>
                <tr>
                    <td></td>
                    <td>Spread</td>
                    <td>Line</td>
                    <td>O/U</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 628, "\"", 669, 1);
#line 21 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
WriteAttributeValue("", 634, Model.AwayTeamNav.WikipediaLogoUrl, 634, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(670, 53, true);
            WriteLiteral(" class=\"teamLogoSM\" /></td>\r\n                    <td>");
            EndContext();
            BeginContext(725, 57, false);
#line 22 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                    Write(Model.PointSpread > 0 ? Model.PointSpread.ToString() : "");

#line default
#line hidden
            EndContext();
            BeginContext(783, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(815, 23, false);
#line 23 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                   Write(Model.AwayTeamMoneyLine);

#line default
#line hidden
            EndContext();
            BeginContext(838, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(870, 15, false);
#line 24 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                   Write(Model.OverUnder);

#line default
#line hidden
            EndContext();
            BeginContext(885, 80, true);
            WriteLiteral("</td>\r\n                </tr>\r\n                <tr>\r\n                    <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 965, "\"", 1006, 1);
#line 27 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
WriteAttributeValue("", 971, Model.HomeTeamNav.WikipediaLogoUrl, 971, 35, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1007, 53, true);
            WriteLiteral(" class=\"teamLogoSM\" /></td>\r\n                    <td>");
            EndContext();
            BeginContext(1062, 57, false);
#line 28 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                    Write(Model.PointSpread < 0 ? Model.PointSpread.ToString() : "");

#line default
#line hidden
            EndContext();
            BeginContext(1120, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1152, 23, false);
#line 29 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                   Write(Model.HomeTeamMoneyLine);

#line default
#line hidden
            EndContext();
            BeginContext(1175, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1207, 15, false);
#line 30 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
                   Write(Model.OverUnder);

#line default
#line hidden
            EndContext();
            BeginContext(1222, 133, true);
            WriteLiteral("</td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n    </div>\r\n    <div class=\"card-footer text-center\">\r\n        ");
            EndContext();
            BeginContext(1355, 87, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6a7e9cb074a5509e27c809d3cbd7fdd6712bd25910958", async() => {
                BeginContext(1431, 7, true);
                WriteLiteral("Preview");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 36 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Games\_IndexBefore.cshtml"
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
            BeginContext(1442, 24, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n\r\n");
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
#pragma checksum "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6e69662db35943aa7024f2479028db8fda23783a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_Delete), @"mvc.1.0.view", @"/Views/Games/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Games/Delete.cshtml", typeof(AspNetCore.Views_Games_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6e69662db35943aa7024f2479028db8fda23783a", @"/Views/Games/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Models.Game>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(75, 174, true);
            WriteLiteral("\r\n<h1>Delete</h1>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>Game</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(250, 42, false);
#line 15 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Season));

#line default
#line hidden
            EndContext();
            BeginContext(292, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(356, 38, false);
#line 18 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Season));

#line default
#line hidden
            EndContext();
            BeginContext(394, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(457, 42, false);
#line 21 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(499, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(563, 38, false);
#line 24 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Status));

#line default
#line hidden
            EndContext();
            BeginContext(601, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(664, 44, false);
#line 27 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.DateTime));

#line default
#line hidden
            EndContext();
            BeginContext(708, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(772, 40, false);
#line 30 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.DateTime));

#line default
#line hidden
            EndContext();
            BeginContext(812, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(875, 49, false);
#line 33 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(924, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(988, 45, false);
#line 36 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.HomeTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(1033, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1096, 49, false);
#line 39 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(1145, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1209, 45, false);
#line 42 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AwayTeamScore));

#line default
#line hidden
            EndContext();
            BeginContext(1254, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1317, 43, false);
#line 45 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(1360, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1424, 39, false);
#line 48 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(1463, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1526, 47, false);
#line 51 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.PointSpread));

#line default
#line hidden
            EndContext();
            BeginContext(1573, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1637, 43, false);
#line 54 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.PointSpread));

#line default
#line hidden
            EndContext();
            BeginContext(1680, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1743, 45, false);
#line 57 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.OverUnder));

#line default
#line hidden
            EndContext();
            BeginContext(1788, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1852, 41, false);
#line 60 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.OverUnder));

#line default
#line hidden
            EndContext();
            BeginContext(1893, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1956, 53, false);
#line 63 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2009, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2073, 49, false);
#line 66 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AwayTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2122, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2185, 53, false);
#line 69 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2238, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2302, 49, false);
#line 72 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.HomeTeamMoneyLine));

#line default
#line hidden
            EndContext();
            BeginContext(2351, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2414, 47, false);
#line 75 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.HomeTeamNav));

#line default
#line hidden
            EndContext();
            BeginContext(2461, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2525, 47, false);
#line 78 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.HomeTeamNav.Key));

#line default
#line hidden
            EndContext();
            BeginContext(2572, 68, true);
            WriteLiteral("\r\n        </dd class>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2641, 47, false);
#line 81 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.AwayTeamNav));

#line default
#line hidden
            EndContext();
            BeginContext(2688, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2752, 47, false);
#line 84 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
       Write(Html.DisplayFor(model => model.AwayTeamNav.Key));

#line default
#line hidden
            EndContext();
            BeginContext(2799, 44, true);
            WriteLiteral("\r\n        </dd class>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2843, 210, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e69662db35943aa7024f2479028db8fda23783a15058", async() => {
                BeginContext(2869, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2879, 40, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "6e69662db35943aa7024f2479028db8fda23783a15451", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 89 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Games\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.GameID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2919, 83, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Delete\" class=\"btn btn-danger\" /> |\r\n        ");
                EndContext();
                BeginContext(3002, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6e69662db35943aa7024f2479028db8fda23783a17356", async() => {
                    BeginContext(3024, 12, true);
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
                BeginContext(3040, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3053, 10, true);
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

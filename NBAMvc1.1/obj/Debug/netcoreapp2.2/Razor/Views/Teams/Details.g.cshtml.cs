#pragma checksum "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a96a9fe8caba1637c7125e9a008c87a6e96d70a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teams_Details), @"mvc.1.0.view", @"/Views/Teams/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Teams/Details.cshtml", typeof(AspNetCore.Views_Teams_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a96a9fe8caba1637c7125e9a008c87a6e96d70a2", @"/Views/Teams/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Teams_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Models.Team>
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
#line 3 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(76, 127, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Team</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(204, 39, false);
#line 14 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Key));

#line default
#line hidden
            EndContext();
            BeginContext(243, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(307, 35, false);
#line 17 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.Key));

#line default
#line hidden
            EndContext();
            BeginContext(342, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(405, 40, false);
#line 20 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(445, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(509, 36, false);
#line 23 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.City));

#line default
#line hidden
            EndContext();
            BeginContext(545, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(608, 40, false);
#line 26 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(648, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(712, 36, false);
#line 29 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(748, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(811, 44, false);
#line 32 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.LeagueID));

#line default
#line hidden
            EndContext();
            BeginContext(855, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(919, 40, false);
#line 35 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.LeagueID));

#line default
#line hidden
            EndContext();
            BeginContext(959, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1022, 46, false);
#line 38 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Conference));

#line default
#line hidden
            EndContext();
            BeginContext(1068, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1132, 42, false);
#line 41 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.Conference));

#line default
#line hidden
            EndContext();
            BeginContext(1174, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1237, 44, false);
#line 44 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Division));

#line default
#line hidden
            EndContext();
            BeginContext(1281, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1345, 40, false);
#line 47 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.Division));

#line default
#line hidden
            EndContext();
            BeginContext(1385, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1448, 48, false);
#line 50 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PrimaryColor));

#line default
#line hidden
            EndContext();
            BeginContext(1496, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1560, 44, false);
#line 53 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.PrimaryColor));

#line default
#line hidden
            EndContext();
            BeginContext(1604, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1667, 50, false);
#line 56 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.SecondaryColor));

#line default
#line hidden
            EndContext();
            BeginContext(1717, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1781, 46, false);
#line 59 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.SecondaryColor));

#line default
#line hidden
            EndContext();
            BeginContext(1827, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1890, 49, false);
#line 62 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TertiaryColor));

#line default
#line hidden
            EndContext();
            BeginContext(1939, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2003, 45, false);
#line 65 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.TertiaryColor));

#line default
#line hidden
            EndContext();
            BeginContext(2048, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(2111, 52, false);
#line 68 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.WikipediaLogoUrl));

#line default
#line hidden
            EndContext();
            BeginContext(2163, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(2227, 48, false);
#line 71 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.WikipediaLogoUrl));

#line default
#line hidden
            EndContext();
            BeginContext(2275, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(2322, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a96a9fe8caba1637c7125e9a008c87a6e96d70a212598", async() => {
                BeginContext(2372, 4, true);
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
#line 76 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
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
            BeginContext(2380, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(2388, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a96a9fe8caba1637c7125e9a008c87a6e96d70a214920", async() => {
                BeginContext(2410, 12, true);
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
            BeginContext(2426, 10, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.Models.Team> Html { get; private set; }
    }
}
#pragma warning restore 1591

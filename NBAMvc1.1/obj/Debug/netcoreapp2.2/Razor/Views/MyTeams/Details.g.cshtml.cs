#pragma checksum "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a16c5eda815852beb1ab3031ef7efa8753b6ca96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MyTeams_Details), @"mvc.1.0.view", @"/Views/MyTeams/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/MyTeams/Details.cshtml", typeof(AspNetCore.Views_MyTeams_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a16c5eda815852beb1ab3031ef7efa8753b6ca96", @"/Views/MyTeams/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_MyTeams_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.ViewModels.MyTeamDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "PlayerMyTeams", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(98, 105, true);
            WriteLiteral("\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>");
            EndContext();
            BeginContext(204, 17, false);
#line 10 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
           Write(Model.MyTeam.Name);

#line default
#line hidden
            EndContext();
            BeginContext(221, 379, true);
            WriteLiteral(@"</h3>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th>Pos</th>
                        <th>Name</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 24 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                     foreach (KeyValuePair<string, Player> entry in Model.Roster)
                    {

#line default
#line hidden
            BeginContext(706, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(769, 9, false);
#line 27 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                           Write(entry.Key);

#line default
#line hidden
            EndContext();
            BeginContext(778, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(819, 47, false);
#line 28 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                            Write(entry.Value != null ? entry.Value.FullName : "");

#line default
#line hidden
            EndContext();
            BeginContext(867, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 29 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                             if (entry.Value == null)
                            {

#line default
#line hidden
            BeginContext(960, 36, true);
            WriteLiteral("                                <td>");
            EndContext();
            BeginContext(996, 127, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a16c5eda815852beb1ab3031ef7efa8753b6ca967382", async() => {
                BeginContext(1116, 3, true);
                WriteLiteral("Add");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-teamID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 31 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                                                                                                WriteLiteral(Model.MyTeam.MyTeamID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["teamID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-teamID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["teamID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1123, 8, true);
            WriteLiteral(" </td>\r\n");
            EndContext();
#line 32 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(1227, 30, true);
            WriteLiteral("                        <td>\r\n");
            EndContext();
#line 36 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                             using (Html.BeginForm("Delete", "PlayerMyTeams"))
                            {
                                

#line default
#line hidden
            BeginContext(1401, 45, false);
#line 38 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                           Write(Html.Hidden("playerID", entry.Value.PlayerID));

#line default
#line hidden
            EndContext();
            BeginContext(1481, 46, false);
#line 39 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                           Write(Html.Hidden("myTeamID", Model.MyTeam.MyTeamID));

#line default
#line hidden
            EndContext();
            BeginContext(1529, 92, true);
            WriteLiteral("                                <input type=\"submit\" value=\"Cut\" class=\"btn btn-danger\" />\r\n");
            EndContext();
#line 41 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                            }

#line default
#line hidden
            BeginContext(1652, 31, true);
            WriteLiteral("                        </td>\r\n");
            EndContext();
#line 43 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                            }

#line default
#line hidden
            BeginContext(1714, 31, true);
            WriteLiteral("                        </tr>\r\n");
            EndContext();
#line 45 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                    }

#line default
#line hidden
            BeginContext(1768, 99, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1867, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a16c5eda815852beb1ab3031ef7efa8753b6ca9612385", async() => {
                BeginContext(1926, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 54 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\MyTeams\Details.cshtml"
                           WriteLiteral(Model.MyTeam.MyTeamID);

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
            BeginContext(1934, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1942, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a16c5eda815852beb1ab3031ef7efa8753b6ca9614718", async() => {
                BeginContext(1964, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1980, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.ViewModels.MyTeamDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4fac335b89edcccf443350b02311325e24dee7f0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Players_Index), @"mvc.1.0.view", @"/Views/Players/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Players/Index.cshtml", typeof(AspNetCore.Views_Players_Index))]
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
#line 2 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4fac335b89edcccf443350b02311325e24dee7f0", @"/Views/Players/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Players_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.Utils.PaginatedList<Player>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(142, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
            EndContext();
#line 7 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
  
    ViewData["Title"] = "Players";

#line default
#line hidden
            BeginContext(191, 201, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <h3>All Players</h3>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n");
            EndContext();
#line 19 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
             if ((await AuthorizationService.AuthorizeAsync(User, "AdminOnly")).Succeeded)
            {

#line default
#line hidden
            BeginContext(499, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(515, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f06032", async() => {
                BeginContext(538, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(552, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 22 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(569, 95, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\">\r\n            ");
            EndContext();
            BeginContext(664, 455, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f07756", async() => {
                BeginContext(702, 150, true);
                WriteLiteral("\r\n                <div class=\"form-actions no-color\">\r\n                    <p>\r\n                        Search: <input type=\"text\" name=\"searchString\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 852, "\"", 886, 1);
#line 30 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
WriteAttributeValue("", 860, ViewData["currentFilter"], 860, 26, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(887, 117, true);
                WriteLiteral(" />\r\n                        <input type=\"submit\" value=\"Search\" class=\"btn btn-primary\" />\r\n                        ");
                EndContext();
                BeginContext(1004, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f08856", async() => {
                    BeginContext(1026, 18, true);
                    WriteLiteral(" Back to full list");
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
                BeginContext(1048, 64, true);
                WriteLiteral("\r\n                    </p>\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1119, 268, true);
            WriteLiteral(@"
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-12"">
            <table class=""table table-responsive table-hover"">
                <thead>
                    <tr>
                        <td>Team</td>
                        <td>");
            EndContext();
            BeginContext(1388, 121, false);
#line 44 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("Player", "Index", new { sortParam = ViewData["playerSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(1509, 74, true);
            WriteLiteral(" </td>\r\n                        <td>Pos</td>\r\n                        <td>");
            EndContext();
            BeginContext(1584, 114, false);
#line 46 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("FG%", "Index", new { sortParam = ViewData["fgSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(1698, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(1735, 114, false);
#line 47 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("FT%", "Index", new { sortParam = ViewData["ftSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(1849, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(1886, 115, false);
#line 48 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("3PT", "Index", new { sortParam = ViewData["3ptSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2001, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(2038, 115, false);
#line 49 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("PPG", "Index", new { sortParam = ViewData["ppgSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2153, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(2190, 115, false);
#line 50 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("APG", "Index", new { sortParam = ViewData["apgSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2305, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(2342, 115, false);
#line 51 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("RPG", "Index", new { sortParam = ViewData["rpgSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2457, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(2494, 115, false);
#line 52 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("SPG", "Index", new { sortParam = ViewData["spgSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2609, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(2646, 115, false);
#line 53 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("BPG", "Index", new { sortParam = ViewData["bpgSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2761, 36, true);
            WriteLiteral(" </td>\r\n                        <td>");
            EndContext();
            BeginContext(2798, 113, false);
#line 54 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink("TO", "Index", new { sortParam = ViewData["toSort"], currentFilter = ViewData["currentFilter"] }));

#line default
#line hidden
            EndContext();
            BeginContext(2911, 121, true);
            WriteLiteral(" </td>\r\n                        <td></td>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 59 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                     foreach (var p in Model)
                    {

#line default
#line hidden
            BeginContext(3102, 58, true);
            WriteLiteral("                    <tr>\r\n                        <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3160, "\"", 3193, 1);
#line 62 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
WriteAttributeValue("", 3166, p.TeamNav.WikipediaLogoUrl, 3166, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3194, 55, true);
            WriteLiteral(" class=\"teamLogo\" /></td>\r\n                        <td>");
            EndContext();
            BeginContext(3250, 64, false);
#line 63 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.ActionLink(@p.FullName, "Details", new { id = p.PlayerID }));

#line default
#line hidden
            EndContext();
            BeginContext(3314, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3350, 32, false);
#line 64 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.Position));

#line default
#line hidden
            EndContext();
            BeginContext(3382, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3418, 53, false);
#line 65 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.FieldGoalsPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(3471, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3507, 53, false);
#line 66 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.FreeThrowsPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(3560, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3596, 50, false);
#line 67 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.ThreePointersMade));

#line default
#line hidden
            EndContext();
            BeginContext(3646, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3682, 36, false);
#line 68 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.PPG));

#line default
#line hidden
            EndContext();
            BeginContext(3718, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3754, 36, false);
#line 69 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.APG));

#line default
#line hidden
            EndContext();
            BeginContext(3790, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3826, 36, false);
#line 70 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.RPG));

#line default
#line hidden
            EndContext();
            BeginContext(3862, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3898, 36, false);
#line 71 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.SPG));

#line default
#line hidden
            EndContext();
            BeginContext(3934, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(3970, 36, false);
#line 72 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.BPG));

#line default
#line hidden
            EndContext();
            BeginContext(4006, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(4042, 36, false);
#line 73 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                       Write(Html.DisplayFor(m => p.StatsNav.TPG));

#line default
#line hidden
            EndContext();
            BeginContext(4078, 65, true);
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4143, 60, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f022518", async() => {
                BeginContext(4192, 7, true);
                WriteLiteral("Details");
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
#line 75 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                                                      WriteLiteral(p.TeamID);

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
            BeginContext(4203, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
#line 76 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                             if ((await AuthorizationService.AuthorizeAsync(User, "AdminOnly")).Succeeded)
                            {

#line default
#line hidden
            BeginContext(4346, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(4378, 58, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f025269", async() => {
                BeginContext(4426, 6, true);
                WriteLiteral("Delete");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 78 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                                                         WriteLiteral(p.TeamID);

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
            BeginContext(4436, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 79 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(4469, 58, true);
            WriteLiteral("                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 82 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(4550, 131, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n");
            EndContext();
#line 89 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
              
                var prevDisabled = !Model.HasPreviousPage ? "disabled" : "";
                var nextDisabled = !Model.HasNextPage ? "disabled" : "";
            

#line default
#line hidden
            BeginContext(4864, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(4876, 234, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f028764", async() => {
                BeginContext(5098, 8, true);
                WriteLiteral("Previous");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortParam", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 93 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                                           WriteLiteral(ViewData["currentSort"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortParam"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortParam", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortParam"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 93 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                                                                                            WriteLiteral(Model.PageIndex - 1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 94 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                            WriteLiteral(ViewData["currentFilter"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentFilter", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5067, "btn", 5067, 3, true);
            AddHtmlAttributeValue(" ", 5070, "btn-primary", 5071, 12, true);
#line 94 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
AddHtmlAttributeValue(" ", 5082, prevDisabled, 5083, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5110, 14, true);
            WriteLiteral("\r\n            ");
            EndContext();
            BeginContext(5124, 230, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4fac335b89edcccf443350b02311325e24dee7f033191", async() => {
                BeginContext(5346, 4, true);
                WriteLiteral("Next");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortParam", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 95 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                                           WriteLiteral(ViewData["currentSort"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortParam"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortParam", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortParam"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 95 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                                                                                            WriteLiteral(Model.PageIndex + 1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-pageNumber", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["pageNumber"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 96 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
                            WriteLiteral(ViewData["currentFilter"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-currentFilter", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["currentFilter"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 3, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 5315, "btn", 5315, 3, true);
            AddHtmlAttributeValue(" ", 5318, "btn-primary", 5319, 12, true);
#line 96 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\Players\Index.cshtml"
AddHtmlAttributeValue(" ", 5330, nextDisabled, 5331, 13, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5354, 38, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAuthorizationService AuthorizationService { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.Utils.PaginatedList<Player>> Html { get; private set; }
    }
}
#pragma warning restore 1591

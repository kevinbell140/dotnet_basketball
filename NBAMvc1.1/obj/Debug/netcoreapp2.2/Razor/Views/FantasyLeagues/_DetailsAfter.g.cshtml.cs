#pragma checksum "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "181dfc7f616f34a1ba076dc64900c81f1aa3ccc6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FantasyLeagues__DetailsAfter), @"mvc.1.0.view", @"/Views/FantasyLeagues/_DetailsAfter.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FantasyLeagues/_DetailsAfter.cshtml", typeof(AspNetCore.Views_FantasyLeagues__DetailsAfter))]
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
#line 1 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\_ViewImports.cshtml"
using NBAMvc1._1;

#line default
#line hidden
#line 2 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\_ViewImports.cshtml"
using NBAMvc1._1.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"181dfc7f616f34a1ba076dc64900c81f1aa3ccc6", @"/Views/FantasyLeagues/_DetailsAfter.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_FantasyLeagues__DetailsAfter : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.ViewModels.FantasyLeagueDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MyTeams", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FantasyMatchups", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(61, 859, true);
            WriteLiteral(@"
    <div class=""container container-fluid bg-white"">
        <div class=""row"">
            <div class=""col-md-6"">
                <div class=""card w-100"">
                    <div class=""card-header"">Standings</div>
                    <div class=""card-body"">
                        <table class=""table table-hover"">
                            <thead>
                                <tr>
                                    <th>Pos</th>
                                    <th>Name</th>
                                    <th>W</th>
                                    <th>L</th>
                                    <th>D</th>
                                    <th>PF</th>
                                    <th>PA</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 22 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                 foreach (KeyValuePair<int, MyTeam> entry in Model.Teams)
                                {

#line default
#line hidden
            BeginContext(1046, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(1133, 9, false);
#line 25 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                       Write(entry.Key);

#line default
#line hidden
            EndContext();
            BeginContext(1142, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 26 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                         if (entry.Value != null)
                                        {

#line default
#line hidden
            BeginContext(1259, 48, true);
            WriteLiteral("                                            <td>");
            EndContext();
            BeginContext(1307, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "181dfc7f616f34a1ba076dc64900c81f1aa3ccc66746", async() => {
                BeginContext(1394, 16, false);
#line 28 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                                                 Write(entry.Value.Name);

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
#line 28 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                   WriteLiteral(entry.Value.MyTeamID);

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
            BeginContext(1414, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 29 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(1553, 55, true);
            WriteLiteral("                                            <td></td>\r\n");
            EndContext();
#line 33 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                        }

#line default
#line hidden
            BeginContext(1651, 44, true);
            WriteLiteral("                                        <td>");
            EndContext();
            BeginContext(1696, 42, false);
#line 34 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                       Write(entry.Value.FantasyLeagueStandingsNav.Wins);

#line default
#line hidden
            EndContext();
            BeginContext(1738, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1790, 44, false);
#line 35 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                       Write(entry.Value.FantasyLeagueStandingsNav.Losses);

#line default
#line hidden
            EndContext();
            BeginContext(1834, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1886, 43, false);
#line 36 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                       Write(entry.Value.FantasyLeagueStandingsNav.Draws);

#line default
#line hidden
            EndContext();
            BeginContext(1929, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(1981, 51, false);
#line 37 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                       Write(entry.Value.FantasyLeagueStandingsNav.FantasyPoints);

#line default
#line hidden
            EndContext();
            BeginContext(2032, 51, true);
            WriteLiteral("</td>\r\n                                        <td>");
            EndContext();
            BeginContext(2084, 58, false);
#line 38 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                       Write(entry.Value.FantasyLeagueStandingsNav.FantasyPointsAgainst);

#line default
#line hidden
            EndContext();
            BeginContext(2142, 50, true);
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
            EndContext();
#line 40 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                }

#line default
#line hidden
            BeginContext(2227, 438, true);
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class=""col-md-5 matchups-div"">
                <div class=""card text-center w-100"">
                    <div class=""card-header"">Matchups</div>
                    <div class=""card-body"">
                        <div class=""current-week-flex"">
                            ");
            EndContext();
            BeginContext(2665, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "181dfc7f616f34a1ba076dc64900c81f1aa3ccc613485", async() => {
                BeginContext(2804, 2, true);
                WriteLiteral("<<");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 51 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                  WriteLiteral(Model.FantasyLeague.FantasyLeagueID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 51 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                                                 WriteLiteral(Model.SelectedWeek - 1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["selectedWeek"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-selectedWeek", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["selectedWeek"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2810, 64, true);
            WriteLiteral("\r\n                            <div class=\"btn btn-primary\">Week ");
            EndContext();
            BeginContext(2875, 18, false);
#line 52 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                         Write(Model.SelectedWeek);

#line default
#line hidden
            EndContext();
            BeginContext(2893, 36, true);
            WriteLiteral("</div>\r\n                            ");
            EndContext();
            BeginContext(2929, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "181dfc7f616f34a1ba076dc64900c81f1aa3ccc617295", async() => {
                BeginContext(3068, 2, true);
                WriteLiteral(">>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                  WriteLiteral(Model.FantasyLeague.FantasyLeagueID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 53 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                                                 WriteLiteral(Model.SelectedWeek + 1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["selectedWeek"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-selectedWeek", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["selectedWeek"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3074, 34, true);
            WriteLiteral("\r\n                        </div>\r\n");
            EndContext();
#line 55 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                         if (Model.Matchups != null)
                        {
                            

#line default
#line hidden
#line 57 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                             foreach (var m in Model.Matchups)
                            {

#line default
#line hidden
            BeginContext(3284, 377, true);
            WriteLiteral(@"                                <div class=""card matchups-card"">
                                    <div class=""card-body text-center"">
                                        <table class=""table table-hover"">
                                            <tbody>
                                                <tr>
                                                    <td>");
            EndContext();
            BeginContext(3661, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "181dfc7f616f34a1ba076dc64900c81f1aa3ccc621618", async() => {
                BeginContext(3740, 18, false);
#line 64 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                                                 Write(m.AwayTeamNav.Name);

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
#line 64 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                           WriteLiteral(m.AwayTeamID);

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
            BeginContext(3762, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(3826, 15, false);
#line 65 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                   Write(m.AwayTeamScore);

#line default
#line hidden
            EndContext();
            BeginContext(3841, 172, true);
            WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <td>");
            EndContext();
            BeginContext(4013, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "181dfc7f616f34a1ba076dc64900c81f1aa3ccc625149", async() => {
                BeginContext(4092, 18, false);
#line 68 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                                                 Write(m.HomeTeamNav.Name);

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
#line 68 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                           WriteLiteral(m.HomeTeamID);

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
            BeginContext(4114, 63, true);
            WriteLiteral("</td>\r\n                                                    <td>");
            EndContext();
            BeginContext(4178, 15, false);
#line 69 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                   Write(m.HomeTeamScore);

#line default
#line hidden
            EndContext();
            BeginContext(4193, 325, true);
            WriteLiteral(@"</td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                    <div class=""card-footer text-center"">
                                        ");
            EndContext();
            BeginContext(4518, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "181dfc7f616f34a1ba076dc64900c81f1aa3ccc628830", async() => {
                BeginContext(4610, 11, true);
                WriteLiteral("See Matchup");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 75 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                                                                                                   WriteLiteral(m.FantasyMatchupID);

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
            BeginContext(4625, 86, true);
            WriteLiteral("\r\n                                    </div>\r\n                                </div>\r\n");
            EndContext();
#line 78 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                            }

#line default
#line hidden
#line 78 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\_DetailsAfter.cshtml"
                             
                        }

#line default
#line hidden
            BeginContext(4769, 100, true);
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.ViewModels.FantasyLeagueDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d423e06bfbb05de8b1254bce40f68b89e6c0e461"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FantasyMatchups_Details), @"mvc.1.0.view", @"/Views/FantasyMatchups/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FantasyMatchups/Details.cshtml", typeof(AspNetCore.Views_FantasyMatchups_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d423e06bfbb05de8b1254bce40f68b89e6c0e461", @"/Views/FantasyMatchups/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_FantasyMatchups_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.ViewModels.FantasyMatchupDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FantasyLeagues", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MyTeams", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Players", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
  
    ViewData["Title"] = "Details";
    

#line default
#line hidden
            BeginContext(112, 154, true);
            WriteLiteral("\r\n\r\n    <div class=\"container container-fluid bg-white\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12 text-center\">\r\n                <h3>");
            EndContext();
            BeginContext(266, 156, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d423e06bfbb05de8b1254bce40f68b89e6c0e4614993", async() => {
                BeginContext(376, 42, false);
#line 12 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                                            Write(Model.FantasyMatchup.FantasyLeagueNav.Name);

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
#line 12 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                              WriteLiteral(Model.FantasyMatchup.FantasyLeagueID);

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
            BeginContext(422, 33, true);
            WriteLiteral("</h3>\r\n                <h6>Week (");
            EndContext();
            BeginContext(456, 25, false);
#line 13 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                     Write(Model.FantasyMatchup.Week);

#line default
#line hidden
            EndContext();
            BeginContext(481, 5, true);
            WriteLiteral(") -- ");
            EndContext();
            BeginContext(487, 30, false);
#line 13 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                    Write(Model.Date.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(517, 268, true);
            WriteLiteral(@"</h6>
                <hr />
            </div>
        </div>
        <div class=""row"">
            <div class=""col-md-6"">
                <div class=""card w-100"">
                    <div class=""card-header"">
                        <div class=""text-center"">");
            EndContext();
            BeginContext(785, 139, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d423e06bfbb05de8b1254bce40f68b89e6c0e4618959", async() => {
                BeginContext(883, 37, false);
#line 21 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                                                             Write(Model.FantasyMatchup.AwayTeamNav.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 21 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                    WriteLiteral(Model.FantasyMatchup.AwayTeamID);

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
            BeginContext(924, 57, true);
            WriteLiteral("</div>\r\n                        <div class=\"text-center\">");
            EndContext();
            BeginContext(982, 49, false);
#line 22 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                            Write(Model.FantasyMatchup.AwayTeamNav.UserNav.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1031, 494, true);
            WriteLiteral(@"</div>
                    </div>
                    <div class=""card-body text-center"">
                        <table class=""table table-hover"">
                            <thead>
                                <tr>
                                    <th>Pos</th>
                                    <th>Player</th>
                                    <th>Opp</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 34 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                 foreach (KeyValuePair<string, Player> entry in Model.AwayRoster)
                                {

#line default
#line hidden
            BeginContext(1659, 78, true);
            WriteLiteral("                                <tr>\r\n                                    <td>");
            EndContext();
            BeginContext(1738, 9, false);
#line 37 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                   Write(entry.Key);

#line default
#line hidden
            EndContext();
            BeginContext(1747, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 38 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                     if (entry.Value != null)
                                    {

#line default
#line hidden
            BeginContext(1856, 44, true);
            WriteLiteral("                                        <td>");
            EndContext();
            BeginContext(1900, 111, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d423e06bfbb05de8b1254bce40f68b89e6c0e46114052", async() => {
                BeginContext(1987, 20, false);
#line 40 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                                             Write(entry.Value.FullName);

#line default
#line hidden
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
#line 40 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                               WriteLiteral(entry.Value.PlayerID);

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
            BeginContext(2011, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 41 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(2138, 51, true);
            WriteLiteral("                                        <td></td>\r\n");
            EndContext();
#line 45 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                    }

#line default
#line hidden
            BeginContext(2228, 42, true);
            WriteLiteral("                                    <td>\r\n");
            EndContext();
#line 47 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                         if (Model.AwayOpp[entry.Key] != null)
                                        {

#line default
#line hidden
            BeginContext(2393, 48, true);
            WriteLiteral("                                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2441, "\"", 2472, 1);
#line 49 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
WriteAttributeValue("", 2447, Model.AwayOpp[entry.Key], 2447, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2473, 24, true);
            WriteLiteral(" class=\"teamLogoSM\" />\r\n");
            EndContext();
#line 50 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                        }

#line default
#line hidden
            BeginContext(2540, 82, true);
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 53 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                }

#line default
#line hidden
            BeginContext(2657, 215, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                    <div class=\"card-footer text-center\">\r\n                        <div class=\"text-center\">Score: ");
            EndContext();
            BeginContext(2873, 34, false);
#line 58 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                   Write(Model.FantasyMatchup.AwayTeamScore);

#line default
#line hidden
            EndContext();
            BeginContext(2907, 254, true);
            WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n            <div class=\"col-md-6\">\r\n                <div class=\"card w-100\">\r\n                    <div class=\"card-header\">\r\n                        <div class=\"text-center\">");
            EndContext();
            BeginContext(3161, 139, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d423e06bfbb05de8b1254bce40f68b89e6c0e46120067", async() => {
                BeginContext(3259, 37, false);
#line 65 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                                                             Write(Model.FantasyMatchup.HomeTeamNav.Name);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 65 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                    WriteLiteral(Model.FantasyMatchup.HomeTeamID);

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
            BeginContext(3300, 57, true);
            WriteLiteral("</div>\r\n                        <div class=\"text-center\">");
            EndContext();
            BeginContext(3358, 49, false);
#line 66 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                            Write(Model.FantasyMatchup.HomeTeamNav.UserNav.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(3407, 494, true);
            WriteLiteral(@"</div>
                    </div>
                    <div class=""card-body text-center"">
                        <table class=""table table-hover"">
                            <thead>
                                <tr>
                                    <th>Pos</th>
                                    <th>Player</th>
                                    <th>Opp</th>
                                </tr>
                            </thead>
                            <tbody>
");
            EndContext();
#line 78 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                 foreach (KeyValuePair<string, Player> entry in Model.HomeRoster)
                                {

#line default
#line hidden
            BeginContext(4035, 78, true);
            WriteLiteral("                                <tr>\r\n                                    <td>");
            EndContext();
            BeginContext(4114, 9, false);
#line 81 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                   Write(entry.Key);

#line default
#line hidden
            EndContext();
            BeginContext(4123, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 82 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                     if (entry.Value != null)
                                    {

#line default
#line hidden
            BeginContext(4232, 44, true);
            WriteLiteral("                                        <td>");
            EndContext();
            BeginContext(4276, 111, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d423e06bfbb05de8b1254bce40f68b89e6c0e46125164", async() => {
                BeginContext(4363, 20, false);
#line 84 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                                                             Write(entry.Value.FullName);

#line default
#line hidden
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
#line 84 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                                                               WriteLiteral(entry.Value.PlayerID);

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
            BeginContext(4387, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 85 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(4514, 51, true);
            WriteLiteral("                                        <td></td>\r\n");
            EndContext();
#line 89 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                    }

#line default
#line hidden
            BeginContext(4604, 42, true);
            WriteLiteral("                                    <td>\r\n");
            EndContext();
#line 91 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                         if (Model.HomeOpp[entry.Key] != null)
                                        {

#line default
#line hidden
            BeginContext(4769, 44, true);
            WriteLiteral("                                        <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4813, "\"", 4844, 1);
#line 93 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
WriteAttributeValue("", 4819, Model.HomeOpp[entry.Key], 4819, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4845, 24, true);
            WriteLiteral(" class=\"teamLogoSM\" />\r\n");
            EndContext();
#line 94 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                        }

#line default
#line hidden
            BeginContext(4912, 82, true);
            WriteLiteral("                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 97 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                }

#line default
#line hidden
            BeginContext(5029, 215, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n                    </div>\r\n                    <div class=\"card-footer text-center\">\r\n                        <div class=\"text-center\">Score: ");
            EndContext();
            BeginContext(5245, 34, false);
#line 102 "C:\Users\kebell\source\repos\dotnet_basketball\NBAMvc1.1\Views\FantasyMatchups\Details.cshtml"
                                                   Write(Model.FantasyMatchup.AwayTeamScore);

#line default
#line hidden
            EndContext();
            BeginContext(5279, 108, true);
            WriteLiteral("</div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.ViewModels.FantasyMatchupDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

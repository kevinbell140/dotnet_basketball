#pragma checksum "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6536ce5944390ff14a609bce395e1a2fd16eb509"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6536ce5944390ff14a609bce395e1a2fd16eb509", @"/Views/Teams/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Teams_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.ViewModels.TeamDetailsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(96, 141, true);
            WriteLiteral("\r\n\r\n<div class=\"container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-12\">\r\n            <div class=\"jumbotron jumbotron-fluid\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 237, "\"", 287, 2);
            WriteAttributeValue("", 245, "background-color:#", 245, 18, true);
#line 11 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 263, Model.Team.PrimaryColor, 263, 24, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(288, 163, true);
            WriteLiteral(">\r\n                <div class=\"container\">\r\n                    <div class=\"row\">\r\n                        <div class=\"col-md-3\">\r\n                            <img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 451, "\"", 485, 1);
#line 15 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 457, Model.Team.WikipediaLogoUrl, 457, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(486, 251, true);
            WriteLiteral(" class=\"teamLogoHeader\" />\r\n                        </div>\r\n                        <div class=\"col-md-4\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col-md-12\">\r\n                                    <h1");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 737, "\"", 778, 2);
            WriteAttributeValue("", 745, "color:#", 745, 7, true);
#line 20 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 752, Model.Team.SecondaryColor, 752, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(779, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(781, 45, false);
#line 20 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                             Write(Html.DisplayFor(model => model.Team.FullName));

#line default
#line hidden
            EndContext();
            BeginContext(826, 226, true);
            WriteLiteral("</h1>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <div class=\"col-md-12\">\r\n                                    <h5");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1052, "\"", 1093, 2);
            WriteAttributeValue("", 1060, "color:#", 1060, 7, true);
#line 25 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 1067, Model.Team.SecondaryColor, 1067, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1094, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1096, 25, false);
#line 25 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                             Write(Model.Team.RecordNav.Wins);

#line default
#line hidden
            EndContext();
            BeginContext(1121, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(1125, 27, false);
#line 25 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                                                          Write(Model.Team.RecordNav.Losses);

#line default
#line hidden
            EndContext();
            BeginContext(1152, 226, true);
            WriteLiteral("</h5>\r\n                                </div>\r\n                            </div>\r\n                            <div class=\"row\">\r\n                                <div class=\"col-md-12\">\r\n                                    <h5");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1378, "\"", 1419, 2);
            WriteAttributeValue("", 1386, "color:#", 1386, 7, true);
#line 30 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 1393, Model.Team.SecondaryColor, 1393, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1420, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(1422, 20, false);
#line 30 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                             Write(Model.ConferenceRank);

#line default
#line hidden
            EndContext();
            BeginContext(1442, 8, true);
            WriteLiteral(" in the ");
            EndContext();
            BeginContext(1451, 21, false);
#line 30 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                                                          Write(Model.Team.Conference);

#line default
#line hidden
            EndContext();
            BeginContext(1472, 361, true);
            WriteLiteral(@" Conference</h5>
                                </div>
                            </div>
                        </div>
                        <div class=""col-md-5"">
                            <div class=""row"">
                                <div class=""col-md-4 offset-8"">
                                    <table class=""table table- float-right""");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 1833, "\"", 1874, 2);
            WriteAttributeValue("", 1841, "color:#", 1841, 7, true);
#line 37 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 1848, Model.Team.SecondaryColor, 1848, 26, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1875, 544, true);
            WriteLiteral(@">
                                        <thead>
                                            <tr>
                                                <td>PPG</td>
                                                <td>RPG</td>
                                                <td>APG</td>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2419, "\"", 2450, 1);
#line 47 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 2425, Model.PPGLeader.PhotoUrl, 2425, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2451, 26, true);
            WriteLiteral(" class=\"playerHeadShot\" />");
            EndContext();
            BeginContext(2478, 24, false);
#line 47 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                                                             Write(Model.PPGLeader.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(2502, 63, true);
            WriteLiteral("</td>\r\n                                                <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2565, "\"", 2596, 1);
#line 48 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 2571, Model.RPGLeader.PhotoUrl, 2571, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2597, 26, true);
            WriteLiteral(" class=\"playerHeadShot\" />");
            EndContext();
            BeginContext(2624, 24, false);
#line 48 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                                                             Write(Model.RPGLeader.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(2648, 63, true);
            WriteLiteral("</td>\r\n                                                <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 2711, "\"", 2742, 1);
#line 49 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 2717, Model.APGLeader.PhotoUrl, 2717, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2743, 26, true);
            WriteLiteral(" class=\"playerHeadShot\" />");
            EndContext();
            BeginContext(2770, 24, false);
#line 49 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                                                                                             Write(Model.APGLeader.LastName);

#line default
#line hidden
            EndContext();
            BeginContext(2794, 160, true);
            WriteLiteral("</td>\r\n                                            </tr>\r\n                                            <tr>\r\n                                                <td>");
            EndContext();
            BeginContext(2955, 28, false);
#line 52 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                               Write(Model.PPGLeader.StatsNav.PPG);

#line default
#line hidden
            EndContext();
            BeginContext(2983, 59, true);
            WriteLiteral("</td>\r\n                                                <td>");
            EndContext();
            BeginContext(3043, 28, false);
#line 53 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                               Write(Model.RPGLeader.StatsNav.RPG);

#line default
#line hidden
            EndContext();
            BeginContext(3071, 59, true);
            WriteLiteral("</td>\r\n                                                <td>");
            EndContext();
            BeginContext(3131, 28, false);
#line 54 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                               Write(Model.APGLeader.StatsNav.APG);

#line default
#line hidden
            EndContext();
            BeginContext(3159, 572, true);
            WriteLiteral(@"</td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-md-6"">
            <h4>Roster</h4>
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th>");
            EndContext();
            BeginContext(3732, 79, false);
#line 72 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                       Write(Html.ActionLink("Pos", "Details", new { sortOrder = ViewData["PosSortParam"] }));

#line default
#line hidden
            EndContext();
            BeginContext(3811, 35, true);
            WriteLiteral("</th>\r\n                        <th>");
            EndContext();
            BeginContext(3847, 85, false);
#line 73 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                       Write(Html.ActionLink("Player", "Details", new { sortOrder = ViewData["PlayerSortParam"] }));

#line default
#line hidden
            EndContext();
            BeginContext(3932, 35, true);
            WriteLiteral("</th>\r\n                        <th>");
            EndContext();
            BeginContext(3968, 79, false);
#line 74 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                       Write(Html.ActionLink("PPG", "Details", new { sortOrder = ViewData["PPGSortParam"] }));

#line default
#line hidden
            EndContext();
            BeginContext(4047, 35, true);
            WriteLiteral("</th>\r\n                        <th>");
            EndContext();
            BeginContext(4083, 79, false);
#line 75 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                       Write(Html.ActionLink("RPG", "Details", new { sortOrder = ViewData["RPGSortParam"] }));

#line default
#line hidden
            EndContext();
            BeginContext(4162, 35, true);
            WriteLiteral("</th>\r\n                        <th>");
            EndContext();
            BeginContext(4198, 79, false);
#line 76 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                       Write(Html.ActionLink("APG", "Details", new { sortOrder = ViewData["APGSortParam"] }));

#line default
#line hidden
            EndContext();
            BeginContext(4277, 85, true);
            WriteLiteral("</th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
            EndContext();
#line 80 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                     foreach (var p in Model.Players)
                    {

#line default
#line hidden
            BeginContext(4440, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(4503, 10, false);
#line 83 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(p.Position);

#line default
#line hidden
            EndContext();
            BeginContext(4513, 40, true);
            WriteLiteral(" </td>\r\n                            <td>");
            EndContext();
            BeginContext(4554, 73, false);
#line 84 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(Html.ActionLink(p.FullName, "Details", "Players", new { id = p.PlayerID}));

#line default
#line hidden
            EndContext();
            BeginContext(4627, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4667, 14, false);
#line 85 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(p.StatsNav.PPG);

#line default
#line hidden
            EndContext();
            BeginContext(4681, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4721, 14, false);
#line 86 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(p.StatsNav.RPG);

#line default
#line hidden
            EndContext();
            BeginContext(4735, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(4775, 14, false);
#line 87 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(p.StatsNav.APG);

#line default
#line hidden
            EndContext();
            BeginContext(4789, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 89 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                    }

#line default
#line hidden
            BeginContext(4850, 466, true);
            WriteLiteral(@"
                </tbody>
            </table>
        </div>
        <div class=""col-md-6"">
            <h4>Recent Games</h4>
            <table class=""table table-hover"">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Home</th>
                        <th>Away</th>
                        <th>Score</th>
                    </tr>
                </thead>
                <tbody>
");
            EndContext();
#line 106 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                     foreach (var g in Model.Next3.Reverse())
                    {

#line default
#line hidden
            BeginContext(5402, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(5465, 10, false);
#line 109 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(g.DateTime);

#line default
#line hidden
            EndContext();
            BeginContext(5475, 43, true);
            WriteLiteral("</td>\r\n                            <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 5518, "\"", 5555, 1);
#line 110 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 5524, g.HomeTeamNav.WikipediaLogoUrl, 5524, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5556, 63, true);
            WriteLiteral(" class=\"teamLogo\" /></td>\r\n                            <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 5619, "\"", 5656, 1);
#line 111 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 5625, g.AwayTeamNav.WikipediaLogoUrl, 5625, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5657, 105, true);
            WriteLiteral(" class=\"teamLogo\" /></td>\r\n                            <td>Upcoming</td>\r\n                        </tr>\r\n");
            EndContext();
#line 114 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                    }

#line default
#line hidden
            BeginContext(5785, 20, true);
            WriteLiteral("                    ");
            EndContext();
#line 115 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                     foreach (var g in Model.Last5)
                    {

#line default
#line hidden
            BeginContext(5861, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(5924, 10, false);
#line 118 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(g.DateTime);

#line default
#line hidden
            EndContext();
            BeginContext(5934, 43, true);
            WriteLiteral("</td>\r\n                            <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 5977, "\"", 6014, 1);
#line 119 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 5983, g.HomeTeamNav.WikipediaLogoUrl, 5983, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6015, 63, true);
            WriteLiteral(" class=\"teamLogo\" /></td>\r\n                            <td><img");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 6078, "\"", 6115, 1);
#line 120 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
WriteAttributeValue("", 6084, g.AwayTeamNav.WikipediaLogoUrl, 6084, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6116, 59, true);
            WriteLiteral(" class=\"teamLogo\" /></td>\r\n                            <td>");
            EndContext();
            BeginContext(6176, 15, false);
#line 121 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                           Write(g.HomeTeamScore);

#line default
#line hidden
            EndContext();
            BeginContext(6191, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(6195, 15, false);
#line 121 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                                              Write(g.AwayTeamScore);

#line default
#line hidden
            EndContext();
            BeginContext(6210, 38, true);
            WriteLiteral("</td>\r\n                        </tr>\r\n");
            EndContext();
#line 123 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\Teams\Details.cshtml"
                    }

#line default
#line hidden
            BeginContext(6271, 87, true);
            WriteLiteral("\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n    </div>\r\n </div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.ViewModels.TeamDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

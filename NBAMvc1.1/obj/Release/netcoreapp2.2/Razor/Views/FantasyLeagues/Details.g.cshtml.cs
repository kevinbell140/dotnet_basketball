#pragma checksum "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "62bc493d00935389c9a545b367d4f66027d203b5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_FantasyLeagues_Details), @"mvc.1.0.view", @"/Views/FantasyLeagues/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/FantasyLeagues/Details.cshtml", typeof(AspNetCore.Views_FantasyLeagues_Details))]
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
#line 2 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"62bc493d00935389c9a545b367d4f66027d203b5", @"/Views/FantasyLeagues/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_FantasyLeagues_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.ViewModels.FantasyLeagueDetailsViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "FantasyMatchups", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "MyTeams", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(156, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 6 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
  
    ViewData["Title"] = Model.FantasyLeague.Name;

#line default
#line hidden
            BeginContext(218, 152, true);
            WriteLiteral("\r\n    <div class=\"container container-fluid bg-white\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12 text-center\">\r\n                <h3>");
            EndContext();
            BeginContext(371, 24, false);
#line 13 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
               Write(Model.FantasyLeague.Name);

#line default
#line hidden
            EndContext();
            BeginContext(395, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 14 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                 if ((await AuthorizationService.AuthorizeAsync(User, "AdminOnly")).Succeeded)
                {

#line default
#line hidden
            BeginContext(517, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(537, 145, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62bc493d00935389c9a545b367d4f66027d203b56326", async() => {
                BeginContext(663, 15, true);
                WriteLiteral("Create schedule");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-leagueID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 16 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                                                    WriteLiteral(Model.FantasyLeague.FantasyLeagueID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["leagueID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-leagueID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["leagueID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(682, 66, true);
            WriteLiteral("\r\n                    <span class=\"text-center\" style=\"color:red\">");
            EndContext();
            BeginContext(749, 18, false);
#line 17 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                           Write(TempData["NotSet"]);

#line default
#line hidden
            EndContext();
            BeginContext(767, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 18 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(795, 139, true);
            WriteLiteral("            </div>\r\n        </div>\r\n        <div class=\"row\">\r\n            <div class=\"col-md-2\">\r\n                <span style=\"color:red\">");
            EndContext();
            BeginContext(936, 53, false);
#line 23 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                    Write(Model.FantasyLeague.IsFull == false ? "Open" : "Full");

#line default
#line hidden
            EndContext();
            BeginContext(990, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 24 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                 if (!Model.FantasyLeague.IsFull)
                {

#line default
#line hidden
            BeginContext(1069, 20, true);
            WriteLiteral("                    ");
            EndContext();
            BeginContext(1089, 138, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "62bc493d00935389c9a545b367d4f66027d203b510705", async() => {
                BeginContext(1219, 4, true);
                WriteLiteral("Join");
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
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-leagueID", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 26 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                                            WriteLiteral(Model.FantasyLeague.FantasyLeagueID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["leagueID"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-leagueID", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["leagueID"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1227, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 27 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                }

#line default
#line hidden
            BeginContext(1248, 96, true);
            WriteLiteral("            </div>\r\n            <div class=\"col-md-2\">\r\n                <span style=\"color:red\">");
            EndContext();
            BeginContext(1346, 54, false);
#line 30 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                    Write(Model.FantasyLeague.IsSet == false ? "Not set" : "Set");

#line default
#line hidden
            EndContext();
            BeginContext(1401, 119, true);
            WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n                <span style=\"color:red\">Commissioner: ");
            EndContext();
            BeginContext(1521, 43, false);
#line 33 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                 Write(Model.FantasyLeague.ComissionerNav.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(1564, 119, true);
            WriteLiteral("</span>\r\n            </div>\r\n            <div class=\"col-md-2\">\r\n                <span style=\"color:red\">Current Week: ");
            EndContext();
            BeginContext(1684, 17, false);
#line 36 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                 Write(Model.CurrentWeek);

#line default
#line hidden
            EndContext();
            BeginContext(1701, 88, true);
            WriteLiteral("</span>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r\n");
            EndContext();
#line 41 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
             if(!Model.FantasyLeague.IsActive)
            {
                

#line default
#line hidden
            BeginContext(1869, 48, false);
#line 43 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
           Write(await Html.PartialAsync("_DetailsBefore", Model));

#line default
#line hidden
            EndContext();
#line 43 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                                 ;
            }
            else
            {
                

#line default
#line hidden
            BeginContext(1985, 47, false);
#line 47 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
           Write(await Html.PartialAsync("_DetailsAfter", Model));

#line default
#line hidden
            EndContext();
#line 47 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\FantasyLeagues\Details.cshtml"
                                                                ;
            }

#line default
#line hidden
            BeginContext(2050, 30, true);
            WriteLiteral("        </div>\r\n    </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.ViewModels.FantasyLeagueDetailsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

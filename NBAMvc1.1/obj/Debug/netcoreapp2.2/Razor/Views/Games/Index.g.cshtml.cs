#pragma checksum "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ebb258cbfca660ef1de84d23da2606e0c2a58847"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_Index), @"mvc.1.0.view", @"/Views/Games/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Games/Index.cshtml", typeof(AspNetCore.Views_Games_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ebb258cbfca660ef1de84d23da2606e0c2a58847", @"/Views/Games/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<NBAMvc1._1.ViewModels.GameIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
  
    ViewData["Title"] = "Index";
    int count = 0;

#line default
#line hidden
            BeginContext(112, 230, true);
            WriteLiteral("\r\n<div class=\"container container-fluid\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-8 offset-1\">\r\n            <h4 class=\"text-center\">Schedule</h4>\r\n            <div class=\"text-center game-index-dates\">\r\n                ");
            EndContext();
            BeginContext(342, 149, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebb258cbfca660ef1de84d23da2606e0c2a588474423", async() => {
                BeginContext(438, 49, false);
#line 13 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                                                                          Write(Model.dayOf.Value.AddDays(-1).ToShortDateString());

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-dayOf", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 13 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                                   WriteLiteral(Model.dayOf.Value.AddDays(-1));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dayOf"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-dayOf", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dayOf"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(491, 57, true);
            WriteLiteral("\r\n                <span style=\"margin: 0px 5px 5px 5px;\">");
            EndContext();
            BeginContext(549, 37, false);
#line 14 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                  Write(Model.dayOf.Value.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(586, 27, true);
            WriteLiteral("</span>\r\n\r\n                ");
            EndContext();
            BeginContext(613, 147, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ebb258cbfca660ef1de84d23da2606e0c2a588477640", async() => {
                BeginContext(708, 48, false);
#line 16 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                                                                         Write(Model.dayOf.Value.AddDays(1).ToShortDateString());

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-dayOf", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 16 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                                   WriteLiteral(Model.dayOf.Value.AddDays(1));

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dayOf"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-dayOf", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["dayOf"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(760, 24, true);
            WriteLiteral("\r\n            </div>\r\n\r\n");
            EndContext();
#line 19 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
             foreach (var g in Model.Games)
            {
                

#line default
#line hidden
#line 21 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                 if (Model.dayOf.Value < DateTime.Today)
                {
                    

#line default
#line hidden
            BeginContext(942, 143, false);
#line 23 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
               Write(await Html.PartialAsync("_IndexAfter", g, new ViewDataDictionary(ViewData) { { "a", Model.Leaders[count++] }, {"b", Model.Leaders[count++]} } ));

#line default
#line hidden
            EndContext();
#line 23 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                                                                                                                                    
                }
                else
                {
                    

#line default
#line hidden
            BeginContext(1168, 42, false);
#line 27 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
               Write(await Html.PartialAsync("_IndexBefore", g));

#line default
#line hidden
            EndContext();
#line 27 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                                                               
                }

#line default
#line hidden
#line 28 "C:\Users\kebell\Source\Repos\dotnet_basketball_2.0\NBAMvc1.1\Views\Games\Index.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(1246, 36, true);
            WriteLiteral("        </div>\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<NBAMvc1._1.ViewModels.GameIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "932ef95864610994945cd0e8f66be88c70e8fbd5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlayerGameStats_Index), @"mvc.1.0.view", @"/Views/PlayerGameStats/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/PlayerGameStats/Index.cshtml", typeof(AspNetCore.Views_PlayerGameStats_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"932ef95864610994945cd0e8f66be88c70e8fbd5", @"/Views/PlayerGameStats/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"50b20c45ce8e37812bd9341781de72ef5fed7e2f", @"/Views/_ViewImports.cshtml")]
    public class Views_PlayerGameStats_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NBAMvc1._1.Models.PlayerGameStats>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(55, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(98, 29, true);
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(127, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "932ef95864610994945cd0e8f66be88c70e8fbd54771", async() => {
                BeginContext(150, 10, true);
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
            BeginContext(164, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(257, 43, false);
#line 16 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(300, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(356, 43, false);
#line 19 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Minutes));

#line default
#line hidden
            EndContext();
            BeginContext(399, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(455, 50, false);
#line 22 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FieldGoalsMade));

#line default
#line hidden
            EndContext();
            BeginContext(505, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(561, 55, false);
#line 25 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FieldGoalsAttempted));

#line default
#line hidden
            EndContext();
            BeginContext(616, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(672, 56, false);
#line 28 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FieldGoalsPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(728, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(784, 53, false);
#line 31 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ThreePointersMade));

#line default
#line hidden
            EndContext();
            BeginContext(837, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(893, 58, false);
#line 34 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ThreePointersAttempted));

#line default
#line hidden
            EndContext();
            BeginContext(951, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1007, 59, false);
#line 37 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.ThreePointersPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(1066, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1122, 50, false);
#line 40 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FreeThrowsMade));

#line default
#line hidden
            EndContext();
            BeginContext(1172, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1228, 55, false);
#line 43 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FreeThrowsAttempted));

#line default
#line hidden
            EndContext();
            BeginContext(1283, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1339, 56, false);
#line 46 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.FreeThrowsPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(1395, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1451, 53, false);
#line 49 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.OffensiveRebounds));

#line default
#line hidden
            EndContext();
            BeginContext(1504, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1560, 53, false);
#line 52 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.DefensiveRebounds));

#line default
#line hidden
            EndContext();
            BeginContext(1613, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1669, 44, false);
#line 55 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Rebounds));

#line default
#line hidden
            EndContext();
            BeginContext(1713, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1769, 43, false);
#line 58 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Assists));

#line default
#line hidden
            EndContext();
            BeginContext(1812, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1868, 42, false);
#line 61 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Steals));

#line default
#line hidden
            EndContext();
            BeginContext(1910, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1966, 48, false);
#line 64 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.BlockedShots));

#line default
#line hidden
            EndContext();
            BeginContext(2014, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2070, 45, false);
#line 67 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Turnovers));

#line default
#line hidden
            EndContext();
            BeginContext(2115, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2171, 49, false);
#line 70 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PersonalFouls));

#line default
#line hidden
            EndContext();
            BeginContext(2220, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2276, 42, false);
#line 73 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Points));

#line default
#line hidden
            EndContext();
            BeginContext(2318, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2374, 45, false);
#line 76 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PlusMinus));

#line default
#line hidden
            EndContext();
            BeginContext(2419, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2475, 45, false);
#line 79 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.PlayerNav));

#line default
#line hidden
            EndContext();
            BeginContext(2520, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(2576, 43, false);
#line 82 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.GameNav));

#line default
#line hidden
            EndContext();
            BeginContext(2619, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 88 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(2737, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2786, 42, false);
#line 91 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Updated));

#line default
#line hidden
            EndContext();
            BeginContext(2828, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2884, 42, false);
#line 94 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Minutes));

#line default
#line hidden
            EndContext();
            BeginContext(2926, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(2982, 49, false);
#line 97 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FieldGoalsMade));

#line default
#line hidden
            EndContext();
            BeginContext(3031, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3087, 54, false);
#line 100 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FieldGoalsAttempted));

#line default
#line hidden
            EndContext();
            BeginContext(3141, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3197, 55, false);
#line 103 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FieldGoalsPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(3252, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3308, 52, false);
#line 106 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ThreePointersMade));

#line default
#line hidden
            EndContext();
            BeginContext(3360, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3416, 57, false);
#line 109 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ThreePointersAttempted));

#line default
#line hidden
            EndContext();
            BeginContext(3473, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3529, 58, false);
#line 112 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.ThreePointersPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(3587, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3643, 49, false);
#line 115 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FreeThrowsMade));

#line default
#line hidden
            EndContext();
            BeginContext(3692, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3748, 54, false);
#line 118 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FreeThrowsAttempted));

#line default
#line hidden
            EndContext();
            BeginContext(3802, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3858, 55, false);
#line 121 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.FreeThrowsPercentage));

#line default
#line hidden
            EndContext();
            BeginContext(3913, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(3969, 52, false);
#line 124 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.OffensiveRebounds));

#line default
#line hidden
            EndContext();
            BeginContext(4021, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4077, 52, false);
#line 127 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.DefensiveRebounds));

#line default
#line hidden
            EndContext();
            BeginContext(4129, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4185, 43, false);
#line 130 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Rebounds));

#line default
#line hidden
            EndContext();
            BeginContext(4228, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4284, 42, false);
#line 133 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Assists));

#line default
#line hidden
            EndContext();
            BeginContext(4326, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4382, 41, false);
#line 136 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Steals));

#line default
#line hidden
            EndContext();
            BeginContext(4423, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4479, 47, false);
#line 139 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.BlockedShots));

#line default
#line hidden
            EndContext();
            BeginContext(4526, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4582, 44, false);
#line 142 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Turnovers));

#line default
#line hidden
            EndContext();
            BeginContext(4626, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4682, 48, false);
#line 145 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PersonalFouls));

#line default
#line hidden
            EndContext();
            BeginContext(4730, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4786, 41, false);
#line 148 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Points));

#line default
#line hidden
            EndContext();
            BeginContext(4827, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4883, 44, false);
#line 151 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PlusMinus));

#line default
#line hidden
            EndContext();
            BeginContext(4927, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(4983, 53, false);
#line 154 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.PlayerNav.PlayerID));

#line default
#line hidden
            EndContext();
            BeginContext(5036, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(5092, 49, false);
#line 157 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.GameNav.GameID));

#line default
#line hidden
            EndContext();
            BeginContext(5141, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(5196, 57, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "932ef95864610994945cd0e8f66be88c70e8fbd526383", async() => {
                BeginContext(5245, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 160 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
                                       WriteLiteral(item.StatID);

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
            BeginContext(5253, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(5273, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "932ef95864610994945cd0e8f66be88c70e8fbd528738", async() => {
                BeginContext(5325, 7, true);
                WriteLiteral("Details");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 161 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
                                          WriteLiteral(item.StatID);

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
            BeginContext(5336, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(5356, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "932ef95864610994945cd0e8f66be88c70e8fbd531099", async() => {
                BeginContext(5407, 6, true);
                WriteLiteral("Delete");
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
#line 162 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
                                         WriteLiteral(item.StatID);

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
            BeginContext(5417, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 165 "C:\Users\kebell\source\repos\NBAMvc1.1\NBAMvc1.1\Views\PlayerGameStats\Index.cshtml"
}

#line default
#line hidden
            BeginContext(5456, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NBAMvc1._1.Models.PlayerGameStats>> Html { get; private set; }
    }
}
#pragma warning restore 1591
#pragma checksum "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e8274973584979b12bc94ea3f87239b7edff51c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_InactiveItemsReport), @"mvc.1.0.view", @"/Views/Report/InactiveItemsReport.cshtml")]
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
#nullable restore
#line 1 "D:\PharmacyStore\Views\_ViewImports.cshtml"
using PharmacyStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\PharmacyStore\Views\_ViewImports.cshtml"
using PharmacyStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e8274973584979b12bc94ea3f87239b7edff51c", @"/Views/Report/InactiveItemsReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d61daf1b54ca99ff18b94cfed9924d3d45fe9176", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_InactiveItemsReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PharmacyStore.ViewModel.InactiveItemsModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
  
    ViewData["Title"] = "Inactive Items Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Inactive Item Details Report</h1>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr class=\"bg-primary\">\r\n            <th>\r\n                ");
#nullable restore
#line 13 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
           Write(Html.DisplayNameFor(model => model.StockQuantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 24 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.StockQuantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "D:\PharmacyStore\Views\Report\InactiveItemsReport.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PharmacyStore.ViewModel.InactiveItemsModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
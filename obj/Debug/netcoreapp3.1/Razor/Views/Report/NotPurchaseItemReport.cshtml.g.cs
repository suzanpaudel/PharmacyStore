#pragma checksum "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bdf0e8c785b41fc0cb140751773e524dd4c2172a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_NotPurchaseItemReport), @"mvc.1.0.view", @"/Views/Report/NotPurchaseItemReport.cshtml")]
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
#line 1 "E:\PharmacyStore\Views\_ViewImports.cshtml"
using PharmacyStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\PharmacyStore\Views\_ViewImports.cshtml"
using PharmacyStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bdf0e8c785b41fc0cb140751773e524dd4c2172a", @"/Views/Report/NotPurchaseItemReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d61daf1b54ca99ff18b94cfed9924d3d45fe9176", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_NotPurchaseItemReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PharmacyStore.ViewModel.NotPurchaseItemViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
  
    ViewData["Title"] = "Product Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Not Purchased Product Details Report</h1>\r\n\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 13 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
           Write(Html.DisplayNameFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
           Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>Actions</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 22 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 26 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 29 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td> <a");
            BeginWriteAttribute("href", " href=\"", 835, "\"", 874, 2);
            WriteAttributeValue("", 842, "/Products/Delete/", 842, 17, true);
#nullable restore
#line 31 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
WriteAttributeValue("", 859, item.ProductId, 859, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-outline-danger\">Delete</a></td>  \r\n            </tr>\r\n");
#nullable restore
#line 33 "E:\PharmacyStore\Views\Report\NotPurchaseItemReport.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PharmacyStore.ViewModel.NotPurchaseItemViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591

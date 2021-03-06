#pragma checksum "E:\PharmacyStore\Views\Report\BillingReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b12f01d8784ee46aabd9c23b5d3a49f87792376a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Report_BillingReport), @"mvc.1.0.view", @"/Views/Report/BillingReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b12f01d8784ee46aabd9c23b5d3a49f87792376a", @"/Views/Report/BillingReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d61daf1b54ca99ff18b94cfed9924d3d45fe9176", @"/Views/_ViewImports.cshtml")]
    public class Views_Report_BillingReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PharmacyStore.ViewModel.SalesInfo>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h4>Billing Summary</h4>
<hr />
<div class=""card"">
    <div class=""card-header"">
        <h4 class=""card-title text-center"">Unique Pharmacy Store</h4>
        <h6 class=""card-subtitle mb-2 text-muted text-center"">Baneshwor, Kathmandu</h6>
    </div>
    <div class=""card-body p-4"">
        
        <h6>CustomerName: ");
#nullable restore
#line 16 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                     Write(Html.DisplayFor(model =>model.CustomerName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n        <h6>CustomerEmail: ");
#nullable restore
#line 17 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                      Write(Html.DisplayFor(model =>model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
        
            <table class=""table table-bordered"">
                <thead>
                    <tr>
                        <th>ProductName</th>
                        <th>Description</th>
                        <th>Category</th>
                        <th>Quantity</th>
                        <th>Price</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>");
#nullable restore
#line 31 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                       Write(Html.DisplayFor(model => model.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 32 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 33 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                       Write(Html.DisplayFor(model => model.CategoryName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 34 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                       Write(Html.DisplayFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 35 "E:\PharmacyStore\Views\Report\BillingReport.cshtml"
                       Write(Html.DisplayFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n                </tbody>\r\n            </table>\r\n        </div>\r\n</div>\r\n<button class=\"btn btn-outline-primary my-4\">CheckOut</button>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PharmacyStore.ViewModel.SalesInfo> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\Shared\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c972d31795787a469fc8fc1ad09a41c31e690b94"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Error.cshtml", typeof(AspNetCore.Views_Shared_Error))]
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
#line 1 "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\_ViewImports.cshtml"
using EmployeeManagement.ViewModels;

#line default
#line hidden
#line 2 "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\_ViewImports.cshtml"
using EmployeeManagement.Models;

#line default
#line hidden
#line 3 "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 4 "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\_ViewImports.cshtml"
using XenteSDK;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c972d31795787a469fc8fc1ad09a41c31e690b94", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80bd32cc610f7e40d8d2d59d7ce737a186e07476", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\Shared\Error.cshtml"
   
    var message = ViewData.Eval("Message") as string;

#line default
#line hidden
            BeginContext(63, 160, true);
            WriteLiteral("\r\n\r\n<h3>\r\n    An error occured while processing your request. \r\n    The support team is notified and we are working on the fix\r\n</h3>\r\n\r\n<small>Error Message = ");
            EndContext();
            BeginContext(224, 7, false);
#line 11 "E:\Team Xente\Applications\AspNetCore\Azure Applications\ProductManagement\Views\Shared\Error.cshtml"
                  Write(message);

#line default
#line hidden
            EndContext();
            BeginContext(231, 76, true);
            WriteLiteral("</small>\r\n<h5>\r\n    Please contact us on olivenakiyemba@gmail.com\r\n</h5>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

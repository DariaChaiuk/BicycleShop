#pragma checksum "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0df93ccf7ad79b702c6259d39d80d8dbfe88d230"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_UserEdit), @"mvc.1.0.view", @"/Views/User/UserEdit.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0df93ccf7ad79b702c6259d39d80d8dbfe88d230", @"/Views/User/UserEdit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"23ac09be4bcfaa7f9829a01d1a134874eaae1f3b", @"/Views/_ViewImports.cshtml")]
    public class Views_User_UserEdit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ASP_HW_2.Models.ViewModels.UserChangePassword>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("editUser"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UserEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "User", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-flex w-100 flex-column align-items-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0df93ccf7ad79b702c6259d39d80d8dbfe88d2304717", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"w-100 d-flex justify-content-center mb-3 flex-column align-items-center\">\r\n        <h1 class=\"text-light\">Change Password</h1>\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
         if(!String.IsNullOrEmpty(ViewBag.Message))
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h4 class=\"text-success\">\r\n                ");
#nullable restore
#line 11 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
           Write(ViewBag.Message);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n            </h4>\r\n");
#nullable restore
#line 13 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("        \r\n    </div>\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0df93ccf7ad79b702c6259d39d80d8dbfe88d2305930", async() => {
                    WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 19 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.Hidden("UserId", ViewBag.UserId, null));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 21 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.LabelFor(x => x.OldPassword, "Enter your old password", new { @class = "mt-2 text-light" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n        ");
#nullable restore
#line 22 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.TextBoxFor(x => x.OldPassword, new { @type = "password", @class = "w-50" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 24 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.LabelFor(x => x.NewPassword, "Enter your new password", new { @class = "mt-2 text-light" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n        ");
#nullable restore
#line 25 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.TextBoxFor(x => x.NewPassword, new { @type = "password", @class = "w-50" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n        ");
#nullable restore
#line 27 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.LabelFor(x => x.ConfirmPassword, "Confirm your new password", new { @class = "mt-2 text-light" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n        ");
#nullable restore
#line 28 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
   Write(Html.TextBoxFor(x => x.ConfirmPassword, new { @type = "password", @class = "w-50" }));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n\r\n        <div>\r\n            ");
#nullable restore
#line 31 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
       Write(Html.ValidationMessageFor(x => x.OldPassword));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n            ");
#nullable restore
#line 32 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
       Write(Html.ValidationMessageFor(x => x.NewPassword));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n            ");
#nullable restore
#line 33 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
       Write(Html.ValidationMessageFor(x => x.ConfirmPassword));

#line default
#line hidden
#nullable disable
                    WriteLiteral("\r\n        </div>\r\n\r\n        <input type=\"submit\" value=\"Apply changes\" class=\"btn btn-light mt-4 w-50\" />\r\n    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
#nullable restore
#line 17 "C:\Users\Daria\source\repos\ASP_HW_2\ASP_HW_2\Views\User\UserEdit.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ASP_HW_2.Models.ViewModels.UserChangePassword> Html { get; private set; }
    }
}
#pragma warning restore 1591

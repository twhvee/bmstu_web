#pragma checksum "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b9577518a754240755b653dcef43aaba05c7767"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Post_Comadd), @"mvc.1.0.view", @"/Views/Post/Comadd.cshtml")]
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
#line 1 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\_ViewImports.cshtml"
using Course;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\_ViewImports.cshtml"
using Course.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
using Course.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b9577518a754240755b653dcef43aaba05c7767", @"/Views/Post/Comadd.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"376b029bb33b6341e99c19af0cfb4e3c2e2706cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Post_Comadd : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Course.ViewModel.CommentModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "text", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("input"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "Page.User.Identity", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Comadd", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<
<style>

    .date {
        color: #337AB7;
        opacity: 0.8;
    }

    .head {
        text-align: center;
        color: #337AB7;
    }

    .revsec {
        margin-top: 5px;
        //height: 500px;
        display: flex;
        flex-direction: row;
        justify-content: space-around;
        align-items: center;
        //box-shadow: 0 0 10px 5px rgba(221, 221, 221, 1);
    }

    .revimg {
        height: 450px;
        width: 350px;
    }

    .titlerev {
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: center;
    }

    .rate {
        display: flex;
        flex-direction: row;
        align-items: center;
    }

    .like {
        font-size: 18px;
        display: flex;
        flex-direction: row;
        justify-content: space-between;
        align-items: center;
    }

    .likes {
        display: flex;
        flex-direction: row;
        justify-content: center;
 ");
            WriteLiteral(@"       align-items: center;
    }

    .comments {
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
    }

    .star {
        //padding-top: 5px;
        height: 40px;
        width: 40px;
    }


    .divimg {
        padding-top: 50px;
        padding-left: 50px;
    }

    .revtext {
        padding-top: 30px;
        padding-right: 50px;
    }

    .revdata {
        padding: 7px;
        margin-top: 20px;
        font-size: 22px;
        font-family: 'Times New Roman';
        background-color: #F0F8FF;
        box-shadow: 0 0 5px 5px rgba(221, 221, 221, 1);
    }

    .post {
        margin-bottom: 20px;
        border-top: solid 1px #708090;
        display: flex;
        flex-direction: column;
        justify-content: center;
        align-items: center;
    }

    .user {
        width: 1100px;
        box-shadow: 0 0 5px 5px rgba(221, 221, 221, 1);
        border-radius: 10px;
        ");
            WriteLiteral(@"text-align: left;
        padding: 10px;
        margin-top: 20px;
        display: inline;
        flex-direction: row;
        justify-content: center;
        align-items: center;
    }

    .com {
        margin-top: 40px;
        display: flex;
        flex-direction: column;
        //justify-content: center;
        align-items: center;
        box-shadow: 0 0 5px 5px rgba(221, 221, 221, 1);
        border-radius: 10px;
        width: 1100px;
    }

    .userblock {
        float: left; /*Задаем обтекание*/
        text-align: center;
    }

    .userblockcom {
        margin-left: 20px;
        float: left; /*Задаем обтекание*/
        text-align: center;
    }

    .userimg {
        height: 100px;
        width: 100px;
        border-radius: 100px;
        box-shadow: 0 0 0 3px #337AB7, 0 0 13px #333;
    }

    .user1 {
        width: 1100px;
        //box-shadow: 0 0 5px 5px rgba(221, 221, 221, 1);
        //border-radius: 10px;
        text-align: left;
");
            WriteLiteral(@"        padding: 10px;
        margin-top: 20px;
        display: inline;
        flex-direction: row;
        justify-content: center;
        align-items: center;
    }

    .comdata {
        margin-right: 60px;
    }

    .comtext {
        width: 500px;
        display: flex;
        flex-direction: row;
        justify-content: center;
        align-items: center;
        //padding-top: 10px;
        padding-right: 50px;
    }


    .userlogin {
        height: 60px;
        margin-left: 40px;
        display: inline-block;
        //background: #337AB7;
        //color: #fff;
        margin-bottom: 0;
        padding: .5rem 1rem .625rem 1rem;
        font-size: 1.5rem;
        text-transform: uppercase;
        border-radius: 30px;
        border-top: 2px solid #337AB7;
        border-left: 2px solid #337AB7;
    }

    .log {
        padding-top: 30px;
        width: 1000px;
        padding-left: 20px;
        display: flex;
        flex-direction: row;
    ");
            WriteLiteral(@"    justify-content: space-between;
        align-items: center;
    }

    .input {
        background-color: #fafafa;
        width: 500px;
        //resize: vertical;
        padding-top: 20px;
        border-radius: 15px;
        border: 0;
        box-shadow: 4px 4px 10px rgba(0,0,0,0.06);
        height: 70px;
    }

    .but {
        margin-left: 50px;
        width: 210px;
        background-color: #1161ee;
        color: white;
        border: none;
        padding: 15px 20px;
        border-radius: 25px;
    }

        .but:hover {
            background-color: #0b0e1e;
        }

    .postcom {
        margin-bottom: 20px;
        border-top: solid 1px #708090;
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        align-items: center;
    }
</style>


<section class=""post"">

    <section class=""user"">

        <div class=""userblock"">
            <img");
            BeginWriteAttribute("src", " src=\"", 5163, "\"", 5196, 1);
#nullable restore
#line 238 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
WriteAttributeValue("", 5169, ViewBag.Review.User.Avatar, 5169, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"userimg\" alt=\"avatar\" />\r\n        </div>\r\n\r\n        <div class=\"userblock\">\r\n            <h1 class=\"userlogin\">");
#nullable restore
#line 242 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                             Write(ViewBag.Review.User.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        </div>\r\n\r\n\r\n    </section>\r\n    <section class=\"revsec\">\r\n        <div class=\"revtext\">\r\n            <p class=\"date\">");
#nullable restore
#line 249 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                       Write(ViewBag.Review.Public_date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"titlerev\">\r\n                <div class=\"title\">\r\n                    <h1>");
#nullable restore
#line 252 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                   Write(ViewBag.Review.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                </div>\r\n                <div class=\"rate\">\r\n                    <h1>");
#nullable restore
#line 255 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                   Write(ViewBag.Review.RaitingBook);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n                    <img class=\"star\" src=\"https://avatars.mds.yandex.net/get-zen-logos/201842/pub_5d03cd8a2614780df6a1483a_5d03cf663ad2340d4ce51d70/xxh\">\r\n                </div>\r\n\r\n            </div>\r\n            <p class=\"revdata\">");
#nullable restore
#line 260 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                          Write(ViewBag.Review.Review_data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <div class=\"like\">\r\n                <div class=\"likes\">\r\n                    <img class=\"star\" src=\"https://st1.stranamam.ru/data/cache/2015may/19/20/16105431_63633-110x0.jpg\">\r\n                    <p>");
#nullable restore
#line 264 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                  Write(ViewBag.Review.NumLikes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"comments\">\r\n                    <p><a");
            BeginWriteAttribute("href", " href=\"", 6348, "\"", 6385, 2);
            WriteAttributeValue("", 6355, "/Post/", 6355, 6, true);
#nullable restore
#line 267 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
WriteAttributeValue("", 6361, ViewBag.Review.ReviewId, 6361, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"link\">Комментарии</a></p>\r\n                    <img class=\"star\" src=\" https://lite-gate.ru/img/masageicon-238540.png\">\r\n                </div>\r\n            </div>\r\n\r\n        </div>\r\n        <div class=\"divimg\">\r\n            <img class=\"revimg\"");
            BeginWriteAttribute("src", " src=\"", 6638, "\"", 6669, 1);
#nullable restore
#line 274 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
WriteAttributeValue("", 6644, ViewBag.Review.Book.Path, 6644, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Обложка книги\">\r\n        </div>\r\n\r\n\r\n    </section>\r\n\r\n</section>\r\n\r\n<h1 class=\"head\">Комментарии</h1>\r\n\r\n\r\n\r\n");
#nullable restore
#line 286 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
 if (User.Identity.IsAuthenticated)
{


#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b9577518a754240755b653dcef43aaba05c776715742", async() => {
                WriteLiteral("\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b9577518a754240755b653dcef43aaba05c776716009", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 290 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n        <fieldset class=\"log\" style=\"width: 100pt\" align=\"center\">\r\n            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b9577518a754240755b653dcef43aaba05c776717719", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
#nullable restore
#line 293 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Coment_data);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b9577518a754240755b653dcef43aaba05c776719524", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 294 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Coment_data);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div><br />\r\n            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b9577518a754240755b653dcef43aaba05c776721172", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 297 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                                              WriteLiteral(ViewBag.Review.ReviewId);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 297 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ReviewId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b9577518a754240755b653dcef43aaba05c776723672", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 298 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ReviewId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div><br />\r\n            <div class=\"form-group\">\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b9577518a754240755b653dcef43aaba05c776725317", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#nullable restore
#line 301 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("span", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3b9577518a754240755b653dcef43aaba05c776727325", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationMessageTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper);
#nullable restore
#line 302 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.UserId);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-for", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationMessageTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div><br />\r\n            <div>\r\n                <input type=\"submit\" value=\"Добавить комментарий\" class=\"but\" />\r\n            </div>\r\n        </fieldset>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 309 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 311 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
 foreach (Comment com in ViewBag.Review.Comments)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <section class=\"com\">\r\n        <section class=\"user1\">\r\n\r\n            <div class=\"userblockcom\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 8013, "\"", 8035, 1);
#nullable restore
#line 317 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
WriteAttributeValue("", 8019, com.User.Avatar, 8019, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"userimg\" alt=\"avatar\" />\r\n            </div>\r\n\r\n            <div class=\"userblockcom\">\r\n                <h1 class=\"userlogin\">");
#nullable restore
#line 321 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                                 Write(com.User.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n            </div>\r\n            <div class=\"userblockcom\">\r\n                <p class=\"date\">");
#nullable restore
#line 324 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                           Write(com.Public_date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\"\r\n\r\n\r\n        </section>\r\n        <section class=\"comtext\">\r\n\r\n            <div class=\"comdata\">\r\n                <p class=\"revdata\">");
#nullable restore
#line 332 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
                              Write(com.Comment_data);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n\r\n\r\n            <div class=\"like\">\r\n                <img class=\"star\" src=\"https://st1.stranamam.ru/data/cache/2015may/19/20/16105431_63633-110x0.jpg\">\r\n                <p>");
#nullable restore
#line 338 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"
              Write(com.NumLikes);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n\r\n        </section>\r\n    </section>\r\n");
#nullable restore
#line 343 "C:\Users\ASUS\Desktop\db_course\my\Course\Course\Views\Post\Comadd.cshtml"

}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Course.ViewModel.CommentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BulletinBoard.Helpers.TagHelpers
{
    [HtmlTargetElement("hidden-email, Attributes = ForAttributeName")]
    public class HiddenEmailTagHelper : TagHelper
    {
        private const string ForAttributeName = "asp-hidden-email";
        
        [HtmlAttributeName(ForAttributeName)]
        public ModelExpression For { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var text = For.ModelExplorer.GetSimpleDisplayText();
            var formatted = "...";

            if (text.Length > 6)
            {
                var beginning = text.Substring(0, 3);
                var ending = text.Substring(text.Length - 3, 3);
                formatted = beginning + "..." + ending;
            }

            output.Content.SetContent(formatted);
        }
    }
}
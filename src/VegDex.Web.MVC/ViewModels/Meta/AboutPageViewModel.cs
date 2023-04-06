using Markdig;

namespace VegDex.Web.MVC.ViewModels.Meta;

public class AboutPageViewModel
{
    private string _content;
    public string Content
    {
        get => Markdown.ToHtml(_content);
        set => _content = value;
    }
    public DateTime DateUpdated { get; set; }
}

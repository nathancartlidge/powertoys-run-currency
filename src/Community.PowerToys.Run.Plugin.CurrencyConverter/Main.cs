﻿using ManagedCommon;
using System.Text;
using Wox.Plugin;
using System.Text.RegularExpressions;
using Wox.Infrastructure;
using Wox.Plugin.Common;

namespace Community.PowerToys.Run.Plugin.CurrencyConverter;

public partial class Main : IPlugin, IContextMenu
{
    private string IconPath { get; set; }

    private readonly Api _api = new();
    private readonly Matcher _matcher = new();

    private PluginInitContext Context { get; set; }
    public string Name => "Currency Converter";

    public string Description => "Live Currency Conversions";

    // ReSharper disable once InconsistentNaming
    public static string PluginID => "5eb3a12f0bc94937a03b34b75d53fcb1";
    
    public List<ContextMenuResult> LoadContextMenus(Result selectedResult)
    {
        if (selectedResult?.ContextData is null) return [];

        return [];
    }

    public List<Result> Query(Query query)
    {
        // Clean up the raw query by discarding the keyword and trimming
        return Query(string.IsNullOrEmpty(query.ActionKeyword)
            ? query.RawQuery.Trim() // no keyword - just trim
            : query.RawQuery[query.ActionKeyword.Length..].Trim()); // keyword - remove it, then trim
    }
        
    private List<Result> Query(string query)
    {
        var value = 0.7F;
        
        var titleStringBuilder = new StringBuilder();
        titleStringBuilder.Append("Query: ");
        titleStringBuilder.Append(query);
        
        var subtitleStringBuilder = new StringBuilder();
        subtitleStringBuilder.Append(value.ToString("c2"));
        
        return [
            new Result
            {
                Title = titleStringBuilder.ToString(),
                SubTitle = subtitleStringBuilder.ToString(),
                IcoPath = IconPath,
                Score = 1,
                Action = _ =>
                {
                    Clipboard.SetText(value.ToString("c2"));
                    return true;
                },
                ContextData = value,
            }
        ];
    }

    public void Init(PluginInitContext context)
    {
        Context = context;
        Context.API.ThemeChanged += OnThemeChanged;
        UpdateIconPath(Context.API.GetCurrentTheme());
    }

    private void UpdateIconPath(Theme theme)
    {
        IconPath = theme is Theme.Light or Theme.HighContrastWhite ? "images/currency.light.png" : "images/currency.dark.png";
    }

    private void OnThemeChanged(Theme currentTheme, Theme newTheme)
    {
        UpdateIconPath(newTheme);
    }
}
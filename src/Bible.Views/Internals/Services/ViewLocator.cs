using System.Collections.Concurrent;
using System.Reflection;
using Avalonia.Controls.Templates;
using Avalonia.Controls;
using Bible.Abstractions.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.Views.Internals.Services;

/// <summary>
/// <see cref="IDataTemplate" /> 의 구현체이며 <c> View </c> 를 가져오는 Locator Class 입니다.
/// </summary>
/// <param name="provider"> <see cref="IServiceProvider" /> 의 구현체입니다. </param>
internal sealed class ViewLocator(IServiceProvider provider) : IDataTemplate
{
    private readonly Assembly _assembly = Assembly.GetExecutingAssembly();
    private readonly ConcurrentDictionary<Type, Control> _controls = new();

    /// <inheritdoc cref="IDataTemplate.Match(object?)" />
    public bool Match(object? data)
    {
        return data is IViewModel;
    }

    /// <summary>
    /// <see cref="Control" /> 객체를 생성하여 가져옵니다.
    /// </summary>
    /// <param name="param"> ViewModel 객체입니다. </param>
    /// <returns> <see cref="Control" /> 객체를 새로 생성하여 가져옵니다. </returns>
    /// <exception cref="ArgumentNullException"> <paramref name="param" /> 객체가 <see langword="null" /> 일 때 발생합니다. </exception>
    /// <exception cref="ArgumentException"> 잘못된 <paramref name="param" /> 객체로 인하여 <see cref="Control" /> 객체를 생성할 수 없을 때 발생합니다. </exception>
    public Control Build(object? param)
    {
        var viewModelType = param?.GetType() ?? throw new ArgumentNullException(nameof(param));
        if (_controls.TryGetValue(viewModelType, out var control))
        {
            return control;
        }
        else if (GetViewType(viewModelType) is Type viewType && ActivatorUtilities.CreateInstance(provider, viewType) is Control createdControl)
        {
            return _controls.GetOrAdd(viewModelType, createdControl);
        }

        throw new ArgumentException($"{param} is not a valid value to create a {nameof(Control)} object.", nameof(param));
    }

    private Type? GetViewType(Type viewModelType)
    {
        var viewName = viewModelType.Name.Replace("ViewModel", string.Empty, StringComparison.InvariantCulture);
        var viewTypes = _assembly.GetTypes().Where(type => type.IsClass && type.Name == viewName);

        return viewTypes.SingleOrDefault();
    }
}

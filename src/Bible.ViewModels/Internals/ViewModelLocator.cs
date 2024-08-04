using System.Reflection;
using Bible.Abstractions.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Bible.ViewModels.Internals;

/// <summary>
/// <see cref="IViewModelLocator" /> 의 구현체입니다.
/// </summary>
/// <remarks>
/// <see cref="ViewModelLocator" /> 를 초기화합니다.
/// </remarks>
/// <param name="provider"> <see cref="IServiceProvider" /> 의 구현체입니다. </param>
internal sealed class ViewModelLocator(IServiceProvider provider) : IViewModelLocator
{
    private const string SuffixWord = "ViewModel";
    private static readonly Assembly _assembly = Assembly.GetExecutingAssembly();
    private readonly Type[] _types = _assembly.GetTypes();

    /// <inheritdoc cref="IViewModelLocator.GetViewModel{TViewModel}(Type, object[])" />
    public TViewModel? GetViewModel<TViewModel>(Type viewType, params object[] parameters)
        where TViewModel : class, IViewModel
    {
        if (viewType.Assembly == _assembly)
        {
            throw new ArgumentException($"The value of {nameof(viewType)} must not be the same as the Assembly of {typeof(TViewModel)}.", nameof(viewType));
        }

        if (GetViewModelType(viewType) is Type viewModelType)
        {
            if (provider.GetService(viewModelType) is TViewModel viewModel)
            {
                return viewModel;
            }

            return ActivatorUtilities.CreateInstance(provider, viewModelType, parameters) as TViewModel;
        }

        return default;
    }

    /// <inheritdoc cref="IViewModelLocator.GetViewModel{TViewModel}(string, object[])" />
    public TViewModel? GetViewModel<TViewModel>(string viewModelName, params object[] parameters)
        where TViewModel : class, IViewModel
    {
        if (GetViewModelType(viewModelName) is Type viewModelType)
        {
            if (provider.GetService(viewModelType) is TViewModel viewModel)
            {
                return viewModel;
            }

            return ActivatorUtilities.CreateInstance(provider, viewModelType, parameters) as TViewModel;
        }

        return default;
    }

    private Type GetViewModelType(string viewModelName)
    {
        IEnumerable<Type> viewModelTypes = _types.Where(type => type.IsClass && type.Name == viewModelName);
        return viewModelTypes.Single();
    }

    private Type? GetViewModelType(Type viewType)
    {
        return GetViewModelType($"{viewType.Name}{SuffixWord}");
    }
}

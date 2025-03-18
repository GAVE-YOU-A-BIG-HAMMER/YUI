using MaterialDesignColors;
using MaterialDesignColors.ColorManipulation;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace YUI.ViewModels;

public class ColorToolModifyThemeEvent : PubSubEvent<bool> { }

public class ColorToolViewModel : BindableBase
{
	private bool _isDarkTheme;
	public bool IsDarkTheme
	{
		get => _isDarkTheme;
		set
		{
			if (SetProperty(ref _isDarkTheme, value))
			{
				ModifyTheme(theme => theme.SetBaseTheme(value ? BaseTheme.Dark : BaseTheme.Light));
                _eventAggregator.GetEvent<ColorToolModifyThemeEvent>().Publish(value);
            }
		}
	}

    private float _desiredContrastRatio = 4.5f;

    public float DesiredContrastRatio
    {
        get => _desiredContrastRatio;
        set
        {
            if (SetProperty(ref _desiredContrastRatio, value))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme && internalTheme.ColorAdjustment != null)
                        internalTheme.ColorAdjustment.DesiredContrastRatio = value;
                });
            }
        }
    }

    public IEnumerable<Contrast> ContrastValues => Enum.GetValues(typeof(Contrast)).Cast<Contrast>();

    private Contrast _contrastValue;
	public Contrast ContrastValue
    {
        get => _contrastValue;
        set
        {
            if (SetProperty(ref _contrastValue, value))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme && internalTheme.ColorAdjustment != null)
                        internalTheme.ColorAdjustment.Contrast = value;
                });
            }
        }
    }

    public IEnumerable<ColorSelection> ColorSelectionValues => Enum.GetValues(typeof(ColorSelection)).Cast<ColorSelection>();
    private ColorSelection _colorSelectionValue;
    public ColorSelection ColorSelectionValue
    {
        get => _colorSelectionValue;
        set
        {
            if (SetProperty(ref _colorSelectionValue, value))
            {
                ModifyTheme(theme =>
                {
                    if (theme is Theme internalTheme && internalTheme.ColorAdjustment != null)
                        internalTheme.ColorAdjustment.Colors = value;
                });
            }
        }
    }



    public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;

	public DelegateCommand<object> ChangeHueCommand { get; private set; }

	private readonly PaletteHelper paletteHelper = new PaletteHelper();
    private readonly IEventAggregator _eventAggregator;
    public ColorToolViewModel(IEventAggregator eventAggregator)
	{
        _eventAggregator = eventAggregator;
        ChangeHueCommand = new DelegateCommand<object>(ChangeHue);
	}

	private static void ModifyTheme(Action<Theme> modificationAction)
	{
		var paletteHelper = new PaletteHelper();
		Theme theme = paletteHelper.GetTheme();
		modificationAction?.Invoke(theme);
		paletteHelper.SetTheme(theme);
	}

	private void ChangeHue(object obj)
	{
		var hue = (Color)obj;
		Theme theme = paletteHelper.GetTheme();
		theme.PrimaryLight = new ColorPair(hue.Lighten());
		theme.PrimaryMid = new ColorPair(hue);
		theme.PrimaryDark = new ColorPair(hue.Darken());
		paletteHelper.SetTheme(theme);
	}
}

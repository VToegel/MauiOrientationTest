namespace MauiOrientationTest.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public MainViewModel()
    {
        StartOrientation();
    }

    private string orientationLabel = "not working";

    public string OrientationLabel
    {
        get { return orientationLabel; }
        set { orientationLabel = value;
            OnPropertyChanged(nameof(OrientationLabel));
        }
    }


    private void StartOrientation()
    {
        if (OrientationSensor.Default.IsSupported)
        {
            if (!OrientationSensor.Default.IsMonitoring)
            {
                // Turn on orientation
                OrientationSensor.Default.ReadingChanged += Orientation_ReadingChanged;
                OrientationSensor.Default.Start(SensorSpeed.UI);
            }
        }
    }

    private void Orientation_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
    {
        // Update UI Label with orientation state
        OrientationLabel = $"Orientation: {e.Reading}";
    }
}
